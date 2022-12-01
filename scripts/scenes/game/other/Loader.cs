using Godot;
using System;
using Godot.Collections;


/// <summary>
/// Class used to pre-load and format save data
/// </summary>
public class Loader : Node {
    
    /// <summary>
    /// Loads save, then after loading data changes scene to game
    /// </summary>
    /// <param name="saveDir">Save data root directory</param>
    /// <returns>Parsed save data</returns>
    public Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, string>> LoadSave(string saveDir) {
        Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, string>> returnVar = new Dictionary<string, Dictionary<string, string>>();
        Console.Write($"Save dir is {saveDir}");
        string[] folders = System.IO.Directory.GetDirectories(saveDir + "\\data\\","*", System.IO.SearchOption.AllDirectories);
        foreach (var dir in folders) {
            string dirBaseName = System.IO.Path.GetFileNameWithoutExtension(dir);
            Godot.Collections.Dictionary<string, string> tempReturnVal = new Dictionary<string, string>();
            string[] fileList = System.IO.Directory.GetFiles(dir);
            foreach (var file in fileList) {
                tempReturnVal.Add(System.IO.Path.GetFileNameWithoutExtension(file), System.IO.File.ReadAllText(file));
            }

            returnVar.Add(dirBaseName, tempReturnVal);
        }
        return returnVar;
    }
}

