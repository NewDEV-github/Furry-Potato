// // Furry Potato Email.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved

using System;
using FurryPotato.Services;
using Godot;

namespace FurryPotato.Main;

/// <summary>
///     Class of game's main menu
///     @copyright New DEV
///     @author DoS
///     @date 2023-08-27
/// </summary>
public partial class MainMenu : Control {
    /// <summary>
    ///     New game creator popup
    /// </summary>
    private NewGameCreator _newGameCreator;

    /// <summary>
    ///     Options panel
    /// </summary>
    /// <seealso cref="FurryPotato.Services.Options" />
    private Options _options;

    /// <summary>
    ///     Loads data and prepares Main Menu
    /// </summary>
    /// <seealso cref="FurryPotato.Core" />
    /// <seealso cref="System.DateTime" />
    public override void _Ready() {
        _newGameCreator = GetNode<NewGameCreator>("NewGameCreator");
        _newGameCreator.Hide();
        _options = GetNode<Options>("OptionsPopup");
        _options.Hide();
        GD.Print("Ready!");
        GD.Print("Attempting to Test if Core works...");
        var core = GetNode<Core>("/root/Core");
        GD.Print(core.TestCore() ? "Core works!" : "Core is not working!");

        var about = GetNode<Label>("About");
        about.Text = "Furry Potato, version: " + core.GetVersion() + "\n" +
                     "Copyright (c) " + DateTime.Now.Year + " New DEV, All rights reserved.";
    }

    /// <summary>
    ///     Method called when "Start new game" button was pressed. Shows popup for new game name and starts a new game
    /// </summary>
    public void OnStartNewGameButtonPressed() {
        _newGameCreator.PopupCentered();
    }

    /// <summary>
    ///     Method called when "Continue game" button was pressed. Continues last played save
    /// </summary>
    /// @todo Add ability to continue last played save
    public void OnContinueGameButtonPressed() {
        GD.Print("Continuing game...");
    }

    /// <summary>
    ///     Method called when "Load game" button was pressed. Shows menu with list of saves to load game from
    /// </summary>
    /// @todo Add ability to load game from save
    public void OnLoadGameButtonPressed() {
        GD.Print("Loading game...");
    }

    /// <summary>
    ///     Method called when "Options" button was pressed. Shows option menu
    /// </summary>
    /// <seealso cref="FurryPotato.Services.Options" />
    public void OnOptionsButtonPressed() {
        _newGameCreator.Hide();
        _options.Show();
    }

    /// <summary>
    ///     Method called when "Exit" button was pressed. Quits the game
    /// </summary>
    /// @bug It really, really works 🥺
    public void OnExitButtonPressed() {
        GD.Print("Exiting game...");
        GetTree().Quit();
    }
}