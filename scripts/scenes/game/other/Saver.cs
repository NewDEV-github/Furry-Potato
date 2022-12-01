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

    /// <summary>
    /// This method calls SaveContainer class to save data
    /// </summary>
    /// <param name="data">Save data</param>
    /// <param name="dir">Save root directory</param>
    /// <param name="orgSName">Name of the save</param>
    public void SaveGame(Dictionary<string, Dictionary<string, string>> data, string dir, string orgSName) {
        _saveContainer.SetSaveDir(dir);
        _saveContainer.WriteDirectories(data);
        File.WriteAllText(dir + "\\SaveName.dat", orgSName);
        File.WriteAllText(dir + "\\data\\ModificationDate.dat", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        foreach (var d in data) {
            _saveContainer.WriteData($"\\data\\{d.Key}", GodotToSystem(d.Value));
        }
    }

    /// <summary>
    /// This function converts Godot dictionary to the system one
    /// <para>This uses string as both data types</para>
    /// </summary>
    /// <param name="dict">Godot Dictionary, with strings as both data types</param>
    /// <returns>The same dictionary, as <code>System.Collections.Generic.Dictionary</code></returns>
    System.Collections.Generic.Dictionary<string, string> GodotToSystem(Godot.Collections.Dictionary<string, string> dict) {
        System.Collections.Generic.Dictionary<string, string> returner = new System.Collections.Generic.Dictionary<string, string>();
        foreach (var v in dict) {
            returner.Add(v.Key, v.Value);
        }

        return returner;
    }
}
