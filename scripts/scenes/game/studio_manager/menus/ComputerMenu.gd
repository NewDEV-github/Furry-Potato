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


func _on_EmailDomainEdit_text_changed(new_text):
	var has_at = false
	var have_spaces = false
	var err_spaces = "Email domain can not contain spaces"
	var err_at = "Email domain can not contain '@'"
	var err_spaces_at = "Email domain can not contain '@' and spaces"
	var err = "none"
	if "@" in new_text:
		has_at = true
	else:
		has_at = false
	
	if " " in new_text:
		have_spaces = true
	else:
		have_spaces = false
	
	if has_at == true && have_spaces == true:
		err = err_spaces_at
	
	elif has_at == true || have_spaces == true:
		if has_at == true:
			err = err_at
		elif have_spaces == true:
			err = err_spaces
	else:
		err = "Email domain is okay"
		GameController.SetNewEmailDomain(new_text)
