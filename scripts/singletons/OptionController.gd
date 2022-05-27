extends Node


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var option_file_path = ""

# Called when the node enters the scene tree for the first time.
func _ready():
	if Globals.mode_run_from_godot:
		option_file_path = "res://misc/options.cfg"
	else:
		option_file_path = Globals.base_install_path + "misc/options.cfg"
	_load_game_options()

func _load_game_options():
	var cfg = ConfigFile.new()
	cfg.load(option_file_path)
	for i in cfg.get_sections():
		var _tmp_value
		var _tmp_setting_name
		for sec_key in cfg.get_section_keys(i): #sec_key is equal to setting name
			_tmp_setting_name = sec_key
			if str(sec_key).ends_with("_value") and not str(sec_key).ends_with("_node_value"):
				_tmp_value = str(cfg.get_value(i, sec_key))
				print("[OptionController] => Setting %s to %s" % [_tmp_setting_name, _tmp_value])
				set_game_option(_compute_option_name(sec_key), _tmp_value)

func _compute_option_name(input:String):
	var split = input.split('_')
	split.remove(split.size() -1)
	return split.join('_')

func set_game_option(option_name:String, value):
	match option_name:
		"use_discord_avatar":
			_set_use_dsc_av(value)
		"vsync":
			_set_vsync(value)
		"comp_vsync_via_compositor":
			_set_vsync_via_compositor(value)
		"enable_ProtogenTechnology":
			_enable_prototech(value)
		"use_furry_characters":
			_set_furry_characters(value)


func _set_use_dsc_av(val):
	DiscordSDK.av_en = val

func _enable_prototech(val):
	if val == "True":
		Globals.enable_protogen_technology(true)
	elif val == "False":
		Globals.enable_protogen_technology(false)

func _set_furry_characters(val):
	if val == "True":
		Globals.set_use_furry_characters(true)
	elif val == "False":
		Globals.set_use_furry_characters(false)

func _set_vsync(val):
	if val == "True":
		ProjectSettings.set("display/window/vsync/use_vsync", true)
	elif val == "False":
		ProjectSettings.set("display/window/vsync/use_vsync", false)

func _set_vsync_via_compositor(val):
	if val == "True":
		ProjectSettings.set("display/window/vsync/vsync_via_compositor", true)
	elif val == "False":
		ProjectSettings.set("display/window/vsync/vsync_via_compositor", false)
