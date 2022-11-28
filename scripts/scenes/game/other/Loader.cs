using Godot;
using System;
using Godot.Collections;

public class Loader : Node
{
    /// <summary>
    /// Loads save, then after loading data changes scene to game
    /// </summary>
    /// <param name="saveDir">Save data root directory</param>

    /** @todo Get all file list in GameController folder and assign their content to value matching appropriate file name */
    /** @todo Make getting base file name work, to use it with setting save data */
    /** @todo Do the same for OptionController */
    public void LoadSave(string saveDir) {
        Dictionary<string, string> newGameControllerData = new Dictionary<string, string>();
        string[] fileEntriesGameController = System.IO.Directory.GetFiles(saveDir + "\\data\\GameController\\");
        string[] fileEntriesOptionsController = System.IO.Directory.GetFiles(saveDir + "\\data\\OptionsController\\");
        
        //TODO: Finish this fucking shit
        foreach (var gControllerData in fileEntriesGameController) {
            string baseName = null; 
            newGameControllerData.Add(baseName, System.IO.File.ReadAllText(saveDir + "\\data\\GameController\\" + gControllerData));
        }
    }
}
