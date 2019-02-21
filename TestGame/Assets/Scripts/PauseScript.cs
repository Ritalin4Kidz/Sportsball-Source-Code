using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour {
    public Image[] btnArray;
    public string Yaxis;
    public Image hiLight;
    public Canvas pauseScreen;
    public KeyCode accept;
    float delay = 0;
    bool delayOn = false;
    public bool functioning;
    public GameObject gameManager;
    int i = 0;
    // Use this for initialization
    void Start () {
        }
	
	// Update is called once per frame
	void Update ()
    {
        if (functioning && gameManager.GetComponent<SportsballGameManager>().paused)
        {
            if (Input.GetKeyDown(accept))
            {
                if (i == 0)
                {
                    Resume();
                }
                if (i == 1)
                {
                    QuitBtn();
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
            if (Input.GetAxis(Yaxis) > 0)
            {
                if (!delayOn)
                {
                    i--;
                    delayOn = true;
                    if (i < 0)
                    {
                        i = btnArray.Length - 1;
                    }
                    hiLight.transform.position = btnArray[i].transform.position;
                }
            }
            if (Input.GetAxis(Yaxis) < 0)
            {
                if (!delayOn)
                {
                    i++;
                    delayOn = true;
                    if (i > btnArray.Length - 1)
                    {
                        i = 0;
                    }
                    hiLight.transform.position = btnArray[i].transform.position;
                }
            }
            if (Input.GetAxis(Yaxis) == 0)
            {
                delayOn = false;
                delay = 0;
            }
        }
    }

    
    public void QuitBtn()
    {
        gameManager.GetComponent<SportsballGameManager>().paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("ReadyScreen");
    }
    public void Resume()
    {
        gameManager.GetComponent<SportsballGameManager>().paused = false;
        Time.timeScale = 1;
        pauseScreen.enabled = false;
        functioning = false;
    }
}
