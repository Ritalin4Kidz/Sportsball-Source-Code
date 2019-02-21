using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBeeSphere : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BeeSphere"))
        {
            Destroy(other.transform.parent.gameObject);

        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<missionPlayerScript>().hp--;

        }
    }
}
