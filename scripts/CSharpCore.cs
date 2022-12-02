using Godot;
using NewDEVSharp;

/// <summary>
/// Game Core in C#, used for doing C# things in core, that can't be done in Godot at game core
/// </summary>
public class CSharpCore : Node
{
    /// <summary>
    /// NewDEV.Core instance
    /// </summary>
    Core _newDEVCore = new Core();
}
