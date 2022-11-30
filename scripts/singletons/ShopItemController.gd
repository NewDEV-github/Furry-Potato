extends Node

var data = {}

func set_new_data_fields(new_data):
	data = new_data
	print("New data set successfully")

func get_data_field(name) -> String:
	return data[name]

func set_data_field(key, value):
	data[key] = value

func start_new_game():
	data = {}

func _ready():
	var manager = preload("res://scripts/scenes/game/shop/ShopItemManager.cs").new()
	var arr = manager.GetItemList()
	for i in arr:
		data[i+"_bought"] = "False" #false is default
