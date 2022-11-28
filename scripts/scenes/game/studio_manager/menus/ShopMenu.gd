extends WindowDialog
var ShopItemManager = preload("res://scripts/scenes/game/shop/ShopItemManager.cs").new()
var shop_items = []

# Called when the node enters the scene tree for the first time.
func _ready():
	ShopItemManager.InitItems()
	for i in ShopItemManager.GetItemList():
		shop_items.append(ShopItemManager.GetItemData(i))
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
