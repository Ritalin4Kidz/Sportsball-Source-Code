using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) //simple if statement to check whether or not the player has accessed the endzone
    {
        if (other.CompareTag("Player") || other.CompareTag("Lawnmower"))
        {
            SceneManager.LoadScene("levelSuccess");
        }
    }
}
