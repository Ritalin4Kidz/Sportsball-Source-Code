using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainCloud : MonoBehaviour {
    public int minXLoc, minZLoc, maxXLoc, maxZLoc;

    public float timeTillNextDrop;

    public GameObject rainDropRef;
    float timeTaken;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeTaken += Time.deltaTime;
		if (timeTaken >=timeTillNextDrop)
        {
            timeTaken = 0;
            float xPos = Random.Range(minXLoc,maxXLoc);
            float zPos = Random.Range(minZLoc, maxZLoc);
            float yPos = this.gameObject.transform.localPosition.y - 2;
            Instantiate(rainDropRef, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        }
	}
}
