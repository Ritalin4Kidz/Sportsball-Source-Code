using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSphereBossScript : MonoBehaviour {
    GameObject[] beeSpheres;

    public float timeTillAttack;
    bool warmingUp = false;
    float timePassed;
    int beeSize;

    int beeIndex;
    // Use this for initialization
    void Start () {
        beeSize = this.transform.childCount;
        beeSpheres = new GameObject[beeSize];
        for (int i = 0; i < beeSize; i++)
        {
            beeSpheres[i] = this.transform.GetChild(i).gameObject;
        }
        beeIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!warmingUp)
        {
            this.transform.LookAt(player.transform);
        }
        if (timePassed > timeTillAttack && !warmingUp)
        {
            warmingUp = true;
            for (int i = 0; i < beeSize; i++)
            {
                if (beeSpheres[i] != null)
                {
                    beeSpheres[i].transform.GetChild(0).gameObject.transform.LookAt(player.transform);
                }
            }
        }
        if (timePassed > timeTillAttack + 2)
        {
            for (int i = 0; i < beeSize; i++)
            {
                if (beeSpheres[i] != null)
                {
                    if (beeSpheres[i].transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic)
                    {
                        //player = GameObject.FindGameObjectWithTag("Player");
                        //beeSpheres[i].transform.GetChild(0).gameObject.transform.LookAt(player.transform);
                        beeSpheres[i].transform.GetChild(0).gameObject.GetComponent<BeeSphere>().TriggerFunc();
                        beeSpheres[i].transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(beeSpheres[i].transform.GetChild(0).gameObject.transform.forward * 30);
                    }
                }
            }
            timePassed = 0;
            warmingUp = false;
        }
	}
}
