extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


func set_data(data):
	$HBoxContainer/SaveName.text = data["save_name"]
	$HBoxContainer/SaveLastModification.text = data["save_modification_date"]
