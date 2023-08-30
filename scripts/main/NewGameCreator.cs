// // Furry Potato Dialogues.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved

using System.Linq;
using Godot;

namespace FurryPotato.Main;

/// <summary>
///     Popup panel for creating new game
///     @copyright New DEV
///     @author DoS
///     @date 2023-08-30
/// </summary>
public partial class NewGameCreator : PopupPanel {
    /// <summary>
    ///     LineEdit of the character name
    /// </summary>
    private LineEdit _characterName;

    /// <summary>
    ///     Label to display naming errors
    /// </summary>
    private Label _errorLabel;

    /// <summary>
    ///     LineEdit of the save name
    /// </summary>
    private LineEdit _saveName;

    /// <summary>
    ///     Initializes class
    /// </summary>
    public override void _Ready() {
        _errorLabel = GetNode<Label>("Control/Container/ErrorLabel");
        _saveName = GetNode<LineEdit>("Control/Container/SaveName");
        _characterName = GetNode<LineEdit>("Control/Container/CharacterName");
    }

    /// <summary>
    ///     Executed by the "Go!" button
    /// </summary>
    public void OnGoButtonPressed() {
        var errorText = "";
        if (_saveName.Text == "") {
            errorText += "Save name is too short!\n";
        }
        else {
            if (!ValidateInput(_saveName.Text)) errorText += "Save name contains invalid characters!\n";
        }


        if (_characterName.Text == "") {
            errorText += "Character name is too short!\n";
        }
        else {
            if (!ValidateInput(_characterName.Text)) errorText += "Character name contains invalid characters!\n";
        }

        _errorLabel.Text = errorText;

        if (errorText == "") GetTree().ChangeSceneToFile("res://scenes/game/game.tscn");
    }

    /// <summary>
    ///     Executed by the "Cancel" button
    /// </summary>
    public void OnCancelButtonPressed() {
        Hide();
    }

    /// <summary>
    ///     Method that validates input
    /// </summary>
    /// <param name="text">Text to be checked</param>
    /// <returns>Boolean</returns>
    private static bool ValidateInput(string text) {
        return text.All(char.IsLetterOrDigit);
    }
}