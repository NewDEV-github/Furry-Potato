using System;
using System.IO;
using Godot.Collections;

/// <summary>
/// Class that creates save data
/// </summary>
public class SaveContainer : BaseSave {
    private string _saveRoot = "";
    
    /// <summary>
    /// Sets save root directory
    /// </summary>
    /// <param name="baseDir">Root directory</param>
    public override void SetSaveDir(string baseDir) {
        _saveRoot = baseDir;
    }
    
    /// <summary>
    /// Creates all necessary directories
    /// </summary>
    /// <param name="dirData">Data to create directories from</param>
    public override void WriteDirectories(Dictionary<string, Dictionary<string, string>> data) {
        Directory.CreateDirectory(Path.GetDirectoryName(_saveRoot) ?? throw new InvalidOperationException());
        foreach (var s in data) {
            Directory.CreateDirectory(Path.GetDirectoryName(_saveRoot + $"\\data\\{s.Key}\\"));
        }
        

    }

    /// <summary>
    /// This function writes data to file according to data type, path and object that will hold this data
    /// </summary>
    /// <param name="subfolder">Subfolder name. It usually comes with type prefix, but prefix will be removed by this function</param>
    /// <param name="data">Dictionary of data</param>
    public override void WriteData(string subfolder, System.Collections.Generic.Dictionary<string, string> data) {
        foreach (var v in data) {
            
            // This text is added only once to the file.
            string[] prefixes = new string[] { "string_", "int_", "float_" };
            string type = "";
            foreach (var vPrefix in prefixes) {
                if (subfolder.StartsWith(vPrefix)) {
                    type = vPrefix;
                    //remove type prefix from folder name
                    subfolder = subfolder.Substring(vPrefix.Length);
                }
            }
            string name = type + v.Key;
            string path = _saveRoot + "\\" + subfolder + "\\" + name + ".dat";
            File.WriteAllText(path, v.Value);
        }
    }
}
