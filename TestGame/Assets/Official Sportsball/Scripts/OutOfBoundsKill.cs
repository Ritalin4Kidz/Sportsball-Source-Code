using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.GetComponent<missionPlayerScript>())
            {
                collision.collider.GetComponent<missionPlayerScript>().hp = 0;
            }
        }
    }
}
