using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public GameObject lastPlayer;

    public GameObject playerHolding;

    public AudioClip ballSound;
    public Vector3 originalSize;
    bool isStatic;
    float timeStatic;

    bool isAttached;
	// Use this for initialization
	void Start () {
        isStatic = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isStatic)
        {
            timeStatic += Time.deltaTime;
            if (timeStatic >= 3)
            {
                timeStatic = 0;
                isStatic = false;
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(ballSound, this.transform.position, 1.0f);
    }

    public void setAttached(bool a_bool)
    {
        isAttached = a_bool;
    }
    public bool getAttached()
    {
        return isAttached;
    }
    public void unAttach()
    {
        isAttached = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.transform.parent = null;
        this.gameObject.transform.localScale = originalSize;
        if (playerHolding != null)
        {
            playerHolding.GetComponent<PlayerScript>().canScoreEuro = false;
            playerHolding.GetComponent<PlayerScript>().gun.SetActive(true);
            GetComponent<Collider>().enabled = true;
            //Physics.IgnoreCollision(GetComponent<Collider>(), playerHolding.GetComponent<Collider>(), false);
            playerHolding = null;
        }
    }
    public void removeMotion()
    {
        timeStatic = 0;
        this.GetComponent<Rigidbody>().isKinematic = true;
        isStatic = true;
    }
}
