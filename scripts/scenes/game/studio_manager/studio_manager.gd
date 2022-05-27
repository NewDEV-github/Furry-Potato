extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
func show_manager():
	show()

func _on_SettingMenu_pressed():
	$menus/SettingsMenu.popup_centered()


func _on_PartyRatingsMenu_pressed():
	$menus/PartyRatingsMenu.popup_centered()


func _on_ShopMenu_pressed():
	$menus/ShopMenu.popup_centered()


func _on_ComputerMenu_pressed():
	$menus/ComputerMenu.popup_centered()


func _on_EmailMenu_pressed():
	$menus/EmailMenu.popup_centered()


func _on_LookUpForWorkersMenu_pressed():
	$menus/LookUpForWorkersMenu.popup_centered()


func _on_DataMenu_pressed():
	$menus/DataMenu.popup_centered()


func _on_SaveButton_pressed():
	SaveController.save_game(GameController.current_save_name)
