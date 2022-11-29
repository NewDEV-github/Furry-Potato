extends Control
export var transition_duration = 1.00
export var transition_type = 1 # TRANS_SINE
onready var tween_out = $TweenFadeOut
onready var tween_in = $TweenFadeIn
# Called when the node enters the scene tree for the first time.
func fade_in():
	tween_in.interpolate_property($AudioStreamPlayer, "volume_db", -80, 0, transition_duration, transition_type, Tween.EASE_IN, 0)
	tween_in.start()

func fade_out():
	tween_out.interpolate_property($AudioStreamPlayer, "volume_db", 0, -80, transition_duration, transition_type, Tween.EASE_IN, 0)
	tween_out.start()

var start_dialog = Dialogic.start('tutorial1')

var in_game_audio_files = [
	"res://assets/audio/bg/1stage2.mp3",
	"res://assets/audio/bg/beauty.ogg",
	"res://assets/audio/bg/credits_gekagd.ogg",
	"res://assets/audio/bg/nasko.ogg",
	"res://assets/audio/bg/Alphaville - Forever Young _Official Video.ogg",
	"res://assets/audio/bg/Fast_Five_-_Don_Omar_Ft._Lucenzo_-_Danza_Kuduro.mp4.mp3",
	"res://assets/audio/bg/Queen - Radio Ga Ga (Official Video).ogg",
]

var audio_files = [
	"res://assets/audio/bg/1stage2.mp3",
	"res://assets/audio/bg/beauty.ogg",
	"res://assets/audio/bg/credits_gekagd.ogg",
	"res://assets/audio/bg/nasko.ogg",
	"res://assets/audio/bg/Alphaville - Forever Young _Official Video.ogg",
	"res://assets/audio/bg/Fast_Five_-_Don_Omar_Ft._Lucenzo_-_Danza_Kuduro.mp4.mp3",
	"res://assets/audio/bg/Queen - Radio Ga Ga (Official Video).ogg",
]
var song_titles = {
	"res://assets/audio/bg/Queen - Radio Ga Ga (Official Video).ogg": "Radio Ga Ga",
	"res://assets/audio/bg/Fast_Five_-_Don_Omar_Ft._Lucenzo_-_Danza_Kuduro.mp4.mp3": "Danza Kuduro",
	"res://assets/audio/bg/Alphaville - Forever Young _Official Video.ogg": "Forever Young",
	"res://assets/audio/bg/nasko.ogg": "Nasko",
	"res://assets/audio/bg/credits_gekagd.ogg": "Credits",
	"res://assets/audio/bg/beauty.ogg": "Beauty",
	"res://assets/audio/bg/1stage2.mp3": "1st time"
}
var song_authors = {
	"res://assets/audio/bg/Queen - Radio Ga Ga (Official Video).ogg": "Queen",
	"res://assets/audio/bg/Fast_Five_-_Don_Omar_Ft._Lucenzo_-_Danza_Kuduro.mp4.mp3": "Don Omar",
	"res://assets/audio/bg/Alphaville - Forever Young _Official Video.ogg": "Alphaville",
	"res://assets/audio/bg/nasko.ogg": "Gekon",
	"res://assets/audio/bg/credits_gekagd.ogg": "Gekon",
	"res://assets/audio/bg/beauty.ogg": "Gekon",
	"res://assets/audio/bg/1stage2.mp3": "Gekon"
}
var dft_file = File.new()
# Called when the node enters the scene tree for the first time.
func _ready():
	#check whether optioon has been enaboed, if not leave default in game music
	if OptionController.get_option_data("custom_audio_library_enable") == "True":
		print("Custom library enabled")
		#if needed to play alongside, mix with in game music
		if OptionController.get_option_data("custom_audio_library_play_alongside") == "True":
			print("Custom library set to play alongside")
			audio_files += Array($AudioStreamPlayer.LoadSongFiles())
		elif OptionController.get_option_data("custom_audio_library_play_alongside") == "False":
			print("Custom library set to not play alongside")
			audio_files = Array($AudioStreamPlayer.LoadSongFiles())
	else:
		audio_files = in_game_audio_files
	
	GameController.start_new_game()
	Globals.connect("furry",self,  "on_warning")
	dft_file.open("user://dft_setting", File.READ)
	if str(dft_file.get_line()) == "True":
		$AnimatedIcon.show()
	elif str(dft_file.get_line()) == "False":
		$AnimatedIcon.hide()
	dft_file.close()
	play_random_song()
	fade_in()
	start_dialog.connect("dialogic_signal", self, "dialog_listener")
	$Manager/menus/NewNameMenu.connect("new_name_ready", self, "_start_2nd_dialog")
	PartyController.connect("party_ended", self, "on_party_ended")
	add_child(start_dialog)
