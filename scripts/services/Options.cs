// // Furry Potato Options.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved


using Godot;

namespace FurryPotato.Services;

/// <summary>
///     Service for handling game options
/// </summary>
public class Options : Node {
    /// <summary>
    ///     Boolean for checking if game is in fullscreen mode
    /// </summary>
    private bool _fullscreen = true;

    /// <summary>
    ///     Language code
    /// </summary>
    private string _language = "en";

    /// <summary>
    ///     Resolution height
    /// </summary>
    private int _resolutionHeight = 1080;

    /// <summary>
    ///     Resolution width
    /// </summary>
    private int _resolutionWidth = 1920;

    /// <summary>
    ///     Volume
    /// </summary>
    private int _volume = 100;

    /// <summary>
    ///     Method for setting resolution
    ///     @TODO Add resolution validation
    ///     @TODO Add resolution change
    /// </summary>
    /// <param name="width">Width in pixels</param>
    /// <param name="height">Height in pixels</param>
    public void SetResolution(int width, int height) {
        _resolutionHeight = height;
        _resolutionWidth = width;
    }

    /// <summary>
    ///     Sets fullscreen mode
    ///     @TODO Add fullscreen change
    /// </summary>
    /// <param name="fullscreen">Boolean</param>
    public void SetFullscreen(bool fullscreen) {
        _fullscreen = fullscreen;
    }

    /// <summary>
    ///     Sets language
    ///     @TODO Add language change
    /// </summary>
    /// <param name="language">Language code</param>
    public void SetLanguage(string language) {
        _language = language;
    }

    /// <summary>
    ///     Sets volume
    ///     @TODO Add volume change
    /// </summary>
    /// <param name="volume">Volume to set</param>
    public void SetVolume(int volume) {
        _volume = volume;
    }

    /// <summary>
    ///     Method for saving options
    ///     @TODO Save options to file
    /// </summary>
    public void SaveOptions() { }

    /// <summary>
    ///     Method for loading options
    ///     @TODO Load options from file
    /// </summary>
    public void LoadOptions() {
        const int width = 1920;
        const int height = 1080;
        const bool fullscreen = true;
        const string language = "en";
        const int volume = 100;
        SetResolution(width, height);
        SetFullscreen(fullscreen);
        SetLanguage(language);
        SetVolume(volume);
    }
}