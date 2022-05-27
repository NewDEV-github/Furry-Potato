extends WindowDialog


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_Button_pressed():
	$VBoxContainer/ErrorLabel.text = ""
	if save_name_check($VBoxContainer/LineEdit.text) == true:
		GameController.current_save_name = $VBoxContainer/LineEdit.text
		SaveController.save_game(GameController.current_save_name)
		get_tree().change_scene("res://scenes/game/game.tscn")
	else:
		$VBoxContainer/ErrorLabel.text = "\nError: Save name must only contain letters and numbers"

func save_name_check(save_name:String) -> bool:
	var status = true
	var test_string = save_name.insert(0,"a") 
	if test_string.is_valid_identifier() and test_string.find("_") == -1:
		print(save_name," contains only letters and numbers")
		status = true
	else:
		print(save_name," contains something other than letters and numbers")
		status = false
	return status
