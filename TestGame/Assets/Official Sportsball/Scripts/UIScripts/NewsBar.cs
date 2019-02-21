using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewsBar : MonoBehaviour {

    string textTosay;
    public GameObject obj;
    // Use this for initialization
    private IEnumerator Start()
    {
        WWW url = new WWW("https://ritalin4kidz.github.io/SportsballServerText.txt");
        yield return url;
        textTosay = "Server Connection Failed";
        if (!string.IsNullOrEmpty(url.error))
        {
            textTosay = "Server Connection Failed";
        }
        else
        {
            string urlText = url.text;
            List<string> textLines = new List<string>(urlText.Split(';'));
            textTosay = textLines[0];
            Debug.Log(textLines[1]);
            if (textLines[1] == obj.GetComponent<MainMenuMock>().CurrentVersion)
            {
                textTosay += " | Current Sportsball Version : " + textLines[1];
            }
            else
            {
                textTosay += " | New Update Available : Visit The Blog For More Info!";
            }
            
        }
        obj.GetComponent<MainMenuMock>().SetTextToSay(textTosay);
    }
}
