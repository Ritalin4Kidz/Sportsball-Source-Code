using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour {
    public GameObject otherTrap;
    public GameObject laserRef;

    public GameObject sphere1;
    public GameObject sphere2;

    GameObject laser1;
    GameObject laser2;
    // Use this for initialization
    void Start () {
	}
    public void destroyTrap()
    {
        Destroy(laser1);
        Destroy(laser2);
        Destroy(otherTrap);
        Destroy(this.gameObject);
    }
    public void createLaser()
    {
        if (otherTrap != null)
        {
            if (otherTrap.GetComponent<TrapScript>())
            {
                laser1 = Instantiate(laserRef);
                laser1.GetComponent<LaserScript>().trapMain = this.gameObject;
                laser1.transform.position = sphere1.transform.position;
                laser1.transform.LookAt(otherTrap.GetComponent<TrapScript>().sphere1.transform);
                laser1.transform.position = new Vector3(sphere1.transform.position.x + (otherTrap.GetComponent<TrapScript>().sphere1.transform.position.x - sphere1.transform.position.x) / 2, sphere1.transform.position.y + (otherTrap.GetComponent<TrapScript>().sphere1.transform.position.y - sphere1.transform.position.y) / 2, sphere1.transform.position.z + (otherTrap.GetComponent<TrapScript>().sphere1.transform.position.z - sphere1.transform.position.z) / 2);
                laser1.transform.localScale = new Vector3(0.15f,0.25f, Vector3.Distance(sphere1.transform.position, otherTrap.GetComponent<TrapScript>().sphere1.transform.position));


                laser2 = Instantiate(laserRef);
                laser2.GetComponent<LaserScript>().trapMain = this.gameObject;
                laser2.transform.position = sphere2.transform.position;
                laser2.transform.LookAt(otherTrap.GetComponent<TrapScript>().sphere2.transform);
                laser2.transform.position = new Vector3(sphere2.transform.position.x + (otherTrap.GetComponent<TrapScript>().sphere2.transform.position.x - sphere2.transform.position.x) / 2, sphere2.transform.position.y + (otherTrap.GetComponent<TrapScript>().sphere2.transform.position.y - sphere2.transform.position.y) / 2, sphere2.transform.position.z + (otherTrap.GetComponent<TrapScript>().sphere2.transform.position.z - sphere2.transform.position.z) / 2);
                laser2.transform.localScale = new Vector3(0.15f, 0.25f, Vector3.Distance(sphere2.transform.position, otherTrap.GetComponent<TrapScript>().sphere2.transform.position));

            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
