using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<missionPlayerScript>())
            {
                other.GetComponent<missionPlayerScript>().hp--;
            }
            else if (other.GetComponent<missionAI>())
            {
                other.GetComponent<missionAI>().hp--;
            }
        }
    }
}
