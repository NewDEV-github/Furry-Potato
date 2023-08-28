// // Furry Potato Game.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved

using Godot;
using System;
using FurryPotato.Utils.UI;
using FurryPotato.Utils.UI.DialogueLines.R1S1;


namespace FurryPotato.Game;

	/// <summary>
	///     Main game class
	///     @copyright New DEV
	///     @author DoS
	///     @date 2023-09-28
	/// </summary>
	/// <seealso cref="Control" />
public partial class Game : Control
{
	// Called when the node enters the scene tree for the first time.
	private Dialogue _dialogue;
	public override void _Ready() {
		_dialogue = GetNode<Dialogue>("Dialogue");
		_dialogue.StartDialogue(new R1S1_MAIN());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
