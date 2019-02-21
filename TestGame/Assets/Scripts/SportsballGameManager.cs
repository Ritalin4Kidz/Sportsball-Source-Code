using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SportsballGameManager : MonoBehaviour {
    public int team1score;
    public int team2score;
    public int seconds;

    float tempTime = 0;

    public bool paused;

    public bool scoring = true;
    public bool replay = false;
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    public GameObject spawnLoc1;
    public GameObject spawnLoc2;
    public bool inPlay = true;

    public Camera firstPlayerCamera;
    public Camera secondPlayerCamera;
    public Camera replayCamera;
    public Camera winCam;

    public Canvas pauseScreen;
    public Canvas replayUI;
    public Canvas regularUI;
    public KeyCode pause;
    Vector3[] player1locs;
    Vector3[] player2locs;
    Vector3[] balllocs;

    //Quaternion[] player1rots;
    //Quaternion[] player2rots;
    //Quaternion[] ballrots;

    int replayFrame = 0;
    int FrameSave = 0;
    float timePassed;
    // Use this for initialization
    void Start () {
        player1locs = new Vector3[999];
        player2locs = new Vector3[999];
        balllocs = new Vector3[999];
        firstPlayerCamera.enabled = true;
        secondPlayerCamera.enabled = true;
        replayCamera.enabled = false;
        winCam.enabled = false;
        pauseScreen.GetComponent<Canvas>().enabled = false;
        replayUI.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(pause))
        {
            if (!paused)
            {
                pauseScreen.GetComponent<Canvas>().enabled = true;
                pauseScreen.GetComponent<PauseScript>().functioning = true;
                paused = true;
            }
        }
        if (paused)
        {
            Time.timeScale = 0;
        }
        if (!paused)
        {
            if (seconds < 0)
            {
                scoring = false;
                replay = false;
                inPlay = false;
                firstPlayerCamera.enabled = false;
                secondPlayerCamera.enabled = false;
                replayCamera.enabled = false;
                regularUI.enabled = false;
                replayUI.enabled = true;
                winCam.enabled = true;
                ball.transform.position = new Vector3(10, -10, 10);
                if (team1score > team2score)
                {
                    player1.transform.position = new Vector3(0, 0.5f, 0);
                }
                else if (team2score > team1score)
                {
                    player2.transform.position = new Vector3(0, 0.5f, 0);
                }
                else if (team1score == team2score)
                {
                    player1.transform.position = new Vector3(1, 0.5f, 0);
                    player2.transform.position = new Vector3(-1, 0.5f, 0);
                }
                winStage();

            }
            if (replay)
            {
                playReplay(replayFrame, FrameSave);
                //Debug.Log(FrameSave);
                replayFrame++;
                // Debug.Log(replayFrame);
            }
            if (inPlay)
            {
                timePassed += Time.deltaTime;
                if (timePassed >= 1)
                {
                    seconds -= 1;
                    timePassed -= 1;
                }
                if (FrameSave >= 998)
                {
                    for (int ii = 0; ii < 998; ii++)
                    {
                        player1locs[ii] = player1locs[ii + 1];
                        player2locs[ii] = player2locs[ii + 1];
                        balllocs[ii] = balllocs[ii + 1];
                        FrameSave--;
                    }
                }
                {
                    player1locs[FrameSave] = player1.transform.position;
                    player2locs[FrameSave] = player2.transform.position;
                    balllocs[FrameSave] = ball.transform.position;
                    FrameSave++;
                }
            }
        }
	}

    public void playReplay(int i, int goalPoint)
    {
        {
            //Debug.Log(i);
            if ( i > 998 || i > goalPoint || Input.GetKey(KeyCode.JoystickButton0))
            {
                i = 0;
                replay = false;
                scoring = true;
                inPlay = true;
                //for (int ii = 0; ii < 998; ii++)
                //{
                //    player1locs[ii] = Vector3.zero;
                //    player2locs[ii] = Vector3.zero;
                //    balllocs[ii] = Vector3.zero;
                    
                //}
                ball.transform.position = new Vector3(0, 6.25f, 0);
                player1.transform.position = spawnLoc1.transform.position;
                player2.transform.position = spawnLoc2.transform.position;
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
                player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
                FrameSave = 0;
                replayFrame = 0;
                regularUI.enabled = true;
                replayUI.enabled = false;
                firstPlayerCamera.enabled = true;
                
                secondPlayerCamera.enabled = true;
                
                replayCamera.enabled = false;
                return;
            }
            player1.transform.position = player1locs[i];
            player2.transform.position = player2locs[i];
            ball.transform.position = balllocs[i];
            
        }
    }
    public void startReplay()
    {
        scoring = false;
        replay = true;
        inPlay = false;
        regularUI.enabled = false;
        replayUI.enabled = true;
        firstPlayerCamera.enabled = false;
        secondPlayerCamera.enabled = false;
        replayCamera.enabled = true;
    }

    public void winStage()
    {
        tempTime += Time.deltaTime;
        if (tempTime >= 10)
        {
            SceneManager.LoadScene("ReadyScreen");
        }
    }
   
}

