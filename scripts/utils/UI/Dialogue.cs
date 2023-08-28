// // Furry Potato Dialogues.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved


using System;
using System.Collections.Generic;
using System.Linq;
using FurryPotato.Utils.UI.Dialogues;
using Godot;

namespace FurryPotato.Utils.UI;

/// <summary>
///     Class for handling dialogues
///     @copyright New DEV
///     @author DoS
///     @date 2023-09-27
/// </summary>
/// @todo Create dialogue's UI
/// @todo Handle dialogue lines
/// @todo Handle characters
/// @todo Handle character validation
/// @attention This is still under development and might be unstable. There might be a lot of work with that
public partial class Dialogue : Node {
    /// <summary>
    ///     Array of all available characters
    /// </summary>
    private readonly IEnumerable<IDialogueCharacter> _characters = Array.Empty<IDialogueCharacter>();

    /// <summary>
    ///     Index of current line
    /// </summary>
    private int _currentLineIndex;

    /// <summary>
    ///     Array of dialogues that are currently active
    /// </summary>
    private readonly IEnumerable<DialogueLine> _lines = Array.Empty<DialogueLine>();

    /// <summary>
    ///     Method called when the node enters the scene tree for the first time.
    /// </summary>
    /// @todo Add dialogues from their classes to _lines array
    public override void _Ready() { }

    /// <summary>
    ///     Checks if dialogue can be played and if so, plays it
    /// </summary>
    /// <param name="dialogueLine">Name of the dialogue</param>
    /// <exception cref="NotImplementedException">Exception thrown when invalid value is passed</exception>
    /// @todo Handle dialogue playing
    public void StartDialogue(DialogueLine dialogueLine) {
        if (_lines.Contains(dialogueLine)) {
            IEnumerable<IDialogueCharacter> charactersInDialogue = Array.Empty<IDialogueCharacter>();
            charactersInDialogue = dialogueLine.Characters
                .Aggregate(charactersInDialogue,
                    (current1, character) => _characters.Where(character2 => character2.Name == character)
                        .Aggregate(current1, (current, character2) => current.Append(character2)));
            DisplayLineByLine(dialogueLine, charactersInDialogue);
        }
        else {
            throw new NotImplementedException("Dialogue with name " + dialogueLine.Name + " does not exist!");
        }
    }

    /// <summary>
    ///     This method handles player's choice and continues dialogue
    /// </summary>
    /// <param name="dialogueLine">Dialogue line</param>
    /// <param name="choice">Choice name/id</param>
    /// @todo Handle choices
    public void HandleChoice(DialogueLine dialogueLine, string choice) {
        var choices =
            dialogueLine.Choices;
    }

    /// <summary>
    ///     Method that display choices on the screen after current line
    /// </summary>
    /// <param name="dialogueLine">Dialogue to get the choices from</param>
    /// <param name="currentLine">Current line of the dialogue</param>
    /// @todo Handle choice displaying
    public void ShowChoicesAfterCurrentLine(DialogueLine dialogueLine, int currentLine) {
        var choices = dialogueLine.Choices[currentLine];
    }

    /// <summary>
    ///     Method used to display one dialogue line
    /// </summary>
    /// <param name="dialogueLine">Dialogue to get lines from</param>
    /// <param name="charsInDialogue">List of characters in dialogue</param>
    public void DisplayLineByLine(DialogueLine dialogueLine, IEnumerable<IDialogueCharacter> charsInDialogue) {
        var lines = dialogueLine.Lines;
        var currentLineNumber = 0;
        foreach (var line in lines) {
            var characterName = line.Key;
            IDialogueCharacter character;
            foreach (var c in charsInDialogue)
                if (c.Name == characterName)
                    character = c;
            var text = line.Value;
            currentLineNumber++;
            if (characterName == "CHOICE" && text == "CHOICE")
                ShowChoicesAfterCurrentLine(dialogueLine, currentLineNumber);
        }
    }

    /// <summary>
    ///     Ends dialogue
    /// </summary>
    /// @todo Handle ending dialogue
    public void EndDialogue() { }
}