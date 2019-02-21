using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Spectator : MonoBehaviour {

    //initial speed
    public int speed = 1;
    public GameObject gameMan;
    bool cameraON;

    public Canvas ThisCanvas;

    public RenderTexture textureRender;
    public Image playerCamView;
    //public Sprite tvGrey;

    string endline = "endRecord";
    public GameObject boxref;
    string path;
    public Text timer;
    public Text Score;
    public Text team1Txt;
    public Text team2Txt;
    public Camera thisCam;
    public Text[] banners;

    StreamWriter writer;
    public string team1Name;
    public string team2Name;
    RenderTexture cameraRender;

    public Image[] bannerArray;

    string[] playernames;

    public Image[] goalBanners;

    public Image flag1;
    public Image flag2;

    public Sprite[] flags;

    public Canvas cmdBox;
    public InputField cmdField;

    public Material[] skyboxes;
    int skyboxNo;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    float[] alphaVar;

    int frameToLookAt;
    int playerNo;
    bool followPlay;

    bool recording;
    bool recordStart;
    List<string> fileLines;
    int watchLine;

    int tickrate = 32;

    string pathToWatch;

    float frameRecord;
    float timePassed;

    bool watching;
    bool finishrecord;
    // Use this for initialization
    public void goalBanner(int playerNum)
    {
        alphaVar[playerNum] = 1;
        goalBanners[playerNum].color = new Vector4(goalBanners[playerNum].color.r, goalBanners[playerNum].color.g, goalBanners[playerNum].color.b, alphaVar[playerNum]);
    }

    



    void Start()
    {
        playerCamView.enabled = false;
        tickrate = 32;
        frameRecord = 1 / tickrate;
        watchLine = 3;
        recordStart = true;
        playernames = new string[4];
        for (int i = 0; i < playernames.Length; i ++)
        {
            playernames[i] = "Player " + (i + 1);
        }
        team1Name = gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().teamname1;
        team2Name = gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().teamname2;
        cmdBox.enabled = false;
        skyboxNo = 0;
        bannerArray[0].sprite = gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().banner1;
        bannerArray[1].sprite = gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().banner2;
        bannerArray[2].sprite = gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().banner1;
        bannerArray[3].sprite = gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().banner2;
        alphaVar = new float[gameMan.GetComponent<sportsballManager>().playerAmt];
        if (gameMan.GetComponent<sportsballManager>().playerAmt < 4)
        {
            bannerArray[3].color = new Vector4(0, 0, 0, 0);
        }
        if (gameMan.GetComponent<sportsballManager>().playerAmt < 3)
        {
            bannerArray[2].color = new Vector4(0, 0, 0, 0);
        }
        if (gameMan.GetComponent<sportsballManager>().playerAmt < 2)
        {
            bannerArray[1].color = new Vector4(0, 0, 0, 0);
        }
        for (int i = 0; i < gameMan.GetComponent<sportsballManager>().playerAmt; i++)
        {
            if (goalBanners[i].color.a > 0)
            {
                alphaVar[i] = goalBanners[i].color.a;
                goalBanners[i].color = new Vector4(goalBanners[i].color.r, goalBanners[i].color.g, goalBanners[i].color.b, alphaVar[i]);
            }
        }

        followPlay = false;
        playerNo = 0;
        for (int i = 0; i < banners.Length;i++)
        {
            banners[i].text = " ";
        }
        if (Display.displays.Length > 1)
        {
            if (Display.displays[0] != Display.main)
            {
                thisCam.targetDisplay = 1;
                if (!Display.displays[0].active)
                {
                    Display.displays[0].Activate();
                }
            }
            else
            {
                if (!Display.displays[1].active)
                {
                    Display.displays[1].Activate();
                }
            }
        }
        if (!gameMan.GetComponent<sportsballManager>().isPaintball)
        {
            this.transform.LookAt(gameMan.GetComponent<sportsballManager>().ball.transform);
            this.transform.position = new Vector3(gameMan.GetComponent<sportsballManager>().ball.transform.position.x - 5, 8, gameMan.GetComponent<sportsballManager>().ball.transform.position.z - 5);
        }


        if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballDemos"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballDemos");
            
        }
        
        
    }
    public Texture2D getScreenshot(Camera camUsed)
    {
        Rect originalRect = camUsed.rect;
        camUsed.rect = new Rect(0, 0, 1, 1);
        camUsed.targetTexture = textureRender;
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = camUsed.targetTexture;
        camUsed.Render();
        Texture2D image = new Texture2D(camUsed.targetTexture.width, camUsed.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camUsed.targetTexture.width, camUsed.targetTexture.height ), 0, 0);
        image.Apply();
        RenderTexture.active = currentRT;
        camUsed.targetTexture = null;
        camUsed.rect = originalRect;
        return image;
    }
    // Update is called once per frame
    void Update()
    {
        #region recording
        timePassed += Time.deltaTime;
        if (recording && timePassed >= frameRecord)
        {
            RecordMatch();
            frameRecord -= 1 / 32;
        }
        if (watching && timePassed >= frameRecord)
        {
            WatchMatch(pathToWatch);
            frameRecord -= 1 / 32;
        }


        #endregion
        if (gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).GetComponent<PlayerScript>() && playerCamView.enabled)
        {
            Texture2D tempTex = getScreenshot(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).GetComponent<PlayerScript>().cam);
            Sprite tempSprite = Sprite.Create(tempTex, new Rect(0, 0,tempTex.width,tempTex.height), Vector2.zero, 1);
            playerCamView.sprite = tempSprite;
        }
        if (!gameMan.GetComponent<sportsballManager>().GetPaused() && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            frameToLookAt = gameMan.GetComponent<sportsballManager>().getFrameSave();
            if (frameToLookAt > 997)
            {
                frameToLookAt = 997;
            }
        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            if (gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
            {
                if (!gameMan.GetComponent<sportsballManager>().GetPaused())
                {
                    gameMan.GetComponent<sportsballManager>().SetPaused(true);
                    Time.timeScale = 0;
                }
                else
                {
                    gameMan.GetComponent<sportsballManager>().SetPaused(false);
                    Time.timeScale = 1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F10) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
                gameMan.GetComponent<sportsballManager>().addSeconds(1);
        }
        if (Input.GetKeyDown(KeyCode.F12) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
                gameMan.GetComponent<sportsballManager>().addSeconds(-1);
        }
        if (Input.GetKeyDown(KeyCode.F9) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                for (int iii = 0; iii < gameMan.GetComponent<sportsballManager>().playerAmt; iii++)
                {
                    if (gameMan.GetComponent<sportsballManager>().getPlayer(iii).GetComponent<PlayerScript>())
                    {
                        gameMan.GetComponent<sportsballManager>().getPlayer(iii).transform.position = gameMan.GetComponent<sportsballManager>().getPlayer(iii).GetComponent<PlayerScript>().m_SpawnLoc.transform.position;
                        gameMan.GetComponent<sportsballManager>().getPlayer(iii).GetComponent<Rigidbody>().velocity = Vector3.zero;
                        gameMan.GetComponent<sportsballManager>().getPlayer(iii).GetComponent<PlayerScript>().cam.enabled = true;
                    }
                    else
                    {
                        gameMan.GetComponent<sportsballManager>().getPlayer(iii).transform.position = gameMan.GetComponent<sportsballManager>().getPlayer(iii).GetComponent<AI>().m_SpawnLoc.transform.position;
                        gameMan.GetComponent<sportsballManager>().getPlayer(iii).GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }

                }
                gameMan.GetComponent<sportsballManager>().ball.transform.position = new Vector3(0, 6.25f, 0);
                gameMan.GetComponent<sportsballManager>().ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        if (Input.GetKeyDown(KeyCode.F8) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                gameMan.GetComponent<sportsballManager>().DecreaseScore("Team2");
            }
        }
        if (Input.GetKeyDown(KeyCode.F7) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                gameMan.GetComponent<sportsballManager>().DecreaseScore("Team1");
            }
        }
        if (Input.GetKeyDown(KeyCode.F6) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                gameMan.GetComponent<sportsballManager>().AddScore("Team2");
            }
        }
        if (Input.GetKeyDown(KeyCode.F5) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                gameMan.GetComponent<sportsballManager>().AddScore("Team1");
            }
        }
        if (Input.GetKeyDown(KeyCode.F4) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            frameToLookAt = gameMan.GetComponent<sportsballManager>().getFrameSave() - 1;
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                gameMan.GetComponent<sportsballManager>().playReplay(frameToLookAt, frameToLookAt);
            }
        }
        if (Input.GetKey(KeyCode.F3) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                frameToLookAt++;
                if (frameToLookAt > gameMan.GetComponent<sportsballManager>().getFrameSave() - 1)
                {
                    frameToLookAt = gameMan.GetComponent<sportsballManager>().getFrameSave() - 1;
                }
                if (frameToLookAt > 997)
                {
                    frameToLookAt = 997;
                }
                gameMan.GetComponent<sportsballManager>().playReplay(frameToLookAt, gameMan.GetComponent<sportsballManager>().getFrameSave());
            }
        }
        if (Input.GetKey(KeyCode.F2) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                frameToLookAt--;
                if (frameToLookAt < 0)
                {
                    frameToLookAt = 0;
                }
                gameMan.GetComponent<sportsballManager>().playReplay(frameToLookAt, gameMan.GetComponent<sportsballManager>().getFrameSave());
            }
        }
        if (Input.GetKeyDown(KeyCode.F1) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            if (gameMan.GetComponent<sportsballManager>().GetPaused())
            {
                frameToLookAt = 0;
                gameMan.GetComponent<sportsballManager>().playReplay(frameToLookAt, gameMan.GetComponent<sportsballManager>().getFrameSave());
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad9) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            cmdBox.enabled = !cmdBox.enabled;
            if (cmdBox.enabled)
            {
                cmdField.Select();
                cmdField.ActivateInputField();
                cmdField.text = "";
            }
        }
        if (Input.GetKeyDown(KeyCode.BackQuote) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            cmdBox.enabled = !cmdBox.enabled;
            if (cmdBox.enabled)
            {
                cmdField.Select();
                cmdField.ActivateInputField();
                cmdField.text = "";
            }
        }
        if (Input.GetKeyDown(KeyCode.V) && !cmdBox.enabled)
        {
            playerCamView.enabled = !playerCamView.enabled;
        }
        if (Input.GetKeyDown(KeyCode.Semicolon) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {

            if (cmdField.enabled)
            {
                cmdField.DeactivateInputField();
                string stringGrab = cmdField.text;
                string cmd = cmdField.text.ToLower();
                if (cmd.Length > 5)
                {
                    if (cmd.Substring(0, 6) == "team1_")
                    {
                        team1Name = stringGrab.Substring(6, stringGrab.Length - 6);
                    }
                    else if (cmd.Substring(0, 6) == "team2_")
                    {
                        team2Name = stringGrab.Substring(6, stringGrab.Length - 6);
                    }
                }
                if (cmd.Length > 6)
                {
                    if (cmd.Substring(0, 7) == "record_")
                    {
                        if (!recording)
                        {
                            path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballDemos\\" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
                            System.IO.File.WriteAllText(path, "");
                            recording = true;
                            tickrate = int.Parse(stringGrab.Substring(7, stringGrab.Length - 7));
                        }
                    }
                }
                    if (cmd.Length > 7)
                {
                    if (cmd.Substring(0, 8) == "player1_")
                    {
                        playernames[0] = stringGrab.Substring(8, stringGrab.Length - 8);
                        if (gameMan.GetComponent<sportsballManager>().getPlayer(0).GetComponent<PlayerScript>())
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(0).GetComponent<PlayerScript>().setPlayerName(playernames[0]);
                        }
                        else if(gameMan.GetComponent<sportsballManager>().getPlayer(0).GetComponent<AI>())
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(0).GetComponent<AI>().setPlayerName(playernames[0]);
                        }
                    }
                    else if (cmd.Substring(0, 8) == "player2_")
                    {
                        playernames[1] = stringGrab.Substring(8, stringGrab.Length - 8);
                        if (gameMan.GetComponent<sportsballManager>().getPlayer(1).GetComponent<PlayerScript>())
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(1).GetComponent<PlayerScript>().setPlayerName(playernames[1]);
                        }
                        else if (gameMan.GetComponent<sportsballManager>().getPlayer(1).GetComponent<AI>())
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(1).GetComponent<AI>().setPlayerName(playernames[1]);
                        }
                    }
                    else if (cmd.Substring(0, 8) == "player3_")
                    {
                        playernames[2] = stringGrab.Substring(8, stringGrab.Length - 8);
                        if (gameMan.GetComponent<sportsballManager>().getPlayer(2).GetComponent<PlayerScript>())
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(2).GetComponent<PlayerScript>().setPlayerName(playernames[2]);
                        }
                        else if (gameMan.GetComponent<sportsballManager>().getPlayer(2).GetComponent<AI>())
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(2).GetComponent<AI>().setPlayerName(playernames[2]);
                        }
                    }
                    else if (cmd.Substring(0, 8) == "player4_")
                    {
                        playernames[3] = stringGrab.Substring(8, stringGrab.Length - 8);
                        if (gameMan.GetComponent<sportsballManager>().getPlayer(3).GetComponent<PlayerScript>())
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(3).GetComponent<PlayerScript>().setPlayerName(playernames[3]);
                        }
                        else if (gameMan.GetComponent<sportsballManager>().getPlayer(3).GetComponent<AI>())
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(3).GetComponent<AI>().setPlayerName(playernames[3]);
                        }
                    }
                    if (cmd.Substring(0, 8) == "timeadd_")
                    {
                        gameMan.GetComponent<sportsballManager>().addSeconds(int.Parse(stringGrab.Substring(8, stringGrab.Length - 8)));
                    }
                }
                if (cmd.Length > 9)
                {
                    if (cmd.Substring(0, 10) == "loadscene_")
                    {
                        string sceneload = stringGrab.Substring(10, stringGrab.Length - 10);
                        if (Application.CanStreamedLevelBeLoaded(sceneload))
                        {
                            SceneManager.LoadScene(sceneload);
                        }
                    }
                }
                if (cmd.Length > 9)
                {
                    if (cmd.Substring(0, 10) == "teamflag1_")
                    {
                        string flagSwap = cmd.Substring(10, cmd.Length - 10);
                        setFlag(flag1, flagSwap);
                    }
                    else if (cmd.Substring(0, 10) == "teamflag2_")
                    {
                        string flagSwap = cmd.Substring(10, cmd.Length - 10);
                        setFlag(flag2, flagSwap);

                    }
                }
                if (cmd.Length > 11)
                {
                   if (cmd.Substring(0,12) == "watchreplay_")
                    {
                        
                        pathToWatch = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballDemos\\" + stringGrab.Substring(12, stringGrab.Length - 12) + ".txt";
                        if (System.IO.File.Exists(pathToWatch))
                        {
                            watching = true;
                        }
                    }
                }
                switch (cmd)
                {
                    case "pause":
                        gameMan.GetComponent<sportsballManager>().SetPaused(true);
                        Time.timeScale = 0;
                        break;
                    case "resume":
                        gameMan.GetComponent<sportsballManager>().SetPaused(false);
                        Time.timeScale = 1;
                        break;
                    case "speedup":
                        Time.timeScale = 2;
                        break;
                    case "slowdown":
                        Time.timeScale = 0.5f;
                        break;
                    case "dropbox":
                        GameObject newBox = Instantiate(boxref);
                        newBox.transform.position = this.transform.position;
                        newBox.AddComponent<paintSplats>();
                        break;
                    case "startreplay":
                        gameMan.GetComponent<sportsballManager>().startReplay();
                        break;
                    case "noclip":
                        for (int ii = 0; ii < gameMan.GetComponent<sportsballManager>().playerAmt; ii++)
                        {
                            gameMan.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<CapsuleCollider>().enabled = !gameMan.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<CapsuleCollider>().enabled;
                            gameMan.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<Rigidbody>().isKinematic = !gameMan.GetComponent<sportsballManager>().getPlayer(ii).GetComponent<Rigidbody>().isKinematic;
                            
                        }
                        break;
                    case "record":
                        if (!recording)
                        {
                            path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballDemos\\" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
                            System.IO.File.WriteAllText(path, "");
                            recording = true;
                        }                      
                        break;
                    case "recordstop":
                        finishrecord = true;
                        break;
                    default:
                        break;
                }

              
                cmdField.text = "";
                cmdField.ActivateInputField();
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad7) && gameMan.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().spectateCheats == true)
        {
            skyboxNo++;
            if (skyboxNo > skyboxes.Length - 1)
            {
                skyboxNo = 0;
            }
            RenderSettings.skybox = skyboxes[skyboxNo];
        }
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Semicolon))
        {
            if (cmdBox.enabled)
            {
                string newChar = Input.inputString;
                if (cmdField.enabled)
                {
                    cmdField.text += newChar;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (cmdField.enabled && cmdField.text.Length > 1)
            {
                cmdField.text = cmdField.text.Substring(0,cmdField.text.Length-2);
            }
        }

            #region UIStuff
       if (gameMan.GetComponent<sportsballManager>().overtime)
        {
            //score.text = gameMan.GetComponent<sportsballManager>().getTeam1Score() + " : " + gameMan.GetComponent<sportsballManager>().getTeam2Score();
            timer.text = "| OVERTIME |";
        }
        else
        {
            int minutes;
            int secondsToUse;
            minutes = gameMan.GetComponent<sportsballManager>().getSeconds() / 60;
            secondsToUse = gameMan.GetComponent<sportsballManager>().getSeconds() - (minutes * 60);
            if (secondsToUse < 10)
            {
                timer.text = "| " + minutes + ":0" + secondsToUse + " |";
            }
            else
            {
                timer.text = "| " + minutes + ":" + secondsToUse + " |";
            }



        }
        for (int i = 0; i < gameMan.GetComponent<sportsballManager>().playerAmt; i++)
        {
            if (goalBanners[i].color.a > 0)
            {
                alphaVar[i] -= 0.01f;
                goalBanners[i].color = new Vector4(goalBanners[i].color.r, goalBanners[i].color.g, goalBanners[i].color.b, alphaVar[i]);
            }
        }

        Score.text = gameMan.GetComponent<sportsballManager>().getTeam1Score() + " | " + gameMan.GetComponent<sportsballManager>().getTeam2Score();
        team1Txt.text = "| " + team1Name + " : ";
        team2Txt.text = " : " + team2Name + " | ";
        for (int i = 0; i < gameMan.GetComponent<sportsballManager>().playerAmt; i++)
        {
            if (gameMan.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>())
            {
                banners[i].text = playernames[i] + " | " + gameMan.GetComponent<sportsballManager>().getPlayer(i).GetComponent<PlayerScript>().GetMVPPoints();
            }
            else if (gameMan.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>())
            {
                banners[i].text = playernames[i] + " | " + gameMan.GetComponent<sportsballManager>().getPlayer(i).GetComponent<AI>().GetMVPPoints();
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && cmdBox.enabled == false)
        {
            ThisCanvas.enabled = !ThisCanvas.enabled;
        }
        #endregion




        
        //press shift to move faster
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            if (followPlay)
            {
                playerNo++;
                if (playerNo >= gameMan.GetComponent<sportsballManager>().playerAmt)
                {
                    playerNo = 0;
                    followPlay = false;
                }
                else
                {
                    transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);
                    transform.position = gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform.position + new Vector3(3f, 3f, 3f);
                }
            }
            else
            {
                followPlay = true;
                transform.position = gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform.position + new Vector3(3f, 3f, 3f);
                transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);
            }
        }
        if ((Input.GetKeyDown(KeyCode.F)) && !cmdBox.enabled)
        {
            playerNo = 0;
            followPlay = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !cmdBox.enabled || Input.GetKeyDown(KeyCode.Keypad1) && !cmdBox.enabled)
        {
            playerNo = 0;
            followPlay = true;
            transform.position = gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform.position + new Vector3(3f, 3f, 3f);
            transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !cmdBox.enabled || Input.GetKeyDown(KeyCode.Keypad2) && !cmdBox.enabled)
        {
            if (gameMan.GetComponent<sportsballManager>().playerAmt > 1)
            {
                playerNo = 1;
                followPlay = true;
                transform.position = gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform.position + new Vector3(3f, 3f, 3f);
                transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !cmdBox.enabled || Input.GetKeyDown(KeyCode.Keypad3) && !cmdBox.enabled)
        {
            if (gameMan.GetComponent<sportsballManager>().playerAmt > 2)
            {
                playerNo = 2;
                followPlay = true;
                transform.position = gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform.position + new Vector3(3f, 3f, 3f);
                transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);
                
            }          
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && !cmdBox.enabled || Input.GetKeyDown(KeyCode.Keypad4) && !cmdBox.enabled)
        {
            if (gameMan.GetComponent<sportsballManager>().playerAmt > 3)
            {
                playerNo = 3;
                followPlay = true;
                transform.position = gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform.position + new Vector3(3f, 3f, 3f);
                transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);
                
            }
        }



        if (!followPlay)
        {
            yaw += speedH * Input.GetAxis("MouseX");
            pitch -= speedV * Input.GetAxis("MouseY");

            thisCam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speed = 4;

            }
            else
            {
                //if shift is not pressed, reset to default speed
                speed = 1;
            }
            //For the following 'if statements' don't include 'else if', so that the user can press multiple buttons at the same time
            //move camera to the left
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position + thisCam.transform.right * -1 * speed;
            }

            //move camera backwards
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = transform.position + thisCam.transform.forward * -1 * speed;

            }
            //move camera to the right
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + thisCam.transform.right * speed;

            }
            //move camera forward
            if (Input.GetKey(KeyCode.W))
            {

                transform.position = transform.position + thisCam.transform.forward * speed;
            }
            //move camera upwards
            if (Input.GetKey(KeyCode.E))
            {
                transform.position = transform.position + thisCam.transform.up * speed;
            }
            //move camera downwards
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position = transform.position + thisCam.transform.up * -1 * speed;
            }
        }  
        else
        {
            transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);
            if (Input.GetKey(KeyCode.E))
            {
                //transform.RotateAround((gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform.position),transform.position, 10);
                transform.Translate(Vector3.right * 2);
                transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);

            }
            if (Input.GetKey(KeyCode.Q))
            {
                //transform.RotateAround((gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform.position),transform.position, 10);
                transform.Translate(Vector3.right * -2);
                transform.LookAt(gameMan.GetComponent<sportsballManager>().getPlayer(playerNo).transform);

            }


        }

    }
    
    public void RecordMatch()
    {
        StreamWriter writer = new StreamWriter(path, true);
        if (finishrecord)
        {
            writer.WriteLine(endline);
            finishrecord = false;
            recording = false;
            recordStart = true;
        }
        else
        {
            if (recordStart)
            {
                writer.WriteLine("" + SceneManager.GetActiveScene().name);
                writer.WriteLine("" + gameMan.GetComponent<sportsballManager>().playerAmt);
                writer.WriteLine("" + tickrate);
                recordStart = false;
            }
            writer.WriteLine(gameMan.GetComponent<sportsballManager>().getSeconds());
            for (int j = 0; j < gameMan.GetComponent<sportsballManager>().playerAmt; j++)
            {
                writer.WriteLine(gameMan.GetComponent<sportsballManager>().getPlayer(j).transform.position);
                writer.WriteLine(gameMan.GetComponent<sportsballManager>().getPlayer(j).transform.eulerAngles);
                if (gameMan.GetComponent<sportsballManager>().getPlayer(j).GetComponent<PlayerScript>())
                {
                    writer.WriteLine(gameMan.GetComponent<sportsballManager>().getPlayer(j).GetComponent<PlayerScript>().GetMVPPoints());
                }
                else if (gameMan.GetComponent<sportsballManager>().getPlayer(j).GetComponent<AI>())
                {
                    writer.WriteLine(gameMan.GetComponent<sportsballManager>().getPlayer(j).GetComponent<AI>().GetMVPPoints());
                }
            }
            writer.WriteLine(gameMan.GetComponent<sportsballManager>().ball.transform.position);
            writer.WriteLine(gameMan.GetComponent<sportsballManager>().getTeam1Score());
            writer.WriteLine(gameMan.GetComponent<sportsballManager>().getTeam2Score());
            writer.Close();
        }
    }

    public void WatchMatch(string pathWatch)
    {
       // Debug.Log("Watching");
        fileLines = new List<string>(System.IO.File.ReadAllLines(pathWatch));
        if (fileLines[watchLine] == null || fileLines[watchLine] == "endRecord")
        {
            //Debug.Log("nullissue");
            watching = false;
            watchLine = 3;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
        int result1;
        int.TryParse(fileLines[1], out result1);
        int.TryParse(fileLines[2], out tickrate);
        if (SceneManager.GetActiveScene().name == fileLines[0] && gameMan.GetComponent<sportsballManager>().playerAmt == result1)
        {
            int result4;
            int.TryParse(fileLines[watchLine], out result4);
            gameMan.GetComponent<sportsballManager>().setSeconds(result4);
            watchLine++;
            for (int k = 0; k < result1; k++)
            {
                gameMan.GetComponent<sportsballManager>().getPlayer(k).transform.position = stringToVector(fileLines[watchLine]);
                watchLine++;
                gameMan.GetComponent<sportsballManager>().getPlayer(k).transform.eulerAngles = stringToVector(fileLines[watchLine]);
                watchLine++;
                if (gameMan.GetComponent<sportsballManager>().getPlayer(k).GetComponent<PlayerScript>())
                {
                    int result5;
                    int.TryParse(fileLines[watchLine], out result5);
                    gameMan.GetComponent<sportsballManager>().getPlayer(k).GetComponent<PlayerScript>().SetMVPPoints(result5);
                }
                else if (gameMan.GetComponent<sportsballManager>().getPlayer(k).GetComponent<AI>())
                {
                    int result5;
                    int.TryParse(fileLines[watchLine], out result5);
                    gameMan.GetComponent<sportsballManager>().getPlayer(k).GetComponent<AI>().SetMVPPoints(result5);
                }
                watchLine++;
            }
            gameMan.GetComponent<sportsballManager>().ball.transform.position = stringToVector(fileLines[watchLine]);
            watchLine++;
            int result2;
            int.TryParse(fileLines[watchLine], out result2);
            gameMan.GetComponent<sportsballManager>().setTeam1Score(result2);
            watchLine++;
            int result3;
            int.TryParse(fileLines[watchLine], out result3);
            gameMan.GetComponent<sportsballManager>().setTeam2Score(result3);
            watchLine++;
        }
        else
        {
            watching = false;
        }
    }

    public static Vector3 stringToVector(string a_vector)
    {
        a_vector = a_vector.Substring(1, a_vector.Length - 2);
        string[] vectorpoints = a_vector.Split(',');
        //Debug.Log(vectorpoints.Length);
        float resultx, resulty, resultz;
        float.TryParse(vectorpoints[0], out resultx);
        float.TryParse(vectorpoints[1], out resulty);
        float.TryParse(vectorpoints[2], out resultz);
        Vector3 output = new Vector3(resultx, resulty, resultz);
        return output;


    }
    public void setFlag(Image flagImg, string flagCode)
    {
        switch (flagCode)
        {
            case "afg":
                flagImg.sprite = flags[1];
                break;
            case "ago":
                flagImg.sprite = flags[2];
                break;
            case "alb":
                flagImg.sprite = flags[3];
                break;
            case "and":
                flagImg.sprite = flags[4];
                break;
            case "are":
                flagImg.sprite = flags[5];
                break;
            case "arg":
                flagImg.sprite = flags[6];
                break;
            case "arm":
                flagImg.sprite = flags[7];
                break;
            case "atg":
                flagImg.sprite = flags[8];
                break;
            case "aus":
                flagImg.sprite = flags[9];
                break;
            case "aut":
                flagImg.sprite = flags[10];
                break;
            case "aze":
                flagImg.sprite = flags[11];
                break;
            case "bdi":
                flagImg.sprite = flags[12];
                break;
            case "bel":
                flagImg.sprite = flags[13];
                break;
            case "ben":
                flagImg.sprite = flags[14];
                break;
            case "bgd":
                flagImg.sprite = flags[15];
                break;
            case "bgr":
                flagImg.sprite = flags[16];
                break;
            case "bhr":
                flagImg.sprite = flags[17];
                break;
            case "bhs":
                flagImg.sprite = flags[18];
                break;
            case "bih":
                flagImg.sprite = flags[19];
                break;
            case "blr":
                flagImg.sprite = flags[20];
                break;
            case "blz":
                flagImg.sprite = flags[21];
                break;
            case "bol":
                flagImg.sprite = flags[22];
                break;
            case "bra":
                flagImg.sprite = flags[23];
                break;
            case "brb":
                flagImg.sprite = flags[24];
                break;
            case "btn":
                flagImg.sprite = flags[25];
                break;
            case "bwa":
                flagImg.sprite = flags[26];
                break;
            case "caf":
                flagImg.sprite = flags[27];
                break;
            case "can":
                flagImg.sprite = flags[28];
                break;
            case "che":
                flagImg.sprite = flags[29];
                break;
            case "chl":
                flagImg.sprite = flags[30];
                break;
            case "chn":
                flagImg.sprite = flags[31];
                break;
            case "civ": //ivory coast http://www.nationsonline.org/oneworld/country_code_list.htm
                flagImg.sprite = flags[32];
                break;
            case "cmr":
                flagImg.sprite = flags[33];
                break;
            case "cod":
                flagImg.sprite = flags[34];
                break;
            case "cog":
                flagImg.sprite = flags[35];
                break;
            case "col":
                flagImg.sprite = flags[36];
                break;
            case "com":
                flagImg.sprite = flags[37];
                break;
            case "cri":
                flagImg.sprite = flags[38];
                break;
            case "cub":
                flagImg.sprite = flags[39];
                break;
            case "cym":
                flagImg.sprite = flags[40];
                break;
            case "cyp":
                flagImg.sprite = flags[41];
                break;
            case "cze":
                flagImg.sprite = flags[42];
                break;
            case "deu":
                flagImg.sprite = flags[43];
                break;
            case "dji":
                flagImg.sprite = flags[44];
                break;
            case "dma":
                flagImg.sprite = flags[45];
                break;
            case "dnk":
                flagImg.sprite = flags[46];
                break;
            case "dom":
                flagImg.sprite = flags[47];
                break;
            case "dza":
                flagImg.sprite = flags[48];
                break;
            case "ecu":
                flagImg.sprite = flags[49];
                break;
            case "egy":
                flagImg.sprite = flags[50];
                break;
            case "eri":
                flagImg.sprite = flags[51];
                break;
            case "esp":
                flagImg.sprite = flags[52];
                break;
            case "est":
                flagImg.sprite = flags[53];
                break;
            case "eth":
                flagImg.sprite = flags[54];
                break;
            case "fin":
                flagImg.sprite = flags[55];
                break;
            case "fji":
                flagImg.sprite = flags[56];
                break;
            case "fra":
                flagImg.sprite = flags[57];
                break;
            case "fsm":
                flagImg.sprite = flags[58];
                break;
            case "gab":
                flagImg.sprite = flags[59];
                break;
            case "gbr":
                flagImg.sprite = flags[60];
                break;
            case "geo":
                flagImg.sprite = flags[61];
                break;
            case "gha":
                flagImg.sprite = flags[62];
                break;
            case "gin":
                flagImg.sprite = flags[63];
                break;
            case "gmb":
                flagImg.sprite = flags[64];
                break;
            case "gnb":
                flagImg.sprite = flags[65];
                break;
            case "gnq":
                flagImg.sprite = flags[66];
                break;
            case "grc":
                flagImg.sprite = flags[67];
                break;
            case "grd":
                flagImg.sprite = flags[68];
                break;
            case "gtm":
                flagImg.sprite = flags[69];
                break;
            case "guy":
                flagImg.sprite = flags[70];
                break;
            case "hnd":
                flagImg.sprite = flags[71];
                break;
            case "hrv":
                flagImg.sprite = flags[72];
                break;
            case "hti":
                flagImg.sprite = flags[73];
                break;
            case "hun":
                flagImg.sprite = flags[74];
                break;
            case "idn":
                flagImg.sprite = flags[75];
                break;
            case "ind":
                flagImg.sprite = flags[76];
                break;
            case "irl":
                flagImg.sprite = flags[77];
                break;
            case "irn":
                flagImg.sprite = flags[78];
                break;
            case "irq":
                flagImg.sprite = flags[79];
                break;
            case "isl":
                flagImg.sprite = flags[80];
                break;
            case "isr":
                flagImg.sprite = flags[81];
                break;
            case "ita":
                flagImg.sprite = flags[82];
                break;
            case "jam":
                flagImg.sprite = flags[83];
                break;
            case "jor":
                flagImg.sprite = flags[84];
                break;
            case "jpn":
                flagImg.sprite = flags[85];
                break;
            case "kaz":
                flagImg.sprite = flags[86];
                break;
            case "ken":
                flagImg.sprite = flags[87];
                break;
            case "kgz":
                flagImg.sprite = flags[88];
                break;
            case "khm":
                flagImg.sprite = flags[89];
                break;
            case "kir":
                flagImg.sprite = flags[90];
                break;
            case "kna":
                flagImg.sprite = flags[91];
                break;
            case "kor":
                flagImg.sprite = flags[92];
                break;
            case "kwt":
                flagImg.sprite = flags[93];
                break;
            case "lao":
                flagImg.sprite = flags[94];
                break;
            case "lbn":
                flagImg.sprite = flags[95];
                break;
            case "lbr":
                flagImg.sprite = flags[96];
                break;
            case "lby":
                flagImg.sprite = flags[97];
                break;
            case "lca":
                flagImg.sprite = flags[98];
                break;
            case "lie":
                flagImg.sprite = flags[99];
                break;
            case "lka":
                flagImg.sprite = flags[100];
                break;
            case "lso":
                flagImg.sprite = flags[101];
                break;
            case "ltu":
                flagImg.sprite = flags[102];
                break;
            case "lux":
                flagImg.sprite = flags[103];
                break;
            case "lva":
                flagImg.sprite = flags[104];
                break;
            case "mar":
                flagImg.sprite = flags[105];
                break;
            case "mco":
                flagImg.sprite = flags[106];
                break;
            case "mda":
                flagImg.sprite = flags[107];
                break;
            case "mdg":
                flagImg.sprite = flags[108];
                break;
            case "mdv":
                flagImg.sprite = flags[109];
                break;
            case "mex":
                flagImg.sprite = flags[110];
                break;
            case "mhl":
                flagImg.sprite = flags[111];
                break;
            case "mkd":
                flagImg.sprite = flags[112];
                break;
            case "mli":
                flagImg.sprite = flags[113];
                break;
            case "mlt":
                flagImg.sprite = flags[114];
                break;
            case "mmr":
                flagImg.sprite = flags[115];
                break;
            case "mne":
                flagImg.sprite = flags[116];
                break;
            case "mng":
                flagImg.sprite = flags[117];
                break;
            case "moz":
                flagImg.sprite = flags[118];
                break;
            case "mrt":
                flagImg.sprite = flags[119];
                break;
            case "mus":
                flagImg.sprite = flags[120];
                break;
            case "mwi":
                flagImg.sprite = flags[121];
                break;
            case "mys":
                flagImg.sprite = flags[122];
                break;
            case "nam":
                flagImg.sprite = flags[123];
                break;
            case "ner":
                flagImg.sprite = flags[124];
                break;
            case "nga":
                flagImg.sprite = flags[125];
                break;
            case "nic":
                flagImg.sprite = flags[126];
                break;
            case "nld":
                flagImg.sprite = flags[127];
                break;
            case "nor":
                flagImg.sprite = flags[128];
                break;
            case "npl":
                flagImg.sprite = flags[129];
                break;
            case "nru":
                flagImg.sprite = flags[130];
                break;
            case "nzl":
                flagImg.sprite = flags[131];
                break;
            case "omn":
                flagImg.sprite = flags[132];
                break;
            case "pak":
                flagImg.sprite = flags[133];
                break;
            case "pan":
                flagImg.sprite = flags[134];
                break;
            case "per":
                flagImg.sprite = flags[135];
                break;
            case "plw":
                flagImg.sprite = flags[136];
                break;
            case "png":
                flagImg.sprite = flags[137];
                break;
            case "pol":
                flagImg.sprite = flags[138];
                break;
            case "prk":
                flagImg.sprite = flags[139];
                break;
            case "prt":
                flagImg.sprite = flags[140];
                break;
            case "pry":
                flagImg.sprite = flags[141];
                break;
            case "pse":
                flagImg.sprite = flags[142];
                break;
            case "qat":
                flagImg.sprite = flags[143];
                break;
            case "rou":
                flagImg.sprite = flags[144];
                break;
            case "rus":
                flagImg.sprite = flags[145];
                break;
            case "rwa":
                flagImg.sprite = flags[146];
                break;
            case "sau":
                flagImg.sprite = flags[147];
                break;
            case "sdn":
                flagImg.sprite = flags[148];
                break;
            case "sen":
                flagImg.sprite = flags[149];
                break;
            case "sgp":
                flagImg.sprite = flags[150];
                break;
            case "slb":
                flagImg.sprite = flags[151];
                break;
            case "sle":
                flagImg.sprite = flags[152];
                break;
            case "slv":
                flagImg.sprite = flags[153];
                break;
            case "smr":
                flagImg.sprite = flags[154];
                break;
            case "som":
                flagImg.sprite = flags[155];
                break;
            case "srb":
                flagImg.sprite = flags[156];
                break;
            case "ssd":
                flagImg.sprite = flags[157];
                break;
            case "stp":
                flagImg.sprite = flags[158];
                break;
            case "sur":
                flagImg.sprite = flags[159];
                break;
            case "svk":
                flagImg.sprite = flags[160];
                break;
            case "svn":
                flagImg.sprite = flags[161];
                break;
            case "swe":
                flagImg.sprite = flags[162];
                break;
            case "syc":
                flagImg.sprite = flags[163];
                break;
            case "syr":
                flagImg.sprite = flags[164];
                break;
            case "tcd":
                flagImg.sprite = flags[165];
                break;
            case "tgo":
                flagImg.sprite = flags[166];
                break;
            case "tha":
                flagImg.sprite = flags[167];
                break;
            case "tjk":
                flagImg.sprite = flags[168];
                break;
            case "tkm":
                flagImg.sprite = flags[169];
                break;
            case "tls":
                flagImg.sprite = flags[170];
                break;
            case "ton":
                flagImg.sprite = flags[171];
                break;
            case "tto":
                flagImg.sprite = flags[172];
                break;
            case "tun":
                flagImg.sprite = flags[173];
                break;
            case "tur":
                flagImg.sprite = flags[174];
                break;
            case "tuv":
                flagImg.sprite = flags[175];
                break;
            case "twn":
                flagImg.sprite = flags[176];
                break;
            case "tza":
                flagImg.sprite = flags[177];
                break;
            case "uga":
                flagImg.sprite = flags[178];
                break;
            case "ukr":
                flagImg.sprite = flags[179];
                break;
            case "ury":
                flagImg.sprite = flags[180];
                break;
            case "usa":
                flagImg.sprite = flags[181];
                break;
            case "uzb":
                flagImg.sprite = flags[182];
                break;
            case "vat":
                flagImg.sprite = flags[183];
                break;
            case "vct":
                flagImg.sprite = flags[184];
                break;
            case "ven":
                flagImg.sprite = flags[185];
                break;
            case "vnm":
                flagImg.sprite = flags[186];
                break;
            case "vut":
                flagImg.sprite = flags[187];
                break;
            case "wsm":
                flagImg.sprite = flags[188];
                break;
            case "yem":
                flagImg.sprite = flags[189];
                break;
            case "zaf":
                flagImg.sprite = flags[190];
                break;
            case "zmb":
                flagImg.sprite = flags[191];
                break;
            case "zwe":
                flagImg.sprite = flags[192];
                break;
            case "pwy":
                flagImg.sprite = flags[193];
                break;
            case "eng":
                flagImg.sprite = flags[194];
                break;
            case "sco":
                flagImg.sprite = flags[195];
                break;
            case "rks":
                flagImg.sprite = flags[196];
                break;
            default:
                flagImg.sprite = flags[0];
                break;
        }
        
    }

}
