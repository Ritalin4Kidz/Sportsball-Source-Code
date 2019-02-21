using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedTarget : MonoBehaviour {
    //public GameObject gameManage;
    public Canvas[] clocks;
    public float bounty;

    //public GameObject returnArea;

    private bool m_Active = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.childCount == 0 && m_Active) //when all the weeds are gone, the exit opens.
        {
            for (int i = 0; i < clocks.Length; i++)
            {
                clocks[i].GetComponent<TrainingTimer>().clockON = false;
            }
            m_Active = false;
        }
	}
}
