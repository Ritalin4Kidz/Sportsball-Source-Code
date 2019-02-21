using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) //when attacked by the lawnmower, the weed dies
    {
        if (other.CompareTag("Lawnmower"))
        {

            Destroy(gameObject);
        }
    }
}
