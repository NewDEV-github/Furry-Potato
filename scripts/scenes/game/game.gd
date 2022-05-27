extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var start_dialog = Dialogic.start('tutorial1')

# Called when the node enters the scene tree for the first time.
func _ready():
	start_dialog.connect("dialogic_signal", self, "dialog_listener")
	$Manager/menus/NewNameMenu.connect("new_name_ready", self, "_start_2nd_dialog")
	add_child(start_dialog)

func dialog_listener(string:String):
	match string:
		"run_tutorial":
			$Tutorial.run_tutorial()
		"go_to_game":
			$Tutorial.hide()
		"dialog1_closed":
			$Manager/menus/NewNameMenu.popup_centered()

func _start_2nd_dialog():
	var new_dialog = Dialogic.start('tutorial2')
	new_dialog.connect("dialogic_signal", self, "dialog_listener")
	add_child(new_dialog)
