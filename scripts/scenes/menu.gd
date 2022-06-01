extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var dft_file = File.new()

# Called when the node enters the scene tree for the first time.
func _ready():
	Globals.connect("furry",self,  "on_warning")
	MjPlayer.stream = load("res://assets/audio/bg/mj.ogg")
	MjPlayer.start()
	dft_file.open("user://dft_setting", File.READ)
	if str(dft_file.get_line()) == "True":
		$CheckButton.pressed = true
		Globals.set_use_furry_characters(true)
	elif str(dft_file.get_line()) == "False":
		$CheckButton.pressed = false
		Globals.set_use_furry_characters(false)
	dft_file.close()


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_Options_pressed():
	$Control.popup_centered()


func _on_NewGame_pressed():
	get_tree().change_scene("res://scenes/game/game.tscn")
	MjPlayer.fade_out()


func _on_CheckButton_pressed():
	Globals.set_use_furry_characters($CheckButton.pressed)

func on_warning(enabled):
	dft_file.open("user://dft_setting", File.WRITE)
	if enabled:
		$TextureRect.texture = preload("res://assets/Graphics/ProtogenThings/wallpaperflare.com_wallpaper.jpg")
	else:
		$TextureRect.texture = preload("res://assets/Graphics/bg.png")
	dft_file.store_line(str(enabled))
	dft_file.close()
