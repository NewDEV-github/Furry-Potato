extends Node


var option_data = {
	"use_discord_avatar": "False",
	"vsync": "False",
	"comp_vsync_via_compositor": "False",
	"enable_ProtogenTechnology": "False",
	"use_furry_characters": "False",
	"custom_audio_library_enable": "True",
	"custom_audio_library_play_alongside": "False",
	"msec_loading_delay": "0"
}

func set_option_data(key, value):
	option_data[key] = value

func get_option_data(key):
	return option_data[key]

func set_new_data_fields(new_data):
	option_data = new_data
	print("New data set successfully")
