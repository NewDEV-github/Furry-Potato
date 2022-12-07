using Godot;
using NewDEVSharp;
using JetBrains.Annotations;
/// <summary>
/// Game Core in C#, used for doing C# things in core, that can't be done in Godot at game core
/// </summary>
public class CSharpCore : Node
{
    /// <summary>
    /// NewDEV.Core instance
    /// </summary>
    protected Core CoreInstance = new Core();
}
