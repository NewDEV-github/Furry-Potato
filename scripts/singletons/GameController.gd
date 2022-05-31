extends Node


var current_save_name = "NewSave"
var data = {
	"DJName": "DJ",
	"party_money_earnings_multiplier": 0,
	"party_experience_earnings_multiplier": 0,
	"party_music_quality_multiplier": 0,
	"money": 0,
	"experience": 0
}

func set_name(new_name):
	data["DJName"] = new_name
	print("New name is: " + data["DJName"])
