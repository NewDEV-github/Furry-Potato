extends Control

signal party_ended(id, money, experience)
var party_ids = [
	'0',
	'1',
	'2',
	'3',
	'4'
]

var done_partys = []

var party_data = {
	"0_party_name": "",
	"0_club_id": 0,
	"0_base_price": 1000,
	"0_base_experience": 100,
	"0_req_experience": 0,
	
	"1_party_name": "",
	"1_club_id": 1,
	"1_base_price": 1000,
	"1_base_experience": 150,
	"1_req_experience": 10,
	
	"2_party_name": "",
	"2_club_id": 2,
	"2_base_price": 1000,
	"2_base_experience": 170,
	"2_req_experience": 200,
	
	"3_party_name": "",
	"3_club_id": 3,
	"3_base_price": 1000,
	"3_base_experience": 120,
	"3_req_experience": 300,
	
	"4_party_name": "",
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
	$CanvasLayer/Label.show()
	$CanvasLayer/ColorRect.show()
	$CanvasLayer/AnimationPlayer.play("party")

func compute_party_rewards(id:String):
	var default_money = party_data[id+"_base_price"]
	var default_exp = party_data[id+"_base_experience"]
	var money_multi = GameController.data["party_money_earnings_multiplier"]
	var exp_multi = GameController.data["party_experience_earnings_multiplier"]
	var computed_money = default_money
	var computed_exp = default_exp
	if money_multi > 0:
		computed_money += default_money*money_multi
	if exp_multi > 0:
		computed_exp += default_exp*exp_multi
	return {"money": computed_money, "exp": computed_exp}


func _on_AnimationPlayer_animation_finished(anim_name):
	$CanvasLayer/ColorRect.hide()
	$CanvasLayer/Label.hide()
	if anim_name == 'party':
		end_party()

func end_party():
	var party_rewards = compute_party_rewards(current_party_id)
	emit_signal("party_ended", current_party_id, party_rewards["money"], party_rewards["exp"])
	done_partys.append(str(current_party_id))
	party_ids.remove(party_ids.find(str(current_party_id)))

func check_if_party_was_done(id:String):
	return done_partys.has(id)

