extends Node
var scripts_data_path = OS.get_executable_path().get_base_dir() + "/data/script_data.pck"
var scenes_data_path = OS.get_executable_path().get_base_dir() + "/data/scenes_data.pck"
var graphics_data_path = OS.get_executable_path().get_base_dir() + "/data/graphics_data.pck"
var audio_data_path = OS.get_executable_path().get_base_dir() + "/data/audio_data.pck"
var theme_data_path = OS.get_executable_path().get_base_dir() + "/data/theme_data.pck"
var font_data_path = OS.get_executable_path().get_base_dir() + "/data/font_data.pck"
var import_data_path = OS.get_executable_path().get_base_dir() + "/data/import_data.pck"
var base_install_path = OS.get_executable_path().get_base_dir() + '/'
var mode_run_from_godot = true
var proto_tech_initialized = false
var gdsdk_enabled = true
var enable_protogen_technology_bool = false
var use_furry_characters_bool = false
# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	if File.new().file_exists(scripts_data_path):
		mode_run_from_godot = false
		print("Running exported game")
	else:
		mode_run_from_godot = true
		print("Runnig from godot editor")

func enable_protogen_technology(enabled:bool):
	enable_protogen_technology_bool = enabled

func set_use_furry_characters(enabled:bool):
	use_furry_characters_bool = enabled
