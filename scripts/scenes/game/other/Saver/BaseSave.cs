using Godot.Collections;
using System.IO;
public abstract class BaseSave {
    public abstract void SetSaveDir(string baseDir);
    public abstract void WriteDirectories(Dictionary<string, Dictionary<string, string>> dirData);
    public abstract void WriteData(string subfolder, System.Collections.Generic.Dictionary<string, string> data);
}
