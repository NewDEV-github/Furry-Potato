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
var audio_files = [
	"res://assets/audio/bg/1stage2.mp3",
	"res://assets/audio/bg/1stage.ogg",
	"res://assets/audio/bg/beauty.ogg",
	"res://assets/audio/bg/credits_gekagd.ogg",
	"res://assets/audio/bg/love.ogg",
	"res://assets/audio/bg/music_gekagd.ogg",
	"res://assets/audio/bg/nasko.ogg",
	"res://assets/audio/bg/Alphaville - Forever Young _Official Video.ogg",
	"res://assets/audio/bg/Fast_Five_-_Don_Omar_Ft._Lucenzo_-_Danza_Kuduro.mp4.mp3",
	"res://assets/audio/bg/Queen - Radio Ga Ga (Official Video).ogg",
]
# Called when the node enters the scene tree for the first time.
func _ready():
	play_random_song()
	fade_in()
	start_dialog.connect("dialogic_signal", self, "dialog_listener")
	$Manager/menus/NewNameMenu.connect("new_name_ready", self, "_start_2nd_dialog")
	add_child(start_dialog)
func play_random_song():
	randomize()
	var song_file = audio_files[randi()%audio_files.size()]
	$AudioStreamPlayer.stream = load(song_file)
	$AudioStreamPlayer.play()
func dialog_listener(string:String):
	match string:
		"run_tutorial":
			$Tutorial.run_tutorial()
		"go_to_game":
			$Tutorial.hide()
			$Manager/menus/EmailMenu/EmailControl.check_emails()
		"dialog1_closed":
			$Manager/menus/NewNameMenu.popup_centered()

func _start_2nd_dialog():
	var new_dialog = Dialogic.start('tutorial2')
	new_dialog.connect("dialogic_signal", self, "dialog_listener")
	add_child(new_dialog)

func _process(delta):
	if Input.is_action_just_pressed("ui_cancel"):
		if !$PauseMenu.visible:
			fade_out()
		else:
			fade_in()

func _on_TutorialFinished_pressed():
	dialog_listener("go_to_game")


func _on_AudioStreamPlayer_finished():
	play_random_song()


func _on_PauseMenu_visibility_changed():
	fade_in()
