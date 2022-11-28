using System.Collections.Generic;
using System.IO;
public abstract class BaseSave {
    public abstract void SetSaveDir(string baseDir);
    public abstract void WriteDirectories();
    public abstract void WriteData(string subfolder, Dictionary<string, string> data);
}
