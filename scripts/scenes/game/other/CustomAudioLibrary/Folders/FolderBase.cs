using System;


/// <summary>
/// Basic abstract class for folders in <code>CustomAudioLibrary</code>
/// @todo Add extension handling
/// </summary>
public abstract class FolderBase
{
    /// <summary>
    /// Sets filters for extensions for files to look for with
    /// </summary>
    /// <param name="arrayOfExtensions">Array including extensions, eg. <code>["mp3"]</code></param>
    public abstract void SetFileExtensionFilter(System.Array arrayOfExtensions);
    
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
