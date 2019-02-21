using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour {
    public float HP = 100;
    bool dead;
    public GameObject[] nodes;
    public int lastNode;
    public GameObject player;
    public GameObject playerGun;
    bool seen;
    public float moveSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Vector3.Distance(player.GetComponent<CapsuleCollider>().gameObject.transform.localPosition, this.transform.localPosition));
        if (Vector3.Distance(player.GetComponent<CapsuleCollider>().gameObject.transform.localPosition, this.transform.localPosition) < 5)
        {
            seen = true;
        }
        else
        {
            seen = false;
        }
        if (!dead &!seen)
        {
            Wander();
        }
        if (seen & !dead)
        {
            this.transform.LookAt(playerGun.transform);
            this.transform.localPosition += this.transform.forward * moveSpeed * Time.deltaTime;
            if ((Vector3.Distance(player.GetComponent<CapsuleCollider>().gameObject.transform.localPosition, this.transform.localPosition) < 1.5f))
            {
                player.GetComponent<Movement>().hp -= 1;
            }
        }
        if (HP <= 0)
        {
            dead = true;
        }
    }

    public void Wander()
    {
        if (lastNode == nodes.Length - 1)
        {
            this.transform.LookAt(nodes[0].transform);
        }
        else
        {
            this.transform.LookAt(nodes[lastNode + 1].transform);
        }
        this.transform.localPosition += this.transform.forward * moveSpeed * Time.deltaTime;
    }
}
