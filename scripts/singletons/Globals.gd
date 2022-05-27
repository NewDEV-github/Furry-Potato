extends Node
var pck_data_path = OS.get_executable_path().get_base_dir() + "/data/data.pck"
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
	if File.new().file_exists(pck_data_path):
		mode_run_from_godot = false
		print("Running exported game")
	else:
		mode_run_from_godot = true
		print("Runnig from godot editor")

func enable_protogen_technology(enabled:bool):
	enable_protogen_technology_bool = enabled

func set_use_furry_characters(enabled:bool):
	use_furry_characters_bool = enabled
