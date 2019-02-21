using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour {
    public float power;
    // Use this for initialization
    private void Start()
    {
       // this.transform.LookAt(this.transform.up);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Rigidbody>().velocity += this.gameObject.transform.up * power;
        }
    }
}
