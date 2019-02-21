using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalSocketScript : MonoBehaviour {
    public float damage;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BossScript>()) //Only bosses have the boss script, so checks to see that the collision is a boss
        {
            other.gameObject.GetComponent<BossScript>().SetHP(other.gameObject.GetComponent<BossScript>().GetHP()-damage); //removes a portion of the boss' hp
            Destroy(this.gameObject); //Destroys the socket, stops players spamming the same socket
        }
    }
}
