extends WindowDialog


var shop_items = [
	{
		"item_name": "test item",
		"item_price": 23,
		"item_icon": "res://icon.png",
		"item_description": "Best headphones ever",
		"music_quality_multiplier": 0.1,
		"experience_multiplier": 0.1,
		"party_quality_multiplier": 0
	},
	{
		"item_name": "test item",
		"item_price": 23,
		"item_icon": "res://icon.png",
		"item_description": "Best headphones ever",
		"music_quality_multiplier": 0.1,
		"experience_multiplier": 0.1,
		"party_quality_multiplier": 0
	}
]

# Called when the node enters the scene tree for the first time.
func _ready():
	_render_shop_items()


func _render_shop_items():
	for i in shop_items:
		print(i)
		var shop_item_instance = preload("res://scenes/game/other/shop_item_scene_instance.tscn").instance()
		shop_item_instance.set_item_data(i)
		shop_item_instance.connect("item_bought", self, "on_item_bought")
		$ShopContainer.add_child(shop_item_instance)

func on_item_bought(item_name):
	pass
