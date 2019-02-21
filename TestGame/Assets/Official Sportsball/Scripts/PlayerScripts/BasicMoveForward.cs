using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition += new Vector3(this.transform.forward.x * Time.deltaTime * 5 * 2, 0, this.transform.forward.z * Time.deltaTime * 5 * 2);
    }
}
