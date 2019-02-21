using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {  //On node entrance, the ai looks and moves towards the next node
        if (other.CompareTag("Target"))
        {
            if (other.GetComponent<TargetNoGameMan>())
            {
                other.GetComponent<TargetNoGameMan>().lastNode++;
                if (other.GetComponent<TargetNoGameMan>().lastNode >= other.GetComponent<TargetNoGameMan>().nodes.Length)
                {
                    other.GetComponent<TargetNoGameMan>().lastNode = 0;
                }
            }
            else
            {
                other.GetComponent<Target>().lastNode++;
                if (other.GetComponent<Target>().lastNode >= other.GetComponent<Target>().nodes.Length)
                {
                    other.GetComponent<Target>().lastNode = 0;
                }
            }
        }
        if (other.CompareTag("Guard"))
        {
            if (other.GetComponent<TargetNoGameMan>())
            {
                other.GetComponent<TargetNoGameMan>().lastNode++;
                if (other.GetComponent<TargetNoGameMan>().lastNode >= other.GetComponent<TargetNoGameMan>().nodes.Length)
                {
                    other.GetComponent<TargetNoGameMan>().lastNode = 0;
                }
            }
            else
            {
                other.GetComponent<GuardAI>().lastNode++;
                if (other.GetComponent<GuardAI>().lastNode >= other.GetComponent<GuardAI>().nodes.Length)
                {
                    other.GetComponent<GuardAI>().lastNode = 0;
                }
            }
        }
    }
}
