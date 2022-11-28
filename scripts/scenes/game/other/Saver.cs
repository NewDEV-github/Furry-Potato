using System;
using System.Globalization;
using Godot;
using Godot.Collections;
using File = System.IO.File;

public class Saver : Node {
    private readonly SaveContainer _saveContainer = new SaveContainer();
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void SaveGame(string dir, Dictionary<string, string> gOptions, Dictionary<string, string> gData, string orgSName) {
        _saveContainer.SetSaveDir(dir);
        _saveContainer.WriteDirectories();
        File.WriteAllText(dir + "\\SaveName.dat", orgSName);
        File.WriteAllText(dir + "\\data\\ModificationDate.dat", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        //type conversion
        System.Collections.Generic.Dictionary<string, string> gameOptions =  new System.Collections.Generic.Dictionary<string, string>();
        foreach (var gv in gOptions) {
            gameOptions.Add(gv.Key, gv.Value);
        }

        System.Collections.Generic.Dictionary<string, string> gameData = new System.Collections.Generic.Dictionary<string, string>();
        foreach (var gv in gData) {
            gameData.Add(gv.Key, gv.Value);
        }
        
        _saveContainer.WriteData("data\\OptionController", gameOptions);
        _saveContainer.WriteData("data\\GameController", gameData);
    }

    
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
