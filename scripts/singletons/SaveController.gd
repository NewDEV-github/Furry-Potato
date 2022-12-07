extends Node


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
signal game_state_saved
signal game_state_loaded
var save_file_base_path
var cs_saver = preload("res://scripts/scenes/game/other/Saver.cs").new()
func _save_game_state(data ,saveName:String):
	var orgSName = saveName
	saveName.replace(' ', '_')
	LoadingSavingDataIcon.show_icon()
	cs_saver.SaveGame(data, OS.get_user_data_dir() + "\\Saves\\"+ saveName + "\\", orgSName)
	LoadingSavingDataIcon.hide_icon()

func _preload_game_state(saveName:String) -> Dictionary:
	var loaded_data = {}
	var save_path_dir = save_file_base_path+saveName+"/"
	var save_file_name = save_path_dir + "save.cfg"
	var dir = Directory.new()
	var cfg = ConfigFile.new()
	if not dir.dir_exists(save_path_dir):
		OS.alert("Error while loading save :c")
		return {}
	else:
		cfg.load(save_file_name)
		for sec_keys in cfg.get_section_keys("save"): #Only used section
			loaded_data[sec_keys] = cfg.get_value("save", sec_keys)
		return loaded_data

func _ready():
	if Globals.mode_run_from_godot:
		save_file_base_path = "res://saves/"
	else:
		save_file_base_path = Globals.base_install_path + "saves/"

func save_game(save_name:String):
	var data = {
		"string_PartyControllerPartyData": PartyController.party_data,
		"string_PartyRatings": PartyController.get_party_ratings(),
		"string_ShopItemController": ShopItemController.data,
		"string_OptionController": OptionController.option_data,
		"string_GameController": GameController.GetStrings(),
		"int_GameController": GameController.GetInts(),
		"float_GameController": GameController.GetFloats(),
	}
	_save_game_state(data, save_name)

func load_game(save_name:String):
	pass
