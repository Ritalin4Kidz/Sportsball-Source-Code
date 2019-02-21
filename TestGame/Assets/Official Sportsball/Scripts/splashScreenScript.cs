using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class splashScreenScript : MonoBehaviour {
    public Canvas[] UIs;
    Canvas canvasUI;
    int canNo = 0;
	// Use this for initialization
	void Start () {
        canvasUI = Instantiate(UIs[canNo]);
        canvasUI.GetComponent<UILifeScript>().Manager = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void nextScreen()
    {
        canNo++;
        if (canNo >= UIs.Length)
        {
            SceneManager.LoadScene("MenuMockUp");
        }
        else
        {
            canvasUI = Instantiate(UIs[canNo]);
            canvasUI.GetComponent<UILifeScript>().Manager = this.gameObject;
        }
    }

}
