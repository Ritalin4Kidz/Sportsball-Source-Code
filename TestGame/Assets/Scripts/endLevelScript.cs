using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class endLevelScript : MonoBehaviour {
    public GameObject gameManage;
    public Text endLevelStats;

	// Use this for initialization
	void Start () {
        Screen.lockCursor = false;
        endLevelStats.text = "Good job on completing your assignment. Here is your payment \n \n \n \nPayment : $" + gameManage.GetComponent<GameManager>().getLastBounty();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onOnlyButtonClick()
    {
        SceneManager.LoadScene("levelSelect");
    }
}
