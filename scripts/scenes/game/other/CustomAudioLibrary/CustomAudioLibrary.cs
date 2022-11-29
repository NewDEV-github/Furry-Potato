using System;
using Godot;
using Godot.Collections;

/// <summary>
/// Class used to manage all actions related to playing music from user's PC
/// </summary>
/// @todo Load file list and send it via array to Godot code
public class CustomAudioLibrary : AudioStreamPlayer {
    // List of folders
    private readonly FolderBase _systemMusic = new FolderSystemMusic();
    
    /// <summary>
    /// Dictionary of folders to look for music files
    /// </summary>
    private Dictionary<string, FolderBase> _folderList = new Dictionary<string, FolderBase>();

    /// <summary>
    /// Called to initialize folder list
    /// </summary>
    void InitFolderList() {
        _folderList.Add("SystemMusic", _systemMusic);
    }
    
    public override void _Ready() {
        InitFolderList();
    }

    /// <summary>
    /// Loads for ust list of files that will be returned to godot in order to shuffle them
    /// </summary>
    /// <returns>Array of file paths</returns>
    /// @todo Getting file path and inserting it into array to return
    public string[] LoadSongFiles() {
        string[] returnFiles = new string[] { };
        foreach (var folder in _folderList) {
            Console.WriteLine($"Searching for music in {folder.Value.GetFolderPath()}");
        }
        return returnFiles;
    }
}
