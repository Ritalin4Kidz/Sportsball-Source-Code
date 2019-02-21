using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempDisappear : MonoBehaviour {
    bool repairing;
    public float timeToRepair;
    float repairtime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (repairing)
        {
            repairtime += Time.deltaTime;
            if (repairtime >= timeToRepair)
            {
                repairtime = 0;
                repairing = false;
                this.gameObject.GetComponent<Collider>().enabled = true;
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            repairing = true;
        }
    }
}
