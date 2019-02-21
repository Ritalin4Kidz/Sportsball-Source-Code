using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
    public GameObject gameManger;
    public GameObject goalMat;
    public int goalNo;
    // Use this for initialization
    void Start () {
        if (goalNo == 1)
        {
            goalMat.GetComponent<Renderer>().material = gameManger.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().baseTeam1;
        }
        if (goalNo == 2)
        {
            goalMat.GetComponent<Renderer>().material = gameManger.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().baseTeam2;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameManger.GetComponent<sportsballManager>().GetInplay())
            {
                if (goalNo == 1)
                {
                    gameManger.GetComponent<sportsballManager>().AddScore("Team2");
                    gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                    if (other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team2")
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().AddMVPPoints(25);
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().addGoals();
                    }
                    else if (other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().GetTeam() == "Team2")
                    {                                                            
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().AddMVPPoints(25);
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().addGoals();
                    }
                    else if (other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team1")
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().AddMVPPoints(-15);
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().addOwnGoals();
                    }
                    else if (other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team1")
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().AddMVPPoints(-15);
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().addOwnGoals();
                    }
                }
                if (goalNo == 2)
                {
                    gameManger.GetComponent<sportsballManager>().AddScore("Team1");
                    gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                    if (other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team1")
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().AddMVPPoints(25);
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().addGoals();
                    }
                    else if (other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().GetTeam() == "Team1")
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().AddMVPPoints(25);
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().addGoals();
                    }
                    else if (other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team2")
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().AddMVPPoints(-15);
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().addOwnGoals();
                    }
                    else if (other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team2")
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().AddMVPPoints(-15);
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().addOwnGoals();
                    }
                    if (gameManger.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().achievements[0] == false)
                    {
                        gameManger.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().achievements[0] = true;
                    }
                }
                for (int i = 0; i < gameManger.GetComponent<sportsballManager>().playerAmt; i++)
                {
                    if (other.GetComponent<BallScript>().lastPlayer == gameManger.GetComponent<sportsballManager>().getPlayer(i))
                    {
                        if (gameManger.GetComponent<sportsballManager>().getspecCamera() != null)
                            gameManger.GetComponent<sportsballManager>().getspecCamera().GetComponent<Spectator>().goalBanner(i);
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
