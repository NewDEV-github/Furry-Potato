extends WindowDialog


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
signal new_name_ready

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_Button_pressed():
	GameController.set_name($VBoxContainer/LineEdit.text)
	hide()
	Dialogic.set_variable('PlayerName', $VBoxContainer/LineEdit.text)
	emit_signal("new_name_ready")
