using Godot;

namespace FurryPotato;

/// <summary>
/// Core game class
/// </summary>

public partial class Core : Node {
    /// <summary>
    /// This method tests Core class as a singleton. Only for testing purposes
    /// </summary>
    /// <returns>bool</returns>
    /// <example>
    /// <code>
    /// var _core = GetNode("/root/Core");
    /// GD.Print(_core.TestCore() ? "Core works!" : "Core is not working!");
    /// </code>
    /// </example>
    public bool TestCore() {
        return true;
    }
}