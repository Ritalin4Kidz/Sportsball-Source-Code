using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReplayScript2 : MonoBehaviour {

    public GameObject gameManger;
    public Text time;
    public Text score1;
    public Text score2;
    public Text words;
    bool firstAdd = true;
    public Text MVP;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            score1.text = gameManger.GetComponent<sportsballManager>().getTeam1Score() + "";
            score2.text = gameManger.GetComponent<sportsballManager>().getTeam2Score() + "";

            int minutes;
            int secondsToUse;
            if (gameManger.GetComponent<sportsballManager>().getSeconds() < 0)
            {
                if (firstAdd)
                {
                    int tempMVP = 0;
                    for (int i = 0; i < gameManger.GetComponent<sportsballManager>().playerAmt; i++ )
                    {
                        if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>() && gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getShots() > 0)
                        {
                        int acc1 = (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getAccurateShots() / gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getShots()) * 100;
                        gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().AddMVPPoints(acc1);
                        
                        }
                        if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>() && gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetMVPPoints() > tempMVP)
                        {
                            tempMVP = gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetMVPPoints();
                            MVP.text = "Man of the Match : Player " + (i + 1) + " | " + gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetMVPPoints() + " Points";
                        }
                        else if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>() && gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().GetMVPPoints() > tempMVP)
                        {
                            tempMVP = gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().GetMVPPoints();
                            MVP.text = "Man of the Match : Player " + (i + 1) + " | " + gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().GetMVPPoints() + " Points";
                        }
                    }
                    
                    firstAdd = false;
                }
                words.text = "FINAL";
                time.text = "0:00";
            }
            else
            {

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

    }
}
