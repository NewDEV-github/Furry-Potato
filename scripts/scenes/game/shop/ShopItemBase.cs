using System.Collections.Generic;
using System.IO;
public abstract class ShopItemBase {
    protected string ItemName;
    protected string ItemIconPath;
    protected string ItemDescription;
    protected int ItemCost;
    protected float ItemExperienceMultiplier;
    protected float ItemPartyQualityMultiplier;
    protected float ItemMusicQualityMultiplier;
    public abstract void InitItem();
    public abstract string GetItemIconPath();
    public abstract string GetItemDescription();
    public abstract string GetItemName();
    public abstract string GetItemCost();
    public abstract string GetItemExperienceMultiplier();
    public abstract string GetItemPartyQualityMultiplier();
    public abstract string GetItemMusicQualityMultiplier();
}