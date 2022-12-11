extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var dft_file = File.new()

# Called when the node enters the scene tree for the first time.
func _ready():
	print(SaveManager.GetSaveNamesArray())
	if SaveManager.SaveCount >= 1:
		$MenuButtons/LoadGame.disabled = false
	else:
		$MenuButtons/LoadGame.disabled = true
	var stream = VideoStreamGDNative.new()
	var file = "res://assets/Graphics/ProtogenThings/I GOT YOU.webm"
	stream.set_file(file)
	var vp = $VideoPlayer
	vp.stream = stream
	vp.play()
	Globals.connect("furry", self, "on_warning")
	MjPlayer.volume_db = -80
	$VideoPlayer.volume_db = -80
	if not MjPlayer.is_playing:
		MjPlayer.stream = load("res://assets/audio/bg/mj.ogg")
		MjPlayer.start()
	if Directory.new().file_exists("user://dft_setting"):
		dft_file.open("user://dft_setting", File.READ)
		if str(dft_file.get_line()) == "True":
			$CheckButton.pressed = true
			Globals.set_use_furry_characters(true)
	#		on_warning(true)
		else:
			$CheckButton.pressed = false
			Globals.set_use_furry_characters(false)
	#		on_warning(false)
		dft_file.close()
	else:
		$CheckButton.pressed = false
		Globals.set_use_furry_characters(false)
	


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_Options_pressed():
	$Control.popup_centered()


func _on_NewGame_pressed():
#	get_tree().change_scene("res://scenes/game/game.tscn")
#	MjPlayer.fade_out()
#	$VideoPlayer.fade_out()
	$NewGameDialog.popup_centered()

func _on_CheckButton_pressed():
	Globals.set_use_furry_characters($CheckButton.pressed)

func on_warning(enabled):
	print(enabled)
	dft_file.open("user://dft_setting", File.WRITE)
	if enabled:
		$VideoPlayer.show()
		MjPlayer.fade_out()
		Player.set_title("I Got You", "Jason Chen")
		$VideoPlayer.fade_in()
		$TextureRect.hide()
		$AnimatedIcon.show()
	elif enabled == false:
		$VideoPlayer.hide()
		if not MjPlayer.is_playing:
			MjPlayer.stream = load("res://assets/audio/bg/mj.ogg")
			MjPlayer.start()
		MjPlayer.fade_in()
		Player.set_title("We Are The World", "U.S.A For Africa")
		$VideoPlayer.fade_out()
		$TextureRect.show()
		$AnimatedIcon.hide()
	dft_file.store_line(str(enabled))
	dft_file.close()


func _on_VideoPlayer_finished() -> void:
	$VideoPlayer.play()


func _on_LoadGame_pressed():
	$SaveSelectMenuPopup.popup_centered()


func _on_SaveSelectMenuPopup_SaveDataPreloaded():
	
	var new_float_data = {}
	var new_int_data = {}
	
	print($SaveSelectMenuPopup.PreloadedSaveData)
	GameController.SetNewSaveName($SaveSelectMenuPopup.PreloadedSaveData["saveName"]["saveName"])
	GameController.SetNewStringsDataFields($SaveSelectMenuPopup.PreloadedSaveData["string_GameController"])
	
	for i in $SaveSelectMenuPopup.PreloadedSaveData["int_GameController"]:
		new_int_data[i] = int($SaveSelectMenuPopup.PreloadedSaveData["int_GameController"][i])
	GameController.SetNewIntsDataFields(new_int_data)
	
	for i in $SaveSelectMenuPopup.PreloadedSaveData["float_GameController"]:
		new_float_data[i] = float($SaveSelectMenuPopup.PreloadedSaveData["float_GameController"][i])
	GameController.SetNewMultiplierData(new_float_data)
	
	get_tree().change_scene("res://scenes/game/game.tscn")
	MjPlayer.fade_out()
	$"VideoPlayer".fade_out()
