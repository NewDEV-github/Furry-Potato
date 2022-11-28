using Godot;
using System;

public class ShopItemHeadphones : ShopItemBase
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void InitItem() {
        ItemName = "Casual Headphones";
        ItemDescription = "Brr";
        ItemCost = 100;
        ItemExperienceMultiplier = 1.1f;
        ItemIconPath = "res://icon.png";
    }

    public override string GetItemIconPath() {
        return ItemIconPath;
    }

    public override string GetItemDescription() {
        return ItemDescription;
    }

    public override string GetItemName() {
        return ItemName;
    }

    public override string GetItemCost() {
        return ItemCost.ToString();
    }

    public override string GetItemExperienceMultiplier() {
        return ItemExperienceMultiplier.ToString();
    }

    public override string GetItemPartyQualityMultiplier() {
        return ItemPartyQualityMultiplier.ToString();
    }
    
    public override string GetItemMusicQualityMultiplier() {
        return ItemMusicQualityMultiplier.ToString();
    }
}
