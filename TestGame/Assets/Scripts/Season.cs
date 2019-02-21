using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Season : MonoBehaviour {
    public GameObject[] teams;
    public Text ladder;
    public Text ladderScore;
    public Canvas loadScreen;
    public int round;
    float delay = 0;
    bool delayOn = false;
    public Canvas thisCanvas;
    public Image map;
    public Text opponent;
    public Image[] buttons;
    public Image hiLight;
    int buttonNo = 0;
    public GameObject UnivGameManager;
    public string[] positions;
    public GameObject[,,] matchups;

    bool eliminated;

    int matchWithHuman;
    // Use this for initialization
    void Start()
    {
        UnivGameManager.GetComponent<UniGameManager>().listOfTeams = teams;
        loadScreen.enabled = false;
        UnivGameManager.GetComponent<UniGameManager>().seasonMaxrounds = 10;
        matchups = new GameObject[UnivGameManager.GetComponent<UniGameManager>().seasonMaxrounds + 4,teams.Length, 2];
        round = UnivGameManager.GetComponent<UniGameManager>().seasonRound;;
        positions = new string[teams.Length];
        for (int a = 0; a < teams.Length; a++)
        {
            ladder.text += teams[a].GetComponent<TeamScript>().teamName + "\n";

            ladderScore.text += teams[a].GetComponent<TeamScript>().seasonPoints + "\n";
        }


        if (UnivGameManager.GetComponent<UniGameManager>().seasonRound > UnivGameManager.GetComponent<UniGameManager>().seasonMaxrounds)
        {
            eliminated = true;
            GameObject team1 = teams[0];
            GameObject team2 = teams[1];
            for (int k = 0; k < teams.Length; k++)
            {
               if (teams[k].GetComponent<TeamScript>().seasonPoints > team1.GetComponent<TeamScript>().seasonPoints)
                {
                    team1 = teams[k];
                    team2 = team1;
                    if (team1 == UnivGameManager.GetComponent<UniGameManager>().playerSeasonTeam)
                    {
                        eliminated = false;
                    }
                }
               else if (teams[k].GetComponent<TeamScript>().seasonPoints > team2.GetComponent<TeamScript>().seasonPoints && teams[k].GetComponent<TeamScript>().teamName != team1.GetComponent<TeamScript>().teamName)
                {
                    team2 = teams[k];
                    if (team2 == UnivGameManager.GetComponent<UniGameManager>().playerSeasonTeam)
                    {
                        eliminated = false;
                    }
                }
               
            }
            matchups[UnivGameManager.GetComponent<UniGameManager>().seasonRound, 0, 0] = team1;
            matchups[UnivGameManager.GetComponent<UniGameManager>().seasonRound, 0, 1] = team2;
            UnivGameManager.GetComponent<UniGameManager>().GrandFinal = true;
            opponent.text = "Grand Final : " + matchups[UnivGameManager.GetComponent<UniGameManager>().seasonRound, 0, 0].GetComponent<TeamScript>().teamName + " Vs. " + matchups[UnivGameManager.GetComponent<UniGameManager>().seasonRound, 0, 1].GetComponent<TeamScript>().teamName;
            UnivGameManager.GetComponent<UniGameManager>().LevelLoad = team1.GetComponent<TeamScript>().homeGround;
            UnivGameManager.GetComponent<UniGameManager>().team1 = team1;
            UnivGameManager.GetComponent<UniGameManager>().team2 = team2;
            if (UnivGameManager.GetComponent<UniGameManager>().team2 == UnivGameManager.GetComponent<UniGameManager>().playerSeasonTeam)
            {
                UnivGameManager.GetComponent<UniGameManager>().team1 = team2;
                UnivGameManager.GetComponent<UniGameManager>().team2 = team1;
            }
            if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "MountainRange2")
            {
                map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[0];
            }
            else if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "TownOval")
            {
                map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[2];
            }
            else if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "DeadForest")
            {
                map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[1];
            }
            else if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "MagpiesPark")
            {
                map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[3];
            }
            else if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "Moon")
            {
                map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[5];
            }
        }
        else
        {
            SeasonDrawGenerateManual();
        }
        
        for (int ii = 0; ii < teams.Length / 2; ii++)
        {
            for (int iii = 0; iii < 2; iii++)
            {
                if (UnivGameManager.GetComponent<UniGameManager>().playerSeasonTeam == matchups[round-1, ii, iii])
                {
                    matchWithHuman = ii;
                    switch(iii)
                    {
                        case 0:
                            UnivGameManager.GetComponent<UniGameManager>().team1 = matchups[round-1, ii, 0];
                            UnivGameManager.GetComponent<UniGameManager>().team2 = matchups[round-1, ii, 1];
                            opponent.text = "Round " + round + " Vs. " + matchups[round-1, ii, 1].GetComponent<TeamScript>().teamName;
                            
                            break;
                        case 1:
                            UnivGameManager.GetComponent<UniGameManager>().team1 = matchups[round-1, ii, 1];
                            UnivGameManager.GetComponent<UniGameManager>().team2 = matchups[round-1, ii, 0];
                            opponent.text = "Round " + round + " Vs. " + matchups[round-1, ii, 0].GetComponent<TeamScript>().teamName;
                            break;
                        default:
                            break;
                    }
                    UnivGameManager.GetComponent<UniGameManager>().LevelLoad = matchups[round-1, ii, 0].GetComponent<TeamScript>().homeGround;
                    if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "MountainRange2")
                    {
                        map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[0];
                    }
                    else if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "Stadium")
                    {
                        map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[2];
                    }
                    else if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "DeadForest")
                    {
                        map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[1];
                    }
                    else if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "MagpiesPark")
                    {
                        map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[3];
                    }
                    else if (UnivGameManager.GetComponent<UniGameManager>().LevelLoad == "Moon")
                    {
                        map.material = UnivGameManager.GetComponent<UniGameManager>().levelPics[5];
                    }
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (buttonNo == 0 && !eliminated)
            {
                //Simulate Other Match
                for (int j = 0; j < teams.Length / 2; j++)
                {
                    if (matchWithHuman == j)
                    {

                    }
                    else if (!UnivGameManager.GetComponent<UniGameManager>().GrandFinal)
                    {
                        int score1 = Random.Range(0, 6);
                        int score2 = Random.Range(0, 5);
                        if (score1 > score2)
                        {
                            matchups[round - 1, j, 0].GetComponent<TeamScript>().seasonPoints += 2;
                        }
                        if (score1 < score2)
                        {
                            matchups[round - 1, j, 1].GetComponent<TeamScript>().seasonPoints += 2;
                        }
                        if (score1 == score2)
                        {
                            matchups[round - 1, j, 0].GetComponent<TeamScript>().seasonPoints += 1;
                            matchups[round - 1, j, 1].GetComponent<TeamScript>().seasonPoints += 1;
                        }
                    }
                }




                UnivGameManager.GetComponent<UniGameManager>().seasonModeOn = true;
                UnivGameManager.GetComponent<UniGameManager>().players = 1;
                UnivGameManager.GetComponent<UniGameManager>().aiPlayers = 3;
                loadScreen.enabled = true;
                thisCanvas.enabled = false;
                loadScreen.GetComponent<LoadMap>().started = true;

            }
            if (buttonNo == 1)
            {
                for (int l = 0; l < teams.Length;l++)
                {
                    teams[l].GetComponent<TeamScript>().seasonPoints = 0;         
                }
                UnivGameManager.GetComponent<UniGameManager>().seasonRound = 1;
                UnivGameManager.GetComponent<UniGameManager>().GrandFinal = false;
                SceneManager.LoadScene("SeasonMode");
            }
            if (buttonNo == 2)
            {
                SceneManager.LoadScene("MenuMockUp");
            }
        }
        if (delayOn)
        {
            delay += Time.deltaTime;
            if (delay >= 0.1f)
            {
                delayOn = false;
                delay = 0;
            }
            else
            {
                //return;
            }
        }
        if (Input.GetAxis("Player1MoveY") > 0)
        {
            if (!delayOn)
            {
                buttonNo--;
                delayOn = true;
                if (buttonNo < 0)
                {
                    buttonNo = buttons.Length - 1;
                }
                hiLight.transform.position = buttons[buttonNo].transform.position;
            }
        }
        if (Input.GetAxis("Player1MoveY") < 0)
        {
            if (!delayOn)
            {
                buttonNo++;
                delayOn = true;
                if (buttonNo > buttons.Length - 1)
                {
                    buttonNo = 0;
                }
                hiLight.transform.position = buttons[buttonNo].transform.position;
            }
        }
        if (Input.GetAxis("Player1MoveY") == 0)
        {
            delayOn = false;
            delay = 0;
        }
    }
    void SeasonDrawGenerateManual()
    {
        //Round 1
        //Match 1
        matchups[0, 0, 0] = teams[0];
        matchups[0, 0, 1] = teams[1];
        //Match 2
        matchups[0, 1, 0] = teams[2];
        matchups[0, 1, 1] = teams[3];
        //Match 3
        matchups[0, 2, 0] = teams[4];
        matchups[0, 2, 1] = teams[5];

        //Round 2
        //Match 1
        matchups[1, 0, 0] = teams[1];
        matchups[1, 0, 1] = teams[2];
        //Match 2
        matchups[1, 1, 0] = teams[3];
        matchups[1, 1, 1] = teams[4];
        //Match 3
        matchups[1, 1, 0] = teams[5];
        matchups[1, 1, 1] = teams[0];

        //Round 3
        //Match 1
        matchups[2, 0, 0] = teams[0];
        matchups[2, 0, 1] = teams[4];
        //Match 2
        matchups[2, 1, 0] = teams[1];
        matchups[2, 1, 1] = teams[3];
        //Match 3
        matchups[2, 1, 0] = teams[5];
        matchups[2, 1, 1] = teams[2];

        //Round 4
        //Match 1
        matchups[3, 0, 0] = teams[4];
        matchups[3, 0, 1] = teams[2];
        //Match 2
        matchups[3, 1, 0] = teams[5];
        matchups[3, 1, 1] = teams[1];
        //Match 3
        matchups[3, 1, 0] = teams[3];
        matchups[3, 1, 1] = teams[0];

        //Round 5
        //Match 1
        matchups[4, 0, 0] = teams[4];
        matchups[4, 0, 1] = teams[1];
        //Match 2
        matchups[4, 1, 0] = teams[5];
        matchups[4, 1, 1] = teams[3];
        //Match 3
        matchups[4, 1, 0] = teams[2];
        matchups[4, 1, 1] = teams[0];

        //Round 1
        //Match 1
        matchups[5, 0, 0] = teams[1];
        matchups[5, 0, 1] = teams[0];
        //Match 2
        matchups[5, 1, 0] = teams[3];
        matchups[5, 1, 1] = teams[2];
        //Match 3
        matchups[5, 2, 0] = teams[5];
        matchups[5, 2, 1] = teams[4];

        //Round 2
        //Match 1
        matchups[6, 0, 0] = teams[2];
        matchups[6, 0, 1] = teams[1];
        //Match 2
        matchups[6, 1, 0] = teams[4];
        matchups[6, 1, 1] = teams[3];
        //Match 3
        matchups[6, 1, 0] = teams[0];
        matchups[6, 1, 1] = teams[5];

        //Round 3
        //Match 1
        matchups[7, 0, 0] = teams[4];
        matchups[7, 0, 1] = teams[0];
        //Match 2
        matchups[7, 1, 0] = teams[3];
        matchups[7, 1, 1] = teams[1];
        //Match 3
        matchups[7, 1, 0] = teams[2];
        matchups[7, 1, 1] = teams[5];

        //Round 4
        //Match 1
        matchups[8, 0, 0] = teams[2];
        matchups[8, 0, 1] = teams[4];
        //Match 2
        matchups[8, 1, 0] = teams[1];
        matchups[8, 1, 1] = teams[5];
        //Match 3
        matchups[8, 1, 0] = teams[0];
        matchups[8, 1, 1] = teams[3];

        //Round 5
        //Match 1
        matchups[9, 0, 0] = teams[1];
        matchups[9, 0, 1] = teams[4];
        //Match 2
        matchups[9, 1, 0] = teams[2];
        matchups[9, 1, 1] = teams[5];
        //Match 3
        matchups[9, 1, 0] = teams[0];
        matchups[9, 1, 1] = teams[2];


    }

}


