using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {
    public GameObject gameManage;
    public Text moneyText;
    public string LeveltoLoad;
    public Text[] contractText;
    string[] contractLevel;
    // Use this for initialization
    void Start () {
        contractLevel = new string[contractText.Length];
        moneyText.text = "Player Cash $" + gameManage.GetComponent<GameManager>().playerCash; //amount of cash player has
        Screen.lockCursor = false;
        for (int i = 0;  i < contractText.Length;i++)
        {
            int num = Random.Range(0, 4); //a random number is pulled to determine next job, it is then visually represented
            if (num == 0)
            {
                contractText[i].text = " George Amak\n $500 Bounty\n Centre Square\n \n \n \n \n DANGER LEVEL LOW";
                contractLevel[i] = "CentreSquare";
            }
            else if (num == 1)
            {
                contractText[i].text = " Carl Daniels\n $750 Bounty\n Centre Square\n \n \n \n \n DANGER LEVEL LOW";
                contractLevel[i] = "CentreSquare2";
            }
            else if (num == 2)
            {
                contractText[i].text = " Mike Matthews\n $5000 Bounty\n Placio\n \n \n \n \n DANGER LEVEL HIGH";
                contractLevel[i] = "Warehouse";
            }
            else if (num == 3)
            {
                contractText[i].text = "Do the lawn sweetie";
                contractLevel[i] = "lawnMowing";
            }
        }
    }
	
	// Update is called once per frame
	void Update () { 
	}


    public void onForestLevelClick() //level loading, on centre square & load level obselete now
    {
        gameManage.GetComponent<GameManager>().LevelToLoad = "basicTutorialLevel";
        SceneManager.LoadScene("loadCentreSquare");
    }
    public void onCentreSquareClick()
    {
        SceneManager.LoadScene("loadCentreSquare");
    }
    public void onLoadLevelClick()
    {
        SceneManager.LoadScene("loadCentreSquare");
    }
    public void onContract1Click() //loads the loading scene.
    {
        gameManage.GetComponent<GameManager>().LevelToLoad = contractLevel[0];
        SceneManager.LoadScene("loadCentreSquare");
    }
    public void onContract2Click() //loads the loading scene.
    {
        gameManage.GetComponent<GameManager>().LevelToLoad = contractLevel[1];
        SceneManager.LoadScene("loadCentreSquare");
    }
    public void onContract3Click() //loads the loading scene.
    {
        gameManage.GetComponent<GameManager>().LevelToLoad = contractLevel[2];
        SceneManager.LoadScene("loadCentreSquare");
    }
    public void onContract4Click() //loads the loading scene.
    {
        gameManage.GetComponent<GameManager>().LevelToLoad = contractLevel[3];
        SceneManager.LoadScene("loadCentreSquare");
    }
    public void ExitGame() //quits the game
    {
        Application.Quit();
    }
    
}
