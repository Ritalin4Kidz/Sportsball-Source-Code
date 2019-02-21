using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadCentreSquare : MonoBehaviour {
    public float delay;
    float timeTaken;
    public GameObject gameManage;
    public Image loadscreen;
    public Sprite[] sources;
	// Use this for initialization
	void Start () { //loading screen is changed dependant of the level selected.
		if (gameManage.GetComponent<GameManager>().LevelToLoad == "CentreSquare")
        {
            loadscreen.sprite = sources[0];
        }
        else if (gameManage.GetComponent<GameManager>().LevelToLoad == "CentreSquare2")
        {
            loadscreen.sprite = sources[1];
        }
        else if (gameManage.GetComponent<GameManager>().LevelToLoad == "Warehouse")
        {
            loadscreen.sprite = sources[2];
        }
        else if (gameManage.GetComponent<GameManager>().LevelToLoad == "basicTutorialLevel")
        {
            loadscreen.sprite = sources[3];
        }
        else if (gameManage.GetComponent<GameManager>().LevelToLoad == "lawnMowing")
        {
            loadscreen.sprite = sources[4];
        }
    }
	
	// Update is called once per frame
	void Update () { //after a delay, open the level
        timeTaken += Time.deltaTime;
        if (timeTaken >= delay)
        {
            SceneManager.LoadScene(gameManage.GetComponent<GameManager>().LevelToLoad);
        }
	}
}
