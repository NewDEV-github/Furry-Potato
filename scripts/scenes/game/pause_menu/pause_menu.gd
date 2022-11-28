extends WindowDialog


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var visible_connect
var current_submenu_page
func show_submenu_page(page):
	if current_submenu_page != null:
		page.show()
		if not current_submenu_page == page:
			current_submenu_page.hide()
	else:
		page.show()
		current_submenu_page = page

func _process(_delta):
	if Input.is_action_just_pressed("ui_cancel"):
		visible = !visible
		get_tree().paused = visible
		if visible:
			MjPlayer.fade_in()
		else:
			MjPlayer.fade_out()
func _on_Resume_pressed():
	MjPlayer.fade_out()
	hide()
	if not current_submenu_page == null:
		current_submenu_page.hide()
	get_tree().paused = false
func restart():
	MjPlayer.fade_out()
	get_tree().paused = false
	if get_tree().reload_current_scene():
		pass
	else:
		print("error while reloading game scene")

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func _on_Options_pressed():
	show_submenu_page($Options)


func _on_GoToMainMenu_pressed():
	get_tree().paused = false
	go_to_main_menu()


func _on_Quit_pressed():
	get_tree().paused = false
	quit_game()

func _on_PauseMenu_popup_hide():
	MjPlayer.fade_out()
	hide()
	if not current_submenu_page == null:
		current_submenu_page.hide()
	get_tree().paused = false


func quit_game():
	get_tree().paused = false
	get_tree().quit()

func go_to_main_menu():
	get_tree().paused = false
	if get_tree().change_scene("res://scenes/main/menu.tscn"):
		pass
	else:
		print("Error while going to menu")


func _on_PauseMenu_visibility_changed():
	if visible == false:
		_on_PauseMenu_popup_hide()
