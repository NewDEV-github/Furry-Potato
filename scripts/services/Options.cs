// // Furry Potato Options.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved


using Godot;

namespace FurryPotato.Services;

/// <summary>
///     Service for handling game options
///     @copyright New DEV
///     @author DoS
///     @date 2023-09-27
/// </summary>
public partial class Options : Control {
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
    /// </summary>
    /// <param name="width">Width in pixels</param>
    /// <param name="height">Height in pixels</param>
    /// @todo Add resolution change
    /// @todo Add resolution validation
    public void SetResolution(int width, int height) {
        _resolutionHeight = height;
        _resolutionWidth = width;
    }

    /// <summary>
    ///     Sets fullscreen mode
    /// </summary>
    /// <param name="fullscreen">Boolean</param>
    /// @todo Add fullscreen change
    public void SetFullscreen(bool fullscreen) {
        _fullscreen = fullscreen;
    }

    /// <summary>
    ///     Sets language
    /// </summary>
    /// <param name="language">Language code</param>
    /// @todo Add language change
    public void SetLanguage(string language) {
        _language = language;
    }

    /// <summary>
    ///     Sets volume
    /// </summary>
    /// <param name="volume">Volume to set</param>
    /// @todo Add volume change
    public void SetVolume(int volume) {
        _volume = volume;
    }

    /// <summary>
    ///     Method for saving options
    /// </summary>
    /// @todo Save options to file
    public void SaveOptions() { }

    /// <summary>
    ///     Method for loading options
    /// </summary>
    /// @todo Load options from file
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