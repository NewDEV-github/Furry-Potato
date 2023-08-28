// // Furry Potato Line1.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved


using Godot.Collections;

namespace FurryPotato.Utils.UI.DialogueLines;

/// <summary>
///     Example dialogue line
///     @copyright New DEV
///     @author DoS
///     @date 2023-09-28
/// </summary>
/// <seealso cref="DialogueLine" />
public class Line1 : DialogueLine {
    /// <summary>
    ///     Name of this dialogue line
    /// </summary>
    public override string Name { get; set; } = "Line1";

    /// <summary>
    ///     Array of characters in the dialogue line
    /// </summary>
    public override Array<string> Characters { get; set; } = new() { "Jay", "Jay", "Jay" };

    /// <summary>
    ///     Dictionary of lines in the dialogue line. Key is the character name, value is the line.
    /// </summary>
    public override Dictionary<string, string> Lines { get; set; } = new() {
        { "Jay", "Hello!" },
        { "Jay", "How are you?" },
        { "CHOICE", "CHOICE" }
    };

    /// <summary>
    ///     Choices: Dictionary of choices in the dialogue line. Key is the line after the choice will appear, value is the
    ///     dictionary of choices.
    /// </summary>
    public override Dictionary<int, Dictionary<int, string>> Choices { get; set; } = new() {
        {
            0, new Dictionary<int, string> {
                { 0, "Good!" },
                { 1, "Bad!" }
            }
        }
    };
}