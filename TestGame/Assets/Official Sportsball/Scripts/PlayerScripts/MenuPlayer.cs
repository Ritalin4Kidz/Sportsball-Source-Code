using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Player1LookX") > 0 || Input.GetKey(KeyCode.D))
        {
            this.transform.eulerAngles -= new Vector3(0,speed * Time.deltaTime,0);
        }
        if (Input.GetAxis("Player1LookX") < 0 || Input.GetKey(KeyCode.A))
        {
            this.transform.eulerAngles += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Player1LookY") > 0 || Input.GetKey(KeyCode.W))
        {
            this.transform.eulerAngles -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetAxis("Player1LookY") < 0 || Input.GetKey(KeyCode.S))
        {
            this.transform.eulerAngles += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
