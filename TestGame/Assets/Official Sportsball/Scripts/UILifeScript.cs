using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILifeScript : MonoBehaviour {
    public GameObject Manager;
    float timeToSurvive = 5;
    float time;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= timeToSurvive || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Manager.GetComponent<splashScreenScript>().nextScreen();
            Destroy(this.gameObject);
        }
    }

}
