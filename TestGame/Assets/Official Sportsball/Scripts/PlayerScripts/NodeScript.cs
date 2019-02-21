using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BeeSphere>())
        {
            if (other.gameObject.GetComponent<BeeSphere>().Node == this.gameObject)
            {
                if (other.gameObject.GetComponent<BeeSphere>().getMovement())
                {
                    other.gameObject.GetComponent<BeeSphere>().setMovementFalse();
                    other.gameObject.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}
