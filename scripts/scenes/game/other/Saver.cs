using System;
using System.Globalization;
using Godot;
using Godot.Collections;
using File = System.IO.File;
using NewDEVSharp.Collections;
public class Saver : Node {
    private readonly SaveContainer _saveContainer = new SaveContainer();
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    /// <summary>
    /// This method calls SaveContainer class to save data
    /// </summary>
    /// <param name="data">Save data</param>
    /// <param name="dir">Save root directory</param>
    /// <param name="orgSName">Name of the save</param>
    public void SaveGame(Dictionary<string, Dictionary<string, string>> data, string dir, string orgSName) {
        DictionaryConverter dc = new DictionaryConverter();
        _saveContainer.SetSaveDir(dir);
        _saveContainer.WriteDirectories(data);
        File.WriteAllText(dir + "\\SaveName.dat", orgSName);
        File.WriteAllText(dir + "\\data\\ModificationDate.dat", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        foreach (var d in data) {
            _saveContainer.WriteData($"\\data\\{d.Key}", dc.GodotToSystem(d.Value));
        }
    }
}
