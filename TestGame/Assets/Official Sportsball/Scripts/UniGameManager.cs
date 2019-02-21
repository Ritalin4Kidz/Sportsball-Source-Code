using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class UniGameManager : MonoBehaviour {
    public int players = 0;
    public int aiPlayers = 0;
    public Material[] levelPics;
    public bool seasonModeOn;
    public bool TournamentMode;
    public bool GrandFinal;
    public GameObject playerSeasonTeam;
    public int seasonMaxrounds;
    public int seasonRound;

    public string LevelLoad;

    public int gameTime;
    public bool extraTime;

    public GameObject team1;
    public GameObject team2;

    public Material skybox;
    public Material baseTeam1;
    public Material baseTeam2;
    public Material basesplatTeam1;
    public Material basesplatTeam2;

    public Sprite banner1;
    public Sprite banner2;

    public string teamname1;
    public string teamname2;

    public bool isSpectator;
    public bool spectateCheats;
    public bool spectating;

    public bool[] achievements;
    public bool[] lockedRounds;
    public int round;
    public string[] playerType;

    public string[] playerTeams;


    public bool[] playerReady;
    public bool aiIsPlaying;

    public bool boolStopAudio;

    public GameObject[] listOfTeams; //stops point bug

    public string profileName;
    public int profileLvl;
    public int profileXP;
    public int profileXpLvlUp;


    //option saves
    public float songVolume;
    public float lookSens;

    public bool keyBoardPlayer;

    public string MutatorRule;

    public Material ballMat;

    public bool consoleInGame;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
