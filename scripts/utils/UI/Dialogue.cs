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
public partial class Dialogue : Control {

    /// <summary>
    /// Signal emitted when dialogue ends
    /// </summary>
    [Signal]
    public delegate void DialogueEndedEventHandler(string dialogueName);

    /// <summary>
    /// Signal emitted when dialogue starts
    /// </summary>
    [Signal]
    public delegate void DialogueStartedEventHandler();

    /// <summary>
    /// Signal emitted when player presses enter or space
    /// </summary>
    [Signal]
    public delegate void EnterPressedEventHandler();

    /// <summary>
    ///     Array of all available characters
    /// </summary>
    private readonly IEnumerable<IDialogueCharacter> _characters = Array.Empty<IDialogueCharacter>();

    /// <summary>
    ///     Index of current line
    /// </summary>
    private int _currentLineIndex;

    /// <summary>
    ///     Rich text array that displays the text
    /// </summary>
    private RichTextLabel _dialogueText;

    /// <summary>
    /// Panel for choices
    /// </summary>
    private PopupPanel _choicesPanel;

    /// <summary>
    /// Container for choices
    /// </summary>
    private ItemList _choicesContainer;

    /// <summary>
    /// Current dialogue line
    /// </summary>
    private DialogueLine _currentDialogueLine;

    /// <summary>
    ///     Method called when the node enters the scene tree for the first time.
    /// </summary>
    /// @todo Add dialogues from their classes to _lines array
    public override void _Ready() {
        Hide();
        _dialogueText = GetNode<RichTextLabel>("Text");
        _choicesPanel = GetNode<PopupPanel>("ChoicesPanel");
        _choicesContainer = GetNode<ItemList>("ChoicesPanel/ChoicesContainer");
        _choicesPanel.Hide();
    }


    /// <summary>
    ///     Handles pressing keys on the dialogue
    /// </summary>
    /// <param name="event">InputEvent instance</param>
    public override void _Input(InputEvent @event) {
        if (@event.IsActionPressed("ui_accept") && _dialogueText.Visible)
            EmitSignal(nameof(EnterPressed));
    }

    /// <summary>
    ///     Checks if dialogue can be played and if so, plays it
    /// </summary>
    /// <param name="dialogueLine">Name of the dialogue</param>
    /// @todo Handle dialogue playing
    public void StartDialogue(DialogueLine dialogueLine) {
        _currentDialogueLine = dialogueLine;
        Show();
        EmitSignal(nameof(DialogueStarted));
         DisplayLineByLine(dialogueLine);
    }

    /// <summary>
    ///     This method handles player's choice and starts another part of dialogue based on the choice
    /// </summary>
    /// <param name="choice">Choice name/id</param>
    /// @todo Handle choices
    public void HandleChoice(int choice) {
        if (_currentDialogueLine.Name == "R1S1_MAIN") {
            EndDialogue();
        }
    }

    /// <summary>
    ///     Method that display choices on the screen after current line
    /// </summary>
    /// <param name="dialogueLine">Dialogue to get the choices from</param>
    /// <param name="currentLine">Current line of the dialogue</param>
    /// @todo Handle choice displaying
    private void ShowChoicesAfterCurrentLine(DialogueLine dialogueLine, int currentLine) {
        var choices = dialogueLine.Choices;
        foreach (var choice in choices) {
            foreach (var choiceName in choice.Value) {
                _choicesContainer.AddItem(choiceName.Value);
            }
        }
        _choicesPanel.PopupCentered();
        _dialogueText.Hide();
    }

    /// <summary>
    ///     Method used to display one dialogue line
    /// </summary>
    /// <param name="dialogueLine">Dialogue to get lines from</param>
    private async void DisplayLineByLine(DialogueLine dialogueLine) {
        var lines = dialogueLine.Lines;
        var currentLineNumber = 0;
        foreach (var line in lines) {
            _dialogueText.Show();
            string characterName = "";
            if (dialogueLine.Characters.Count == 1) {
                characterName = dialogueLine.Characters[0];
            }
            else {
                var lineId = line.Key;
                characterName = lineId != "CHOICE" ? dialogueLine.Characters[lineId.ToInt()] : "CHOICE";
                characterName = lineId != "END" ? dialogueLine.Characters[lineId.ToInt()] : "END";
            }
            var text = line.Value;
            currentLineNumber++;
            if (characterName == "CHOICE" || text == "CHOICE")
                ShowChoicesAfterCurrentLine(dialogueLine, currentLineNumber);
            else
                _dialogueText.Text = characterName + ": " + text;
            await ToSignal(this, "EnterPressed");
            if (characterName == "END" || text == "END") {
                EndDialogue();
            }
        }
    }

    /// <summary>
    ///     Ends dialogue
    /// </summary>
    /// @todo Handle ending dialogue
    public void EndDialogue() {
        Hide();
        EmitSignal(nameof(DialogueEnded), _currentDialogueLine.Name);
        _currentDialogueLine = null;
    }
}