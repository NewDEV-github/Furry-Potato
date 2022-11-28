using Godot;
using System;
using Godot.Collections;

public class ShopItemManager : Node {
    private System.Collections.Generic.Dictionary<string, ShopItemBase> _shopItems = new System.Collections.Generic.Dictionary<string, ShopItemBase>();
    private readonly ShopItemBase _casualHeadphones = new ShopItemHeadphones();
    private Array<string> _itemList = new Array<string>();
    /// <summary>
    /// Initializes all shop items. Needs to be called before everything
    /// </summary>
    public void InitItems() {
        _casualHeadphones.InitItem();
        _shopItems.Add("CasualHeadphones", _casualHeadphones);
        _itemList.Add("CasualHeadphones");
    }

    public Array<string> GetItemList() {
        return _itemList;
    }

    public Dictionary<string, string> GetItemData(string itemName) {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("item_name", _shopItems[itemName].GetItemName());
        data.Add("item_description", _shopItems[itemName].GetItemDescription());
        data.Add("item_price", _shopItems[itemName].GetItemCost());
        data.Add("item_icon", _shopItems[itemName].GetItemIconPath());
        data.Add("experience_multiplier", _shopItems[itemName].GetItemExperienceMultiplier());
        data.Add("party_quality_multiplier", _shopItems[itemName].GetItemPartyQualityMultiplier());
        data.Add("music_quality_multiplier", _shopItems[itemName].GetItemMusicQualityMultiplier());
        return data;
    }
}
