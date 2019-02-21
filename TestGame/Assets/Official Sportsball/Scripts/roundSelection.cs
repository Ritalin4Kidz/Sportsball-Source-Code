using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class roundSelection : MonoBehaviour {
    public GameObject[] nodes;
    int node;
    int node2;
    int node3;
    bool delay;
    bool delay2;
    bool delay3;
    public Canvas thisCanvas;
    public Canvas loadCanvas;
    public GameObject universalGame;
    public Material playerColours;
    public Material playerSplat;
    public Material ballMat;
    public Text gameText;
    public Text classText;
    public Text player2Text;
    bool player2playing;
    public string[] playerClass;
    public Canvas CutSceneRef;

    string[] emailMessages;
    public Canvas emailCvs;
    public Text emailTxt;
    public GameObject audioPlayer;
    // Use this for initialization
    void setTextMsgs()
    {
        emailMessages[0] = "From : West Townie Amateur Sportsball Tournament Officials \n To : Herman Red \n Subject : Application Approved \n Dear Mr Red \n We have reviewed your participation application and have accepted you and Mr Scroff into the 2018 West Townie Amateur Sportsball Tournament. \n We wish you and Scroff luck in your attempts, and more importantly, hope you have fun. \n From, WTASTO";
        emailMessages[1] = "From : FreePornSex.xxx  \n To : Herman Red \n Subject : \n dear mr Red \n pls click, good sex awaits.. see Nakd wuman plows 50 yr ld mif aawdf sexe asin \n FreePornSex.xxx";
        emailMessages[2] = "From : Charlotte Red  \n To : Herman Red \n Subject : Support Payments \n I'm sorry Hermie but your father and I had a good long talk, and we've come to the agreement that we can no longer afford to support you financially. You're welcome to move back in but you can't stay forever like you did last time. \n Love, Mum ";
        emailMessages[3] = "From : West Townie Amateur Sportsball Tournament Officials  \n To : Herman Red; Georgio Scroff \n Subject : Congratulations \n Dear Mr Red and Mr Scroff \n Congratulations on making it to the grand finals of the 2018 West Townie Amateur Sportsball Tournaments. You'll be facing the West Townie Potatoes, who have won the tournament 4 of the past 5 years, including 2017. We also have word that Sudiike is currently looking to sponsor an young and upcoming sportsball team, so play well and you just might impress them. \n Also before you feel like we're giving you special treatment with this information, we literally sent the same information to the other team with the names swapped out, so don't get too high and mighty. \n Good Luck, WTASTO ";
        emailMessages[4] = "From : Sudiike \n To : Herman Red \n Subject : Sponsorship \n Dear Mr Red \n After seeing you and Scroff's performance in that West Townie tournament, we have decided to consider giving you two an official sponsorship. \n The only issue is that we have also been considering this with another upcoming team. So we have decided to let you two teams fight out for a sponsorship in a game of Aus Sportsball (no one plays it so it should be fair). If you agree and win we will award you with a sponsorship. If you don't agree of you lose, will we hand it to the Magpies. \n Yours Truly, Sudiike ";
        emailMessages[5] = "From : Sudiike \n To : Herman Red \n Subject : Magpie Stadium Tournament \n Dear Mr Red \n Once again congratulations on receiving a sponsorship with us. Our job as sponsor will not only be to hook you up with neccesary gear, but also to inform you of events that might be worth your interest. \n For example, Magpie Stadium is hosting an Euro Sportball Tournament. Euro Sportsball is a pretty big deal in this country, especially with the world cup being held here this year. So you're bound to get a lot of buzz just by playing. Plus, Mr Red, you'll be one of the only Australian Euro Sportsball players so if you play well they might consider you when selection time comes. \n no pressure guys, but we're risking a lot on you so probably try to win. \n Suddike";
        emailMessages[6] = "From : Georgio Scroff \n To : Herman Red \n Subject : Dinner Plans Sunday \n Sorry for the incorrect subject title, but i want to keep this a little more secret. \n I don't trust Sudiike, and I think they realise. I overheard them planning to replace me last night. Please, for the love of fuck, if they go through with this leave with me, we cannot let them push around little teams. \n Georgio";
        emailMessages[7] = "From : Sudiike \n To : Herman Red \n Subject : Congratulations You Two \n Congratulations on making the Grand Final Mr Red. As much as we would like to celebrate though, we need to discuss a much needed change for your team. Georgio is deadweight, and we would be better off without him. \n If you do not agree with this change, we will drop you as well and withdraw our application to the Cloudsia nationals. Again no pressure, use this final as a way to think about it \n Yours truly, Sudiike";
        emailMessages[8] = "From : Sudiike \n To : Herman Red \n Subject : You Made The Right Choice \n Dear Mr Red \n We want to trial some of the contenders for your new partner before the Cloudsia Nationals Qualifiers. So show in the streets of the Western suburbs by 6:30pm tonight. \n Sudiike";
        emailMessages[9] = "From : Georgio Scroff \n To : Herman Red \n Subject : FUCKING TRAITOR \n WHAT THE FUCK MAN?!!? \n I THOUGHT WE HAD A DEAL, THEN I FIND OUT YOU FUCKING STAYED ON SUDIIKE'S SIDE?!?! \n I'M FUCKING DONE WITH YOU MAN, HAVE A SHITTY LIFE";
        emailMessages[10] = "From : Daniel Simmons \n To : Herman Red \n Subject : Overdue Rent \n Dear Mr Red \n You have until Friday. I cannot write this simply enough. You have been missing payments practically every time and I am near boling point. If you do not pay your rent by Friday, you will three days to pack your shit up and leave. \n I'm fucking sick of this man, Daniel";
        emailMessages[11] = "From : Charlotte Red \n To : Herman Red \n Subject : RE: Moving Back In \n Dear Hermie \n We will clear out your bedroom so that you have space to move back in. Again, we can't let you stay forever, so you have a month to move back out. \n Love, Mum";
        emailMessages[12] = "From : Sudiike \n To : Herman Red \n Subject : Qualifications and Euro \n Dear Mr Red \n Congratulations on your qualification to the Cloudsia Nationals, this is the biggest Sportsball tournament in Cloudsia, so just by being there will you create a huge name for yourself and Sudiike. Before the nationals though, we would like you and Mr Clive to participate in a Showmatch for Euro Sportsball. there's a good chance the Australian selectors will be watching so try and play well Mr Red. \n Yours Truly, Sudiike.";
        emailMessages[13] = "From : Cloudsia Nationals Officials \n To : Herman Red; Grant Clive \n Subject : Welcome To The Cloudsia Nationals \n Dear Mr Red & Mr Clive \n Congratulations on your qualifications to the Cloudsia Nationals. As You know this is Cloudsia's biggest sporting event and one of the biggest sportsball events in the nation. We wish you and Clive luck in your attempts, and more importantly, hope you have fun. \n Your first opponent will be the South West Oceans. \n ,CNO";
        emailMessages[14] = "From : chearleader9000@simail.com \n To : Herman Red \n Subject : U OWE ME OR UR DIE \n Dear Mr Red \n FCUK YOUUUUUU \n I FUKING PIACED $300 ON OCEANS WIN. NOW MY PARETS ARE GONNA BE UPSET WHEN TEY SEE $300 MISSIN. \n YOU OWE ME MY MONE BCK OR THERE WILL BE TRUBLE";
        emailMessages[15] = "From : chearleader9000@simail.com \n To : Herman Red \n Subject : im sorry \n Dear Mr Red \n my mum tod me that i should sya sorri to yu 4 the mean message \n \n sorry";
        emailMessages[16] = "From : ShameStop \n To : Herman Red \n Subject : BIG DEALS STOREWIDE \n Dear Mr Red \n BUY OUR GAMES, PLEASE HOLY FUCK WE'RE DESPERATE. THEY'RE GONNA CUT OFF OUR ARMS!";
        emailMessages[17] = "From : Sudiike \n To : Herman Red \n Subject : Euro Sportsball Season\n Dear Mr Red \n There's rumours going around that one of the teams involved with the upcoming season of Sportsball is pulling out, winning this tournament might be a good way to advertise ourselves for that spot.";
        emailMessages[18] = "From : Offical Sportsball League Officials \n To : Herman Red \n Subject : Sportsball Season \n Dear Mr Red \n We are inviting you and the Mountain City Reds to join the upcoming season of Sportsball. If you accept the invitation, your first game will be against the South West Oceans, at their home ground.";
        emailMessages[19] = "From :  \n To : Herman Red \n Subject : \n Dear Mr Red \n ";
        emailMessages[20] = "From :  \n To : Herman Red \n Subject : \n Dear Mr Red \n ";
        emailMessages[21] = "From :  \n To : Herman Red \n Subject : \n Dear Mr Red \n ";
        emailMessages[22] = "From :  \n To : Herman Red \n Subject : \n Dear Mr Red \n ";
        emailMessages[23] = "From :  \n To : Herman Red \n Subject : \n Dear Mr Red \n ";
        emailMessages[24] = "From :  \n To : Herman Red \n Subject : \n Dear Mr Red \n ";
        emailMessages[25] = "From :  \n To : Herman Red \n Subject : \n Dear Mr Red \n ";
        emailMessages[26] = "From :  \n To : Herman Red \n Subject : \n Dear Mr Red \n ";
    }
    void Start () {
        Time.timeScale = 1.0f;
        if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
        }
        string path;
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\LevelSaves.txt";
       
        
        
        emailMessages = new string[40];
        setTextMsgs();
        node = 0;
        emailTxt.text = emailMessages[node];
        emailCvs.enabled = false;
        loadCanvas.enabled = false;
        if (System.IO.File.Exists(path))
        {
            List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(path));
            for (int i = 0; i < universalGame.GetComponent<UniGameManager>().lockedRounds.Length; i++)
            {
                bool.TryParse(fileLines[i], out universalGame.GetComponent<UniGameManager>().lockedRounds[i]);
                if (universalGame.GetComponent<UniGameManager>().lockedRounds[i] == false)
                {
                    node = i;
                    this.gameObject.transform.position = new Vector3(nodes[node].transform.position.x, nodes[node].transform.position.y + 24.0f, nodes[node].transform.position.z);
                    if (!nodes[node].GetComponent<roundSelect>().locked)
                    {
                        gameText.text = nodes[node].GetComponent<roundSelect>().levelInfo;
                        emailTxt.text = emailMessages[node];
                    }
                    else
                    {
                        gameText.text = "LOCKED";
                        emailTxt.text = "Connection Error";
                    }
                }
            }
        }
        for (int i = 0; i < nodes.Length; i ++)
        {
            nodes[i].GetComponent<roundSelect>().locked = universalGame.GetComponent<UniGameManager>().lockedRounds[i];
        }
       
        classText.text = playerClass[node2];
        this.gameObject.transform.position = new Vector3(nodes[node].transform.position.x, nodes[node].transform.position.y + 24.0f, nodes[node].transform.position.z);
        if (!nodes[node].GetComponent<roundSelect>().locked)
        {
            gameText.text = nodes[node].GetComponent<roundSelect>().levelInfo;
        }
        else
        {
            gameText.text = "LOCKED";
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Player1LookX") > 0 && !delay2 || Input.GetKeyDown(KeyCode.E))
        {
            if (node2 < playerClass.Length - 1)
            {
                delay2 = true;
                node2++;
                classText.text = playerClass[node2];
            }
        }
        if (Input.GetAxis("Player1LookX") < 0 && !delay2 || Input.GetKeyDown(KeyCode.Q))
        {
            if(node2 > 0)
            {
                delay2 = true;
                node2--;
                classText.text = playerClass[node2];
            }
        }
        if (Input.GetAxis("Player1LookX") == 0)
        {
            delay2 = false;
        }
        if (Input.GetAxis("Player2LookX") > 0 && !delay3)
        {
            if (node3 < playerClass.Length - 1)
            {
                delay3 = true;
                node3++;
                player2Text.text = playerClass[node3];
            }
        }
        if (Input.GetAxis("Player2LookX") < 0 && !delay3)
        {
            if (node3 > 0)
            {
                delay3 = true;
                node3--;
                player2Text.text = playerClass[node3];
            }
        }
        if (Input.GetAxis("Player2LookX") == 0)
        {
            delay3 = false;
        }
        if (Input.GetAxis("Player1MoveX") > 0 && !delay || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (node < nodes.Length - 1)
            {
                delay = true;
                node++;
                this.gameObject.transform.position = new Vector3(nodes[node].transform.position.x, nodes[node].transform.position.y + 24.0f, nodes[node].transform.position.z);
                if (!nodes[node].GetComponent<roundSelect>().locked)
                {
                    gameText.text = nodes[node].GetComponent<roundSelect>().levelInfo;
                    emailTxt.text = emailMessages[node];
                }
                else
                {
                    gameText.text = "LOCKED";
                    emailTxt.text = "Connection Error";
                }
            }
        }
        if (Input.GetAxis("Player1MoveX") < 0 && !delay || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (node > 0)
            {
                delay = true;
                node--;
                this.gameObject.transform.position = new Vector3(nodes[node].transform.position.x, nodes[node].transform.position.y + 24.0f, nodes[node].transform.position.z);
                if (!nodes[node].GetComponent<roundSelect>().locked)
                {
                    gameText.text = nodes[node].GetComponent<roundSelect>().levelInfo;
                    emailTxt.text = emailMessages[node];
                }
                else
                {
                    gameText.text = "LOCKED";
                    emailTxt.text = "Connection Error";
                }
            }
        }
        if (Input.GetAxis("Player1MoveX") == 0)
        {
            delay = false;
        }
        if(Input.GetKey(KeyCode.Joystick1Button6) || Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("MenuMockUp");
        }
        if(Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            if (!player2playing)
            {
                player2playing = true;
                player2Text.text = playerClass[node3];
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            if (player2playing)
            {
                player2playing = false;
                player2Text.text = "Player 2 Press 'A'";
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.X))
        {
            emailCvs.enabled = !emailCvs.enabled;
        }
        if (Input.GetKey(KeyCode.Joystick1Button7) && !nodes[node].GetComponent<roundSelect>().locked)
        {
            universalGame.GetComponent<UniGameManager>().keyBoardPlayer = false;
            universalGame.GetComponent<UniGameManager>().consoleInGame = false;
            universalGame.GetComponent<UniGameManager>().aiIsPlaying = true;
            universalGame.GetComponent<UniGameManager>().playerReady[0] = true;
            universalGame.GetComponent<UniGameManager>().playerReady[1] = player2playing;
            universalGame.GetComponent<UniGameManager>().playerReady[2] = false;
            universalGame.GetComponent<UniGameManager>().playerReady[3] = false;
            universalGame.GetComponent<UniGameManager>().players = 1;
            if (player2playing)
            {
                universalGame.GetComponent<UniGameManager>().players = 2;
            }
            universalGame.GetComponent<UniGameManager>().aiPlayers = 4 - universalGame.GetComponent<UniGameManager>().players;
            universalGame.GetComponent<UniGameManager>().TournamentMode = true;
            universalGame.GetComponent<UniGameManager>().round = node;
            universalGame.GetComponent<UniGameManager>().baseTeam1 = nodes[node].GetComponent<roundSelect>().playerteamColours;
            universalGame.GetComponent<UniGameManager>().basesplatTeam1 = nodes[node].GetComponent<roundSelect>().playerteamSplat;
            universalGame.GetComponent<UniGameManager>().baseTeam2 = nodes[node].GetComponent<roundSelect>().teamColours;
            universalGame.GetComponent<UniGameManager>().basesplatTeam2 = nodes[node].GetComponent<roundSelect>().teamSplat;
            universalGame.GetComponent<UniGameManager>().spectateCheats = false;
            universalGame.GetComponent<UniGameManager>().spectating = false;
            universalGame.GetComponent<UniGameManager>().gameTime = 300;
            universalGame.GetComponent<UniGameManager>().extraTime = true;
            universalGame.GetComponent<UniGameManager>().ballMat = ballMat;
            universalGame.GetComponent<UniGameManager>().playerType[0] = playerClass[node2];
            if (player2playing)
            {
                universalGame.GetComponent<UniGameManager>().playerType[1] = playerClass[node3];
            }
            universalGame.GetComponent<UniGameManager>().playerTeams[0] = "Team1";
            universalGame.GetComponent<UniGameManager>().playerTeams[1] = "Team1";
            universalGame.GetComponent<UniGameManager>().playerTeams[2] = "Team2";
            universalGame.GetComponent<UniGameManager>().playerTeams[3] = "Team2";
            universalGame.GetComponent<UniGameManager>().LevelLoad = nodes[node].GetComponent<roundSelect>().levelLoad;
            if (!nodes[node].GetComponent<roundSelect>().cutScenePlay)
            {
                loadCanvas.GetComponent<LoadMap>().started = true;
                thisCanvas.enabled = false;
                loadCanvas.enabled = true;
                
            }
            else
            {
                universalGame.GetComponent<UniGameManager>().boolStopAudio = true;
                Canvas CS = Instantiate(CutSceneRef);
                CS.GetComponent<CutScene>().setLoad(loadCanvas);
                CS.GetComponent<CutScene>().videoChange(nodes[node].GetComponent<roundSelect>().cutSceneVideo);
                audioPlayer.GetComponent<AudioSource>().clip = nodes[node].GetComponent<roundSelect>().cutSceneAudio;
                audioPlayer.GetComponent<AudioSource>().Play();
                thisCanvas.enabled = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !nodes[node].GetComponent<roundSelect>().locked)
        {
            universalGame.GetComponent<UniGameManager>().keyBoardPlayer = true;
            universalGame.GetComponent<UniGameManager>().consoleInGame = false;
            universalGame.GetComponent<UniGameManager>().aiIsPlaying = true;
            universalGame.GetComponent<UniGameManager>().playerReady[0] = true;
            universalGame.GetComponent<UniGameManager>().playerReady[1] = player2playing;
            universalGame.GetComponent<UniGameManager>().playerReady[2] = false;
            universalGame.GetComponent<UniGameManager>().playerReady[3] = false;
            universalGame.GetComponent<UniGameManager>().players = 1;
            if (player2playing)
            {
                universalGame.GetComponent<UniGameManager>().players = 2;
            }
            universalGame.GetComponent<UniGameManager>().aiPlayers = 4 - universalGame.GetComponent<UniGameManager>().players;
            universalGame.GetComponent<UniGameManager>().TournamentMode = true;
            universalGame.GetComponent<UniGameManager>().MutatorRule = "None";
            universalGame.GetComponent<UniGameManager>().round = node;
            universalGame.GetComponent<UniGameManager>().baseTeam1 = nodes[node].GetComponent<roundSelect>().playerteamColours;
            universalGame.GetComponent<UniGameManager>().basesplatTeam1 = nodes[node].GetComponent<roundSelect>().playerteamSplat;
            universalGame.GetComponent<UniGameManager>().baseTeam2 = nodes[node].GetComponent<roundSelect>().teamColours;
            universalGame.GetComponent<UniGameManager>().basesplatTeam2 = nodes[node].GetComponent<roundSelect>().teamSplat;
            universalGame.GetComponent<UniGameManager>().spectateCheats = false;
            universalGame.GetComponent<UniGameManager>().spectating = false;
            universalGame.GetComponent<UniGameManager>().gameTime = 300;
            universalGame.GetComponent<UniGameManager>().extraTime = true;
            universalGame.GetComponent<UniGameManager>().ballMat = ballMat;
            universalGame.GetComponent<UniGameManager>().playerType[0] = playerClass[node2];
            if (player2playing)
            {
                universalGame.GetComponent<UniGameManager>().playerType[1] = playerClass[node3];
            }
            universalGame.GetComponent<UniGameManager>().playerTeams[0] = "Team1";
            universalGame.GetComponent<UniGameManager>().playerTeams[1] = "Team1";
            universalGame.GetComponent<UniGameManager>().playerTeams[2] = "Team2";
            universalGame.GetComponent<UniGameManager>().playerTeams[3] = "Team2";
            universalGame.GetComponent<UniGameManager>().LevelLoad = nodes[node].GetComponent<roundSelect>().levelLoad;
            if (!nodes[node].GetComponent<roundSelect>().cutScenePlay)
            {
                loadCanvas.GetComponent<LoadMap>().started = true;
                thisCanvas.enabled = false;
                loadCanvas.enabled = true;

            }
            else
            {
                universalGame.GetComponent<UniGameManager>().boolStopAudio = true;
                Canvas CS = Instantiate(CutSceneRef);
                CS.GetComponent<CutScene>().setLoad(loadCanvas);
                CS.GetComponent<CutScene>().videoChange(nodes[node].GetComponent<roundSelect>().cutSceneVideo);
                audioPlayer.GetComponent<AudioSource>().clip = nodes[node].GetComponent<roundSelect>().cutSceneAudio;
                audioPlayer.GetComponent<AudioSource>().Play();
                thisCanvas.enabled = false;
            }
        }
    }
}
