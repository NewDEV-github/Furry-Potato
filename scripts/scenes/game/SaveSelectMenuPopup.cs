using Godot;
using System;
using Godot.Collections;

public class SaveSelectMenuPopup : WindowDialog {
    private ItemList _itemList;
    SaveManager _saveManager = new SaveManager();
    
    /// <summary>
    /// Dictionary used to keep where is root path for each save. To make it easier the key is id of ItemList's item.
    /// </summary>
    private Dictionary<int, string> _pathsForItemList = new Dictionary<int, string>();

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

    protected void SaveSelectedToLoad(int index) {
        Loader loader = new Loader();
        string path = _pathsForItemList[index];
        GD.Print($"Pressed save item with index {index} and assigned path:\n{path}");
        loader.LoadSave(path);
    }

}
