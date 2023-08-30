// // Furry Potato Game.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved

using FurryPotato.Utils.UI;
using FurryPotato.Utils.UI.DialogueLines.R1S1;
using Godot;

namespace FurryPotato.Game;

/// <summary>
///     Main game class
///     @copyright New DEV
///     @author DoS
///     @date 2023-08-28
/// </summary>
/// <seealso cref="Control" />
public partial class Game : Control {
    // Called when the node enters the scene tree for the first time.
    private Dialogue _dialogue;

    /// <summary>
    ///     Setups the game
    /// </summary>
    public override void _Ready() {
        _dialogue = GetNode<Dialogue>("Dialogue");
        _dialogue.Show();
        _dialogue.StartDialogue(new R1S1_MAIN());
    }
}