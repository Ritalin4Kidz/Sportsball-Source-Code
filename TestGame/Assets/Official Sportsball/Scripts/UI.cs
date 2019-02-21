using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {
    public GameObject gameManger;
    public Text time;
    public Text score;
    float timePassed;

    public Text killfeedref;
    public Text[] killFeedPos;
    Text[] killfeed;
    // Use this for initialization
    void Start()
    {
        killfeed = new Text[killFeedPos.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //timePassed += Time.deltaTime;
        //if (timePassed >= 1)
        //{
        //    gameManger.GetComponent<SportsballGameManager>().seconds -= 1;
        //    timePassed -= 1;
        //}
        
        if (gameManger.GetComponent<sportsballManager>().overtime)
        {
            score.text = gameManger.GetComponent<sportsballManager>().getTeam1Score() + " : " + gameManger.GetComponent<sportsballManager>().getTeam2Score();
            time.text = "OVERTIME";
        }
        else
        {
            score.text = gameManger.GetComponent<sportsballManager>().getTeam1Score() + " : " + gameManger.GetComponent<sportsballManager>().getTeam2Score();
            int minutes;
            int secondsToUse;
            minutes = gameManger.GetComponent<sportsballManager>().getSeconds() / 60;
            secondsToUse = gameManger.GetComponent<sportsballManager>().getSeconds() - (minutes * 60);
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
    public void KillFeed(string textToWrite)
    {
        int i = 0;
        while (killfeed[i] != null && i < killfeed.Length - 1)
        {
            i++;
        }
        if (i == killfeed.Length - 1 && killfeed[i] != null)
        {
            for (int ii = 0; ii < killfeed.Length - 1; ii++)
            {
                killfeed[ii].text = killfeed[ii + 1].text;
                killfeed[ii].GetComponent<killFeedTimer>().setTime(killfeed[ii + 1].GetComponent<killFeedTimer>().getTime());
            }
            killfeed[killfeed.Length - 1].text = null;
            killfeed[killfeed.Length - 1] = null;
        }
        killfeed[i] = Instantiate(killfeedref); 
        killfeed[i].transform.SetParent(this.transform,false);
        killfeed[i].transform.position = killFeedPos[i].transform.position;
        killfeed[i].text = textToWrite;
    }
}
