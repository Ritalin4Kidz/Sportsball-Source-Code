using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AudioScriptAddSongs : MonoBehaviour {
    string path;

    string line1;
    string line2;
    string line3;
    string line4;
    void stringToSongArray(string a_Line)
    {
        string[] vectorpoints = a_Line.Split(';');
        //Debug.Log(vectorpoints.Length);
        line1 = vectorpoints[0];
        //Debug.Log(line1);
        line2 = vectorpoints[1];
        line3 = vectorpoints[2];
        line4 = vectorpoints[3];
    }
    // Use this for initialization

    IEnumerator Start()
    {
        if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
        }
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\AddedSongs.txt";
        if (System.IO.File.Exists(path))
        {
            List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(path));
            for (int i = 0; i < fileLines.Capacity; i++)
            {
                stringToSongArray(fileLines[i]);
                if (System.IO.File.Exists(line1))
                {
                    string url = "file:///" + line1;
                    using (WWW www = new WWW(url))
                    {
                        yield return www;
                        AudioClip Song = www.GetAudioClip();
                        AudioClip[] temp = new AudioClip[this.GetComponent<MyAudioScript>().songs.Length + 1];
                        this.GetComponent<MyAudioScript>().songs.CopyTo(temp, 0);
                        this.GetComponent<MyAudioScript>().songs = temp;
                        this.GetComponent<MyAudioScript>().songs[this.GetComponent<MyAudioScript>().songs.Length - 1] = Song;
                    }
                    string[] temp2 = new string[this.GetComponent<MyAudioScript>().songNames.Length + 1];
                    this.GetComponent<MyAudioScript>().songNames.CopyTo(temp2, 0);
                    this.GetComponent<MyAudioScript>().songNames = temp2;
                    this.GetComponent<MyAudioScript>().songNames[this.GetComponent<MyAudioScript>().songs.Length - 1] = line2;
                    string[] temp3 = new string[this.GetComponent<MyAudioScript>().artistNames.Length + 1];
                    this.GetComponent<MyAudioScript>().artistNames.CopyTo(temp3, 0);
                    this.GetComponent<MyAudioScript>().artistNames = temp3;
                    this.GetComponent<MyAudioScript>().artistNames[this.GetComponent<MyAudioScript>().songs.Length - 1] = line3;
                    string[] temp4 = new string[this.GetComponent<MyAudioScript>().details.Length + 1];
                    this.GetComponent<MyAudioScript>().details.CopyTo(temp4, 0);
                    this.GetComponent<MyAudioScript>().details = temp4;
                    this.GetComponent<MyAudioScript>().details[this.GetComponent<MyAudioScript>().songs.Length - 1] = line4;
                }
            }
        }
    }

   
}
