tool
extends EditorPlugin


func _enter_tree():
	add_export_plugin(preload("res://addons/export/export.gd").new())


func _exit_tree():
	pass
