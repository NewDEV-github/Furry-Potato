using System;
using System.Globalization;
using Godot;
using Godot.Collections;
using File = System.IO.File;
using NewDEVSharp.Collections;

/// <summary>
/// Class that holds all save-related actions for current game save
/// </summary>
public class Saver : Node {
    
    /// <summary>
    /// SaveContainer instance
    /// </summary>
    private readonly SaveContainer _saveContainer = new SaveContainer();
    
    /// <summary>
    /// NewDEVSharp.Collections.DictionaryConverter instance
    /// </summary>
    private readonly DictionaryConverter _dc = new DictionaryConverter();

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
            _saveContainer.WriteData($"\\data\\{d.Key}", _dc.GodotToSystem(d.Value));
        }
    }
}
