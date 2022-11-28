using Godot;
using System;
using Godot.Collections;

public class SaveSelectMenuPopup : WindowDialog
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private PackedScene saveItem = (PackedScene)ResourceLoader.Load("res://scenes/game/other/save_scene_instance.tscn");
    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        SaveManager saveManager = new SaveManager();
        saveManager._Ready();
        if (saveManager.SaveCount >= 0) {
            foreach (var i in saveManager.GetSaveNamesArray()) {
                Godot.Collections.Dictionary<string, string> saveData = new Dictionary<string, string>();
                saveData.Add("save_modification_date", saveManager.GetSaveLastModificationDate(i));
                saveData.Add("save_name", i);
                Control saveItemInstance = (Control)saveItem.Instance();
                saveItemInstance.Call("set_data", saveData);
                GetNode<VBoxContainer>("Container").AddChild(saveItemInstance);
            }
            
        }
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
