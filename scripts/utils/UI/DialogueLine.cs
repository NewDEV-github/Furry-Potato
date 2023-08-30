// // Furry Potato DialogueLine.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved

using Godot.Collections;

namespace FurryPotato.Utils.UI;

/// <summary>
///     Interface for base dialogue line classes
///     @copyright New DEV
///     @author DoS
///     @date 2023-08-27
/// </summary>
public abstract class DialogueLine {
    /// <summary>
    ///     Name of this dialogue line
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    ///     Array of characters in the dialogue line
    /// </summary>
    public abstract Array<string> Characters { get; set; }

    /// <summary>
    ///     Dictionary of lines in the dialogue line. Key is the character name, value is the line.
    /// </summary>
    public abstract Dictionary<string, string> Lines { get; set; }

    /// <summary>
    ///     Choices: Dictionary of choices in the dialogue line. Key is the line after the choice will appear, value is the
    ///     dictionary of choices.
    /// </summary>
    public abstract Dictionary<int, Dictionary<int, string>> Choices { get; set; }
}