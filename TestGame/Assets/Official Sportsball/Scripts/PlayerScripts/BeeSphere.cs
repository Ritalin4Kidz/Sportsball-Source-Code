using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSphere : MonoBehaviour {
    public float TimeToNode;
    bool nodeMovementDelay = false;
    bool nodeMovement = false;
    float timePassed;

    public float speed;

    public GameObject Node;
	// Use this for initialization
	void Start () {
        timePassed = 0;
	}
    public bool getMovement()
    {
        return nodeMovement;
    }
	public void setMovementFalse()
    {
        nodeMovement = false;
        nodeMovementDelay = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.GetComponent<Collider>().isTrigger = true;
    }
	// Update is called once per frame
	void Update () {
		if (nodeMovementDelay) //is preparing to move
        {
            timePassed += Time.deltaTime;
            if (timePassed >= TimeToNode) //delay is done, time to make it start moving
            {
                nodeMovement = true;
                nodeMovementDelay = false;
                timePassed = 0;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                this.gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
        else if (nodeMovement)
        {
            this.gameObject.transform.LookAt(Node.transform); //looks at original placement
            this.gameObject.transform.position += this.gameObject.transform.forward * speed * Vector3.Distance(this.gameObject.transform.position,Node.transform.position) * Time.deltaTime; //moves towards origin point
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.GetComponent<Collider>().isTrigger = false;
            nodeMovementDelay = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("BeeSphere") && !other.gameObject.CompareTag("Node"))
        {
            TriggerFunc();
        }
    }
    public void TriggerFunc() //basic on trigger function, easily to call when it's in a sub-routine
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        nodeMovementDelay = true;
    }
}
