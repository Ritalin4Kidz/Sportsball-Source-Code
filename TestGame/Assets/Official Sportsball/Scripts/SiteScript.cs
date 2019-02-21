using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteScript : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerScript>())
            {
                other.GetComponent<PlayerScript>().setCanPlant(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerScript>())
            {
                other.GetComponent<PlayerScript>().setCanPlant(false);
                other.GetComponent<PlayerScript>().resetCounter();
            }
        }
    }
}
