using Godot.Collections;
using System.IO;
/// <summary>
/// Base class for all save-classes
/// </summary>
public abstract class BaseSave {
    
    /// <summary>
    /// Sets save root directory
    /// </summary>
    /// <param name="baseDir">Root directory</param>
    public abstract void SetSaveDir(string baseDir);
    
    /// <summary>
    /// Creates all necessary directories
    /// </summary>
    /// <param name="dirData">Data to create directories from</param>
    public abstract void WriteDirectories(Dictionary<string, Dictionary<string, string>> dirData);
    
    /// <summary>
    /// Writes passes in as arguments save data
    /// </summary>
    /// <param name="subfolder">Subfolder where data will be saved to</param>
    /// <param name="data">Dictionary of data</param>
    public abstract void WriteData(string subfolder, System.Collections.Generic.Dictionary<string, string> data);
}
