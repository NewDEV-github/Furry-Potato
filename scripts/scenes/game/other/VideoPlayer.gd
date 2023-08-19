extends VideoPlayer
export var transition_duration = 1.00
export var transition_type = 1 # TRANS_SINE
export (NodePath) var tween_in_path
export (NodePath) var tween_out_path
onready var tween_out = get_node(tween_out_path)
onready var tween_in = get_node(tween_in_path)
# Called when the node enters the scene tree for the first time.
func fade_in():
	tween_in.interpolate_property(self, "volume_db", -80, 0, transition_duration, transition_type, Tween.EASE_IN, 0)
	tween_in.start()

func fade_out():
	tween_out.interpolate_property(self, "volume_db", 0, -80, transition_duration, transition_type, Tween.EASE_IN, 0)
	tween_out.start()
