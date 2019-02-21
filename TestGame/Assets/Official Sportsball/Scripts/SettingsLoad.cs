using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsLoad : MonoBehaviour {
    public GameObject UniGame;
	// Use this for initialization
	void Start () {
        if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
        }
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\SportsballSettings.txt";
        if (System.IO.File.Exists(path))
        {
            List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(path));
            float.TryParse(fileLines[0], out UniGame.GetComponent<UniGameManager>().songVolume);
            float.TryParse(fileLines[1], out UniGame.GetComponent<UniGameManager>().lookSens);
        }
            string[] contents = new string[3];
            contents[0] = "" + UniGame.GetComponent<UniGameManager>().songVolume;
            contents[1] = "" + UniGame.GetComponent<UniGameManager>().lookSens;
            File.WriteAllLines(path, contents);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
