using System;
using System.IO;
using Godot;
using Godot.Collections;
using Directory = System.IO.Directory;
using File = System.IO.File;

/// <summary>
/// Class used to manage all game saves.
/// </summary>
public class SaveManager : Control {
    /// <summary>
    /// Array that contains only list of save names
    /// </summary>
    public int SaveCount = 0;
    private Array<string> _saveNamesList = new Array<string>();
    /// <summary>
    /// Dictionary that contains save name as key and path to root of save as a value
    /// </summary>
    public Dictionary<string, string> SavePaths = new Dictionary<string, string>();
    public override void _Ready()
    {
        GetSaveList();
    }

    /// <summary>
    /// Loads all save names from disk
    /// </summary>
    private void GetSaveList() {
        string saveDir = OS.GetUserDataDir() + "\\Saves\\";
        if (Directory.Exists(saveDir)) {
            string[] dirs = Directory.GetDirectories(saveDir, "*", SearchOption.TopDirectoryOnly);
            SaveCount = dirs.Length;
            foreach (string dir in dirs) {
                string filePath = dir + "\\SaveName.dat";
                Console.WriteLine("Looking up for save name data in: " + dir);
                string realSaveName = File.ReadAllText(filePath);
                _saveNamesList.Add(realSaveName);
                SavePaths.Add(realSaveName, dir);
            }
        } else {
            Console.WriteLine("Zero saves found");
        }
    }
    
    /// <summary>
    /// Public interface for getting list of save names
    /// </summary>
    /// <returns>Array of save names</returns>
    public Array<string> GetSaveNamesArray() {
        return _saveNamesList;
    }

    /// <summary>
    /// Public interface for getting save modification date
    /// </summary>
    /// <param name="saveName">Name of the save</param>
    /// <returns>Last modification date in string</returns>
    public string GetSaveLastModificationDate(string saveName) {
        string path = OS.GetUserDataDir() + "\\Saves\\" + saveName + "\\data\\ModificationDate.dat";
        return File.ReadAllText(path);
    }
}
