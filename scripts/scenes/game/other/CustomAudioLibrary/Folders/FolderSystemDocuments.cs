using System;
using Godot;

public class FolderSystemDocuments : FolderBase
{
    /// <summary>
    /// Sets filters for extensions for files to look for with
    /// </summary>
    /// <param name="arrayOfExtensions">Array including extensions, eg. <code>["mp3"]</code></param>
    /// @todo Get extensions on mind while filtering files
    public override void SetFileExtensionFilter(System.Array arrayOfExtensions) {
        
    }
    
    /// <summary>
    /// Returns array of files in folder
    /// </summary>
    /// <returns>Array of files in folder</returns>
    /// @todo Implement scanning with extensions
    public override Array GetFilesInFolder() {
        string[] filesList = new string[] { };

        return filesList;
    }

    /// <summary>
    /// Returns folder path
    /// </summary>
    /// <returns>Folder path</returns>
    public override string GetFolderPath() {
        return OS.GetSystemDir(OS.SystemDir.Documents) + "\\New DEV\\Furry Potato\\Custom Music\\";
    }
}
