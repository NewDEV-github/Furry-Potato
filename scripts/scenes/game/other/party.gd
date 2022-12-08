extends Control

signal party_ended(id, money, experience, music_quality)
var party_ids = [
	'0',
	'1',
	'2',
	'3',
	'4'
]

var done_partys = []

var party_data = {
	"0_club_id": 0,
	"0_base_price": 1000,
	"0_base_experience": 100,
	"0_req_experience": 0,
	
	"1_club_id": 1,
	"1_base_price": 1000,
	"1_base_experience": 150,
	"1_req_experience": 10,
	
	"2_club_id": 2,
	"2_base_price": 1000,
	"2_base_experience": 170,
	"2_req_experience": 200,
	
	"3_club_id": 3,
	"3_base_price": 1000,
	"3_base_experience": 120,
	"3_req_experience": 300,
	
	"4_club_id": 4,
	"4_base_price": 1000,
	"4_base_experience": 400,
	"4_req_experience": 450,
}
# Called when the node enters the scene tree for the first time.
func _ready():
	$CanvasLayer/ColorRect.hide()
	$CanvasLayer/Label.hide()
var current_party_id = ''

# Called every frame. 'delta' is the elapsed time since the previous frame.
func start_party(id:String):
	current_party_id = id
	PartyCS.CurrentPartyId = id
	$CanvasLayer/Label.show()
	$CanvasLayer/ColorRect.show()
	$CanvasLayer/AnimationPlayer.play("party")

func compute_party_rewards(id:String):
	var default_money = party_data[id+"_base_price"]
	var default_exp = party_data[id+"_base_experience"]
	var money_multi = GameController.GetFloats()["party_money_earnings_multiplier"]
	var exp_multi = GameController.GetFloats()["party_experience_earnings_multiplier"]
	var music_quality = GameController.GetFloats()["party_music_quality_multiplier"]
	var computed_money = default_money
	var computed_exp = default_exp
	if money_multi > 0:
		computed_money += default_money*money_multi
	if exp_multi > 0:
		computed_exp += default_exp*exp_multi
	return {"money": computed_money, "exp": computed_exp, "music_quality": music_quality}


func _on_AnimationPlayer_animation_finished(anim_name):
	$CanvasLayer/ColorRect.hide()
	$CanvasLayer/Label.hide()
	if anim_name == 'party':
		PartyCS.EndParty()

func end_party():
	var party_rewards = compute_party_rewards(current_party_id)
	emit_signal("party_ended", current_party_id, party_rewards["money"], party_rewards["exp"], party_rewards["music_quality"])
	add_party_rating(current_party_id, party_rewards["exp"], party_rewards["money"], party_rewards["music_quality"], GameController.GetFloats()["party_experience_earnings_multiplier"], GameController.GetFloats()["party_money_earnings_multiplier"], GameController.GetFloats()["party_music_quality_multiplier"])
	done_partys.append(str(current_party_id))
	party_ids.remove(party_ids.find(str(current_party_id)))

func check_if_party_was_done(id:String):
	return done_partys.has(id)

var party_ratings = {
	
}

func add_party_rating(id, experience, money, m_quality, experience_boost, money_boost, m_quality_boost):
	party_ratings[id] = m_quality
	party_ratings[id + "_exp"] = experience
	party_ratings[id + "_money"] = money
	party_ratings[id+ "_m_quality"] = m_quality
	party_ratings[id + "_exp_boost"] = experience_boost
	party_ratings[id + "_money_boost"] = money_boost
	party_ratings[id+ "_m_quality_boost"] = m_quality_boost

func get_party_ratings():
	return party_ratings
