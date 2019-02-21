using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TexturePackApply : MonoBehaviour {
    public bool colorNormalize;
    public Image profileImg;
    string path;
    public int lineNo;
    IEnumerator Start()
    {
        if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
        }
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\TexturePack.txt";
        if (System.IO.File.Exists(path))
        {
            List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(path));
            if (lineNo < fileLines.Capacity && System.IO.File.Exists(fileLines[lineNo]))
            {

                Texture2D tex;
                tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                using (WWW www = new WWW(fileLines[lineNo]))
                {
                    yield return www;
                    www.LoadImageIntoTexture(tex);
                    
                    profileImg.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
                    if (colorNormalize)
                    {
                        profileImg.color = Color.white;
                    }
                    
                }
            }
        }
    }
}
