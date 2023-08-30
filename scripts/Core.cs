// // Furry Potato Email.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved


using Godot;

namespace FurryPotato;

/// <summary>
///     Core game class
///     @copyright New DEV
///     @author DoS
///     @date 2023-08-27
/// </summary>
public partial class Core : Node {
    private string _version = "0.0.1";

    /// <summary>
    ///     This method tests Core class as a singleton. Only for testing purposes
    /// </summary>
    /// <returns>bool</returns>
    /// <example>
    ///     <code>
    /// var _core = GetNode("/root/Core");
    /// GD.Print(_core.TestCore() ? "Core works!" : "Core is not working!");
    /// </code>
    /// </example>
    /// @todo Add more tests
    /// @bug While logging into New DEV account, game crashes. Related to SSL certificate
    /// @note User should be logged in ASAP, after the game starts
    public bool TestCore() {
        return true;
    }

    /// <summary>
    ///     Returns game version
    /// </summary>
    /// <returns>Game version</returns>
    public string GetVersion() {
        return _version;
    }
}