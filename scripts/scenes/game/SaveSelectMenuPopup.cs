using Godot;
using System;
using Godot.Collections;

/// <summary>
/// Class used by save menu popup
/// </summary>
public class SaveSelectMenuPopup : WindowDialog {
    
    /// <summary>
    /// Signal emitted when save data has been preloaded
    /// </summary>
    [Signal]
    delegate void SaveDataPreloaded();
    
    /// <summary>
    /// ItemList's node instance
    /// </summary>
    private ItemList _itemList;

    /// <summary>
    /// Contains preloaded save data, previously set by <code>new Loader().LoadSave(string path)</code>
    /// Useful after only <code>SaveDataPreloaded</code> signal has been called.
    /// </summary>
    public Dictionary<string, Dictionary<string, string>> PreloadedSaveData = new Dictionary<string, Dictionary<string, string>>();
    SaveManager _saveManager = new SaveManager();
    
    /// <summary>
    /// Dictionary used to keep where is root path for each save. To make it easier the key is id of ItemList's item.
    /// </summary>
    private Dictionary<int, string> _pathsForItemList = new Dictionary<int, string>();

    /// <summary>
    /// Current ID of next non-existent Item in the ItemList
    /// </summary>
    private int _currentItemListId = 0;
    public override void _Ready() {
        _itemList = GetNode<ItemList>("Container");
        _itemList.Connect("item_selected", this, "SaveSelectedToLoad");
        
        _saveManager._Ready();
        if (_saveManager.SaveCount >= 0) {
            foreach (var i in _saveManager.GetSaveNamesArray()) {
                string itemText = i + " | " + _saveManager.GetSaveLastModificationDate(i);
                _pathsForItemList.Add(_currentItemListId, _saveManager.SavePaths[i]);
                _itemList.AddItem(itemText);
                _currentItemListId += 1;
            }
            
        }
        
    }

    /// <summary>
    /// Called by Godot, when user has selected save to load
    /// </summary>
    /// <param name="index">Index of item, in displayed ItemList with save list, that contains selected save name</param>
    protected void SaveSelectedToLoad(int index) {
        Loader loader = new Loader();
        string path = _pathsForItemList[index];
        GD.Print($"Pressed save item with index {index} and assigned path:\n{path}");
        PreloadedSaveData = loader.LoadSave(path);
        EmitSignal("SaveDataPreloaded");
    }

}
