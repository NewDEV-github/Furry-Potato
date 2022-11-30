using System;


/// <summary>
/// Basic abstract class for folders in <code>CustomAudioLibrary</code>
/// </summary>
public abstract class FolderBase
{
    /// <summary>
    /// Returns array of files in folder
    /// </summary>
    /// <returns>Array of files in folder</returns>
    public abstract Array GetFilesInFolder();
    
    /// <summary>
    /// Returns folder path
    /// </summary>
    /// <returns>Folder path</returns>
    public abstract string GetFolderPath();
}
