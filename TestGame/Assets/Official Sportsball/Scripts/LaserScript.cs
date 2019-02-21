using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {
    // Use this for initialization
    public GameObject trapMain;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() && other.CompareTag("Ball"))
        {
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * 200);
        }
        if (other.GetComponent<Rigidbody>() && other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * 500);
        }
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerScript>())
            {
                if (other.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().isPaintball)
                {
                    other.GetComponent<PlayerScript>().active = false;
                    other.GetComponent<PlayerScript>().throwBomb();
                    other.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().sendToDead(other.gameObject);
                    other.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().KillFeedSend(other.GetComponent<PlayerScript>().getPlayerName() + " Got Trapped");
                    other.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
                }
            }
        }
        else if (other.CompareTag("Gun"))
        {
            if (other.transform.parent.GetComponent<PlayerScript>())
            {
                if (other.transform.parent.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().isPaintball)
                {
                    other.transform.parent.GetComponent<PlayerScript>().active = false;
                    other.transform.parent.GetComponent<PlayerScript>().throwBomb();
                    other.transform.parent.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().sendToDead(other.transform.parent.gameObject);
                    other.transform.parent.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().KillFeedSend(other.transform.parent.GetComponent<PlayerScript>().getPlayerName() + " Got Trapped");
                    other.transform.parent.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
                }
                else
                {
                    other.transform.parent.GetComponent<Rigidbody>().AddForce(-other.transform.forward * 500);
                }
            }
        }
        trapMain.GetComponent<TrapScript>().destroyTrap();
        Destroy(this.gameObject);
        
    }

    
}
