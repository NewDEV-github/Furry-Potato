extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	load_game()


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
func load_game():
	if Globals.enable_protogen_technology_bool:
		if str(ProtogenTechnologyCore.new().init_sdk(1)) == "init_d":
			Globals.proto_tech_initialized = true
	if Globals.mode_run_from_godot:
		get_tree().change_scene("res://scenes/main/menu.tscn")
	else:
		ProjectSettings.load_resource_pack(Globals.pck_data_path)
		ProjectSettings.load_resource_pack(Globals.import_data_path)
		get_tree().change_scene("res://scenes/main/menu.tscn")
