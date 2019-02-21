using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNoBallBlock : MonoBehaviour {
    public GameObject ball;
	// Use this for initialization
	void Start () {
        Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), ball.GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
