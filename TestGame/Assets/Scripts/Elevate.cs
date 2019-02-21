using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//simple lift script i made for the warehouse level.
public class Elevate : MonoBehaviour {
    public GameObject bottomRef;
    public GameObject topRef;
    public GameObject lift;
    public float speed;

    bool movingUp;
    bool movingDown;
	// Use lift for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movingUp == true)
        {
            lift.transform.localPosition = new Vector3(lift.transform.localPosition.x, lift.transform.localPosition.y + speed, lift.transform.localPosition.z);
            if (lift.transform.localPosition.y > topRef.transform.localPosition.y)
            {
                lift.transform.localPosition = topRef.transform.localPosition;
                movingUp = false;
            }
        }
        if (movingDown == true)
        {
            lift.transform.localPosition = new Vector3(lift.transform.localPosition.x, lift.transform.localPosition.y - speed, lift.transform.localPosition.z);
            if (lift.transform.localPosition.y < bottomRef.transform.localPosition.y)
            {
                lift.transform.localPosition = bottomRef.transform.localPosition;
                movingDown = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            {
                //Debug.Log("Hello");
                if (lift.transform.localPosition == bottomRef.transform.localPosition)
                {
                    movingUp = true;
                }
                if (lift.transform.localPosition == topRef.transform.localPosition)
                {
                    movingDown = true;
                }
            }
        }
    }
}
