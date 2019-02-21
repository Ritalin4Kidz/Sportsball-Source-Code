using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
    public Image[] btnArray;
    public Image hiLight;
    public Canvas pauseScreen;
    float delay = 0;
    bool delay2 = false;
    bool delayOn = false;
    public bool functioning;
    public GameObject player;
    int i = 0;
    // Use this for initialization
    void Start () {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerScript>())
        {
            if (player.GetComponent<PlayerScript>().GetPaused() && functioning)
            {
                if (Input.GetKeyDown(player.GetComponent<PlayerScript>().GetJump()))
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
                if (Input.GetAxis(player.GetComponent<PlayerScript>().GetYaxis()) > 0)
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
                if (Input.GetAxis(player.GetComponent<PlayerScript>().GetYaxis()) < 0)
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
                if (Input.GetAxis(player.GetComponent<PlayerScript>().GetYaxis()) == 0)
                {
                    delayOn = false;
                    delay = 0;
                }
                if (!delay2 && Input.GetAxis(player.GetComponent<PlayerScript>().GetXaxis()) > 0)
                {
                    delay2 = true;
                    player.GetComponent<PlayerScript>().setLookSensitivity(player.GetComponent<PlayerScript>().GetSens() + 0.5f);
                    if (player.GetComponent<PlayerScript>().GetSens() > 5)
                    {
                        player.GetComponent<PlayerScript>().setLookSensitivity(0.5f);
                    }
                    player.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().KillFeedSend(player.GetComponent<PlayerScript>().getPlayerName() + " Sens : " + player.GetComponent<PlayerScript>().GetSens());
                }
                if (!delay2 && Input.GetAxis(player.GetComponent<PlayerScript>().GetXaxis()) < 0)
                {
                    delay2 = true;
                    player.GetComponent<PlayerScript>().setLookSensitivity(player.GetComponent<PlayerScript>().GetSens() - 0.5f);
                    if (player.GetComponent<PlayerScript>().GetSens() <= 0)
                    {
                        player.GetComponent<PlayerScript>().setLookSensitivity(5.0f);
                    }
                    player.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().KillFeedSend(player.GetComponent<PlayerScript>().getPlayerName() + " Sens : " + player.GetComponent<PlayerScript>().GetSens());
                }
                if (Input.GetAxis(player.GetComponent<PlayerScript>().GetXaxis()) == 0)
                {
                    delay2 = false;
                }
            }
        }

        else if (player.GetComponent<missionPlayerScript>())
        {
            if (player.GetComponent<missionPlayerScript>().GetPaused() && functioning)
            {
                if (Input.GetKeyDown(player.GetComponent<missionPlayerScript>().GetJump()))
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
                if (Input.GetAxis(player.GetComponent<missionPlayerScript>().GetYaxis()) > 0)
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
                if (Input.GetAxis(player.GetComponent<missionPlayerScript>().GetYaxis()) < 0)
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
                if (Input.GetAxis(player.GetComponent<missionPlayerScript>().GetYaxis()) == 0)
                {
                    delayOn = false;
                    delay = 0;
                }
            }
        }
    }


    public void QuitBtn()
    {
        if (player.GetComponent<PlayerScript>())
        {
            player.GetComponent<PlayerScript>().SetPaused(false);
        }
        else if (player.GetComponent<missionPlayerScript>())
        {
            player.GetComponent<missionPlayerScript>().SetPaused(false);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuMockUp");
    }
    public void Resume()
    {
        if (player.GetComponent<PlayerScript>())
        {
            player.GetComponent<PlayerScript>().SetPaused(false);
        }
        else if (player.GetComponent<missionPlayerScript>())
        {
            player.GetComponent<missionPlayerScript>().SetPaused(false);
        }
        functioning = false;
        //Time.timeScale = 1;
        pauseScreen.enabled = false;
     }
}
