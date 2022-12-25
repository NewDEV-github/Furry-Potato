using System.Runtime.Remoting;
using Godot;
using NewDEVSharp;
using NewDEVSharp.User;
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

    protected Auth Auth = new Auth();

    public override void _Ready() {
        Auth.ClassInit();
        Auth.Login("test", "test");
    }
}
