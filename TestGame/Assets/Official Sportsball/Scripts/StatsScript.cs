using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StatsScript : MonoBehaviour {
    public Text[] playerTexts;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < playerTexts.Length; i++)
        {
            if (playerTexts[i].text == "New Text")
            {
                playerTexts[i].text = "";
            }
        }
    }
	public void setPlayerText(int no, string textStr)
    {
        playerTexts[no].text = textStr;
    }
    public void addPlayerText(int no, string textStr)
    {
        playerTexts[no].text += textStr;
    }
    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("ReadyScreen");
        }
	}
}
