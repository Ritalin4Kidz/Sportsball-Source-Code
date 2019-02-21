using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingGoalScript1 : MonoBehaviour {
    public GameObject roof;
    public Material successLight;
    public bool success;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            success = true;
            roof.GetComponent<Renderer>().material = successLight;
        }
    }
}
