extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var item_data = {}
signal item_bought(item_name)
# Called when the node enters the scene tree for the first time.
func set_item_data(data:Dictionary):
	var item_modifier_text = "Experience boost: %s\nMusic quality boost: %s\nParty satisfaciton boost: %s" % [data["item_experience_multiplier"], data["item_music_quality_multiplier"], data["item_party_quality_multiplier"]]
	item_data = data
	var tex
	var image = Image.new()
	var err = image.load(data["item_icon"])
	if err != OK:
		print("Can not render item image")
	tex= ImageTexture.new()
	tex.create_from_image(image, 0)
	$Panel/VBoxContainer/Title.text = data["item_name"]
	$Panel/VBoxContainer/Description.text = data["item_description"]
	$Panel/VBoxContainer/Price.text = "Price: " + str(data["item_price"])
	$Panel/VBoxContainer/TextureRect.texture = tex
	$Panel/VBoxContainer/ItemModifiers.text = item_modifier_text


func _on_Button_pressed():
	emit_signal("item_bought", item_data["item_name"])
