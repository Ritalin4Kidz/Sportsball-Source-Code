using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintSplats : MonoBehaviour {
    Material paintsplat;
   float lifeSpan;
    float time;
	// Use this for initialization
	void Start () {
        lifeSpan = 15;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= lifeSpan)
        {
            
            Destroy(this.gameObject);
            Destroy(this);
        }
	}
    public void SetSplat(Material newSplat)
    {
        paintsplat = newSplat;
    }
    public Material GetSplat()
    {
        return paintsplat;
    }
}
