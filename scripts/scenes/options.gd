extends WindowDialog




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
