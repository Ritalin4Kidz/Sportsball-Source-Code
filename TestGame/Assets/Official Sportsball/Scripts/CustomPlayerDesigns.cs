using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomPlayerDesigns : MonoBehaviour {
    string path;
    string[] Lines = new string[4];
    // Use this for initialization
    void stringToMaterialArray(string a_Line)
    {
        string[] vectorpoints = a_Line.Split(';');
        //Debug.Log(vectorpoints.Length);
        Lines[0] = vectorpoints[0]; //sprite
        //Debug.Log(Lines[0]);
        Lines[1] = vectorpoints[1]; //banner
        Lines[2] = vectorpoints[2]; //splat
        Lines[3] = vectorpoints[3]; //name
    }
    IEnumerator Start()
    {
        //string[] Lines = new string[4];
        if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
        }
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\AddUniforms.txt";
        if (System.IO.File.Exists(path))
        {
            List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(path));
            for (int i = 0; i < fileLines.Capacity; i++)
            {
               // Debug.Log("working");
                stringToMaterialArray(fileLines[i]);

                if (System.IO.File.Exists(Lines[0]))
                {
                    string url = "file:///" + Lines[0];
                    using (WWW www = new WWW(url))
                    {
                        Sprite addSprite;
                        Texture2D tex;
                        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                        yield return www;
                        www.LoadImageIntoTexture(tex);
                        addSprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
                        Sprite[] temp = new Sprite[this.GetComponent<readyCanvasScript>().teamMat.Length + 1];
                        this.GetComponent<readyCanvasScript>().teamMat.CopyTo(temp, 0);
                        this.GetComponent<readyCanvasScript>().teamMat = temp;
                        this.GetComponent<readyCanvasScript>().teamMat[this.GetComponent<readyCanvasScript>().teamMat.Length - 1] = addSprite;
                        Material myNewMaterial = new Material(Shader.Find("Standard"));
                        //Set Texture on the material
                        myNewMaterial.SetTexture("_MainTex", addSprite.texture);
                        Material[] temp2 = new Material[this.GetComponent<readyCanvasScript>().teamcolours.Length + 1];
                        this.GetComponent<readyCanvasScript>().teamcolours.CopyTo(temp2, 0);
                        this.GetComponent<readyCanvasScript>().teamcolours = temp2;
                        this.GetComponent<readyCanvasScript>().teamcolours[this.GetComponent<readyCanvasScript>().teamcolours.Length - 1] = myNewMaterial;

                    }
                }
                if (System.IO.File.Exists(Lines[1]))
                {
                    string url = "file:///" + Lines[1];
                    using (WWW www = new WWW(url))
                    {
                        Sprite addSprite;
                        Texture2D tex;
                        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                        yield return www;
                        www.LoadImageIntoTexture(tex);
                        addSprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
                        Sprite[] temp = new Sprite[this.GetComponent<readyCanvasScript>().banners.Length + 1];
                        this.GetComponent<readyCanvasScript>().banners.CopyTo(temp, 0);
                        this.GetComponent<readyCanvasScript>().banners = temp;
                        this.GetComponent<readyCanvasScript>().banners[this.GetComponent<readyCanvasScript>().banners.Length - 1] = addSprite;
                    }
                }
                else if (System.IO.File.Exists(Lines[0]))
                {
                    string url = "file:///" + Lines[0];
                    using (WWW www = new WWW(url))
                    {
                        Sprite addSprite;
                        Texture2D tex;
                        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                        yield return www;
                        www.LoadImageIntoTexture(tex);
                        addSprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
                        Sprite[] temp = new Sprite[this.GetComponent<readyCanvasScript>().banners.Length + 1];
                        this.GetComponent<readyCanvasScript>().banners.CopyTo(temp, 0);
                        this.GetComponent<readyCanvasScript>().banners = temp;
                        this.GetComponent<readyCanvasScript>().banners[this.GetComponent<readyCanvasScript>().banners.Length - 1] = addSprite;
                    }
                }
                if (System.IO.File.Exists(Lines[2]))
                {
                    string url = "file:///" + Lines[2];
                    using (WWW www = new WWW(url))
                    {
                        Sprite addSprite;
                        Texture2D tex;
                        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                        yield return www;
                        www.LoadImageIntoTexture(tex);
                        addSprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
                        
                        Material myNewMaterial = new Material(Shader.Find("Standard"));
                        //Set Texture on the material
                        myNewMaterial.SetTexture("_MainTex", addSprite.texture);
                        myNewMaterial.shader = Shader.Find("Transparent/Diffuse");
                        Material[] temp2 = new Material[this.GetComponent<readyCanvasScript>().teamSplatcolours.Length + 1];
                        this.GetComponent<readyCanvasScript>().teamSplatcolours.CopyTo(temp2, 0);
                        this.GetComponent<readyCanvasScript>().teamSplatcolours = temp2;
                        this.GetComponent<readyCanvasScript>().teamSplatcolours[this.GetComponent<readyCanvasScript>().teamSplatcolours.Length - 1] = myNewMaterial;

                    }
                }
                else if (System.IO.File.Exists(Lines[0]))
                {
                    string url = "file:///" + Lines[0];
                    using (WWW www = new WWW(url))
                    {
                        Sprite addSprite;
                        Texture2D tex;
                        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                        yield return www;
                        www.LoadImageIntoTexture(tex);
                        addSprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
                        Material myNewMaterial = new Material(Shader.Find("Standard"));
                        //Set Texture on the material
                        myNewMaterial.SetTexture("_MainTex", addSprite.texture);
                        Material[] temp2 = new Material[this.GetComponent<readyCanvasScript>().teamSplatcolours.Length + 1];
                        this.GetComponent<readyCanvasScript>().teamSplatcolours.CopyTo(temp2, 0);
                        this.GetComponent<readyCanvasScript>().teamSplatcolours = temp2;
                        this.GetComponent<readyCanvasScript>().teamSplatcolours[this.GetComponent<readyCanvasScript>().teamSplatcolours.Length - 1] = myNewMaterial;
                    }
                }
                string[] temp3 = new string[this.GetComponent<readyCanvasScript>().teamnames.Length + 1];
                this.GetComponent<readyCanvasScript>().teamnames.CopyTo(temp3, 0);
                this.GetComponent<readyCanvasScript>().teamnames = temp3;
                this.GetComponent<readyCanvasScript>().teamnames[this.GetComponent<readyCanvasScript>().banners.Length - 1] = Lines[3] ;

            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
