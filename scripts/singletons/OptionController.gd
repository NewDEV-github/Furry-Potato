extends Node


var option_data = {
	"use_discord_avatar": "False",
	"vsync": "False",
	"comp_vsync_via_compositor": "False",
	"enable_ProtogenTechnology": "False",
	"use_furry_characters": "False",
	"custom_audio_library_enable": "True",
	"custom_audio_library_play_alongside": "True"
	}

func set_option_data(key, value):
	option_data[key] = value

func get_option_data(key):
	pass
