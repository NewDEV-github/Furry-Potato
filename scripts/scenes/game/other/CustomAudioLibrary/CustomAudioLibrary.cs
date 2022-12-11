using System;
using System.Linq;
using Godot;
using Godot.Collections;

/// <summary>
/// Class used to manage all actions related to playing music from user's PC
/// </summary>
public class CustomAudioLibrary : AudioStreamPlayer {
    // List of folders
    private readonly FolderBase _systemMusic = new FolderSystemMusic();
    private readonly FolderBase _systemDocuments = new FolderSystemDocuments();
    
    /// <summary>
    /// Dictionary of folders to look for music files
    /// </summary>
    private readonly Dictionary<string, string> _folderList = new Dictionary<string, string>();

    /// <summary>
    /// Called to initialize folder list
    /// </summary>
    void InitFolderList() {
        _folderList.Add("SystemMusic", "_systemMusic");
        _folderList.Add("SystemDocuments", "_systemDocuments");

    }
    
    public override void _Ready() {
        InitFolderList();
    }

    /// <summary>
    /// Loads for ust list of files that will be returned to godot in order to shuffle them
    /// </summary>
    /// <returns>Array of file paths</returns>
    public string[] LoadSongFiles() {
        string[] returnFiles = new string[] { };
        foreach (var folder in _folderList) {
            FolderBase inst = null;
            if (folder.Value == "_systemMusic") {
                inst = new FolderSystemMusic();
            } else if (folder.Value == "_systemDocuments") {
                inst = new FolderSystemDocuments();
            }

            if (inst != null) {
                Console.WriteLine($"Searching for music in {inst.GetFolderPath()}");

                if (System.IO.Directory.Exists(inst.GetFolderPath())) {
                    string[] fileEntries = System.IO.Directory.GetFiles(inst.GetFolderPath());
                    foreach (string fileName in fileEntries) {
                        if (System.IO.Path.GetExtension(fileName) == ".mp3" || System.IO.Path.GetExtension(fileName) == ".ogg") {
                            returnFiles = returnFiles.Concat(new string[] { fileName }).ToArray();
                            Console.WriteLine($"Found {fileName}");
                        }
                    }
                } else {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(inst.GetFolderPath()) ??
                                                        throw new InvalidOperationException());
                }
            }
        }
        return returnFiles;
    }
}
