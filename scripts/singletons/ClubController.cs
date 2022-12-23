using Godot;
using System;
using Godot.Collections;

/// <summary>
/// This class controls data of in-game Clubs, like e.g. their names and managers
/// </summary>
public class ClubController : Node {
    /// <summary>
    /// Sorted string array of id's of all available in-game clubs
    /// </summary>
    public string[] ClubIds = new string[] {
        "0",
        "1",
        "2",
        "3",
        "4"
    };
    /// <summary>
    /// Sorted dictionary of all data of all available in-game clubs
    /// </summary>
    public readonly Godot.Collections.Dictionary<string, string> ClubData = new Dictionary<string, string>() {
        ["0_name"] = "Spin Masters",
        ["0_manager"] = "Michael",
        ["1_name"] = "The Good Timers",
        ["1_manager"] = "Frank",
        ["2_name"] = "Upper Crusts",
        ["2_manager"] = "Moon",
        ["3_name"] = "PartyCrew",
        ["3_manager"] = "Szlugobal",
        ["4_name"] = "Party at Home",
        ["4_manager"] = "Mr. LadyBoy",
    };
}
