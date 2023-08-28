// // Furry Potato Example.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved


using FurryPotato.Utils.UI.Dialogues;

namespace FurryPotato.Utils.UI.Characters;

/// <summary>
///     Example character derived from IDialogueCharacter
///     @copyright New DEV
///     @author DoS
///     @date 2023-09-27
/// </summary>
/// <seealso cref="FurryPotato.Utils.UI.Dialogues.IDialogueCharacter" />
public class Example : IDialogueCharacter {
    /// <summary>
    ///     Name of the character
    /// </summary>
    public string Name { get; set; } = "Jay";
}