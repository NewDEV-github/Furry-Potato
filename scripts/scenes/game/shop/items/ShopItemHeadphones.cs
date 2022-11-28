/// <summary>
/// Class for "Casual headphones" item
/// </summary>
public class ShopItemHeadphones : ShopItemBase
{

    public override void InitItem() {
        ItemName = "Casual Headphones";
        ItemDescription = "Brr";
        ItemCost = 100;
        ItemExperienceMultiplier = 1.1f;
        ItemIconPath = "res://icon.png";
        ItemPartyQualityMultiplier = 1.0f;
        ItemMusicQualityMultiplier = 1.05f;
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
