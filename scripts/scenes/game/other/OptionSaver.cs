using System;
using System.Globalization;
using Godot;
using Godot.Collections;
using NewDEVSharp.Collections;
using File = System.IO.File;

/// <summary>
///     Class used to save and load game options
/// </summary>
public class OptionSaver : Node {
        /// <summary>
        ///     NewDEVSharp.Collections.DictionaryConverter instance
        /// </summary>
        private readonly DictionaryConverter _dc = new DictionaryConverter();

        /// <summary>
        ///     SaveContainer instance
        /// </summary>
        private readonly SaveContainer _saveContainer = new SaveContainer();

        /// <summary>
        ///     String and string-dictionary dictionary that holds preloaded option data.
        ///     <para>If the PreloadOptions method haven't been called yet, this dictionary is null</para>
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> PreloadedOptionSaveData =
        new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        ///     Method tor saving options
        /// </summary>
        /// <param name="data">Dictionary of options data to dave</param>
        public void SaveOptions(Dictionary<string, Dictionary<string, string>> data) {
        var dir = OS.GetUserDataDir() + "/OptionSave/";
        _saveContainer.SetSaveDir(dir);
        _saveContainer.WriteDirectories(data);
        File.WriteAllText(dir + "\\SaveName.dat", "OptionSave");
        File.WriteAllText(dir + "\\data\\ModificationDate.dat", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        foreach (var d in data) _saveContainer.WriteData($"\\data\\{d.Key}", _dc.GodotToSystem(d.Value));
    }

        /// <summary>
        ///     Method that we use to preload option data
        ///     <para>It fills out PreloadedOptionSaveData variable with found save data and emits OptionSaveDataPreload signal.</para>
        /// </summary>
        public void PreloadOptions() {
        var loader = new Loader();
        var path = OS.GetUserDataDir() + "/OptionSave/";
        PreloadedOptionSaveData = loader.LoadSave(path);
        EmitSignal("OptionSaveDataPreloaded");
    }

        /// <summary>
        ///     Signal emitted, when save options have been preloaded.
        ///     <para>Use PreloadedOptionSaveData to access them.</para>
        /// </summary>
        [Signal]
    private delegate void OptionSaveDataPreloaded();
}