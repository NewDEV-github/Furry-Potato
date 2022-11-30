using System;
using Godot;

public class FolderSystemMusic : FolderBase
{
    public override Array GetFilesInFolder() {
        string[] filesList = new string[] { };

        return filesList;
    }

    /// <summary>
    /// Returns folder path
    /// </summary>
    /// <returns>Folder path</returns>
    public override string GetFolderPath() {
        return OS.GetSystemDir(OS.SystemDir.Music);
    }
}
