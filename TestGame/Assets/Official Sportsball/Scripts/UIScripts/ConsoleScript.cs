using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ConsoleScript : MonoBehaviour {
    public InputField cmdField;
    public Text textBox;
    public Image consoleBox;
    public Sprite[] crosshairSprites;
    public Sprite[] consoleSprites;
    public GameObject uniManage;


    bool cheats = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("`"))
        {
            Destroy(this.gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            string cmd = cmdField.text;
            string commandLower = cmdField.text;
            char[] commandUse = commandLower.ToCharArray();
            textBox.text += cmd + "\n";
            cmdField.text = "";
            string valueStr = "";
            for (int i = 0; i < commandUse.Length; i++)
            {
                if (commandUse[i] == '<')
                {
                    for (int ii = i + 1; ii < commandUse.Length; ii++)
                    {
                        if (commandUse[ii] == '>')
                        {
                            commandLower = commandLower.Substring(0, (commandLower.Length - (valueStr.Length + 2)));
                            break;
                        }
                        else
                        {
                            valueStr += commandUse[ii];
                        }
                    }
                }
            }
            //Debug.Log(commandLower + "," + valueStr);
            commandLower = commandLower.ToLower();
            commandExec(commandLower, valueStr);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (cmdField.text.Length > 0)
            {
                cmdField.text = cmdField.text.Substring(0, cmdField.text.Length - 1);
            }
        }
        else if (Input.anyKeyDown)
        {
            string newChar = Input.inputString;
            if (cmdField.enabled)
            {
                cmdField.text += newChar;
            }
        }
    }

    void commandExec(string a_cmd, string value)
    {
        GameObject sbMan = GameObject.FindGameObjectWithTag("Game Manager");
        switch (a_cmd)
        {
            //console commands
            case "console_cheats":
                bool m_cheats;
                bool.TryParse(value, out m_cheats);
                cheats = m_cheats;
                textBox.text += "Cheats : " + cheats + "\n";
                break;
            case "console_colour":
                Color colourConsole = ColourReturn(value, Color.gray);
                consoleBox.color = colourConsole;
                break;
            case "console_textcolour":
                Color colourTextConsole = ColourReturn(value, Color.white);
                textBox.color = colourTextConsole;
                break;
            case "console_clear":
                textBox.text = "";
                break;
            case "console_bg":
                Sprite bg = consoleSprites[ConsoleInt(value)];
                consoleBox.sprite = bg;
                break;
            case "console_quit":
                Destroy(this.gameObject);
                break;
            //game commands
            case "game_pause":
                if (sbMan != null)
                {
                    sbMan.GetComponent<sportsballManager>().SetInplay(false);
                }
                break;
            case "game_resume":
                if (sbMan != null)
                {
                    sbMan.GetComponent<sportsballManager>().SetInplay(true);
                }
                break;
            case "game_seconds":
                if (sbMan != null)
                {
                    int secondsToUse;
                    int.TryParse(value, out secondsToUse);
                    sbMan.GetComponent<sportsballManager>().setSeconds(secondsToUse);
                }
                break;
            case "game_teamscore1":
                if (sbMan != null)
                {
                    int intToUse;
                    int.TryParse(value, out intToUse);
                    sbMan.GetComponent<sportsballManager>().setTeam1Score(intToUse);
                }
                break;
            case "game_teamscore2":
                if (sbMan != null)
                {
                    int intToUse;
                    int.TryParse(value, out intToUse);
                    sbMan.GetComponent<sportsballManager>().setTeam2Score(intToUse);
                }
                break;

            //player commands
            case "player1_sens":
                if (sbMan != null)
                {
                    float floatToUse;
                    float.TryParse(value, out floatToUse);
                    sbMan.GetComponent<sportsballManager>().setSens(0,floatToUse);
                }
                break;
            case "player2_sens":
                if (sbMan != null)
                {
                    float floatToUse;
                    float.TryParse(value, out floatToUse);
                    sbMan.GetComponent<sportsballManager>().setSens(1, floatToUse);
                }
                break;
            case "player3_sens":
                if (sbMan != null)
                {
                    float floatToUse;
                    float.TryParse(value, out floatToUse);
                    sbMan.GetComponent<sportsballManager>().setSens(2, floatToUse);
                }
                break;
            case "player4_sens":
                if (sbMan != null)
                {
                    float floatToUse;
                    float.TryParse(value, out floatToUse);
                    sbMan.GetComponent<sportsballManager>().setSens(3, floatToUse);
                }
                break;
            case "player1_name":
                if (sbMan != null)
                {
                    sbMan.GetComponent<sportsballManager>().setName(0,value);
                }
                break;
            case "player2_name":
                if (sbMan != null)
                {
                    sbMan.GetComponent<sportsballManager>().setName(1, value);
                }
                break;
            case "player3_name":
                if (sbMan != null)
                {
                    sbMan.GetComponent<sportsballManager>().setName(2, value);
                }
                break;
            case "player4_name":
                if (sbMan != null)
                {
                    sbMan.GetComponent<sportsballManager>().setName(3, value);
                }
                break;
            case "player1_crosshaircolour":
                if (sbMan != null)
                {
                    value = value.ToLower();
                    Color colour = ColourReturn(value, sbMan.GetComponent<sportsballManager>().getCrosshairColour(0));
                    sbMan.GetComponent<sportsballManager>().setCrosshairColour(0, colour);
                }
                break;
            case "player2_crosshaircolour":
                if (sbMan != null)
                {
                    value = value.ToLower();
                    Color colour = ColourReturn(value, sbMan.GetComponent<sportsballManager>().getCrosshairColour(1));
                    sbMan.GetComponent<sportsballManager>().setCrosshairColour(1, colour);
                }
                break;
            case "player3_crosshaircolour":
                if (sbMan != null)
                {
                    value = value.ToLower();
                    Color colour = ColourReturn(value, sbMan.GetComponent<sportsballManager>().getCrosshairColour(2));
                    sbMan.GetComponent<sportsballManager>().setCrosshairColour(2, colour);
                }
                break;
            case "player4_crosshaircolour":
                if (sbMan != null)
                {
                    value = value.ToLower();
                    Color colour = ColourReturn(value, sbMan.GetComponent<sportsballManager>().getCrosshairColour(3));
                    sbMan.GetComponent<sportsballManager>().setCrosshairColour(3, colour);
                }
                break;
            case "player1_crosshairstyle":
                if (sbMan != null)
                {
                    Sprite cross_hair = crosshairSprites[CrosshairInt(value)];
                    sbMan.GetComponent<sportsballManager>().setCrosshairStyle(0, cross_hair);
                }
                break;
            case "player2_crosshairstyle":
                if (sbMan != null)
                {
                    Sprite cross_hair = crosshairSprites[CrosshairInt(value)];
                    sbMan.GetComponent<sportsballManager>().setCrosshairStyle(1, cross_hair);
                }
                break;
            case "player3_crosshairstyle":
                if (sbMan != null)
                {
                    Sprite cross_hair = crosshairSprites[CrosshairInt(value)];
                    sbMan.GetComponent<sportsballManager>().setCrosshairStyle(2, cross_hair);
                }
                break;
            case "player4_crosshairstyle":
                if (sbMan != null)
                {
                    Sprite cross_hair = crosshairSprites[CrosshairInt(value)];
                    sbMan.GetComponent<sportsballManager>().setCrosshairStyle(3, cross_hair);
                }
                break;
            case "player1_crosshairsize":
                if (sbMan != null)
                {
                    float floatToUse;
                    float.TryParse(value, out floatToUse);
                    sbMan.GetComponent<sportsballManager>().setCrosshairSize(0, floatToUse);
                }
                break;
            case "player2_crosshairsize":
                if (sbMan != null)
                {
                    float floatToUse;
                    float.TryParse(value, out floatToUse);
                    sbMan.GetComponent<sportsballManager>().setCrosshairSize(1, floatToUse);
                }
                break;
            case "player3_crosshairsize":
                if (sbMan != null)
                {
                    float floatToUse;
                    float.TryParse(value, out floatToUse);
                    sbMan.GetComponent<sportsballManager>().setCrosshairSize(2, floatToUse);
                }
                break;
            case "player4_crosshairsize":
                if (sbMan != null)
                {
                    float floatToUse;
                    float.TryParse(value, out floatToUse);
                    sbMan.GetComponent<sportsballManager>().setCrosshairSize(3, floatToUse);
                }
                break;

            //game process commands
            case "process_exit":
                Application.Quit();
                break;
            case "process_sceneload":
                if (Application.CanStreamedLevelBeLoaded(value))
                {
                    SceneManager.LoadScene(value);
                }
                break;
            case "process_timescale":
                if (cheats)
                {
                    float floatTime;
                    float.TryParse(value, out floatTime);
                    Time.timeScale = floatTime;         
                }
                break;
            case "process_gravity":
                if (cheats)
                {
                    float floatGrav;
                    float.TryParse(value, out floatGrav);
                    Physics.gravity = new Vector3(Physics.gravity.x, -(Mathf.Abs(floatGrav)), Physics.gravity.z);
                }
                break;
            case "process_gravityvec3":
                if (cheats)
                {
                    string[] floatGravStr = value.Split(',');
                    if (floatGravStr.Length < 3)
                    {
                        break;
                    }
                    float[] floatGrav = new float[floatGravStr.Length];
                    for (int i = 0; i < floatGravStr.Length; i++)
                    {
                        float.TryParse(floatGravStr[i], out floatGrav[i]);
                        //floatGrav[i] = (Mathf.Abs(floatGrav[i]));
                    }
                    floatGrav[1] = (Mathf.Abs(floatGrav[1]));
                    Physics.gravity = new Vector3(floatGrav[0], -floatGrav[1], floatGrav[2]);
                }
                break;
            default:
                break;

        }
    }
    public int CrosshairInt(string value)
    {
        int valueNo;
        value = value.ToLower();
        switch (value)
        {
            case "block":
                valueNo = 0;
                break;
            case "dots":
                valueNo = 1;
                break;
            case "classic":
                valueNo = 2;
                break;
            case "scope":
                valueNo = 3;
                break;
            default:
                valueNo = 0;
                break;
        }
        return valueNo;
    }
    public int ConsoleInt(string value)
    {
        int valueNo;
        value = value.ToLower();
        switch (value)
        {
            case "solid":
                valueNo = 0;
                break;
            case "hacker":
                valueNo = 1;
                break;
            case "annoying_spiral":
                valueNo = 2;
                break;
            case "gradient":
                valueNo = 3;
                break;
            default:
                valueNo = 0;
                break;
        }
        return valueNo;
    }
    public Color ColourReturn(string a_value, Color defaultColour)
    {
        Color colour;
        switch (a_value)
        {
            case "white":
                colour = Color.white;
                break;
            case "green":
                colour = Color.green;
                break;
            case "blue":
                colour = Color.blue;
                break;
            case "red":
                colour = Color.red;
                break;
            case "yellow":
                colour = Color.yellow;
                break;
            case "black":
                colour = Color.black;
                break;
            case "cyan":
                colour = Color.cyan;
                break;
            case "magenta":
                colour = Color.magenta;
                break;
            default:
                colour = defaultColour;
                break;

        }
        return colour;
    }
}
