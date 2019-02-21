using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {
    public bool canBePickedUp;
    public Vector3 spawnLoc;
    public string teamPickup;
    public float minY = -2.5f;

    public GameObject flagRef;
    GameObject flag;

    public int secondsTillExplode;
	// Use this for initialization
	void Start () {
        spawnLoc = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < minY)
        {
            this.transform.position = spawnLoc;
            this.transform.eulerAngles = Vector3.zero;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}
    public void spawnFlag()
    {
        if (flagRef != null)
        {
            flag = Instantiate(flagRef);
            flag.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (this.transform.localScale.y / 2) + (flag.transform.localScale.y / 2), this.transform.position.z);
        }
    }
    public void destroyFlag()
    {
        if (flag != null)
        {
            Destroy(flag);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && canBePickedUp)
        {
            if (collision.collider.GetComponent<PlayerScript>())
            {
                if (collision.collider.GetComponent<PlayerScript>().GetTeam() == teamPickup)
                {
                    collision.collider.GetComponent<PlayerScript>().setHoldingBomb(true, this.gameObject);
                    canBePickedUp = false;
                }
            }
        }
    }
}
