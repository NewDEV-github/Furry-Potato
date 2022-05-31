extends EditorExportPlugin


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var base_install_dir = OS.get_executable_path().get_base_dir() + "/"
# Called when the node enters the scene tree for the first time.
func _export_begin(features, is_debug, path:String, flags):
	print("[%s ScriptExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s ScriptExport] => Scanning & collecting data..." % _generate_timestamp())
	var core_files = get_all_files('res://scripts')
	print("[%s ScriptExport] => Preparing export directory..." % _generate_timestamp())
	var pck = PCKPacker.new()
	var dir = Directory.new()
	var file = File.new()
	if not dir.dir_exists(path.get_base_dir() + '/data/'):
		dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if file.file_exists(path.get_base_dir()+ "/data/script_data.pck"):
		dir.remove(path.get_base_dir()+ "/data/script_data.pck")
	print("[%s ScriptExport] => Adding files to data/script_data.pck..." % _generate_timestamp())
	pck.pck_start(path.get_base_dir()+ "/data/script_data.pck")
	for i in core_files:
		pck.add_file(i, i)
	print("[%s ScriptExport] => Flushing data/script_data.pck..." % _generate_timestamp())
	pck.flush()
	print("[%s ScriptExport] => Done exporting data/script_data.pck..." % _generate_timestamp())
	
	
	print("[%s ScriptExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s ScriptExport] => Scanning & collecting data..." % _generate_timestamp())
	
	var scenes_files = get_all_files('res://scenes')
	print("[%s ScenesExport] => Preparing export directory..." % _generate_timestamp())
	var scenes_pck = PCKPacker.new()
	var scenes_dir = Directory.new()
	var scenes_file = File.new()
	if not scenes_dir.dir_exists(path.get_base_dir() + '/data/'):
		scenes_dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if scenes_file.file_exists(path.get_base_dir()+ "/data/scenes_data.pck"):
		scenes_dir.remove(path.get_base_dir()+ "/data/scenes_data.pck")
	print("[%s ScenesExport] => Adding files to data/scenes_data.pck..." % _generate_timestamp())
	scenes_pck.pck_start(path.get_base_dir()+ "/data/scenes_data.pck")
	for i in scenes_files:
		scenes_pck.add_file(i, i)
	print("[%s ScenesExport] => Flushing data/scenes_data.pck..." % _generate_timestamp())
	scenes_pck.flush()
	print("[%s ScenesExport] => Done exporting data/scenes_data.pck..." % _generate_timestamp())
	
	print("[%s CoreExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s CoreExport] => Scanning & collecting data..." % _generate_timestamp())
	
	
	var graphics_files = get_all_files('res://assets/Graphics')
	print("[%s GraphicsExport] => Preparing export directory..." % _generate_timestamp())
	var graphics_pck = PCKPacker.new()
	var graphics_dir = Directory.new()
	var graphics_file = File.new()
	if not graphics_dir.dir_exists(path.get_base_dir() + '/data/'):
		graphics_dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if graphics_file.file_exists(path.get_base_dir()+ "/data/graphics_data.pck"):
		graphics_dir.remove(path.get_base_dir()+ "/data/graphics_data.pck")
	print("[%s GraphicsExport] => Adding files to data/graphics_data.pck..." % _generate_timestamp())
	graphics_pck.pck_start(path.get_base_dir()+ "/data/graphics_data.pck")
	for i in graphics_files:
		graphics_pck.add_file(i, i)
	print("[%s GraphicsExport] => Flushing data/graphics_data.pck..." % _generate_timestamp())
	graphics_pck.flush()
	print("[%s GraphicsExport] => Done exporting data/graphics_data.pck..." % _generate_timestamp())
	
	print("[%s GraphicsExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s GraphicsExport] => Scanning & collecting data..." % _generate_timestamp())
	
	var audio_files = get_all_files('res://assets/audio')
	print("[%s AudioExport] => Preparing export directory..." % _generate_timestamp())
	var audio_pck = PCKPacker.new()
	var audio_dir = Directory.new()
	var audio_file = File.new()
	if not audio_dir.dir_exists(path.get_base_dir() + '/data/'):
		audio_dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if audio_file.file_exists(path.get_base_dir()+ "/data/audio_data.pck"):
		audio_dir.remove(path.get_base_dir()+ "/data/audio_data.pck")
	print("[%s AudioExport] => Adding files to data/audio_data.pck..." % _generate_timestamp())
	audio_pck.pck_start(path.get_base_dir()+ "/data/audio_data.pck")
	for i in audio_files:
		audio_pck.add_file(i, i)
	print("[%s AudioExport] => Flushing data/audio_data.pck..." % _generate_timestamp())
	audio_pck.flush()
	print("[%s AudioExport] => Done exporting data/audio_data.pck..." % _generate_timestamp())

	print("[%s AudioExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s AudioExport] => Scanning & collecting data..." % _generate_timestamp())
	
	var theme_files = get_all_files('res://assets/themes')
	print("[%s ThemeExport] => Preparing export directory..." % _generate_timestamp())
	var theme_pck = PCKPacker.new()
	var theme_dir = Directory.new()
	var theme_file = File.new()
	if not theme_dir.dir_exists(path.get_base_dir() + '/data/'):
		theme_dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if theme_file.file_exists(path.get_base_dir()+ "/data/theme_data.pck"):
		theme_dir.remove(path.get_base_dir()+ "/data/theme_data.pck")
	print("[%s ThemeExport] => Adding files to data/theme_data.pck..." % _generate_timestamp())
	theme_pck.pck_start(path.get_base_dir()+ "/data/theme_data.pck")
	for i in theme_files:
		theme_pck.add_file(i, i)
	print("[%s ThemeExport] => Flushing data/theme_data.pck..." % _generate_timestamp())
	theme_pck.flush()
	print("[%s ThemeExport] => Done exporting data/theme_data.pck..." % _generate_timestamp())
	
	print("[%s ThemeExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s ThemeExport] => Scanning & collecting data..." % _generate_timestamp())
	
	
	
	var font_files = get_all_files('res://assets/fonts')
	print("[%s FontExport] => Preparing export directory..." % _generate_timestamp())
	var font_pck = PCKPacker.new()
	var font_dir = Directory.new()
	var font_file = File.new()
	if not font_dir.dir_exists(path.get_base_dir() + '/data/'):
		font_dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if font_file.file_exists(path.get_base_dir()+ "/data/font_data.pck"):
		font_dir.remove(path.get_base_dir()+ "/data/font_data.pck")
	print("[%s FontExport] => Adding files to data/font_data.pck..." % _generate_timestamp())
	font_pck.pck_start(path.get_base_dir()+ "/data/font_data.pck")
	for i in font_files:
		font_pck.add_file(i, i)
	print("[%s FontExport] => Flushing data/font_data.pck..." % _generate_timestamp())
	font_pck.flush()
	print("[%s FontExport] => Done exporting data/font_data.pck..." % _generate_timestamp())
	
	print("[%s ImportDataExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s ImportDataExport] => Scanning & collecting data..." % _generate_timestamp())
	var import_data_files = get_all_files('res://.import')
	print("[%s ImportDataExport] => Preparing export directory..." % _generate_timestamp())
	var import_data_pck = PCKPacker.new()
	var import_data_dir = Directory.new()
	var import_data_file = File.new()
	if not import_data_dir.dir_exists(path.get_base_dir() + '/data/'):
		import_data_dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if import_data_file.file_exists(path.get_base_dir()+ "/data/import_data.pck"):
		import_data_dir.remove(path.get_base_dir()+ "/data/import_data.pck")
	print("[%s ImportDataExport] => Adding files to data/import_data.pck..." % _generate_timestamp())
	import_data_pck.pck_start(path.get_base_dir()+ "/data/import_data.pck")
	for i in import_data_files:
		import_data_pck.add_file(i, i)
	print("[%s ImportDataExport] => Flushing data/import_data.pck..." % _generate_timestamp())
	import_data_pck.flush()
	print("[%s ImportDataExport] => Done exporting data/import_data.pck..." % _generate_timestamp())
	
	print("[%s DialogicDataExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s DialogicDataExport] => Scanning & collecting data..." % _generate_timestamp())
	var dialogic_data_files = get_all_files('res://dialogic')
	print("[%s DialogicDataExport] => Preparing export directory..." % _generate_timestamp())
	var dialogic_data_pck = PCKPacker.new()
	var dialogic_data_dir = Directory.new()
	var dialogic_data_file = File.new()
	if not dialogic_data_dir.dir_exists(path.get_base_dir() + '/data/'):
		dialogic_data_dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if dialogic_data_file.file_exists(path.get_base_dir()+ "/data/dialogic_data.pck"):
		dialogic_data_dir.remove(path.get_base_dir()+ "/data/dialogic_data.pck")
	print("[%s DialogicDataExport] => Adding files to data/dialogic_data.pck..." % _generate_timestamp())
	dialogic_data_pck.pck_start(path.get_base_dir()+ "/data/dialogic_data.pck")
	for i in dialogic_data_files:
		dialogic_data_pck.add_file(i, i)
	print("[%s DialogicDataExport] => Flushing data/dialogic_data.pck..." % _generate_timestamp())
	dialogic_data_pck.flush()
	print("[%s DialogicDataExport] => Done exporting data/dialogic_data.pck..." % _generate_timestamp())
	
	var data_files = get_all_files('res://misc/')
	for i in data_files:
		var splitted_path = str(i).split("/")
		splitted_path.remove(0)
		splitted_path.remove(0)
		var compiled_path = splitted_path.join('/')
		var dest_path = path.get_base_dir() + "/" + compiled_path
		print("[%s MiscExport] => Checking if \"misc\" export dir exists..." % _generate_timestamp())
		if not dir.dir_exists(str(dest_path).get_base_dir()):
			print("[%s MiscExport] => \"misc\" export dir doesn't exist, creating new one at: %s" % [_generate_timestamp(), str(dest_path).get_base_dir()])
			dir.make_dir_recursive(str(dest_path).get_base_dir())
		else:
			print("[%s MiscExport] => \"misc\" export dir exists at: %s" % [_generate_timestamp(), str(dest_path).get_base_dir()])
		print("[%s MiscExport] => Copying %s => %s" % [_generate_timestamp(), splitted_path[splitted_path.size() -1], dest_path])
		dir.copy(i, dest_path)
	var saves_files = get_all_files('res://saves/')
	for i in saves_files:
		var splitted_path = str(i).split("/")
		splitted_path.remove(0)
		splitted_path.remove(0)
		var compiled_path = splitted_path.join('/')
		var dest_path = path.get_base_dir() + "/" + compiled_path
		print("[%s SavesExport] => Checking if \"saves\" export dir exists..." % _generate_timestamp())
		if not dir.dir_exists(str(dest_path).get_base_dir()):
			print("[%s SavesExport] => \"saves\" export dir doesn't exist, creating new one at: %s" % [_generate_timestamp(), str(dest_path).get_base_dir()])
			dir.make_dir_recursive(str(dest_path).get_base_dir())
		else:
			print("[%s SavesExport] => \"saves\" export dir exists at: %s" % [_generate_timestamp(), str(dest_path).get_base_dir()])
		print("[%s SavesExport] => Copying %s => %s" % [_generate_timestamp(), splitted_path[splitted_path.size() -1], dest_path])
		dir.copy(i, dest_path)
func get_all_files(path: String, file_ext := "", files := []):
	var dir = Directory.new()

	if dir.open(path) == OK:
		dir.list_dir_begin(true, true)

		var file_name = dir.get_next()

		while file_name != "":
			if dir.current_is_dir():
				files = get_all_files(dir.get_current_dir().plus_file(file_name), file_ext, files)
			else:
				if file_ext and file_name.get_extension() != file_ext:
					file_name = dir.get_next()
					continue

				files.append(dir.get_current_dir().plus_file(file_name))

			file_name = dir.get_next()
	else:
		print("[%s FileScannerExport] => An error occurred when trying to access %s." % [_generate_timestamp(), path])

	return files

func _generate_timestamp():
	return str(OS.get_time().hour) + ":" + str(OS.get_time().minute) + ":" + str(OS.get_time().second)
