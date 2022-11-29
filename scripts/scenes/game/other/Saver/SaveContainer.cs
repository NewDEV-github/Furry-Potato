using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class SaveContainer : BaseSave {
    private string _saveRoot = "";
    public override void SetSaveDir(string baseDir) {
        _saveRoot = baseDir;
    }
    public override void WriteDirectories() {
        Directory.CreateDirectory(Path.GetDirectoryName(_saveRoot) ?? throw new InvalidOperationException());
        Directory.CreateDirectory(Path.GetDirectoryName(_saveRoot + "\\data\\GameController\\"));
        Directory.CreateDirectory(Path.GetDirectoryName(_saveRoot + "\\data\\OptionController\\"));

    }

    public override void WriteData(string subfolder, Dictionary<string, string> data) {
        foreach (var v in data) {
            string name = v.Key;
            string path = _saveRoot + "\\" + subfolder + "\\" + name + ".dat";
            // This text is added only once to the file.
            File.WriteAllText(path, v.Value);
        }
    }
}
