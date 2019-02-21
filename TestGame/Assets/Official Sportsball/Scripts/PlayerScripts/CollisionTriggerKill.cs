using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerKill : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<missionPlayerScript>())
        {
            collision.gameObject.GetComponent<missionPlayerScript>().hp--;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<missionPlayerScript>())
        {
            collision.gameObject.GetComponent<missionPlayerScript>().hp--;
        }
    }
}
