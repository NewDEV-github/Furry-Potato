using Godot;
using System;
using Godot.Collections;


/// <summary>
/// Class used to pre-load and format save data
/// </summary>
public class Loader : Node {
    
    /// <summary>
    /// Loads save, then after loading data changes scene to game
    /// </summary>
    /// <param name="saveDir">Save data root directory</param>
    /// <returns>Parsed save data</returns>
    public Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, string>> LoadSave(string saveDir) {
        Console.Write($"Save dir is {saveDir}");
        Dictionary<string, string> newGameControllerData = new Dictionary<string, string>();
        Dictionary<string, string> newOptionControllerData = new Dictionary<string, string>();
        Dictionary<string, string> newShopItemControllerData = new Dictionary<string, string>();
        string[] fileEntriesGameController = System.IO.Directory.GetFiles(saveDir + "\\data\\GameController\\");
        string[] fileEntriesOptionsController = System.IO.Directory.GetFiles(saveDir + "\\data\\OptionController\\");
        string[] fileEntriesShopItemController = System.IO.Directory.GetFiles(saveDir + "\\data\\OptionController\\");

        //TODO: Finish this fucking shit
        foreach (var gControllerData in fileEntriesGameController) {
            string baseName = System.IO.Path.GetFileNameWithoutExtension(gControllerData);
            newGameControllerData.Add(baseName, System.IO.File.ReadAllText(gControllerData));
        }

        foreach (var oControllerData in fileEntriesOptionsController) {
            string baseName = System.IO.Path.GetFileNameWithoutExtension(oControllerData);
            newOptionControllerData.Add(baseName, System.IO.File.ReadAllText(oControllerData));
        }
        
        foreach (var siControllerData in fileEntriesShopItemController) {
            string baseName = System.IO.Path.GetFileNameWithoutExtension(siControllerData);
            newShopItemControllerData.Add(baseName, System.IO.File.ReadAllText(siControllerData));
        }

        Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, string>> returnVar = new Dictionary<string, Dictionary<string, string>>();
        returnVar.Add("GameController", newGameControllerData);
        returnVar.Add("OptionController", newOptionControllerData);
        returnVar.Add("ShopItemController", newShopItemControllerData);

        return returnVar;
    }
}

