using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuMock : MonoBehaviour {
    public KeyCode play;
    float delay = 0;
    bool delayOn = false;

    //public Image Tv;
    public Camera[] tvImage;
   int tvImageNo;

    public Text scrollText;
    public Text musicTxt;
    public Text sensTxt;
    string textTosay;
    int startText,endText;
    public Image[] buttonsMain;
    public Image[] buttonsSettings;
    public Canvas settings;
    Image[] buttons;
    public Image hiLight;
    int buttonNo = 0;
    float timeToNextScroll;
    public GameObject universalGameManager;

    public Text pNameTxt;
    public Text pLvlTxt;
    public Text pXPTxt;



    public Image profileImg;
    public string CurrentVersion;
    // Use this for initialization
    public void SetTextToSay(string urlPath)
    {
        textTosay = urlPath;
        endText = 275;
    }
    IEnumerator GetTextureFromPath(string url)
    {
       
        if (System.IO.File.Exists(url))
        {
            
            Texture2D tex;
            tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            using (WWW www = new WWW(url))
            {
                yield return www;
                www.LoadImageIntoTexture(tex);
                profileImg.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
            }
        }
    }
    void Start () {
        Time.timeScale = 1.0f;
        if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
        }
        string path;
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\Profile.txt";
        if (!System.IO.File.Exists(path))
        {
            System.IO.File.WriteAllText(path, "");
            string[] contents = new string[5];
            contents[0] = universalGameManager.GetComponent<UniGameManager>().profileName;
            contents[1] = "" + universalGameManager.GetComponent<UniGameManager>().profileLvl;
            contents[2] = "" + universalGameManager.GetComponent<UniGameManager>().profileXP;
            contents[3] = "" + universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp;
            contents[4] = "";
            File.WriteAllLines(path, contents);
        }
        else
        {
            List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(path));
            universalGameManager.GetComponent<UniGameManager>().profileName = fileLines[0];
            int.TryParse(fileLines[1], out universalGameManager.GetComponent<UniGameManager>().profileLvl);
            int.TryParse(fileLines[2], out universalGameManager.GetComponent<UniGameManager>().profileXP);
            int.TryParse(fileLines[3], out universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp);

        }
        buttons = buttonsMain;
        pNameTxt.text = " Player : " +universalGameManager.GetComponent<UniGameManager>().profileName;
        pLvlTxt.text = " Level : " + universalGameManager.GetComponent<UniGameManager>().profileLvl;
        pXPTxt.text = " XP : " + universalGameManager.GetComponent<UniGameManager>().profileXP + "/" + universalGameManager.GetComponent<UniGameManager>().profileXpLvlUp;


        //https://ritalin4kidz.github.io/SportsballServerText.txt
        SetTextToSay("https://ritalin4kidz.github.io/SportsballServerText.txt");
        //textTosay = "";
        //textTosay = " | Welcome to Sportsball, select Free play if you're looking to play a quick pick up game, or select Missions if you're feeling adventure! | Current Sportsball Version : Alpha_066 | Check out the blog on ritalin4kidz.github.io to check out any progress updates, or to check out any other projects i've made | Septemberball Update, check out the blog for more info | Try out training mode if you want to improve your skills outside of the park";
        startText = 0;
        endText = 275;
        //Tv.material = tvImage[tvImageNo];
        for (int i = 0; i < tvImage.Length;i++)
        {
            tvImage[i].enabled = false;
        }
        tvImage[0].enabled = true;
        settings.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
       
        timeToNextScroll += Time.deltaTime;
        if (timeToNextScroll >= 0.05f && textTosay.Length > 275)
        {
            scrollText.text = textTosay.Substring(startText, endText);
            startText++;
            if (startText >= textTosay.Length - endText)
            {
                string temp = textTosay;
                textTosay = textTosay.Substring(startText, endText);
                textTosay += temp;
                startText = 0;
            }
            
            timeToNextScroll -= 0.05f;
        }
        if (Input.GetKey(play) && settings.enabled == false || Input.GetKeyDown(KeyCode.Return) && settings.enabled == false)
        {
            switch (buttonNo)
            {
                case 0:
                    SceneManager.LoadScene("TournamentMode");
                    break;
                case 1:
                   SceneManager.LoadScene("Missions");
                break;
                case 2:
                    SceneManager.LoadScene("Training");
                    break;
                case 3:
                    SceneManager.LoadScene("ReadyScreen");
                    break;
                case 4:
                    SceneManager.LoadScene("BookOfLore");
                    break;
                case 5:
                    Application.Quit();
                    break;
                default:
                    break;


            }
        }
        if (Input.GetKeyDown(play) && settings.enabled == true || Input.GetKeyDown(KeyCode.Return) && settings.enabled == true)
        {
            switch (buttonNo)
            {
                case 0:
                    universalGameManager.GetComponent<UniGameManager>().songVolume -= 0.25f;
                    if (universalGameManager.GetComponent<UniGameManager>().songVolume < 0f)
                    {
                        universalGameManager.GetComponent<UniGameManager>().songVolume = 1;
                    }
                   GameObject AudioObj = GameObject.FindGameObjectWithTag("Audio");
                    AudioObj.GetComponent<MyAudioScript>().AudioVolumeChange();
                    musicTxt.text = "Music Volume " + Mathf.Round(((universalGameManager.GetComponent<UniGameManager>().songVolume / 1) * 100)) + "%";
                    break;
                case 1:
                    universalGameManager.GetComponent<UniGameManager>().lookSens -= 0.5f;
                    if (universalGameManager.GetComponent<UniGameManager>().lookSens <= 0f)
                    {
                        universalGameManager.GetComponent<UniGameManager>().lookSens = 5;
                    }
                    sensTxt.text = "Look Sensitivity " + universalGameManager.GetComponent<UniGameManager>().lookSens;
                    break;
                default:
                    break;


            }
        }

        if (Input.GetAxis("Player1MoveY") > 0 || Input.GetKeyDown(KeyCode.UpArrow))
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
        if (Input.GetAxis("Player1MoveY") < 0 || Input.GetKeyDown(KeyCode.DownArrow))
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
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.P))
        {
            tvImageNo++;
            if (tvImageNo > tvImage.Length - 1)
            {
                tvImageNo = 0;
            }
            for (int i = 0; i < tvImage.Length; i++)
            {
                tvImage[i].enabled = false;
            }
            tvImage[tvImageNo].enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.O))
        {
            tvImageNo--;
            if (tvImageNo < 0)
            {
                tvImageNo = tvImage.Length - 1;
            }
            for (int i = 0; i < tvImage.Length; i++)
            {
                tvImage[i].enabled = false;
            }
            tvImage[tvImageNo].enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.X))
        {
            if (settings.enabled == false)
            {
                musicTxt.text = "Music Volume " + Mathf.Round(((universalGameManager.GetComponent<UniGameManager>().songVolume / 1) * 100)) + "%";
                sensTxt.text = "Look Sensitivity " + universalGameManager.GetComponent<UniGameManager>().lookSens;
                settings.enabled = true;
                buttonNo = 0;
                buttons = buttonsSettings;
                hiLight.transform.position = buttons[buttonNo].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Backspace))
        {
            if (settings.enabled == true)
            {
                if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
                {
                    Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
                }
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\SportsballSettings.txt";
                string[] contents = new string[3];
                contents[0] = "" + universalGameManager.GetComponent<UniGameManager>().songVolume;
                contents[1] = "" + universalGameManager.GetComponent<UniGameManager>().lookSens;
                File.WriteAllLines(path, contents);
                settings.enabled = false;
                buttonNo = 0;
                buttons = buttonsMain;
                hiLight.transform.position = buttons[buttonNo].transform.position;
                
            }
        }
    }
}
