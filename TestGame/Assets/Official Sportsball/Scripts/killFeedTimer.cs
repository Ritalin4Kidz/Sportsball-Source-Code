using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class killFeedTimer : MonoBehaviour {
    public float time;
    float timeTaken;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeTaken += Time.deltaTime;
        if (timeTaken >= time)
        {
            Destroy(this.gameObject);
        }
	}
    public void quickDestroy()
    {
        Destroy(this.gameObject);
    }
    public void setTime(float timeA)
    {
        timeTaken = timeA;
    }
    public float getTime()
    {
        return timeTaken;
    }
}
