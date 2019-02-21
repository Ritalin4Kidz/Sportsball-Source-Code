using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class OptionsScreen : MonoBehaviour {
    public Canvas thisCanvas;
    public Canvas ReadyCanvas;
    int buttonNo;
    public Image[] buttons;
    public Text[] buttonTexts;
    bool delayOn;
    bool delayOn2;
    public Image hiLight;
    public GameObject uniGameManager;

    public GameObject networkObj;

    public Material day;
    public Material night;

    public Material[] ballMats;

    public string[] Mutators;
    int ii = 0;
    int iii = 0;
    bool dayTime = true;
    bool extraTime;
    int seconds = 300;
	// Use this for initialization
	void Start () {
        seconds = 300;
        extraTime = false;
        dayTime = true;
        uniGameManager.GetComponent<UniGameManager>().gameTime = seconds;
        uniGameManager.GetComponent<UniGameManager>().extraTime = extraTime;
        uniGameManager.GetComponent<UniGameManager>().skybox = day;
        uniGameManager.GetComponent<UniGameManager>().spectating = false;
        uniGameManager.GetComponent<UniGameManager>().spectateCheats = false;
        uniGameManager.GetComponent<UniGameManager>().aiIsPlaying = false;
        uniGameManager.GetComponent<UniGameManager>().MutatorRule = "None";
        uniGameManager.GetComponent<UniGameManager>().ballMat = ballMats[0];
        uniGameManager.GetComponent<UniGameManager>().consoleInGame = false;
    }
	// Update is called once per frame
	void Update () {
        if (thisCanvas.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.B))
            {
                thisCanvas.enabled = false;
                ReadyCanvas.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space))
            {
                switch (buttonNo)
                {
                    case 0:
                        if (uniGameManager.GetComponent<UniGameManager>().aiIsPlaying)
                        {
                          
                                buttonTexts[buttonNo].text = "AI : Off";
                                uniGameManager.GetComponent<UniGameManager>().aiIsPlaying = false;
                        }
                        else
                        {
                            buttonTexts[buttonNo].text = "AI : On";
                            uniGameManager.GetComponent<UniGameManager>().aiIsPlaying = true;
                        }
                        break;
                    case 1:
                    if (extraTime)
                       {
                            buttonTexts[buttonNo].text = "Extra Time : Off";
                            extraTime = false;
                            delayOn2 = false;
                       }
                       else
                       {
                            buttonTexts[buttonNo].text = "Extra Time : On";
                            extraTime = true;
                            delayOn2 = false;
                       }
                    uniGameManager.GetComponent<UniGameManager>().extraTime = extraTime;
                        break;
                    case 2:
                        if (dayTime)
                        {
                            dayTime = false;
                            uniGameManager.GetComponent<UniGameManager>().skybox = night;
                            buttonTexts[buttonNo].text = "Time : Night";
                        }
                        else
                        {
                            dayTime = true;
                            uniGameManager.GetComponent<UniGameManager>().skybox = day;
                            buttonTexts[buttonNo].text = "Time : Day";
                        }
                        break;
                    case 3:
                        seconds -= 60;
                        if (seconds <= 0)
                        {
                            seconds = 300;
                        }
                        uniGameManager.GetComponent<UniGameManager>().gameTime = seconds;
                        buttonTexts[buttonNo].text = "Match Time : " + seconds/60 + " Mins";
                        break;
                    case 4:
                        if (!uniGameManager.GetComponent<UniGameManager>().spectating)
                        {
                            uniGameManager.GetComponent<UniGameManager>().spectating = true;
                            buttonTexts[buttonNo].text = "Spectator Window : On";
                        }
                        else
                        {
                            uniGameManager.GetComponent<UniGameManager>().spectating = false;
                            buttonTexts[buttonNo].text = "Spectator Window : Off";
                        }


                        break;
                    case 5:
                        if (!uniGameManager.GetComponent<UniGameManager>().spectateCheats)
                        {
                            uniGameManager.GetComponent<UniGameManager>().spectateCheats = true;
                            buttonTexts[buttonNo].text = "Spectator Cheats : On";
                        }
                        else
                        {
                            uniGameManager.GetComponent<UniGameManager>().spectateCheats = false;
                            buttonTexts[buttonNo].text = "Spectator Cheats : Off";
                        }

                        break;
                    case 6:
                        ii++;
                        if (ii >= Mutators.Length)
                        {
                            ii = 0;
                        }
                        uniGameManager.GetComponent<UniGameManager>().MutatorRule = Mutators[ii];
                        buttonTexts[buttonNo].text = "Mutator : " + Mutators[ii];
                        break;
                    case 7:
                        iii++;
                        if (iii >= ballMats.Length)
                        {
                            iii = 0;
                        }
                        uniGameManager.GetComponent<UniGameManager>().ballMat = ballMats[iii];
                        buttonTexts[buttonNo].text = "Ball Skin : ";
                        switch (iii)
                        {
                            case 0:
                                buttonTexts[buttonNo].text += "Regular";
                                break;
                            case 1:
                                buttonTexts[buttonNo].text += "Chompball";
                                break;
                            case 2:
                                buttonTexts[buttonNo].text += "Poland Ball";
                                break;
                            case 3:
                                buttonTexts[buttonNo].text += "Gold Ball";
                                break;
                            case 4:
                                buttonTexts[buttonNo].text += "Baseball";
                                break;
                            case 5:
                                buttonTexts[buttonNo].text += "Autographed";
                                break;
                            case 6:
                                buttonTexts[buttonNo].text += "Miss Chompball";
                                break;
                            case 7:
                                buttonTexts[buttonNo].text += "Bus Seat Cover";
                                break;
                            case 8:
                                buttonTexts[buttonNo].text += "Wordsmith";
                                break;
                            case 9:
                                buttonTexts[buttonNo].text += "Jackson Ball";
                                break;
                            default:
                                break;
                        }

                        break;
                    case 8:
                        uniGameManager.GetComponent<UniGameManager>().consoleInGame = !uniGameManager.GetComponent<UniGameManager>().consoleInGame;
                        buttonTexts[buttonNo].text = "Console : " + uniGameManager.GetComponent<UniGameManager>().consoleInGame;
                        break;
                    default:
                        break;


                }
            }
            if (Input.GetAxis("Player1MoveY") > 0 || Input.GetKeyDown(KeyCode.DownArrow))
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
            if (Input.GetAxis("Player1MoveY") < 0 || Input.GetKeyDown(KeyCode.UpArrow))
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
            }
            if (Input.GetAxis("Player1MoveX") == 0)
            {
                delayOn2 = false;
            }
        }
    }

}
