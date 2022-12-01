using Godot;
using System;
using Godot.Collections;


/// <summary>
/// Class for managing all shop items
/// </summary>
public class ShopItemManager : Node {
    /// <summary>
    /// Dictionary of items in shops. Includes item name and it's instance.
    /// string includes item name, and <code>ShopItemBase</code> it's instance
    /// </summary>
    private System.Collections.Generic.Dictionary<string, ShopItemBase> _shopItems = new System.Collections.Generic.Dictionary<string, ShopItemBase>();
    // Item instances
    private readonly ShopItemBase _casualHeadphones = new ShopItemHeadphones();
    /// <summary>
    /// Array of items in shops.
    /// Includes only item names for reference to load their data in Godot and display them in game
    /// </summary>
    private Array<string> _itemList = new Array<string>();
    /// <summary>
    /// Initializes all shop items. Needs to be called before everything
    /// </summary>
    public void InitItems() {
        _casualHeadphones.InitItem();
        _shopItems.Add("CasualHeadphones", _casualHeadphones);
        _itemList.Add("CasualHeadphones");
    }

    /// <summary>
    /// Returns array of items in shops.
    /// Includes only item names for reference to load their data in Godot and display them in game
    /// </summary>
    /// <returns>List of in shop items</returns>
    public Array<string> GetItemList() {
        return _itemList;
    }

    
    /// <summary>
    /// Returns item data for given item.
    /// </summary>
    /// <param name="itemName">Item name</param>
    /// <returns>Item data in dictionary</returns>
    public Dictionary<string, string> GetItemData(string itemName) {
        Dictionary<string, string> data = new Dictionary<string, string> {
            { "item_name", _shopItems[itemName].GetItemName() },
            { "item_description", _shopItems[itemName].GetItemDescription() },
            { "item_price", _shopItems[itemName].GetItemCost() },
            { "item_icon", _shopItems[itemName].GetItemIconPath() },
            { "item_experience_multiplier", _shopItems[itemName].GetItemExperienceMultiplier() },
            { "item_party_quality_multiplier", _shopItems[itemName].GetItemPartyQualityMultiplier() },
            { "item_music_quality_multiplier", _shopItems[itemName].GetItemMusicQualityMultiplier() }
        };
        return data;
    }
}
