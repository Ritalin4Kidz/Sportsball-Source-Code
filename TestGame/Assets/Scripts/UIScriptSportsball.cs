using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScriptSportsball : MonoBehaviour {
    public GameObject gameManger;
    public Text time;
    public Text score;
    float timePassed;

  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //timePassed += Time.deltaTime;
        //if (timePassed >= 1)
        //{
        //    gameManger.GetComponent<SportsballGameManager>().seconds -= 1;
        //    timePassed -= 1;
        //}
        score.text = gameManger.GetComponent<SportsballGameManager>().team1score + " : " + gameManger.GetComponent<SportsballGameManager>().team2score;
        int minutes;
        int secondsToUse;
        minutes = gameManger.GetComponent<SportsballGameManager>().seconds / 60;
        secondsToUse = gameManger.GetComponent<SportsballGameManager>().seconds - (minutes * 60);
        if (secondsToUse < 10)
        {
            time.text = minutes + ":0" + secondsToUse;
        }
        else
        {
            time.text = minutes + ":" + secondsToUse;
        }
    }


    
}
