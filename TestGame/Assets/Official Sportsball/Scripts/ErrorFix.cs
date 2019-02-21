using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ErrorFix : MonoBehaviour {
    public float timeTillRs;
    float time;
    public bool errorON;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (errorON)
        {
            time += Time.deltaTime;
            if (time > timeTillRs)
            {
                SceneManager.LoadScene("MenuMockUp");
            }
        }
	}
}