func play_random_song():
	randomize()
	var song_file = audio_files[randi()%audio_files.size()]
	$AudioStreamPlayer.stream = _load_audio_file(song_file)
	$AudioStreamPlayer.play()
	if song_titles.has(song_file) && song_authors.has(song_file):
		Player.set_title(song_titles[song_file], song_authors[song_file])
func dialog_listener(string:String):
	match string:
		"run_tutorial":
			$Tutorial.run_tutorial()
		"go_to_game":
			$Tutorial.hide()
			$Manager/menus/EmailMenu/EmailControl.check_emails()
		"dialog1_closed":
			$Manager/menus/NewNameMenu.popup_centered()
		'after_first_party':
			$PartyResults.popup_centered()
		'game_finally_ended':
			fade_out()
			get_tree().change_scene("res://scenes/main/menu.tscn")
		'after_fourth_party_finish':
			pass

func _start_2nd_dialog():
	var new_dialog = Dialogic.start('tutorial2')
	new_dialog.connect("dialogic_signal", self, "dialog_listener")
	add_child(new_dialog)

func _process(delta):
	$MoneyAndExperience.text="Money: " + str(GameController.get_money()) +"\n\nExperience: " + str(GameController.get_experience())
	if Input.is_action_just_pressed("ui_cancel"):
		if !$PauseMenu.visible:
			fade_out()
		else:
			fade_in()

func _on_TutorialFinished_pressed():
	$Visualizer.show()
	dft_file.open("user://dft_setting", File.READ)
	if str(dft_file.get_line()) == "True":
		$AnimatedIcon.show()
	elif str(dft_file.get_line()) == "False":
		$AnimatedIcon.hide()
	dft_file.close()
	dialog_listener("go_to_game")


func _on_AudioStreamPlayer_finished():
	play_random_song()


func _on_PauseMenu_visibility_changed():
	fade_in()

func on_party_ended(current_party_id, party_rewards_money, party_rewards_exp):
	$Manager/menus/EmailMenu/EmailPreview.hide()
	$Manager/menus/EmailMenu.hide()
	var c_n = ClubController.club_data[str(PartyController.party_data[current_party_id+"_club_id"])+"_name"]
	_render_party_results(c_n, party_rewards_money, party_rewards_exp)
	if str(current_party_id) == '0':
		var dialog = Dialogic.start('first_party_end')
		dialog.connect("dialogic_signal", self, "dialog_listener")
		add_child(dialog)
	if str(current_party_id) == '3':
		var dialog = Dialogic.start('after_fourth_party')
		dialog.connect("dialogic_signal", self, "dialog_listener")
		add_child(dialog)
	if str(current_party_id) == '4':
		var dialog = Dialogic.start('end_game')
		dialog.connect("dialogic_signal", self, "dialog_listener")
		add_child(dialog)
	else:
		$PartyResults.popup_centered()
	print("Recived %s money" % str(party_rewards_money))
	GameController.add_money(party_rewards_money)
	print("Recived %s exp" % str(party_rewards_exp))
	GameController.add_experience(party_rewards_exp)
	$Manager/menus/EmailMenu/EmailControl.check_emails()

func _render_party_results(club_name, new_money, new_exp):
	var base_string = "Party at %s\n\nRecived money: %s\nRecived experience: %s" % [club_name, new_money, new_exp]
	$PartyResults/RichTextLabel.text = base_string

func on_warning(enabled):
	print(enabled)
	dft_file.open("user://dft_setting", File.WRITE)
	if enabled:
		$AnimatedIcon.show()
	else:
		$AnimatedIcon.hide()
	dft_file.store_line(str(enabled))
	dft_file.close()

func _load_audio_file(path: String):
	# get file bytes
	var file = File.new()
	file.open(path, File.READ)
	print("Loading from path: " + path)
	var buffer = file.get_buffer(file.get_len())
	if buffer == null:
		print("buffer is null")
	file.close()
	
	# create stream out of these bytes
	var stream
	if path.get_extension() == "ogg":
		stream = AudioStreamOGGVorbis.new()
#		stream.format = AudioStreamSample.FORMAT_16_BITS
		stream.data = buffer
#		stream.mix_rate = 44100
#		stream.stereo = false
	elif path.get_extension() == 'mp3':
		stream = AudioStreamMP3.new()
#		stream.format = AudioStreamSample.FORMAT_16_BITS
		stream.data = buffer
#		stream.mix_rate = 44100
#		stream.stereo = false
	# return this stream
	return stream
