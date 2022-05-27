extends WindowDialog

var option_file_path = OptionController.option_file_path
var setting_properties = {
	"use_discord_avatar_node": "splitter/left/discord_avatar",
	"use_discord_avatar_value": "True",
	"use_discord_avatar_node_value": "pressed",
	"vsync_node": "splitter/left/vsync",
	"vsync_value": true,
	"vsync_node_value": "pressed",
	"comp_vsync_via_compositor_node": "splitter/left/vsync_compositor",
	"comp_vsync_via_compositor_value": true,
	"comp_vsync_via_compositor_node_value": "pressed",
	"use_furry_characters_node": "splitter/left/UseDifferentCharacterSet",
	"use_furry_characters_value": "False",
	"use_furry_characters_node_value": "pressed",
	"enable_ProtogenTechnology_node": "splitter/left/enableProtogenTechnology",
	"enable_ProtogenTechnology_value": "False",
	"enable_ProtogenTechnology_node_value": "pressed",
}
var setting_names = [
	"use_discord_avatar",
	"vsync",
	"comp_vsync_via_compositor",
	"enable_ProtogenTechnology",
	"use_furry_characters"
]
# Called when the node enters the scene tree for the first time.
func _ready():
	_load_options_visually()


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func _load_options_visually():
	var cfg = ConfigFile.new()
	cfg.load(option_file_path)
	for i in cfg.get_sections():
		var _tmp_value
		var _tmp_node_value
		var _tmp_node
		for sec_key in cfg.get_section_keys(i):
			if str(sec_key).ends_with("_value") and not str(sec_key).ends_with("_node_value"):
				_tmp_value = cfg.get_value(i, sec_key)
			elif str(sec_key).ends_with("_node"):
				_tmp_node = cfg.get_value(i, sec_key)
			elif str(sec_key).ends_with("_node_value"):
				_tmp_node_value = cfg.get_value(i, sec_key)
		print("[OptionMenu] => Setting %s - %s to %s" % [_tmp_node, _tmp_node_value, _tmp_value])
		var _tmp_value_bool
		if _tmp_value == "True":
			_tmp_value_bool = true
		elif _tmp_value == "False":
			_tmp_value_bool = false
		get_node(NodePath(_tmp_node)).set(_tmp_node_value, _tmp_value_bool)
	
	
	### fix vsync via compositor
	$splitter/left/vsync_compositor.disabled = !cfg.get_value("vsync", "vsync_value")
	
	##fix use different character set
	if cfg.get_value("enable_ProtogenTechnology", "enable_ProtogenTechnology_value") == "True":
		$splitter/left/UseDifferentCharacterSet.disabled = false
	elif cfg.get_value("enable_ProtogenTechnology", "enable_ProtogenTechnology_value") == "False":
		$splitter/left/UseDifferentCharacterSet.disabled = true

func _save_options():
	var cfg = ConfigFile.new()
	cfg.load(option_file_path)
	for i in setting_names:
		for setting in setting_properties:
			if str(setting).begins_with(i):
				cfg.set_value(i, setting, setting_properties[setting]) #convert dict to string
	cfg.save(option_file_path)


func _on_Button_pressed():
	_save_options()
	_print_temp_settings()


func _on_discord_avatar_toggled(button_pressed):
	setting_properties["use_discord_avatar_value"] = str(button_pressed)
	OptionController.set_game_option("use_discord_avatar", str(button_pressed))


func _on_vsync_toggled(button_pressed):
	setting_properties["vsync_value"] = str(button_pressed)
	OptionController.set_game_option("vsync", str(button_pressed))
	$splitter/left/vsync_compositor.disabled = !button_pressed


func _print_temp_settings():
	print(setting_properties)


func _on_vsync_compositor_toggled(button_pressed):
	setting_properties["comp_vsync_via_compositor_value"] = str(button_pressed)
	OptionController.set_game_option("comp_vsync_via_compositor", str(button_pressed))


func _on_enableProtogenTechnology_toggled(button_pressed):
	setting_properties["enable_ProtogenTechnology_value"] = str(button_pressed)
	OptionController.set_game_option("enable_ProtogenTechnology", str(button_pressed))
	$splitter/left/UseDifferentCharacterSet.disabled = !button_pressed


func _on_UseDifferentCharacterSet_toggled(button_pressed):
	setting_properties["use_furry_characters_value"] = str(button_pressed)
	OptionController.set_game_option("use_furry_characters", str(button_pressed))
