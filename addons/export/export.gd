extends EditorExportPlugin


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var base_install_dir = OS.get_executable_path().get_base_dir() + "/"
# Called when the node enters the scene tree for the first time.
func _export_begin(features, is_debug, path:String, flags):
	print("[%s CoreExport] => Exporting to path: %s" % [_generate_timestamp(), path.get_base_dir()])
	print("[%s CoreExport] => Scanning & collecting data..." % _generate_timestamp())
	var core_files = get_all_files('res://scripts')
	core_files += get_all_files('res://scenes')
	core_files += get_all_files('res://assets')
	core_files += get_all_files('res://dialogic')
	print("[%s CoreExport] => Preparing export directory..." % _generate_timestamp())
	var pck = PCKPacker.new()
	var dir = Directory.new()
	var file = File.new()
	if not dir.dir_exists(path.get_base_dir() + '/data/'):
		dir.make_dir_recursive(path.get_base_dir() + '/data/')
	if file.file_exists(path.get_base_dir()+ "/data/data.pck"):
		dir.remove(path.get_base_dir()+ "/data/data.pck")
	print("[%s CoreExport] => Adding files to data/data.pck..." % _generate_timestamp())
	pck.pck_start(path.get_base_dir()+ "/data/data.pck")
	for i in core_files:
		pck.add_file(i, i)
	print("[%s CoreExport] => Flushing data/data.pck..." % _generate_timestamp())
	pck.flush()
	print("[%s CoreExport] => Done exporting data/data.pck..." % _generate_timestamp())
	
	
	
	
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
