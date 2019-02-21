using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class sportsballManager : MonoBehaviour {
    //TODO : Convert old manager script into here
    int teamScore1;
    int teamScore2;
    public int playerAmt;
    GameObject[] players;
    public GameObject universalGameManager;
    public GameObject playerRef;
    public GameObject aiRef;
    public GameObject[] m_playerSpawnsTeam1;
    public GameObject[] m_playerSpawnsTeam2;

    public Material team1colour;
    public Material team1coloursplat;
    public Material team2colour;
    public Material team2coloursplat;

    bool conversion;
    public GameObject conversionRef;
    Vector3 ballPosition;
    public GameObject network;
    public bool isPaintball;
    bool roundEnd;
    //Old Manager
    float tempTime = 0;
    int seconds;
    bool paused;
    bool inplay;
    public bool replay = false;

    public bool overtime = false;

    public bool boundaryRule = false;
    public Vector3 ballRespawn;

    public GameObject ball;
    public GameObject bomb;

    public GameObject[] deadZonearray;
    int deadzoneNo;

    bool bombIsON;
    public Camera IntroCam;

    public Camera[] playerCams;
    public Camera replayCamera;
    public Camera winCam;

    public Camera specRef;

    Camera spec;

    public Canvas replayUI;
    public Canvas regularUI;
    public Canvas winRoundUIRef;
    public Canvas msgPopUpRef;

    public GameObject[] vents;
    public Canvas statsRef;
    Canvas stats;
    Canvas msgPop;
    Canvas wonRound;
    Vector3[,] replaylocs;
    Vector3[,] replayRot;
    int replayFrame = 0;
    int FrameSave = 0;
    float timePassed;

    float timeReplayBuffer;
    int maxRounds;
    int swapRound;
    float timeTillFrame;
    int team1playercount = 0;
    int team2playercount = 0;

    string axisXLook;
    string axisYLook;
    string axisXMove;

    KeyCode shoot;

    public bool isTugOfWar;
    public GameObject TugOfWarGoal1;
    public GameObject TugOfWarGoal2;

    public void setAxis(string axisX1, string axisX2, string axisY)
    {
        axisXLook = axisX1;
        axisXMove = axisX2;
        axisYLook = axisY;
    }
    public int getFrameSave()
    {
        return FrameSave;

    }
    public void setBomb(bool a_BombOn)
    {
        bombIsON = a_BombOn;
    }
    public bool getBomb()
    {
        return bombIsON;
    }
    public void SetBallPosition(Vector3 pos)
    {
        ballPosition = pos;
    }

    public Camera getspecCamera()
    {
        return spec;
    }
    public void setShoot(KeyCode a_shoot)
    {
        shoot = a_shoot;
    }
    public void setRoundEnd(bool a_bool)
    {
        roundEnd = a_bool;
    }
    public bool getRoundEnd()
    {
        return roundEnd;
    }
    public void popUpUI(string teamBanner, string textWrite)
    {
        inplay = false;
        wonRound = Instantiate(winRoundUIRef);
        wonRound.GetComponent<RoundWinCanvas>().sportsballMan = this.gameObject;
        if (teamBanner == "Team1")
        {
            wonRound.GetComponent<RoundWinCanvas>().banner.sprite = universalGameManager.GetComponent<UniGameManager>().banner1;
        }
        else if (teamBanner == "Team2")
        {
            wonRound.GetComponent<RoundWinCanvas>().banner.sprite = universalGameManager.GetComponent<UniGameManager>().banner2;
        }
        wonRound.GetComponent<RoundWinCanvas>().winText.text = textWrite;
        wonRound.GetComponent<RoundWinCanvas>().setReplay(true);
        wonRound.GetComponent<RoundWinCanvas>().setAliveTime(3);
    }
    public void generateAIProfile(int playerNo)
    {
        int numberGen = Random.Range(0, 30);
        switch (numberGen)
        {
            case 0:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Ali");
                break;
            case 1:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Kelin");
                break;
            case 2:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Callum");
                break;
            case 3:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Jackson");
                break;
            case 4:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Ran");
                break;
            case 5:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Andrew");
                break;
            case 6:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Joseph");
                break;
            case 7:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Seth");
                break;
            case 8:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Igor");
                break;
            case 9:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Matt");
                break;
            case 10:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Daniel");
                break;
            case 11:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Ben");
                break;
            case 12:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Cameron");
                break;
            case 13:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Luke");
                break;
            case 14:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Tom");
                break;
            case 15:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout";
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Mike");
                break;
            case 16:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular";
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Connor");
                break;
            case 17:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner";
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Sam");
                break;
            case 18:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout";
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Peter");
                break;
            case 19:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular";
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Kyle");
                break;
            case 20:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Ashton");
                break;
            case 21:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Arnold");
                break;
            case 22:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Herman");
                break;
            case 23:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot John");
                break;
            case 24:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Psychic"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Eric");
                break;
            case 25:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Regular"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Brett");
                break;
            case 26:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Brendan");
                break;
            case 27:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Will");
                break;
            case 28:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Psychic"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Alex");
                break;
            case 29:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Gunner"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot David");
                break;
            default:
                universalGameManager.GetComponent<UniGameManager>().playerType[playerNo] = "Scout"; ;
                players[playerNo].GetComponent<AI>().setPlayerName("Bot Simon");
                break;

        }
    }
    public string teamplayersText(string team)
    {
            string textToReturn = "Team List : \n";
            for (int iii = 0; iii < players.Length;iii++ )
            {
                if (universalGameManager.GetComponent<UniGameManager>().playerTeams[iii] == team)
                {
                    if (players[iii].GetComponent<PlayerScript>())
                    {
                        textToReturn += players[iii].GetComponent<PlayerScript>().getPlayerName() + "\n";
                    }
                    if (players[iii].GetComponent<AI>())
                    {
                        textToReturn += players[iii].GetComponent<AI>().getPlayerName() + "\n";
                    }
                }
            }
        return textToReturn;
    }
    public void ResetRound()
    {
        if (teamScore1 + teamScore2 == swapRound)
        {
            swapSides();
        }
        for (int i = 0; i < vents.Length; i++)
        {
            vents[i].GetComponent<ReplenishableVent>().fixVent();
        }
        deadzoneNo = 0;
        for (int ii = 0; ii < playerAmt; ii++)
        {
            if (players[ii].GetComponent<PlayerScript>())
            {
                players[ii].GetComponent<PlayerScript>().active = true;
                players[ii].transform.position = players[ii].GetComponent<PlayerScript>().m_SpawnLoc.transform.position;
            }
            else if (players[ii].GetComponent<AI>())
            {
                players[ii].GetComponent<AI>().active = true;
                players[ii].transform.position = players[ii].GetComponent<AI>().m_SpawnLoc.transform.position;
            }

        }
        for (int iii = 0; iii < playerAmt; iii++)
        {
            if (players[iii].GetComponent<PlayerScript>())
            {
                players[iii].GetComponent<PlayerScript>().face.GetComponent<FaceUIScript>().alphaVar = 0;
            }
        }
        for (int i = 0; i < playerAmt; i++)
        {
            if (players[i].GetComponent<PlayerScript>())
            {
                if (players[i].GetComponent<PlayerScript>().getHoldingBomb())
                {
                    players[i].GetComponent<PlayerScript>().setHoldingBomb(false, bomb);
                }
            }
        }
        bombIsON = false;
        bomb.transform.parent = null;
        bomb.transform.position = bomb.GetComponent<BombScript>().spawnLoc;
        bomb.transform.eulerAngles = Vector3.zero;
        bomb.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bomb.GetComponent<BombScript>().canBePickedUp = true;
        bomb.GetComponent<Rigidbody>().isKinematic = false;
        seconds = universalGameManager.GetComponent<UniGameManager>().gameTime;
        IntroCam.GetComponent<IntroCamera>().playCamera(4, Vector3.zero);
    }
    //public Canvas pauseScreen;
    // Use this for initialization
    public void swapSides()
    {
        msgPop = Instantiate(msgPopUpRef);
        msgPop.GetComponent<PopUpText>().SetString("Switch Sides");
        if (bomb.GetComponent<BombScript>().teamPickup == "Team1")
        {
            bomb.GetComponent<BombScript>().teamPickup = "Team2";
        }
        else
        {
            bomb.GetComponent<BombScript>().teamPickup = "Team1";
        }
        GameObject temp;
        temp = new GameObject();
        temp.transform.position = m_playerSpawnsTeam1[0].transform.position;
        m_playerSpawnsTeam1[0].transform.position = m_playerSpawnsTeam2[0].transform.position;
        m_playerSpawnsTeam2[0].transform.position = temp.transform.position;
        temp.transform.position = m_playerSpawnsTeam1[1].transform.position;
        m_playerSpawnsTeam1[1].transform.position = m_playerSpawnsTeam2[1].transform.position;
        m_playerSpawnsTeam2[1].transform.position = temp.transform.position;
        Destroy(temp);
    }
    public void sendToDead(GameObject playerToSend)
    {
        playerToSend.transform.position = deadZonearray[deadzoneNo].transform.position;
        deadzoneNo++;
    }

    //PLAYER VARIABLES
    public void setName(int playerNo, string a_name)
    {
        if (getPlayer(playerNo) != null)
        {
            if (getPlayer(playerNo).GetComponent<PlayerScript>())
            {
                getPlayer(playerNo).GetComponent<PlayerScript>().setPlayerName(a_name);
            }
            else
            {
                getPlayer(playerNo).GetComponent<AI>().setPlayerName(a_name);
            }
        }
    }
    public void setSens(int playerNo, float sens)
    {
        if (getPlayer(playerNo) != null)
        {
            if (getPlayer(playerNo).GetComponent<PlayerScript>())
            {
                getPlayer(playerNo).GetComponent<PlayerScript>().setLookSensitivity(sens);
            }
        }
    }
    public void setCrosshairColour(int playerNo, Color a_color)
    {
        if (getPlayer(playerNo) != null)
        {
            if (getPlayer(playerNo).GetComponent<PlayerScript>())
            {
                getPlayer(playerNo).GetComponent<PlayerScript>().Crosshair.color = a_color;
            }
        }
    }
    public Color getCrosshairColour(int playerNo)
    {
        if (getPlayer(playerNo) != null)
        {
            if (getPlayer(playerNo).GetComponent<PlayerScript>())
            {
                return getPlayer(playerNo).GetComponent<PlayerScript>().Crosshair.color;
            }
        }
        return Color.grey;
    }
    public void setCrosshairStyle(int playerNo, Sprite a_sprite)
    {
        if (getPlayer(playerNo) != null)
        {
            if (getPlayer(playerNo).GetComponent<PlayerScript>())
            {
                getPlayer(playerNo).GetComponent<PlayerScript>().Crosshair.sprite = a_sprite;
            }
        }
    }
    public void setCrosshairStyle(int playerNo)
    {
        if (getPlayer(playerNo) != null)
        {
            if (getPlayer(playerNo).GetComponent<PlayerScript>())
            {
                getPlayer(playerNo).GetComponent<PlayerScript>().Crosshair.sprite = null;
            }
        }
    }
    public void setCrosshairSize(int playerNo, float value)
    {
        if (getPlayer(playerNo) != null)
        {
            if (getPlayer(playerNo).GetComponent<PlayerScript>())
            {
                getPlayer(playerNo).GetComponent<PlayerScript>().Crosshair.rectTransform.localScale = new Vector3(value,value, getPlayer(playerNo).GetComponent<PlayerScript>().Crosshair.rectTransform.localScale.z);
            }
        }
    }

    public void SetConversion(bool a_bool)
    {
        conversion = a_bool;
    }

    void Start() {
        {
            if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
            {           
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
            }
            if (universalGameManager.GetComponent<UniGameManager>().consoleInGame)
            {
                Instantiate(universalGameManager);
            }
            maxRounds = 16;
            swapRound = 8;
            conversion = false;
            //Mutators With Effect Applied In Start
            Physics.gravity = new Vector3(0, -9.81f, 0);
            Time.timeScale = 1.0f;
            switch (universalGameManager.GetComponent<UniGameManager>().MutatorRule)
            {
                case "Low Gravity":
                    Physics.gravity = new Vector3(0, -3f, 0);
                    break;
                case "Sugar Rush":
                    Time.timeScale = 2.0f;
                    break;
                case "Come Down":
                    Time.timeScale = 0.5f;
                    break;
                default:
                    break;
            }

            //pauseScreen.enabled = false;
            RenderSettings.skybox = universalGameManager.GetComponent<UniGameManager>().skybox;
            for (int i = 0; i < 4; i++)
            {
                if (universalGameManager.GetComponent<UniGameManager>().playerTeams[i] == "Team1")
                {
                    team1playercount++;
                    if (team1playercount > 2)
                    {
                        universalGameManager.GetComponent<UniGameManager>().playerTeams[i] = null;
                        team1playercount = 2;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (universalGameManager.GetComponent<UniGameManager>().playerTeams[i] == null)
                {
                    if (team1playercount < 2)
                    {
                        universalGameManager.GetComponent<UniGameManager>().playerTeams[i] = "Team1";
                        team1playercount++;
                    }
                    else
                    {
                        universalGameManager.GetComponent<UniGameManager>().playerTeams[i] = "Team2";

                    }
                }
            }

            if (universalGameManager.GetComponent<UniGameManager>().spectating)
            {
                spec = Instantiate(specRef);
                spec.GetComponent<Spectator>().gameMan = this.gameObject;
            }
            replayUI.enabled = false;
            replayCamera.enabled = false;
            winCam.enabled = false;
            playerAmt = universalGameManager.GetComponent<UniGameManager>().players + universalGameManager.GetComponent<UniGameManager>().aiPlayers;
            inplay = true;
            seconds = universalGameManager.GetComponent<UniGameManager>().gameTime;
            players = new GameObject[playerAmt];
            playerCams = new Camera[playerAmt];
            replaylocs = new Vector3[playerAmt + 1, 999];
            replayRot = new Vector3[playerAmt + 1, 999];
            int team1spawns = 0;
            int team2spawns = 0;
            float x = 0;
            float y = 0;

            for (int i = 0; i < playerAmt; i++)
            {
                if (universalGameManager.GetComponent<UniGameManager>().players >= 2)
                {
                    y = 0.5f;
                }
                if (universalGameManager.GetComponent<UniGameManager>().players >= 3)
                {
                    x = 0.5f;
                }
                if (universalGameManager.GetComponent<UniGameManager>().playerTeams[i] == "Team1")
                {
                    if (universalGameManager.GetComponent<UniGameManager>().playerReady[i])
                    {
                        players[i] = Instantiate(playerRef, m_playerSpawnsTeam1[team1spawns].transform.position, Quaternion.identity);
                        players[i].GetComponent<Renderer>().material = universalGameManager.GetComponent<UniGameManager>().baseTeam1;
                        players[i].GetComponent<PlayerScript>().m_SpawnLoc = m_playerSpawnsTeam1[team1spawns];
                        if (!isPaintball)
                        {
                            players[i].transform.LookAt(ball.transform);
                        }
                        players[i].GetComponent<PlayerScript>().SetManager(this.gameObject);
                        players[i].GetComponent<PlayerScript>().setPaintSplat(universalGameManager.GetComponent<UniGameManager>().basesplatTeam1);
                        players[i].GetComponent<PlayerScript>().SetTeam("Team1");
                        players[i].GetComponent<PlayerScript>().setPitch(players[i].transform.eulerAngles.x);
                        players[i].GetComponent<PlayerScript>().setYaw(players[i].transform.eulerAngles.y);
                        players[i].GetComponent<PlayerScript>().setPlayerName("Player " + (i + 1));
                        players[i].GetComponent<PlayerScript>().setLookSensitivity(universalGameManager.GetComponent<UniGameManager>().lookSens);
                        if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Regular")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(5);
                            players[i].GetComponent<PlayerScript>().setGunForce(75);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.025f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.01f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.2f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Bomb");
                            players[i].GetComponent<PlayerScript>().setCooldown(5);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Scout")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(7);
                            players[i].GetComponent<PlayerScript>().setGunForce(125);
                            players[i].GetComponent<PlayerScript>().setFireRate(1.5f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.3f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.7f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Scope/Dash");
                            players[i].GetComponent<PlayerScript>().setCooldown(0);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Gunner")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(3);
                            players[i].GetComponent<PlayerScript>().setGunForce(100);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.25f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.2f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Spewer");
                            players[i].GetComponent<PlayerScript>().setCooldown(20);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Painter")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(8);
                            players[i].GetComponent<PlayerScript>().setGunForce(70);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.00f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.00f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.0f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setMelee(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Shield");
                            players[i].GetComponent<PlayerScript>().setCooldown(0);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Psychic")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(6);
                            players[i].GetComponent<PlayerScript>().setGunForce(20);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.05f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.02f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Telekinesis");
                            players[i].GetComponent<PlayerScript>().setCooldown(30);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Pacifist")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(8);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setPacifist(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Throw/Hit");
                            players[i].GetComponent<PlayerScript>().setCooldown(0);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Spy")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(8);
                            players[i].GetComponent<PlayerScript>().setGunForce(30);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.5f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Extract");
                            players[i].GetComponent<PlayerScript>().setCooldown(30);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Jester")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(4);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setJester(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Clone");
                            players[i].GetComponent<PlayerScript>().setCooldown(45);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Scientist")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(5);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.5f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.2f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Teleporter");
                            players[i].GetComponent<PlayerScript>().setCooldown(0);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "NSA Agent")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(6);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.35f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("SpyCamera");
                            players[i].GetComponent<PlayerScript>().setCooldown(30);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Hacker")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(6);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.35f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("SystemHack");
                            players[i].GetComponent<PlayerScript>().setCooldown(30);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Trapper")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(4);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.15f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("LaserTrap");
                            players[i].GetComponent<PlayerScript>().setCooldown(45);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Bee Keeper")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(5);
                            players[i].GetComponent<PlayerScript>().setGunForce(40);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.25f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.04f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.08f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Hive");
                            players[i].GetComponent<PlayerScript>().setCooldown(7.5f);
                        }
                        if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Dead Eye")
                        {
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.00f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.0f);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Ghost")
                        {
                            players[i].GetComponent<PlayerScript>().toggleRenderer();
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Rugby")
                        {
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setPacifist(false);
                            players[i].GetComponent<PlayerScript>().setJester(false);
                            players[i].GetComponent<PlayerScript>().setMelee(false);
                            players[i].GetComponent<PlayerScript>().setRugby(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Tackle/Kick");
                        }
                    }
                    else if (universalGameManager.GetComponent<UniGameManager>().aiIsPlaying)
                    {
                        players[i] = Instantiate(aiRef, m_playerSpawnsTeam1[team1spawns].transform.position, Quaternion.identity);
                        players[i].GetComponent<Renderer>().material = universalGameManager.GetComponent<UniGameManager>().baseTeam1;
                        players[i].GetComponent<AI>().m_SpawnLoc = m_playerSpawnsTeam1[team1spawns];
                        if (!isPaintball)
                        {
                            players[i].transform.LookAt(ball.transform);
                        }
                        players[i].GetComponent<AI>().SetManager(this.gameObject);
                        //players[i].GetComponent<AI>().setPlayerName("Player " + (i + 1));
                        generateAIProfile(i);
                        players[i].GetComponent<AI>().setPaintSplat(universalGameManager.GetComponent<UniGameManager>().basesplatTeam1);
                        players[i].GetComponent<AI>().SetTeam("Team1");
                        //int rand = Random.Range(0, 4);
                        //switch (rand)
                        //{
                        //    case 0:
                        //        universalGameManager.GetComponent<UniGameManager>().playerType[i] = "Regular";
                        //        break;
                        //    case 1:
                        //        universalGameManager.GetComponent<UniGameManager>().playerType[i] = "Scout";
                        //        break;
                        //    case 2:
                        //        universalGameManager.GetComponent<UniGameManager>().playerType[i] = "Gunner";
                        //        break;
                        //    default:
                        //        universalGameManager.GetComponent<UniGameManager>().playerType[i] = "Regular";
                        //        break;

                        //}

                        if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Regular")
                        {
                            players[i].GetComponent<AI>().setMoveSpeed(5);
                            players[i].GetComponent<AI>().setGunForce(75);
                            players[i].GetComponent<AI>().setFireRate(0.025f);
                            players[i].GetComponent<AI>().setAutomatic(false);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Scout")
                        {
                            players[i].GetComponent<AI>().setMoveSpeed(7);
                            players[i].GetComponent<AI>().setGunForce(125);
                            players[i].GetComponent<AI>().setFireRate(1.5f);
                            players[i].GetComponent<AI>().setAutomatic(false);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Gunner")
                        {
                            players[i].GetComponent<AI>().setMoveSpeed(3);
                            players[i].GetComponent<AI>().setGunForce(100);
                            players[i].GetComponent<AI>().setFireRate(0.25f);
                            players[i].GetComponent<AI>().setAutomatic(true);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Psychic")
                        {
                            players[i].GetComponent<AI>().setMoveSpeed(6);
                            players[i].GetComponent<AI>().setGunForce(20);
                            players[i].GetComponent<AI>().setFireRate(0.05f);
                            players[i].GetComponent<AI>().setAutomatic(false);
                        }
                        if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Ghost")
                        {
                            players[i].GetComponent<AI>().toggleRenderer();
                        }
                    }
                    
                    //if (universalGameManager.GetComponent<UniGameManager>().seasonModeOn)
                    //{
                    //    players[i].GetComponent<Renderer>().material = universalGameManager.GetComponent<UniGameManager>().team1.GetComponent<TeamScript>().teamColour;
                    //    players[i].GetComponent<PlayerScript>().setPaintSplat(universalGameManager.GetComponent<UniGameManager>().team1.GetComponent<TeamScript>().teamsplatColour);
                    //}
                    team1spawns++;

                }
                if (universalGameManager.GetComponent<UniGameManager>().playerTeams[i] == "Team2")
                {
                    if (universalGameManager.GetComponent<UniGameManager>().playerReady[i])
                    {
                        players[i] = Instantiate(playerRef, m_playerSpawnsTeam2[team2spawns].transform.position, Quaternion.identity);
                        players[i].GetComponent<Renderer>().material = universalGameManager.GetComponent<UniGameManager>().baseTeam2;
                        players[i].GetComponent<PlayerScript>().m_SpawnLoc = m_playerSpawnsTeam2[team2spawns];
                        if (!isPaintball)
                        {
                            players[i].transform.LookAt(ball.transform);
                        }
                        players[i].GetComponent<PlayerScript>().SetManager(this.gameObject);
                        players[i].GetComponent<PlayerScript>().setPaintSplat(universalGameManager.GetComponent<UniGameManager>().basesplatTeam2);
                        players[i].GetComponent<PlayerScript>().SetTeam("Team2");
                        players[i].GetComponent<PlayerScript>().setPitch(players[i].transform.eulerAngles.x);
                        players[i].GetComponent<PlayerScript>().setYaw(players[i].transform.eulerAngles.y);
                        players[i].GetComponent<PlayerScript>().setPlayerName("Player " + (i + 1));
                        players[i].GetComponent<PlayerScript>().setLookSensitivity(universalGameManager.GetComponent<UniGameManager>().lookSens);
                        if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Regular")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(5);
                            players[i].GetComponent<PlayerScript>().setGunForce(75);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.025f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.01f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.2f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Bomb");
                            players[i].GetComponent<PlayerScript>().setCooldown(5);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Scout")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(7);
                            players[i].GetComponent<PlayerScript>().setGunForce(125);
                            players[i].GetComponent<PlayerScript>().setFireRate(1.5f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.3f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.7f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Scope/Dash");
                            players[i].GetComponent<PlayerScript>().setCooldown(0);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Gunner")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(3);
                            players[i].GetComponent<PlayerScript>().setGunForce(100);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.25f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.2f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Spewer");
                            players[i].GetComponent<PlayerScript>().setCooldown(20);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Painter")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(8);
                            players[i].GetComponent<PlayerScript>().setGunForce(70);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.00f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.00f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.0f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setMelee(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Shield");
                            players[i].GetComponent<PlayerScript>().setCooldown(0);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Psychic")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(6);
                            players[i].GetComponent<PlayerScript>().setGunForce(20);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.05f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.02f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Telekinesis");
                            players[i].GetComponent<PlayerScript>().setCooldown(30);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Pacifist")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(8);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setPacifist(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Throw/Hit");
                            players[i].GetComponent<PlayerScript>().setCooldown(0);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Spy")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(8);
                            players[i].GetComponent<PlayerScript>().setGunForce(30);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.5f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Extract");
                            players[i].GetComponent<PlayerScript>().setCooldown(30);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Jester")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(4);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setJester(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Clone");
                            players[i].GetComponent<PlayerScript>().setCooldown(45);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Scientist")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(5);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.5f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.2f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("Teleporter");
                            players[i].GetComponent<PlayerScript>().setCooldown(0);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "NSA Agent")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(6);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.35f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("SpyCamera");
                            players[i].GetComponent<PlayerScript>().setCooldown(30);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Hacker")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(6);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.35f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setSpecial("SystemHack");
                            players[i].GetComponent<PlayerScript>().setCooldown(30);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Trapper")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(4);
                            players[i].GetComponent<PlayerScript>().setGunForce(50);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.15f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.05f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.1f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("LaserTrap");
                            players[i].GetComponent<PlayerScript>().setCooldown(45);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Bee Keeper")
                        {
                            players[i].GetComponent<PlayerScript>().setMoveSpeed(5);
                            players[i].GetComponent<PlayerScript>().setGunForce(40);
                            players[i].GetComponent<PlayerScript>().setFireRate(0.25f);
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.04f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.08f);
                            players[i].GetComponent<PlayerScript>().setAutomatic(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Hive");
                            players[i].GetComponent<PlayerScript>().setCooldown(7.5f);
                        }
                        if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Dead Eye")
                        {
                            players[i].GetComponent<PlayerScript>().setAccuracy(0.00f);
                            players[i].GetComponent<PlayerScript>().setMaxAccuracy(0.0f);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Ghost")
                        {
                            players[i].GetComponent<PlayerScript>().toggleRenderer();
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Rugby")
                        {
                            players[i].GetComponent<PlayerScript>().setAutomatic(false);
                            players[i].GetComponent<PlayerScript>().setPacifist(false);
                            players[i].GetComponent<PlayerScript>().setJester(false);
                            players[i].GetComponent<PlayerScript>().setMelee(false);
                            players[i].GetComponent<PlayerScript>().setRugby(true);
                            players[i].GetComponent<PlayerScript>().setSpecial("Tackle/Kick");
                        }
                    }
                    else if (universalGameManager.GetComponent<UniGameManager>().aiIsPlaying)
                        {
                        players[i] = Instantiate(aiRef, m_playerSpawnsTeam2[team2spawns].transform.position, Quaternion.identity);
                        players[i].GetComponent<Renderer>().material = universalGameManager.GetComponent<UniGameManager>().baseTeam2;
                        players[i].GetComponent<AI>().m_SpawnLoc = m_playerSpawnsTeam2[team2spawns];
                        if (!isPaintball)
                        {
                            players[i].transform.LookAt(ball.transform);
                        }
                        players[i].GetComponent<AI>().SetManager(this.gameObject);
                        //players[i].GetComponent<AI>().setPlayerName("Player " + (i + 1));
                        generateAIProfile(i);
                        players[i].GetComponent<AI>().setPaintSplat(universalGameManager.GetComponent<UniGameManager>().basesplatTeam2);
                        players[i].GetComponent<AI>().SetTeam("Team2");
                        //int rand = Random.Range(0, 4);
                        //switch (rand)
                        //{
                        //    case 0:
                        //        universalGameManager.GetComponent<UniGameManager>().playerType[i] = "Regular";
                        //        break;
                        //    case 1:
                        //        universalGameManager.GetComponent<UniGameManager>().playerType[i] = "Scout";
                        //        break;
                        //    case 2:
                        //        universalGameManager.GetComponent<UniGameManager>().playerType[i] = "Gunner";
                        //        break;
                        //    default:
                        //        universalGameManager.GetComponent<UniGameManager>().playerType[i] = "Regular";
                        //        break;

                        //}
                        if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Regular")
                        {
                            players[i].GetComponent<AI>().setMoveSpeed(5);
                            players[i].GetComponent<AI>().setGunForce(75);
                            players[i].GetComponent<AI>().setFireRate(0.025f);
                            players[i].GetComponent<AI>().setAutomatic(false);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Scout")
                        {
                            players[i].GetComponent<AI>().setMoveSpeed(7);
                            players[i].GetComponent<AI>().setGunForce(125);
                            players[i].GetComponent<AI>().setFireRate(1.5f);
                            players[i].GetComponent<AI>().setAutomatic(false);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Gunner")
                        {
                            players[i].GetComponent<AI>().setMoveSpeed(3);
                            players[i].GetComponent<AI>().setGunForce(100);
                            players[i].GetComponent<AI>().setFireRate(0.25f);
                            players[i].GetComponent<AI>().setAutomatic(true);
                        }
                        else if (universalGameManager.GetComponent<UniGameManager>().playerType[i] == "Psychic")
                        {
                            players[i].GetComponent<AI>().setMoveSpeed(6);
                            players[i].GetComponent<AI>().setGunForce(20);
                            players[i].GetComponent<AI>().setFireRate(0.05f);
                            players[i].GetComponent<AI>().setAutomatic(false);
                        }
                        if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Ghost")
                        {
                            players[i].GetComponent<AI>().toggleRenderer();
                        }
                    }
                    
                    //if (universalGameManager.GetComponent<UniGameManager>().seasonModeOn)
                    //{
                    //    players[i].GetComponent<Renderer>().material = universalGameManager.GetComponent<UniGameManager>().team2.GetComponent<TeamScript>().teamColour;
                    //    players[i].GetComponent<PlayerScript>().setPaintSplat(universalGameManager.GetComponent<UniGameManager>().team2.GetComponent<TeamScript>().teamsplatColour);
                    //}
                    team2spawns++;

                }
                switch (i)
                {
                    case 0:
                        if (players[i].GetComponent<PlayerScript>())
                        {
                            //not controller
                            if (universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer)
                            {
                                players[i].GetComponent<PlayerScript>().SetAxisAll("Player1MoveXPC", "Player1MoveYPC", "Player1LookXPC", "Player1LookYPC");
                                players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Mouse0, KeyCode.Space, KeyCode.LeftShift, KeyCode.Escape, KeyCode.Q, KeyCode.E);
                            }
                            else
                            {
                                //Windows
                                players[i].GetComponent<PlayerScript>().SetAxisAll("Player1MoveX", "Player1MoveY", "Player1LookX", "Player1LookY");
                                players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick1Button5, KeyCode.Joystick1Button0, KeyCode.Joystick1Button8, KeyCode.Joystick1Button7, KeyCode.Joystick1Button4, KeyCode.Joystick1Button1);
                            }
                            //Mac
                            //players[i].GetComponent<PlayerScript>().SetAxisAll("Player1MoveXMac", "Player1MoveYMac", "Player1LookXMac", "Player1LookYMac");
                            //players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick1Button18, KeyCode.Joystick1Button16, KeyCode.Joystick1Button14, KeyCode.Joystick1Button9);
                            players[i].GetComponent<PlayerScript>().cam.rect = (new Rect(-x, y, 1, 1));
                        }
                        break;
                    case 1:
                        if (players[i].GetComponent<PlayerScript>())
                        {
                            if (universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer)
                            {
                                players[i].GetComponent<PlayerScript>().SetAxisAll("Player1MoveX", "Player1MoveY", "Player1LookX", "Player1LookY");
                                players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick1Button5, KeyCode.Joystick1Button0, KeyCode.Joystick1Button8, KeyCode.Joystick1Button7, KeyCode.Joystick1Button4, KeyCode.Joystick1Button1);
                            }
                            else
                            {
                                //Windows
                                players[i].GetComponent<PlayerScript>().SetAxisAll("Player2MoveX", "Player2MoveY", "Player2LookX", "Player2LookY");
                                players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick2Button5, KeyCode.Joystick2Button0, KeyCode.Joystick2Button8, KeyCode.Joystick2Button7, KeyCode.Joystick2Button4, KeyCode.Joystick2Button1);
                            }
                            //Mac
                            //players[i].GetComponent<PlayerScript>().SetAxisAll("Player2MoveXMac", "Player2MoveYMac", "Player2LookXMac", "Player2LookYMac");
                            //players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick2Button18, KeyCode.Joystick2Button16, KeyCode.Joystick2Button14, KeyCode.Joystick2Button9);
                            players[i].GetComponent<PlayerScript>().cam.rect = (new Rect(x, -y, 1, 1));
                        }
                        break;
                    case 2:
                        if (players[i].GetComponent<PlayerScript>())
                        {
                            if (universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer)
                            {
                                players[i].GetComponent<PlayerScript>().SetAxisAll("Player2MoveX", "Player2MoveY", "Player2LookX", "Player2LookY");
                                players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick2Button5, KeyCode.Joystick2Button0, KeyCode.Joystick2Button8, KeyCode.Joystick2Button7, KeyCode.Joystick2Button4, KeyCode.Joystick2Button1);
                            }
                            else
                            {
                                //Windows
                                players[i].GetComponent<PlayerScript>().SetAxisAll("Player3MoveX", "Player3MoveY", "Player3LookX", "Player3LookY");
                                players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick3Button5, KeyCode.Joystick3Button0, KeyCode.Joystick3Button8, KeyCode.Joystick3Button7, KeyCode.Joystick3Button4, KeyCode.Joystick3Button1);
                            }
                            //Mac
                            //players[i].GetComponent<PlayerScript>().SetAxisAll("Player3MoveXMac", "Player3MoveYMac", "Player3LookXMac", "Player3LookYMac");
                            //players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick3Button18, KeyCode.Joystick3Button16, KeyCode.Joystick3Button14, KeyCode.Joystick3Button9);
                            players[i].GetComponent<PlayerScript>().cam.rect = (new Rect(x, y, 1, 1));
                        }
                        break;
                    case 3:
                        if (players[i].GetComponent<PlayerScript>())
                        {
                            if (universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer)
                            {
                                players[i].GetComponent<PlayerScript>().SetAxisAll("Player3MoveX", "Player3MoveY", "Player3LookX", "Player3LookY");
                                players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick3Button5, KeyCode.Joystick3Button0, KeyCode.Joystick3Button8, KeyCode.Joystick3Button7, KeyCode.Joystick3Button4, KeyCode.Joystick3Button1);
                            }
                            else
                            {
                                //Windows
                                players[i].GetComponent<PlayerScript>().SetAxisAll("Player4MoveX", "Player4MoveY", "Player4LookX", "Player4LookY");
                                players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick4Button5, KeyCode.Joystick4Button0, KeyCode.Joystick4Button8, KeyCode.Joystick4Button7, KeyCode.Joystick4Button4, KeyCode.Joystick4Button1);
                            }//Mac
                            //players[i].GetComponent<PlayerScript>().SetAxisAll("Player4MoveXMac", "Player4MoveYMac", "Player4LookXMac", "Player4LookYMac");
                            //players[i].GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick4Button18, KeyCode.Joystick4Button16, KeyCode.Joystick4Button14, KeyCode.Joystick4Button9);
                            players[i].GetComponent<PlayerScript>().cam.rect = (new Rect(-x, -y, 1, 1));
                        }
                        break;
                    default:
                        break;
                }
                if (!isPaintball)
                {
                    ball.GetComponent<BallScript>().lastPlayer = getPlayer(0);
                }
               
            }
        }
        if (isPaintball)
        {
            team1playercount = 0;
            team2playercount = 0;
            for (int ii = 0; ii < playerAmt; ii++)
            {
                if (players[ii].GetComponent<PlayerScript>())
                {
                    if (players[ii].GetComponent<PlayerScript>().GetTeam() == "Team1")
                    {
                        team1playercount++;
                    }
                    else if (players[ii].GetComponent<PlayerScript>().GetTeam() == "Team2")
                    {
                        team2playercount++;
                    }
                }
                else if (players[ii].GetComponent<AI>())
                {
                    if (players[ii].GetComponent<AI>().GetTeam() == "Team1")
                    {
                        team1playercount++;
                    }
                    else if (players[ii].GetComponent<AI>().GetTeam() == "Team2")
                    {
                        team2playercount++;
                    }
                }
            }
            bomb.GetComponent<BombScript>().teamPickup = "Team2";
        }
        IntroCam.GetComponent<ErrorFix>().errorON = false;
        Destroy(IntroCam.GetComponent<ErrorFix>());
        if (ball != null)
        {
            ball.GetComponent<Renderer>().material = universalGameManager.GetComponent<UniGameManager>().ballMat;
            if (universalGameManager.GetComponent<UniGameManager>().MutatorRule == "Chomp Ball")
            {
                ball.gameObject.AddComponent<ChompScript>();
                ball.GetComponent<ChompScript>().SetPlayerSearch(true);
                ball.GetComponent<ChompScript>().GameMan = this.gameObject;
            }
        }
        if (players[0].GetComponent<PlayerScript>())
        {
            players[0].GetComponent<PlayerScript>().setPlayerName(universalGameManager.GetComponent<UniGameManager>().profileName);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //different update function occurs if it's a different game mode
        if (!isPaintball)
        {
            GameUpdateFnc();
        }
        else
        {
            PaintballGameFnc();
        }
    }
    public int getSeconds() { return seconds; }
    public void setSeconds(int a_new) { seconds = a_new; }
    public void addSeconds(int secondsToAdd) {seconds += secondsToAdd; }
    public bool GetPaused()
    {
        return paused;
    }
    public void PaintballGameFnc()
    {
        if (teamScore1 == (maxRounds / 2) + 1 || teamScore2 == (maxRounds / 2) + 1)
        {
            winStage();
        }
        else if (teamScore1 == (maxRounds / 2) && teamScore2 == (maxRounds / 2) && !universalGameManager.GetComponent<UniGameManager>().extraTime)
        {
            winStage();
        }
        if (inplay)
        {
            
            timePassed += Time.deltaTime;
            timeTillFrame += Time.deltaTime;
            if (timePassed >= 1)
            {
                seconds -= 1;
                timePassed -= 1;
            }
            if (seconds < 0)
            {
                PaintballPlayerActiveCheck(true);
                bombIsON = false;
                roundEnd = true;
            }
            //FrameSave++;
        }
    }
    public void PaintballPlayerActiveCheck(bool secondsDone)
    {
        if (!roundEnd)
        {
            int team1Alive = team1playercount;
            int team2Alive = team2playercount;
            for (int i = 0; i < playerAmt; i++)
            {
                if (players[i].GetComponent<PlayerScript>())
                {
                    if (players[i].GetComponent<PlayerScript>().GetTeam() == "Team1" && !players[i].GetComponent<PlayerScript>().active)
                    {
                        team1Alive--;
                    }
                    else if (players[i].GetComponent<PlayerScript>().GetTeam() == "Team2" && !players[i].GetComponent<PlayerScript>().active)
                    {
                        team2Alive--;
                    }
                }
                else if (players[i].GetComponent<AI>())
                {
                    if (players[i].GetComponent<AI>().GetTeam() == "Team1" && !players[i].GetComponent<AI>().active)
                    {
                        team1Alive--;
                    }
                    else if (players[i].GetComponent<AI>().GetTeam() == "Team2" && !players[i].GetComponent<AI>().active)
                    {
                        team2Alive--;
                    }
                }
            }
            if (bomb.GetComponent<BombScript>().teamPickup == "Team2")
            {
                if (team1Alive == 0 && team2Alive > 0 || bombIsON && secondsDone)
                {
                    AddScore("Team2");
                    if (bombIsON && secondsDone)
                    {
                        bomb.GetComponent<BombScript>().spawnFlag();
                    }
                    roundEnd = true;
                    wonRound = Instantiate(winRoundUIRef);
                    wonRound.GetComponent<RoundWinCanvas>().sportsballMan = this.gameObject;
                    wonRound.GetComponent<RoundWinCanvas>().banner.sprite = universalGameManager.GetComponent<UniGameManager>().banner2;
                    wonRound.GetComponent<RoundWinCanvas>().winText.text = universalGameManager.GetComponent<UniGameManager>().teamname2 + " Wins The Round";
                    seconds = 7;
                    if (teamScore2 == ((maxRounds/2) + 1))
                    {
                        wonRound.GetComponent<RoundWinCanvas>().dontRS = true;
                        inplay = false;
                        for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                        {
                            players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                        }
                        replayCamera.enabled = false;
                        regularUI.enabled = false;
                        replayUI.enabled = true;
                        winCam.enabled = true;


                        for (int iii = 0; iii < playerAmt; iii++)
                        {
                            if (players[iii].GetComponent<PlayerScript>() && (players[iii].GetComponent<PlayerScript>().GetTeam() == "Team2"))
                            {
                                players[iii].transform.position = new Vector3(0, 0.5f, 0);
                            }
                            else if (players[iii].GetComponent<AI>() && (players[iii].GetComponent<AI>().GetTeam() == "Team2"))
                            {
                                players[iii].transform.position = new Vector3(0, 0.5f, 0);
                            }
                        }


                        winStage();
                    }
                    else if (teamScore1 == (maxRounds / 2) && teamScore2 == (maxRounds / 2))
                    {
                        if (universalGameManager.GetComponent<UniGameManager>().extraTime)
                        {
                            maxRounds += 4;
                            swapRound = maxRounds - 2;
                        }
                        else
                        {
                            wonRound.GetComponent<RoundWinCanvas>().dontRS = true;
                            inplay = false;
                            for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                            {
                                players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                            }
                            replayCamera.enabled = false;
                            regularUI.enabled = false;
                            replayUI.enabled = true;
                            winCam.enabled = true;
                            winStage();
                        }
                    }

                }
                else if (team2Alive == 0 && team1Alive > 0 && !bombIsON || secondsDone && !bombIsON)
                {
                    AddScore("Team1");
                    roundEnd = true;
                    wonRound = Instantiate(winRoundUIRef);
                    wonRound.GetComponent<RoundWinCanvas>().sportsballMan = this.gameObject;
                    wonRound.GetComponent<RoundWinCanvas>().banner.sprite = universalGameManager.GetComponent<UniGameManager>().banner1;
                    wonRound.GetComponent<RoundWinCanvas>().winText.text = universalGameManager.GetComponent<UniGameManager>().teamname1 + " Wins The Round";
                    seconds = 7;
                    if (teamScore1 == ((maxRounds / 2) + 1))
                    {
                        wonRound.GetComponent<RoundWinCanvas>().dontRS = true;
                        inplay = false;
                        for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                        {
                            players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                        }
                        replayCamera.enabled = false;
                        regularUI.enabled = false;
                        replayUI.enabled = true;
                        winCam.enabled = true;


                        for (int iii = 0; iii < playerAmt; iii++)
                        {
                            if (players[iii].GetComponent<PlayerScript>() && (players[iii].GetComponent<PlayerScript>().GetTeam() == "Team1"))
                            {
                                players[iii].transform.position = new Vector3(0, 0.5f, 0);
                            }
                            else if (players[iii].GetComponent<AI>() && (players[iii].GetComponent<AI>().GetTeam() == "Team1"))
                            {
                                players[iii].transform.position = new Vector3(0, 0.5f, 0);
                            }
                        }


                        winStage();

                    }
                    else if (teamScore1 == (maxRounds / 2) && teamScore2 == (maxRounds / 2))
                    {
                        if (universalGameManager.GetComponent<UniGameManager>().extraTime)
                        {
                            maxRounds += 4;
                            swapRound = maxRounds - 2;
                        }
                        else
                        {
                            wonRound.GetComponent<RoundWinCanvas>().dontRS = true;
                            inplay = false;
                            for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                            {
                                players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                            }
                            replayCamera.enabled = false;
                            regularUI.enabled = false;
                            replayUI.enabled = true;
                            winCam.enabled = true;
                            winStage();
                        }
                    }

                }
            }




            else if (bomb.GetComponent<BombScript>().teamPickup == "Team1")
            {
                if (team2Alive == 0 && team1Alive > 0 || bombIsON && secondsDone)
                {
                    AddScore("Team1");
                    if (bombIsON && secondsDone)
                    {
                        bomb.GetComponent<BombScript>().spawnFlag();
                    }
                    roundEnd = true;
                    wonRound = Instantiate(winRoundUIRef);
                    wonRound.GetComponent<RoundWinCanvas>().sportsballMan = this.gameObject;
                    wonRound.GetComponent<RoundWinCanvas>().banner.sprite = universalGameManager.GetComponent<UniGameManager>().banner1;
                    wonRound.GetComponent<RoundWinCanvas>().winText.text = universalGameManager.GetComponent<UniGameManager>().teamname1 + " Wins The Round";
                    seconds = 7;
                    if (teamScore1 == ((maxRounds / 2) + 1))
                    {
                        wonRound.GetComponent<RoundWinCanvas>().dontRS = true;
                        inplay = false;
                        for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                        {
                            players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                        }
                        replayCamera.enabled = false;
                        regularUI.enabled = false;
                        replayUI.enabled = true;
                        winCam.enabled = true;


                        for (int iii = 0; iii < playerAmt; iii++)
                        {
                            if (players[iii].GetComponent<PlayerScript>() && (players[iii].GetComponent<PlayerScript>().GetTeam() == "Team1"))
                            {
                                players[iii].transform.position = new Vector3(0, 0.5f, 0);
                            }
                            else if (players[iii].GetComponent<AI>() && (players[iii].GetComponent<AI>().GetTeam() == "Team1"))
                            {
                                players[iii].transform.position = new Vector3(0, 0.5f, 0);
                            }
                        }


                        winStage();
                    }
                    else if (teamScore1 == (maxRounds / 2) && teamScore2 == (maxRounds / 2))
                    {
                        if (universalGameManager.GetComponent<UniGameManager>().extraTime)
                        {
                            maxRounds += 4;
                            swapRound = maxRounds - 2;
                        }
                        else
                        {
                            wonRound.GetComponent<RoundWinCanvas>().dontRS = true;
                            inplay = false;
                            for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                            {
                                players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                            }
                            replayCamera.enabled = false;
                            regularUI.enabled = false;
                            replayUI.enabled = true;
                            winCam.enabled = true;
                            winStage();
                        }
                    }

                }
                else if (team1Alive == 0 && team2Alive > 0 && !bombIsON || secondsDone && !bombIsON)
                {
                    AddScore("Team2");
                    roundEnd = true;
                    wonRound = Instantiate(winRoundUIRef);
                    wonRound.GetComponent<RoundWinCanvas>().sportsballMan = this.gameObject;
                    wonRound.GetComponent<RoundWinCanvas>().banner.sprite = universalGameManager.GetComponent<UniGameManager>().banner2;
                    wonRound.GetComponent<RoundWinCanvas>().winText.text = universalGameManager.GetComponent<UniGameManager>().teamname2 + " Wins The Round";
                    seconds = 7;
                    if (teamScore2 == ((maxRounds / 2) + 1))
                    {
                        wonRound.GetComponent<RoundWinCanvas>().dontRS = true;
                        inplay = false;
                        for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                        {
                            players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                        }
                        replayCamera.enabled = false;
                        regularUI.enabled = false;
                        replayUI.enabled = true;
                        winCam.enabled = true;


                        for (int iii = 0; iii < playerAmt; iii++)
                        {
                            if (players[iii].GetComponent<PlayerScript>() && (players[iii].GetComponent<PlayerScript>().GetTeam() == "Team2"))
                            {
                                players[iii].transform.position = new Vector3(0, 0.5f, 0);
                            }
                            else if (players[iii].GetComponent<AI>() && (players[iii].GetComponent<AI>().GetTeam() == "Team2"))
                            {
                                players[iii].transform.position = new Vector3(0, 0.5f, 0);
                            }
                        }


                        winStage();

                    }
                    else if (teamScore1 == (maxRounds / 2) && teamScore2 == (maxRounds / 2))
                    {
                        if (universalGameManager.GetComponent<UniGameManager>().extraTime)
                        {
                            maxRounds += 4;
                            swapRound = maxRounds - 2;
                        }
                        else
                        {
                            wonRound.GetComponent<RoundWinCanvas>().dontRS = true;
                            inplay = false;
                            for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                            {
                                players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                            }
                            replayCamera.enabled = false;
                            regularUI.enabled = false;
                            replayUI.enabled = true;
                            winCam.enabled = true;
                            winStage();
                        }
                    }

                }
            }
        }
    }
    public void SetPaused(bool a_paused)
    {
       paused = a_paused;
    }
    public void KillFeedSend(string feedSend)
    {
        regularUI.GetComponent<UI>().KillFeed(feedSend);
    }
    public bool GetInplay()
    {
        return inplay;
    }
    public void SetInplay(bool a_bool)
    {
         inplay = a_bool;
    }
    void GameUpdateFnc()
    {
        if (!paused)
        {
            if (inplay)
            {
                timePassed += Time.deltaTime;
                timeTillFrame += Time.deltaTime;
                if (timePassed >= 1)
                {
                    seconds -= 1;
                    timePassed -= 1;
                    if (isTugOfWar && seconds % 5 == 0)
                    {
                        if (Vector3.Distance(ball.transform.position, TugOfWarGoal1.transform.position) < Vector3.Distance(ball.transform.position, TugOfWarGoal2.transform.position))
                        {
                            teamScore2++;
                        }
                        else if (Vector3.Distance(ball.transform.position, TugOfWarGoal1.transform.position) > Vector3.Distance(ball.transform.position, TugOfWarGoal2.transform.position))
                        {
                            teamScore1++;
                        }
                    }
                }
                if (timeTillFrame > 0.01f)
                {
                    replaySaveFrame();
                    timeTillFrame -= 0.01f;
                }
                //FrameSave++;
            }
            if (replay)
            {
                    playReplay(replayFrame, FrameSave);
                    replayFrame++;
            }
            if (seconds < 0 && !overtime)
            {
                if (universalGameManager.GetComponent<UniGameManager>().extraTime)
                {
                    if (teamScore1 == teamScore2)
                    {
                        if (isTugOfWar)
                        {
                            seconds = 30;
                        }
                        else
                        {
                            overtime = true;
                            ball.GetComponent<BallScript>().unAttach();
                            for (int iii = 0; iii < playerAmt; iii++)
                            {
                                if (players[iii].GetComponent<PlayerScript>())
                                {
                                    players[iii].transform.position = players[iii].GetComponent<PlayerScript>().m_SpawnLoc.transform.position;
                                    players[iii].GetComponent<Rigidbody>().velocity = Vector3.zero;
                                    players[iii].GetComponent<PlayerScript>().cam.enabled = true;
                                }
                                else
                                {
                                    players[iii].transform.position = players[iii].GetComponent<AI>().m_SpawnLoc.transform.position;
                                    players[iii].GetComponent<Rigidbody>().velocity = Vector3.zero;
                                }
                                ball.transform.position = new Vector3(0, 6.25f, 0);
                                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            }
                        }
                        return;
                    }
                    
                }
                replay = false;
                inplay = false;
                for (int iii = 0; iii < universalGameManager.GetComponent<UniGameManager>().players; iii++)
                {
                    players[iii].GetComponent<PlayerScript>().cam.enabled = false;
                }
                replayCamera.enabled = false;
                regularUI.enabled = false;
                replayUI.enabled = true;
                winCam.enabled = true;
                ball.transform.position = new Vector3(10, -10, 10);
                if (teamScore1 > teamScore2)
                {
                    for (int iii = 0; iii < playerAmt; iii++)
                    {
                        if (players[iii].GetComponent<PlayerScript>() && (players[iii].GetComponent<PlayerScript>().GetTeam() == "Team1"))
                        {
                            players[iii].transform.position = new Vector3(0, 0.5f, 0);
                        }
                        else if (players[iii].GetComponent<AI>() && (players[iii].GetComponent<AI>().GetTeam() == "Team1"))
                        {
                            players[iii].transform.position = new Vector3(0, 0.5f, 0);
                        }
                    }
                }
                if (teamScore1 < teamScore2)
                {
                    for (int iii = 0; iii < playerAmt; iii++)
                    {
                        if (players[iii].GetComponent<PlayerScript>() && (players[iii].GetComponent<PlayerScript>().GetTeam() == "Team2"))
                        {
                            players[iii].transform.position = new Vector3(0, 0.5f, 0);
                        }
                        else if (players[iii].GetComponent<AI>() && (players[iii].GetComponent<AI>().GetTeam() == "Team2"))
                        {
                            players[iii].transform.position = new Vector3(0, 0.5f, 0);
                        }
                    }
                }
                if (teamScore1 == teamScore2) //Change With Overtime
                {
                    for (int iii = 0; iii < playerAmt; iii++)
                    {
                        if (players[iii].GetComponent<PlayerScript>() && (players[iii].GetComponent<PlayerScript>().GetTeam() == "Team1" || players[iii].GetComponent<PlayerScript>().GetTeam() == "Team2"))
                        {
                            players[iii].transform.position = new Vector3(0, 0.5f, 0);
                        }
                        else if (players[iii].GetComponent<AI>() && (players[iii].GetComponent<AI>().GetTeam() == "Team1" || players[iii].GetComponent<AI>().GetTeam() == "Team2"))
                        {
                            players[iii].transform.position = new Vector3(0, 0.5f, 0);
                        }
                    }
                }
                winStage();

            }
        }
        else
        {

        }
    }
    void replaySaveFrame()
    {

        if (FrameSave >= 998)
        {
            for (int ii = 0; ii < 998; ii++)
            {
                for (int iii = 0; iii < playerAmt; iii++)
                {
                    replaylocs[iii, ii] = replaylocs[iii, ii + 1];
                    replayRot[iii, ii] = replayRot[iii, ii + 1];

                }
                replaylocs[playerAmt, ii] = replaylocs[playerAmt, ii + 1];
                replayRot[playerAmt, ii] = replayRot[playerAmt, ii + 1];
                FrameSave--;
            }
        }
        for (int iii = 0; iii < playerAmt; iii++)
        {
            //if (a_Frame < 998)
            {
                replaylocs[iii, FrameSave] = players[iii].transform.position;
                replayRot[iii, FrameSave] = players[iii].transform.eulerAngles;//find out overflow array problem
            }

        }
        //if (a_Frame < 998)
        {
            replaylocs[playerAmt, FrameSave] = ball.transform.position;
            FrameSave++;
        }
        

    }
    public void AddScore(string team)
    {
        if (team == "Team1")
        {
            teamScore1++;
        }
        else if (team == "Team2")
        {
            teamScore2++;
        }
    }
    public void AddScoreInt(string team, int score)
    {
        if (team == "Team1")
        {
            teamScore1+=score;
        }
        else if (team == "Team2")
        {
            teamScore2+=score;
        }
    }
    public void DecreaseScore(string team)
    {
        if (team == "Team1")
        {
            teamScore1--;
        }
        else if (team == "Team2")
        {
            teamScore2--;
        }
    }
    public void addBanner(string team)
    {
        inplay = false;
        if (team == "Team 1")
        {
            wonRound = Instantiate(winRoundUIRef);
            wonRound.GetComponent<RoundWinCanvas>().sportsballMan = this.gameObject;
            wonRound.GetComponent<RoundWinCanvas>().setReplay(true);
            wonRound.GetComponent<RoundWinCanvas>().banner.sprite = universalGameManager.GetComponent<UniGameManager>().banner1;
            wonRound.GetComponent<RoundWinCanvas>().winText.text = universalGameManager.GetComponent<UniGameManager>().teamname1 + " Scores";
            wonRound.GetComponent<RoundWinCanvas>().setAliveTime(3);
        }
        else if (team == "Team 2")
        {
            wonRound = Instantiate(winRoundUIRef);
            wonRound.GetComponent<RoundWinCanvas>().sportsballMan = this.gameObject;
            wonRound.GetComponent<RoundWinCanvas>().setReplay(true);
            wonRound.GetComponent<RoundWinCanvas>().banner.sprite = universalGameManager.GetComponent<UniGameManager>().banner2;
            wonRound.GetComponent<RoundWinCanvas>().winText.text = universalGameManager.GetComponent<UniGameManager>().teamname2 + " Scores";
            wonRound.GetComponent<RoundWinCanvas>().setAliveTime(3);
        }
    }
    public int getTeam1Score() { return teamScore1; }
    public int getTeam2Score() { return teamScore2; }
    public void setTeam1Score(int a_score) {teamScore1 = a_score; }
    public void setTeam2Score(int a_score) { teamScore2 = a_score; }
    public GameObject getPlayer(int ii)
    {
        return players[ii];
    }
    public void playReplay(int i, int goalPoint)
    {
        {
            //Debug.Log(i);
            if (i >= 998 || i > goalPoint || Input.GetKey(KeyCode.JoystickButton0))
            {
                i = 0;
                replay = false;
                ball.GetComponent<BallScript>().unAttach();
                if (conversion && axisXLook != null && axisXMove != null && axisYLook != null)
                {
                    {
                        regularUI.enabled = true;
                        replayUI.enabled = false;
                        conversion = false;
                        replayCamera.enabled = false;
                        GameObject conversionState = Instantiate(conversionRef);
                        conversionState.GetComponent<ConversionKick>().ball.GetComponent<ConversionBall>().gameManager = this.gameObject;
                        if (ballPosition.z < 0)
                        {
                            conversionState.transform.position = new Vector3(ballPosition.x, 1, ballPosition.z + 20);
                            conversionState.GetComponent<ConversionKick>().cameraObj.transform.position = new Vector3(ballPosition.x, 1, ballPosition.z + 30);
                            conversionState.GetComponent<ConversionKick>().ball.transform.localPosition = new Vector3(ball.transform.localPosition.x, ball.transform.localPosition.y, ball.transform.localPosition.z);
                        }
                        else if (ballPosition.z > 0)
                        {
                            conversionState.transform.position = new Vector3(ballPosition.x, 1, ballPosition.z - 20);
                            conversionState.GetComponent<ConversionKick>().cameraObj.transform.position = new Vector3(ballPosition.x, 1, ballPosition.z - 30);
                            conversionState.GetComponent<ConversionKick>().ball.transform.localPosition = new Vector3(ball.transform.localPosition.x, ball.transform.localPosition.y, -ball.transform.localPosition.z);
                        }
                        conversionState.GetComponent<ConversionKick>().cameraObj.transform.LookAt(conversionState.GetComponent<ConversionKick>().ball.transform);
                        conversionState.GetComponent<ConversionKick>().setAxis(axisXLook, axisXMove, axisYLook);
                        conversionState.GetComponent<ConversionKick>().shoot = shoot;
                        axisXLook = null;
                        axisXMove = null;
                        axisYLook = null;
                    }
                }
                else
                {
                    inplay = true;
                    //for (int ii = 0; ii < 998; ii++)
                    //{
                    //    player1locs[ii] = Vector3.zero;
                    //    player2locs[ii] = Vector3.zero;
                    //    balllocs[ii] = Vector3.zero;

                    //}
                    if (overtime)
                    {
                        if (teamScore1 != teamScore2)
                        {
                            overtime = false;
                        }
                    }
                    if (boundaryRule)
                    {
                        ball.transform.position = ballRespawn;
                    }
                    else
                    {
                        ball.transform.position = new Vector3(0, 6.25f, 0);
                    }

                    for (int iii = 0; iii < playerAmt; iii++)
                    {
                        if (players[iii].GetComponent<PlayerScript>())
                        {
                            if (boundaryRule)
                            {
                                if (players[iii].GetComponent<PlayerScript>().GetTeam() == "Team1")
                                {
                                    players[iii].transform.position = new Vector3(players[iii].GetComponent<PlayerScript>().m_SpawnLoc.transform.position.x, 0.5f, ballRespawn.z + 10);
                                }
                                else
                                {
                                    players[iii].transform.position = new Vector3(players[iii].GetComponent<PlayerScript>().m_SpawnLoc.transform.position.x, 0.5f, ballRespawn.z - 10);
                                }
                            }
                            else
                            {
                                players[iii].transform.position = players[iii].GetComponent<PlayerScript>().m_SpawnLoc.transform.position;
                            }
                            players[iii].transform.LookAt(ball.transform);
                            players[iii].GetComponent<Rigidbody>().velocity = Vector3.zero;
                            players[iii].GetComponent<PlayerScript>().setPitch(players[iii].transform.eulerAngles.x);
                            players[iii].GetComponent<PlayerScript>().setYaw(players[iii].transform.eulerAngles.y);
                            players[iii].GetComponent<PlayerScript>().cam.enabled = true;
                        }
                        else
                        {
                            if (boundaryRule)
                            {
                                if (players[iii].GetComponent<AI>())
                                {
                                    if (players[iii].GetComponent<AI>().GetTeam() == "Team1")
                                    {
                                        players[iii].transform.position = new Vector3(players[iii].GetComponent<AI>().m_SpawnLoc.transform.position.x, 0.5f, ballRespawn.z + 10);
                                    }
                                    else
                                    {
                                        players[iii].transform.position = new Vector3(players[iii].GetComponent<AI>().m_SpawnLoc.transform.position.x, 0.5f, ballRespawn.z - 10);
                                    }
                                }

                            }
                            else
                            {
                                players[iii].transform.position = players[iii].GetComponent<AI>().m_SpawnLoc.transform.position;
                            }
                            players[iii].transform.LookAt(ball.transform);
                            players[iii].GetComponent<Rigidbody>().velocity = Vector3.zero;
                        }

                    }
                    ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    i = 0;
                    goalPoint = 0;
                    FrameSave = 0;
                    replayFrame = 0;
                    regularUI.enabled = true;
                    replayUI.enabled = false;
                    boundaryRule = false;
                    replayCamera.enabled = false;
                    for (int iii = 0; iii < playerAmt; iii++)
                    {
                        if (players[iii].GetComponent<PlayerScript>())
                        {
                            players[iii].GetComponent<PlayerScript>().face.GetComponent<FaceUIScript>().alphaVar = 0;
                        }
                    }
                    IntroCam.GetComponent<IntroCamera>().playCamera(4);
                    return;
                }
            }
            for (int iii = 0; iii < playerAmt; iii++)
            {
               players[iii].transform.position = replaylocs[iii, i];
                players[iii].transform.eulerAngles = replayRot[iii, i];
            }
            ball.transform.position = replaylocs[playerAmt, i];
            
        }
    }
    public void startReplay()
    {
        replay = true;
        inplay = false;
        regularUI.enabled = false;
        replayUI.enabled = true;
        for (int iii = 0; iii < playerAmt; iii++)
        {
            if (players[iii].GetComponent<PlayerScript>())
            {
                players[iii].GetComponent<PlayerScript>().cam.enabled = false;
            }
        }
        replayCamera.enabled = true;
    }
    public void winStage()
    {
        tempTime += Time.deltaTime;
        
        if (tempTime >= 10)
        {
            string path;
            path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\Profile.txt";
            List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(path));
            System.IO.File.WriteAllText(path, "");
            string[] profileContents= new string[5];
            profileContents[0] = universalGameManager.GetComponent<UniGameManager>().profileName;
            profileContents[1] = "" + universalGameManager.GetComponent<UniGameManager>().profileLvl;
            profileContents[2] = "" + universalGameManager.GetComponent<UniGameManager>().profileXP;
            profileContents[3] = "" + universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp;
            profileContents[4] = fileLines[4];
            File.WriteAllLines(path, profileContents);
            if (teamScore1 > teamScore2 && universalGameManager.GetComponent<UniGameManager>().achievements[1] == false)
            {
                universalGameManager.GetComponent<UniGameManager>().achievements[1] = true;
                path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\AchievementSaves.txt";
                System.IO.File.WriteAllText(path, "");
                string[] contents = new string[universalGameManager.GetComponent<UniGameManager>().achievements.Length];
                for (int i = 0; i < universalGameManager.GetComponent<UniGameManager>().achievements.Length; i++)
                {
                    contents[i] = "" + universalGameManager.GetComponent<UniGameManager>().achievements[i];
                }
                File.WriteAllLines(path, contents);
            }
            //if (universalGameManager.GetComponent<UniGameManager>().seasonModeOn)
            //{
            //    if (universalGameManager.GetComponent<UniGameManager>().GrandFinal)
            //    {
            //        for (int l = 0; l < universalGameManager.GetComponent<UniGameManager>().listOfTeams.Length; l++)
            //        {
            //            universalGameManager.GetComponent<UniGameManager>().listOfTeams[l].GetComponent<TeamScript>().seasonPoints = 0;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().seasonRound = 0;
            //        universalGameManager.GetComponent<UniGameManager>().GrandFinal = false;
            //    }
            //    else
            //    {
            //        if (teamScore1 > teamScore2)
            //        {
            //            universalGameManager.GetComponent<UniGameManager>().team1.GetComponent<TeamScript>().seasonPoints += 2;
            //        }
            //        if (teamScore1 < teamScore2)
            //        {
            //            universalGameManager.GetComponent<UniGameManager>().team2.GetComponent<TeamScript>().seasonPoints += 2;
            //        }
            //        if (teamScore1 == teamScore2)
            //        {
            //            universalGameManager.GetComponent<UniGameManager>().team1.GetComponent<TeamScript>().seasonPoints += 1;
            //            universalGameManager.GetComponent<UniGameManager>().team2.GetComponent<TeamScript>().seasonPoints += 1;
            //        }
            //    }
            //}
            //if (universalGameManager.GetComponent<UniGameManager>().seasonModeOn)
            //{
            //    universalGameManager.GetComponent<UniGameManager>().seasonRound += 1;
            //    SceneManager.LoadScene("SeasonMode");
            //}
            //else
            if (universalGameManager.GetComponent<UniGameManager>().TournamentMode)
            {
                if (teamScore1 > teamScore2)
                {
                    if (universalGameManager.GetComponent<UniGameManager>().round < universalGameManager.GetComponent<UniGameManager>().lockedRounds.Length - 1)
                    {
                        universalGameManager.GetComponent<UniGameManager>().lockedRounds[universalGameManager.GetComponent<UniGameManager>().round + 1] = false;
                    }
                }
                path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\LevelSaves.txt";
                System.IO.File.WriteAllText(path, "");
                string[] contents = new string[universalGameManager.GetComponent<UniGameManager>().lockedRounds.Length];
               
                
                for (int i = 0; i< universalGameManager.GetComponent<UniGameManager>().lockedRounds.Length;i++)
                {
                    contents[i] = "" + universalGameManager.GetComponent<UniGameManager>().lockedRounds[i];
                }
                File.WriteAllLines(path, contents);
                universalGameManager.GetComponent<UniGameManager>().profileXP += 50 + players[0].GetComponent<PlayerScript>().GetMVPPoints();
                while (universalGameManager.GetComponent<UniGameManager>().profileXP > universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp)
                {
                    universalGameManager.GetComponent<UniGameManager>().profileXP -= universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp;
                    universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp = (int)(universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp * 1.25f);
                    universalGameManager.GetComponent<UniGameManager>().profileLvl++;
                }
                SceneManager.LoadScene("TournamentMode");
            }
            else
            {
                //SceneManager.LoadScene("MenuMockUp");
                if (stats == null)
                {
                    universalGameManager.GetComponent<UniGameManager>().profileXP += 50 + players[0].GetComponent<PlayerScript>().GetMVPPoints();
                    while (universalGameManager.GetComponent<UniGameManager>().profileXP > universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp)
                    {
                        universalGameManager.GetComponent<UniGameManager>().profileXP -= universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp;
                        universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp = (int)(universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp * 1.25f);
                        universalGameManager.GetComponent<UniGameManager>().profileLvl++;
                    }
                    stats = Instantiate(statsRef);
                    for (int j = 0; j < playerAmt; j++)
                    {
                        if (getPlayer(j).GetComponent<PlayerScript>())
                        {
                            //var amp = getPlayer(j).GetComponent<PlayerScript>();
                            stats.GetComponent<StatsScript>().setPlayerText(j, getPlayer(j).GetComponent<PlayerScript>().getPlayerName() + " : " + "\n" + "MVP : " + getPlayer(j).GetComponent<PlayerScript>().GetMVPPoints() + "\n" + "Shots Fired : " + getPlayer(j).GetComponent<PlayerScript>().getShots() + "\n" + "Shots Hit : " + getPlayer(j).GetComponent<PlayerScript>().getAccurateShots());
                            //if (isPaintball)
                            {
                                stats.GetComponent<StatsScript>().addPlayerText(j,"\n" + "Kills : " + getPlayer(j).GetComponent<PlayerScript>().GetKills() + "\n" + "Plants : " + getPlayer(j).GetComponent<PlayerScript>().GetPlants() + "\n" +"Defuses : " + getPlayer(j).GetComponent<PlayerScript>().GetDefuses());
                            }
                            //else
                            {
                                stats.GetComponent<StatsScript>().addPlayerText(j, "\n" + "Goals : " + getPlayer(j).GetComponent<PlayerScript>().GetGoals() + "\n" + "Own Goals : " + getPlayer(j).GetComponent<PlayerScript>().GetOwnGoals());
                            }
                        }
                        else if (getPlayer(j).GetComponent<AI>())
                        {
                            //var amp = getPlayer(j).GetComponent<AI>();
                            stats.GetComponent<StatsScript>().setPlayerText(j, getPlayer(j).GetComponent<AI>().getPlayerName() + " : " + "\n" + "MVP : " + getPlayer(j).GetComponent<AI>().GetMVPPoints() + "\n" + "Shots Fired : " + getPlayer(j).GetComponent<AI>().getShots() + "\n" + "Shots Hit : " + getPlayer(j).GetComponent<AI>().getAccurateShots());
                            //if (isPaintball)
                            {
                                stats.GetComponent<StatsScript>().addPlayerText(j, "\n" + "Kills : " + getPlayer(j).GetComponent<AI>().GetKills() + "\n" + "Plants : " + getPlayer(j).GetComponent<AI>().GetPlants() + "\n" + "Defuses : " + getPlayer(j).GetComponent<AI>().GetDefuses());
                            }
                            //else
                            {
                                stats.GetComponent<StatsScript>().addPlayerText(j, "\n" + "Goals : " + getPlayer(j).GetComponent<AI>().GetGoals() + "\n" + "Own Goals : " + getPlayer(j).GetComponent<AI>().GetOwnGoals());
                            }
                        }
                        stats.GetComponent<StatsScript>().addPlayerText(j, "\n" + "Class : " + universalGameManager.GetComponent<UniGameManager>().playerType[j]);
                    }
                }
            }
        }
    }
    public void shutoffcameras()
    {
        for (int iii = 0; iii < playerAmt; iii++)
        {
            if (players[iii].GetComponent<PlayerScript>())
            {
                players[iii].GetComponent<PlayerScript>().cam.enabled = false;
            }
        }
    }
    public void turnoncameras()
    {
        for (int iii = 0; iii < playerAmt; iii++)
        {
            if (players[iii].GetComponent<PlayerScript>())
            {
                players[iii].GetComponent<PlayerScript>().cam.enabled = true;
            }
        }
    }
}
