using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalZone : MonoBehaviour
{
    public GameObject gameManger;
    public GameObject goalMat;
    public int goalNo;

    public int scoretoadd;

    public bool euroOn;

    public bool conversionOn;
    // Use this for initialization
    void Start()
    {
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
        if (other.CompareTag("ConversionBall"))
        {
            //if (gameManger.GetComponent<sportsballManager>().GetInplay())
            {
                if (goalNo == 1)
                {
                    gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", 2);
                    gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                }
                else if (goalNo == 2)
                {
                    gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", 2);
                    gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                }
            }
            Destroy(other.transform.parent.gameObject);
        }
        if (other.CompareTag("Ball") && !euroOn)
        {
            if (gameManger.GetComponent<sportsballManager>().GetInplay())
            {
                if (goalNo == 1)
                {
                    gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", scoretoadd);
                    gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                    gameManger.GetComponent<sportsballManager>().SetInplay(false);
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
                }
                if (goalNo == 2)
                {
                    gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", scoretoadd);
                    gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                    gameManger.GetComponent<sportsballManager>().SetInplay(false);
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
                //gameManger.GetComponent<sportsballManager>().startReplay();
            }
        }
        else if (other.CompareTag("Player") && euroOn)
        {
            if (gameManger.GetComponent<sportsballManager>().GetInplay())
            {
                if (goalNo == 1)
                {
                    if (other.GetComponent<PlayerScript>())
                    {
                        if (other.GetComponent<PlayerScript>().GetTeam() == "Team2")
                        {
                            if (other.GetComponent<PlayerScript>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == other.gameObject)
                            {
                                gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", scoretoadd);
                                gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                                gameManger.GetComponent<sportsballManager>().SetConversion(conversionOn);
                                for (int i = 0; i < gameManger.GetComponent<sportsballManager>().playerAmt; i++)
                                {
                                    if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>())
                                    {
                                        if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetTeam() == "Team2")
                                        {
                                            gameManger.GetComponent<sportsballManager>().setAxis(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetXLookaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetXaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetYLookaxis());
                                            gameManger.GetComponent<sportsballManager>().setShoot(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getShootKey());
                                            break;
                                        }
                                    }
                                }
                                gameManger.GetComponent<sportsballManager>().SetBallPosition(new Vector3(other.transform.position.x, 1.5f, this.transform.position.z));
                                //gameManger.GetComponent<sportsballManager>().startReplay();
                                if (other.GetComponent<PlayerScript>() && other.GetComponent<PlayerScript>().GetTeam() == "Team2")
                                {
                                    other.GetComponent<PlayerScript>().AddMVPPoints(25);
                                    other.GetComponent<PlayerScript>().addGoals();                            
                                }
                                else if (other.GetComponent<AI>() && other.GetComponent<AI>().GetTeam() == "Team2")
                                {
                                    other.GetComponent<AI>().AddMVPPoints(25);
                                    other.GetComponent<AI>().addGoals();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (other.GetComponent<AI>().GetTeam() == "Team2")
                        {
                            if (other.GetComponent<AI>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == other.gameObject)
                            {
                                gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", scoretoadd);
                                gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                                //gameManger.GetComponent<sportsballManager>().startReplay();
                                if (other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team2")
                                {
                                    other.GetComponent<PlayerScript>().AddMVPPoints(25);
                                    other.GetComponent<PlayerScript>().addGoals();
                                }
                                else if (other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>() && other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().GetTeam() == "Team2")
                                {
                                    other.GetComponent<AI>().AddMVPPoints(25);
                                    other.GetComponent<AI>().addGoals();
                                }
                            }
                        }
                    }
                }
                else if (goalNo == 2)
                {
                    if (other.GetComponent<PlayerScript>())
                    {
                        if (other.GetComponent<PlayerScript>().GetTeam() == "Team1")
                        {
                            if (other.GetComponent<PlayerScript>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == other.gameObject)
                            {
                                gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", scoretoadd);
                                gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                                gameManger.GetComponent<sportsballManager>().SetConversion(conversionOn);
                                gameManger.GetComponent<sportsballManager>().SetBallPosition(new Vector3(other.transform.position.x, 1.5f, this.transform.position.z));
                                for (int i = 0; i < gameManger.GetComponent<sportsballManager>().playerAmt; i++)
                                {
                                    if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>())
                                    {
                                        if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetTeam() == "Team1")
                                        {
                                            gameManger.GetComponent<sportsballManager>().setAxis(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetXLookaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetXaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetYLookaxis());
                                            gameManger.GetComponent<sportsballManager>().setShoot(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getShootKey());
                                            break;
                                        }
                                    }
                                }
                                // gameManger.GetComponent<sportsballManager>().startReplay();
                                if (other.GetComponent<PlayerScript>() && other.GetComponent<PlayerScript>().GetTeam() == "Team1")
                                {
                                    other.GetComponent<PlayerScript>().AddMVPPoints(25);
                                    other.GetComponent<PlayerScript>().addGoals();
                                }
                                else if (other.GetComponent<AI>() && other.GetComponent<AI>().GetTeam() == "Team1")
                                {
                                    other.GetComponent<AI>().AddMVPPoints(25);
                                    other.GetComponent<AI>().addGoals();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (other.GetComponent<AI>().GetTeam() == "Team1")
                        {
                            if (other.GetComponent<AI>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == other.gameObject)
                            {
                                gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", scoretoadd);
                                gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                                //gameManger.GetComponent<sportsballManager>().startReplay();
                                if (other.GetComponent<PlayerScript>() && other.GetComponent<PlayerScript>().GetTeam() == "Team1")
                                {
                                    other.GetComponent<PlayerScript>().AddMVPPoints(25);
                                    other.GetComponent<PlayerScript>().addGoals();
                                }
                                else if (other.GetComponent<AI>() && other.GetComponent<AI>().GetTeam() == "Team1")
                                {
                                    other.GetComponent<AI>().AddMVPPoints(25);
                                    other.GetComponent<AI>().addGoals();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && euroOn)
        {
            if (gameManger.GetComponent<sportsballManager>().GetInplay())
            {


                if (goalNo == 1)
                {
                    if (other.GetComponent<PlayerScript>())
                    {
                        if (other.GetComponent<PlayerScript>().GetTeam() == "Team2")
                        {
                            if (other.GetComponent<PlayerScript>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == other.gameObject)
                            {
                                gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", scoretoadd);
                                gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                                gameManger.GetComponent<sportsballManager>().SetConversion(conversionOn);
                                for (int i = 0; i < gameManger.GetComponent<sportsballManager>().playerAmt; i++)
                                {
                                    if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>())
                                    {
                                        if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetTeam() == "Team2")
                                        {
                                            gameManger.GetComponent<sportsballManager>().setAxis(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetXLookaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetXaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetYLookaxis());
                                            gameManger.GetComponent<sportsballManager>().setShoot(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getShootKey());
                                            break;
                                        }
                                    }
                                }
                                gameManger.GetComponent<sportsballManager>().SetBallPosition(new Vector3(other.transform.position.x, 1.5f, this.transform.position.z));
                                gameManger.GetComponent<sportsballManager>().KillFeedSend(other.GetComponent<PlayerScript>().getPlayerName() + " !");
                                //gameManger.GetComponent<sportsballManager>().startReplay();
                                if (other.GetComponent<PlayerScript>() && other.GetComponent<PlayerScript>().GetTeam() == "Team2")
                                {
                                    other.GetComponent<PlayerScript>().AddMVPPoints(25);
                                    other.GetComponent<PlayerScript>().addGoals();
                                    
                                }
                                else if (other.GetComponent<AI>() && other.GetComponent<AI>().GetTeam() == "Team2")
                                {
                                    other.GetComponent<AI>().AddMVPPoints(25);
                                    other.GetComponent<AI>().addGoals();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (other.GetComponent<AI>().GetTeam() == "Team2")
                        {
                            if (other.GetComponent<AI>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == other.gameObject)
                            {
                                gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", scoretoadd);
                                gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                                gameManger.GetComponent<sportsballManager>().KillFeedSend(other.GetComponent<AI>().getPlayerName() + " !");
                                //gameManger.GetComponent<sportsballManager>().startReplay();
                                if (other.GetComponent<PlayerScript>() && other.GetComponent<PlayerScript>().GetTeam() == "Team2")
                                {
                                    other.GetComponent<PlayerScript>().AddMVPPoints(25);
                                    other.GetComponent<PlayerScript>().addGoals();
                                }
                                else if (other.GetComponent<AI>() && other.GetComponent<AI>().GetTeam() == "Team2")
                                {
                                    other.GetComponent<AI>().AddMVPPoints(25);
                                    other.GetComponent<AI>().addGoals();
                                }
                            }
                        }
                    }
                }
                else if (goalNo == 2)
                {
                    if (other.GetComponent<PlayerScript>())
                    {
                        if (other.GetComponent<PlayerScript>().GetTeam() == "Team1")
                        {
                            if (other.GetComponent<PlayerScript>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == other.gameObject)
                            {
                                gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", scoretoadd);
                                gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                                gameManger.GetComponent<sportsballManager>().SetConversion(conversionOn);
                                for (int i = 0; i < gameManger.GetComponent<sportsballManager>().playerAmt; i++)
                                {
                                    if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>())
                                    {
                                        if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetTeam() == "Team1")
                                        {
                                            gameManger.GetComponent<sportsballManager>().setAxis(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetXLookaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetXaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetYLookaxis());
                                            gameManger.GetComponent<sportsballManager>().setShoot(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getShootKey());
                                            break;
                                        }
                                    }
                                }
                                gameManger.GetComponent<sportsballManager>().SetBallPosition(new Vector3(other.transform.position.x, 1.5f, this.transform.position.z));
                                gameManger.GetComponent<sportsballManager>().KillFeedSend(other.GetComponent<PlayerScript>().getPlayerName() + " !");
                                //gameManger.GetComponent<sportsballManager>().startReplay();
                                if (other.GetComponent<PlayerScript>() && other.GetComponent<PlayerScript>().GetTeam() == "Team1")
                                {
                                    other.GetComponent<PlayerScript>().AddMVPPoints(25);
                                    other.GetComponent<PlayerScript>().addGoals();
                                }
                                else if (other.GetComponent<AI>() && other.GetComponent<AI>().GetTeam() == "Team1")
                                {
                                    other.GetComponent<AI>().AddMVPPoints(25);
                                    other.GetComponent<AI>().addGoals();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (other.GetComponent<AI>().GetTeam() == "Team1")
                        {
                            if (other.GetComponent<AI>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == other.gameObject)
                            {
                                gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", scoretoadd);
                                gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                                gameManger.GetComponent<sportsballManager>().KillFeedSend(other.GetComponent<AI>().getPlayerName() + " !");
                                //gameManger.GetComponent<sportsballManager>().startReplay();
                                if (other.GetComponent<PlayerScript>() && other.GetComponent<PlayerScript>().GetTeam() == "Team1")
                                {
                                    other.GetComponent<PlayerScript>().AddMVPPoints(25);
                                    other.GetComponent<PlayerScript>().addGoals();
                                }
                                else if (other.GetComponent<AI>() && other.GetComponent<AI>().GetTeam() == "Team1")
                                {
                                    other.GetComponent<AI>().AddMVPPoints(25);
                                    other.GetComponent<AI>().addGoals();
                                }
                            }
                        }
                    }
                }
            }
        }
        if (other.CompareTag("Ball") && euroOn)
        {
            if (gameManger.GetComponent<sportsballManager>().GetInplay())
            {
                if (goalNo == 1)
                {
                    for (int i = 0; i < gameManger.GetComponent<sportsballManager>().playerAmt; i++)
                    {
                        if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>())
                        {
                            if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetTeam() == "Team2")
                            {
                                if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().getPlayer(i).gameObject == other.GetComponent<BallScript>().playerHolding)
                                {
                                    gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", scoretoadd);
                                    gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                                    gameManger.GetComponent<sportsballManager>().SetConversion(conversionOn);
                                    for (int ii = 0; ii < gameManger.GetComponent<sportsballManager>().playerAmt; ii++)
                                    {
                                        if (gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>())
                                        {
                                            if (gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().GetTeam() == "Team2")
                                            {
                                                gameManger.GetComponent<sportsballManager>().setAxis(gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().GetXLookaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().GetXaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().GetYLookaxis());
                                                gameManger.GetComponent<sportsballManager>().setShoot(gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().getShootKey());
                                                break;
                                            }
                                        }
                                    }
                                    gameManger.GetComponent<sportsballManager>().SetBallPosition(new Vector3(other.transform.position.x, 1.5f, this.transform.position.z));
                                    gameManger.GetComponent<sportsballManager>().KillFeedSend(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getPlayerName() + " !");
                                    //gameManger.GetComponent<sportsballManager>().startReplay();
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
                                }
                            }
                        }
                        else
                        {
                            if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().GetTeam() == "Team2")
                            {
                                if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().getPlayer(i).gameObject == other.GetComponent<BallScript>().playerHolding)
                                {
                                    gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", scoretoadd);
                                    gameManger.GetComponent<sportsballManager>().addBanner("Team 2");
                                    gameManger.GetComponent<sportsballManager>().KillFeedSend(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().getPlayerName() + " !");
                                    //gameManger.GetComponent<sportsballManager>().startReplay();
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
                                }
                            }
                        }
                    }
                }

                else if (goalNo == 2)
                {
                    for (int i = 0; i < gameManger.GetComponent<sportsballManager>().playerAmt; i++)
                    {
                        if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>())
                        {
                            if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetTeam() == "Team1")
                            {
                                if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().getPlayer(i).gameObject == other.GetComponent<BallScript>().playerHolding)
                                {
                                    gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", scoretoadd);
                                    gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                                    gameManger.GetComponent<sportsballManager>().SetConversion(conversionOn);
                                    for (int ii = 0; ii < gameManger.GetComponent<sportsballManager>().playerAmt; ii++)
                                    {
                                        if (gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>())
                                        {
                                            if (gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().GetTeam() == "Team1")
                                            {
                                                gameManger.GetComponent<sportsballManager>().setAxis(gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().GetXLookaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().GetXaxis(), gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().GetYLookaxis());
                                                gameManger.GetComponent<sportsballManager>().setShoot(gameManger.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<PlayerScript>().getShootKey());
                                                break;
                                            }
                                        }
                                    }
                                    gameManger.GetComponent<sportsballManager>().SetBallPosition(new Vector3(other.transform.position.x, 1.5f, this.transform.position.z));
                                    gameManger.GetComponent<sportsballManager>().KillFeedSend(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().getPlayerName() + " !");
                                    //gameManger.GetComponent<sportsballManager>().startReplay();
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
                                }
                            }
                        }
                        else
                        {
                            if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().GetTeam() == "Team1")
                            {
                                if (gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().canScoreEuro == true || gameManger.GetComponent<sportsballManager>().getPlayer(i).gameObject == other.GetComponent<BallScript>().playerHolding)
                                {
                                    gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", scoretoadd);
                                    gameManger.GetComponent<sportsballManager>().addBanner("Team 1");
                                    gameManger.GetComponent<sportsballManager>().KillFeedSend(gameManger.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().getPlayerName() + " !");
                                    //gameManger.GetComponent<sportsballManager>().startReplay();
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
                                }
                            }
                        }
                    }
                }
            }



        }
    }
}

