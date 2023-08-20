using Godot;

namespace FurryPotato.Main;

/// <summary>
/// Class of game's main menu
/// </summary>
public partial class MainMenu : Control {
    public override void _Ready() {
        GD.Print("Ready!");
        GD.Print("Attempting to Test if Core works...");
        var core = GetNode<Core>("/root/Core");
        GD.Print(core.TestCore() ? "Core works!" : "Core is not working!");
    }

    /// <summary>
    /// Method called when "Start new game" button was pressed. Shows popup for new game name and starts a new game
    /// </summary>
    public void OnStartNewGameButtonPressed() {
        GD.Print("Starting new game...");
    }

    /// <summary>
    /// Method called when "Continue game" button was pressed. Continues last played save
    /// </summary>
    public void OnContinueGameButtonPressed() {
        GD.Print("Continuing game...");
    }

    /// <summary>
    /// Method called when "Load game" button was pressed. Shows menu with list of saves to load game from
    /// </summary>
    public void OnLoadGameButtonPressed() {
        GD.Print("Loading game...");
    }

    /// <summary>
    /// Method called when "Options" button was pressed. Shows option menu
    /// </summary>
    public void OnOptionsButtonPressed() {
        GD.Print("Showing options...");
    }

    /// <summary>
    /// Method called when "Exit" button was pressed. Quits the game
    /// </summary>
    public void OnExitButtonPressed() {
        GD.Print("Exiting game...");
        GetTree().Quit();
    }
}