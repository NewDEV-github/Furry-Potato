using Godot;
using System;
using System.Threading;

/// <summary>
/// Class for asynchronous scene loading
/// </summary>
public class BackgroundLoader : Node
{
    /// <summary>
    /// Self instance
    /// </summary>
    public static BackgroundLoader Instance = null;
    
    /// <summary>
    /// Resource instance
    /// </summary>
    Resource _res;
    
    /// <summary>
    /// Contains boolean  to let us know whether we can change scene or not, if scene won't be changed automatically after it's preloading.
    /// </summary>
    public bool CanChange = false;
    
    /// <summary>
    /// Thread system instance
    /// </summary>
    System.Threading.Thread _thread;
    
    /// <summary>
    /// New scene
    /// </summary>
    Node _newScene;
    
    /// <summary>
    /// Path of scene that is being preloading
    /// </summary>
    string _scenePath = "";

    public override void _Ready()
    {
        Instance = this;
    }
    
    /// <summary>
    /// This method loads scene using threading
    /// </summary>
    private void ThreadLoad() {
        ResourceInteractiveLoader ril = ResourceLoader.LoadInteractive(_scenePath);
        int total = ril.GetStageCount();
        Instance._res = null;
        while(true) {
            Error err = ril.Poll();
            if (err == Error.FileEof) {
                Instance._res = ril.GetResource();
                Instance.CanChange = true;
                break;
            } else if (err != Error.Ok) {
                GD.Print("ERROR LOADING");
                break;
            }

        }
    }

    /// <summary>
    /// Used to clear stuff and reset all variables to their default values
    /// </summary>
    private void ClearStuff() {
        _thread = null;
        _newScene = null;
        _scenePath = "";
        CanChange = false;
        _res = null;
    }
    
    /// <summary>
    /// Called when threading is finished and changes scene finally
    /// </summary>
    /// <param name="packedScene">Packed scene</param>
    private async void ThreadDone(PackedScene packedScene) {
        while (_thread.IsAlive) {
            GD.Print("Thread is alive!");
            await ToSignal(GetTree().CreateTimer(1,false),"timeout");
        }
        _newScene = packedScene.Instance();
        GetTree().CurrentScene.Free();
        GetTree().CurrentScene = null;
        GetTree().Root.AddChild(_newScene);
        GetTree().CurrentScene = _newScene;
        ClearStuff();
        
    }
    
    /// <summary>
    /// Loads new scene using threading
    /// </summary>
    /// <param name="path">Path to scene file</param>
    public void PreloadScene(string path) {
        GD.Print("Calling new Scene");
        _scenePath = path;
        CanChange = false;
        _thread = new System.Threading.Thread(new ThreadStart(ThreadLoad));
        _thread.Start();
        Raise();
    }
    
    /// <summary>
    /// If it hasn't been done automatically, this method can change scene to preloaded one
    /// </summary>
    public void ChangeSceneToPreloaded() {
        CallDeferred(nameof(ThreadDone), _res);
    }


    


}