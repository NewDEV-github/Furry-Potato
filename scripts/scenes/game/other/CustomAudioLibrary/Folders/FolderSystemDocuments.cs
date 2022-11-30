using System;
using Godot;

public class FolderSystemDocuments : FolderBase
{

    /// <summary>
    /// Returns array of files in folder
    /// </summary>
    /// <returns>Array of files in folder</returns>
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
