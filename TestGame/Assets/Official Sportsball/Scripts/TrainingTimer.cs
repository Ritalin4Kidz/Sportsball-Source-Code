using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrainingTimer : MonoBehaviour {
    public Text time;
    float timePassed;
    int seconds;

    public bool clockON;
    // Use this for initialization
    void Start () {
        clockON = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (clockON)
        {
            timePassed += Time.deltaTime;
            seconds = (int)timePassed;
            int minutes;
            int secondsToUse;
            int milliseconds;
            float millisecondsToUse;
            minutes = seconds / 60;
            secondsToUse = seconds - (minutes * 60);
            millisecondsToUse = (timePassed % 1) * 100;
            milliseconds = (int)millisecondsToUse;

            if (secondsToUse < 10)
            {
                if (milliseconds < 10)
                {
                    time.text = minutes + ":0" + secondsToUse + ":0" + milliseconds;
                }
                else
                {
                    time.text = minutes + ":0" + secondsToUse + ":" + milliseconds;
                }
            }
            else
            {
                if (milliseconds < 10)
                {
                    time.text = minutes + ":" + secondsToUse + ":0" + milliseconds;
                }
                else
                {
                    time.text = minutes + ":" + secondsToUse + ":" + milliseconds;
                }
            }
        }
    }
}
