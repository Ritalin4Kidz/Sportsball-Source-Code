using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour {
    public GameObject otherPortal;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (otherPortal != null && collision.gameObject.GetComponent<Rigidbody>())
        {
            collision.gameObject.transform.position = new Vector3(otherPortal.transform.position.x, otherPortal.transform.position.y + 2.5f, otherPortal.transform.position.z);
            //collision.gameObject.transform.eulerAngles = otherPortal.transform.up;
            //collision.gameObject.transform.position += collision.gameObject.transform.forward * 5;
            collision.gameObject.GetComponent<Rigidbody>().velocity = -collision.gameObject.GetComponent<Rigidbody>().velocity;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 250, 0);
        }
    }
}
