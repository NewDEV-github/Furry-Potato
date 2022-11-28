/// <summary>
/// Abstract base class for all shop items
/// </summary>
public abstract class ShopItemBase {
    /// <summary>
    /// Item's name
    /// </summary>
    protected string ItemName;
    
    /// <summary>
    /// Path to the item's icon
    /// </summary>
    protected string ItemIconPath;
    
    /// <summary>
    /// Item's description
    /// </summary>
    protected string ItemDescription;
    
    /// <summary>
    /// Cost of the item
    /// </summary>
    protected int ItemCost;
    
    /// <summary>
    /// Item's experience multiplier
    /// </summary>
    protected float ItemExperienceMultiplier;
    
    /// <summary>
    /// Multiplier for "party quality" value
    /// </summary>
    protected float ItemPartyQualityMultiplier;
    
    /// <summary>
    /// Multiplier for "party quality" value
    /// </summary>
    protected float ItemMusicQualityMultiplier;
    
    /// <summary>
    /// Item initializer. Initialize all item data HERE
    /// </summary>
    public abstract void InitItem();
    
    /// <summary>
    /// Gets path to the item's icon
    /// </summary>
    /// <returns>Path to item's icon</returns>
    public abstract string GetItemIconPath();
    
    /// <summary>
    /// Gets description of the item
    /// </summary>
    /// <returns>Item's description</returns>
    public abstract string GetItemDescription();
    
    /// <summary>
    /// Gets item's name
    /// </summary>
    /// <returns>Name of the item</returns>
    public abstract string GetItemName();
    
    /// <summary>
    /// Gets cost of the item
    /// </summary>
    /// <returns>Item's cost</returns>
    public abstract string GetItemCost();
    
    /// <summary>
    /// Gets value of experience multiplier for the item
    /// </summary>
    /// <returns>Value of experience multiplier</returns>
    public abstract string GetItemExperienceMultiplier();
    
    /// <summary>
    /// Gets value of "Party quality" multiplier for the item
    /// </summary>
    /// <returns>Value of "Party quality" multiplier</returns>
    public abstract string GetItemPartyQualityMultiplier();
    
    /// <summary>
    /// Gets value of "Music quality" multiplier for the item
    /// </summary>
    /// <returns>Value of "Music quality" multiplier</returns>
    public abstract string GetItemMusicQualityMultiplier();
}