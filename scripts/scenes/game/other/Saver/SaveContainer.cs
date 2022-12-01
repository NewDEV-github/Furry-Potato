using System;
using System.IO;
using Godot.Collections;

public class SaveContainer : BaseSave {
    private string _saveRoot = "";
    public override void SetSaveDir(string baseDir) {
        _saveRoot = baseDir;
    }
    public override void WriteDirectories(Dictionary<string, Dictionary<string, string>> data) {
        Directory.CreateDirectory(Path.GetDirectoryName(_saveRoot) ?? throw new InvalidOperationException());
        foreach (var s in data) {
            Directory.CreateDirectory(Path.GetDirectoryName(_saveRoot + $"\\data\\{s.Key}\\"));
        }
        

    }

    public override void WriteData(string subfolder, System.Collections.Generic.Dictionary<string, string> data) {
        foreach (var v in data) {
            string name = v.Key;
            string path = _saveRoot + "\\" + subfolder + "\\" + name + ".dat";
            // This text is added only once to the file.
            File.WriteAllText(path, v.Value);
        }
    }
}
