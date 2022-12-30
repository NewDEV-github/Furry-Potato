extends WindowDialog

func string_to_bool(string):
	if string == "True":
		return true
	elif string == "False":
		return false

func _ready():
	OptionController.connect("option_save_loaded", self, "load_data")
	load_data()

func load_data():
	$splitter/left/discord_avatar.pressed = string_to_bool(OptionController.get_option_data("use_discord_avatar"))
	$splitter/left/vsync.pressed = string_to_bool(OptionController.get_option_data("vsync"))
	$splitter/left/vsync_compositor.pressed = string_to_bool(OptionController.get_option_data("comp_vsync_via_compositor"))
	$splitter/left/enableProtogenTechnology.pressed = string_to_bool(OptionController.get_option_data("enable_ProtogenTechnology"))
	$splitter/left/UseDifferentCharacterSet.pressed = string_to_bool(OptionController.get_option_data("use_furry_characters"))
	$splitter/right/EnableCustomMusicLibrary.pressed = string_to_bool(OptionController.get_option_data("custom_audio_library_enable"))
	$splitter/right/MixWithBuiltinSongs.pressed = string_to_bool(OptionController.get_option_data("custom_audio_library_play_alongside"))
	var value = float(OptionController.get_option_data("MasterVolume_value"))
	print("Master volume is:" + str(value) + "\nAnd will be:" + str(value-4.6))
	$splitter/right/MasterVolume.value = value
	AudioServer.set_bus_volume_db(0, value-4.6)
	AudioServer.set_bus_volume_db(1, value)


func _on_discord_avatar_toggled(button_pressed):
	OptionController.set_option_data("use_discord_avatar", str(button_pressed))


func _on_vsync_toggled(button_pressed):
	OptionController.set_option_data("vsync", str(button_pressed))
	$splitter/left/vsync_compositor.disabled = !button_pressed


func _on_vsync_compositor_toggled(button_pressed):
	OptionController.set_option_data("comp_vsync_via_compositor", str(button_pressed))


func _on_enableProtogenTechnology_toggled(button_pressed):
	OptionController.set_option_data("enable_ProtogenTechnology", str(button_pressed))
	$splitter/left/UseDifferentCharacterSet.disabled = !button_pressed


func _on_UseDifferentCharacterSet_toggled(button_pressed):
	OptionController.set_option_data("use_furry_characters", str(button_pressed))


func _on_EnableCustomMusicLibrary_toggled(button_pressed):
	OptionController.set_option_data("custom_audio_library_enable", str(button_pressed))


func _on_MixWithBuiltinSongs_toggled(button_pressed):
	OptionController.set_option_data("custom_audio_library_play_alongside", str(button_pressed))


func _on_MasterVolume_value_changed(value):
	OptionController.set_option_data("MasterVolume_value", str(value))
	AudioServer.set_bus_volume_db(0, value-4.6)
	AudioServer.set_bus_volume_db(1, value)

func _on_CacheClear_pressed():
	delete_dir("user://cache/")


func delete_dir(path):
	var dir = Directory.new()
	dir.open(path)
	var file = dir.get_next()
	while file != "":
		if dir.current_is_dir():
			delete_dir(file)
		else:
			dir.remove(file)
		file = dir.get_next()


func _on_SaveButton_pressed():
	OptionController.save_options()


func _on_Control_popup_hide():
	OptionController.save_options()
