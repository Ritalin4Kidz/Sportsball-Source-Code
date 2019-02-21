using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReplayUIScript : MonoBehaviour {
    public GameObject gameManger;
    public Text time;
    public Text score1;
    public Text score2;
    public Text words;
    bool firstAdd = true;
    public Text MVP;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        {
            score1.text = gameManger.GetComponent<SportsballGameManager>().team1score + "";
            score2.text = gameManger.GetComponent<SportsballGameManager>().team2score + "";
            
            int minutes;
            int secondsToUse;
            if (gameManger.GetComponent<SportsballGameManager>().seconds < 0)
            {
                if (firstAdd)
                {
                    if (gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().GetShots() > 0)
                    {
                        int acc1 = (gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().GetAccurateShots() / gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().GetShots()) * 100;
                        gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().mvp += acc1;
                    }
                    if (gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().GetShots() > 0)
                    {
                        int acc2 = (gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().GetAccurateShots() / gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().GetShots()) * 100;
                        gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().mvp += acc2;
                    }
                    if (gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().GetShots() < gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().GetShots())
                    {
                        gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().mvp += 50;
                    }
                    else if (gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().GetShots() > gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().GetShots())
                    {
                        gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().mvp += 50;
                    }
                    else if (gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().GetShots() == gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().GetShots())
                    {
                        gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().mvp += 25;
                        gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().mvp += 25;
                    }
                    firstAdd = false;
                }
                if (gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().mvp > gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().mvp)
                {
                    MVP.text = "Man of the Match : Red Guy | " + gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().mvp + " MVP Points";
                }
                if (gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().mvp < gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().mvp)
                {
                    MVP.text = "Man of the Match : Blue Guy| " + gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().mvp + " MVP Points";
                }
                if (gameManger.GetComponent<SportsballGameManager>().player1.GetComponent<Movement>().mvp == gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().mvp)
                {
                    MVP.text = "Men of the Match : Red/Blue Guy| " + gameManger.GetComponent<SportsballGameManager>().player2.GetComponent<Movement>().mvp + " MVP Points";
                }
                words.text = "FINAL";
                time.text = "0:00" ;
            }
            else
            {
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

    }
}
