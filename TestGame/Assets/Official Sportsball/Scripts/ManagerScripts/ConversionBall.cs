using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversionBall : MonoBehaviour {
    public GameObject gameManager;
    bool destroy;
    float timetaken = 0;
    // Use this for initialization
    private void Update()
    {
        if (destroy)
        {
            timetaken += Time.deltaTime;
            if (timetaken >= 5)
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (this.GetComponent<Rigidbody>().isKinematic == false)
        {
            destroy = true;
        }
    }
    private void OnDestroy()
    {
        gameManager.GetComponent<sportsballManager>().startReplay();
    }
}
