using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDummy : MonoBehaviour {
    public float timeTilldeath;
    float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > timeTilldeath)
        {
            Destroy(this.gameObject);
        }
	}
}
