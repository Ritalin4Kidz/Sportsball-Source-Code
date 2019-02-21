using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MissionMenu : MonoBehaviour {

    public Material[] levelPics;
    public string[] levels;
    public KeyCode LevelUp;
    public KeyCode LevelDown;
    public KeyCode quitBtn;
    public string LevelLoad;
    public GameObject universalGameManager;
    public Image levelImg;
    public Image ready1Img;
    bool ready1;
    public Text mapName;
    KeyCode readyBtn1;
    public Canvas thisCanvas;
    public Canvas loadCanvas;
    public Canvas startImg;
    int i = 0;
    // Use this for initialization
    void Start()
    {
        loadCanvas.enabled = false;
        readyBtn1 = KeyCode.Joystick1Button0;
        startImg.enabled = false;
        mapName.text = "Assignment A0178";
    }
    void MapNameChange(int j)
    {
        switch (j)
        {
            case 0:
                mapName.text = "Assignment A0178";
                break;
            case 1:
                mapName.text = "Chompball's Arena";
                break;
            case 2:
                mapName.text = "Lawn Mowing (Contract)";
                break;
            case 3:
                mapName.text = "Centre Square Assassination (Contract)";
                break;
            case 4:
                mapName.text = "Lawn Mowing (Sports Field)";
                break;
            case 5:
                mapName.text = "Bee Keeper (For Some Reason)";
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(readyBtn1) || Input.GetKeyDown(KeyCode.Space))
        {
            {
                if (!ready1)
                {
                    ready1Img.color = new Vector4(1, 1, 1, 1);
                    ready1 = true;
                    startImg.enabled = true;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.B))
        {
            if (ready1)
            {
                ready1Img.color = new Vector4(0, 0, 0, 1);
                ready1 = false;
                startImg.enabled = false;
            }
        }
        if (Input.GetKey(quitBtn) || Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("MenuMockUp");
        }
        if (Input.GetKeyDown(LevelUp) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            i++;
            if (i > levels.Length - 1)
            {
                i = 0;
            }
            universalGameManager.GetComponent<UniGameManager>().LevelLoad = levels[i];
            levelImg.material = levelPics[i];
            MapNameChange(i);

        }
        if (Input.GetKeyDown(LevelDown) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            i--;
            if (i < 0)
            {
                i = levels.Length - 1;
            }
            universalGameManager.GetComponent<UniGameManager>().LevelLoad = levels[i];
            levelImg.material = levelPics[i];
            MapNameChange(i);
        }
        if (Input.GetKey(KeyCode.Joystick1Button7) && ready1)
        {
            universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer = false;
            loadCanvas.enabled = true;
            loadCanvas.GetComponent<LoadMap>().started = true;
            thisCanvas.enabled = false;
        }
        if (Input.GetKey(KeyCode.Return) && ready1)
        {
            universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer = true;
            loadCanvas.enabled = true;
            loadCanvas.GetComponent<LoadMap>().started = true;
            thisCanvas.enabled = false;
        }
    }
}
