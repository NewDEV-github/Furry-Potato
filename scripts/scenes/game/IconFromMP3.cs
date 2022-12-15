using Godot;
using System.Diagnostics;
using System.Drawing;
using NewDEVSharp.Utils.MP3;
using Image = Godot.Image;

public class IconFromMp3 : TextureRect {
    public override void _Ready() {
        
        string path = @"D:\YouTubeDL\out.mp3";
        LoadImageFromAudio(path);
    }

    /// <summary>
    /// Method used to load image data from MP3 file and display it as an TextureRect's texture.
    /// </summary>
    /// <param name="path">Path to the audio file</param>
    private void LoadImageFromAudio(string path) {
        byte[] d = new DataTags().Image(path).Data.Data;
        ImageTexture t = new ImageTexture();
        Image img = new Image();
        //@todo Fix setting proper image sizes
        System.Drawing.Image ipicturePicture = (Bitmap)((new ImageConverter()).ConvertFrom(d));

        Debug.Assert(ipicturePicture != null, nameof(ipicturePicture) + " != null");
        img.CreateFromData(ipicturePicture.Width, ipicturePicture.Height, false, Image.Format.Max, d);
        t.CreateFromImage(img);
        Texture = t;
    }
}
