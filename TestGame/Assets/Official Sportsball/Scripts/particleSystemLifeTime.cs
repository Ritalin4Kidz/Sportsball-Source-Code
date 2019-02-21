using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemLifeTime : MonoBehaviour {
    float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            this.gameObject.GetComponent<ParticleSystem>().Stop();
        }
        if (time >= 3)
        {
            Destroy(this.gameObject);
        }
    }
}
