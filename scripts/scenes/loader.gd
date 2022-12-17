extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	load_game()



func load_game():
	var dir = Directory.new()
	if not dir.dir_exists("user://cache"):
		dir.make_dir_recursive("user://cache")
	if Globals.enable_protogen_technology_bool:
		if str(ProtogenTechnologyCore.new().init_sdk(1)) == "init_d":
			Globals.proto_tech_initialized = true
	get_tree().change_scene("res://scenes/main/menu.tscn")
