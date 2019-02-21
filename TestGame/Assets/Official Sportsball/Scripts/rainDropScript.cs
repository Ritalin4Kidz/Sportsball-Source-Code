using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainDropScript : MonoBehaviour {

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Destroy(this);
    }
}
