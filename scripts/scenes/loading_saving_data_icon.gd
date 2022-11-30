extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


func show_icon():
	$CanvasLayer/AnimationPlayer.play("show_up")

func _process(delta):
	if OptionController.get_option_data("use_discord_avatar") == "True":
		if DiscordSDK.discord_user_img != null:
			$CanvasLayer/TextureRect.texture = DiscordSDK.discord_user_img

func hide_icon():
	$CanvasLayer/AnimationPlayer.play("hide")
