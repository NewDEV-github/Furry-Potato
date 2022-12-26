extends Node

onready var OptionSaver = preload("res://scripts/scenes/game/other/OptionSaver.cs").new()
signal option_save_loaded
var option_data = {
	"use_discord_avatar": "False",
	"vsync": "False",
	"comp_vsync_via_compositor": "False",
	"enable_ProtogenTechnology": "False",
	"use_furry_characters": "False",
	"custom_audio_library_enable": "False",
	"custom_audio_library_play_alongside": "False",
	"msec_loading_delay": "0",
	"MasterVolume_value": "0"
}
func _ready():
	if Directory.new().dir_exists("user://OptionSave/"):
		load_options()

func load_options():
	OptionSaver.PreloadOptions()
	yield(OptionSaver, "OptionSaveDataPreloaded")
	set_new_data_fields(OptionSaver.PreloadedOptionSaveData["string_OptionController"])
	emit_signal("option_save_loaded")

func set_option_data(key, value):
	option_data[key] = value

func get_option_data(key):
	return option_data[key]

func set_new_data_fields(new_data):
	option_data = new_data
	print("New data set successfully")

func save_options():
	OptionSaver.SaveOptions({"string_OptionController": option_data})
