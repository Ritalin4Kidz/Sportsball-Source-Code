using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNoGameMan : MonoBehaviour {
    public GameObject[] nodes;
    public int lastNode;
    public bool inCircles;
    public float moveSpeed;
    bool alive;
    // Use this for initialization
    void Start () {
        alive = true;
	}
	public void setAlive(bool a_alive)
    {
        alive = a_alive;
    }
	// Update is called once per frame
	void Update () {
        if (alive)
        {
            Wander(inCircles);
        }
    }

    public void Wander(bool repeat) //simple node paths
    {
        if (lastNode == nodes.Length - 1 && repeat)
        {
            this.transform.LookAt(nodes[0].transform);
        }
        else
        {
            if (!(lastNode == nodes.Length - 1))
            {
                this.transform.LookAt(nodes[lastNode + 1].transform);
            }
        }
        this.transform.localPosition += this.transform.forward * moveSpeed * Time.deltaTime;
    }
}
