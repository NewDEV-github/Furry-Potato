extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var item_data = {}
signal item_bought(item_name)
# Called when the node enters the scene tree for the first time.
func set_item_data(data:Dictionary):
	item_data = data
	$Panel/VBoxContainer/Title.text = data["item_name"]
	$Panel/VBoxContainer/Description.text = data["item_description"]
	$Panel/VBoxContainer/Price.text = str(data["item_price"])
	$Panel/VBoxContainer/TextureRect.texture = load(data["item_icon"])


func _on_Button_pressed():
	emit_signal("item_bought", item_data["item_name"])
