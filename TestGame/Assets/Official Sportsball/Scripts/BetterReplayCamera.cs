using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterReplayCamera : MonoBehaviour {
    public GameObject ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(ball.transform);
        this.transform.position = new Vector3(ball.transform.position.x - 5, 8, ball.transform.position.z - 5);
    }
}
