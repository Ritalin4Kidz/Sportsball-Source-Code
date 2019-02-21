using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConsole : MonoBehaviour {
    public Canvas consoleRef;
    Canvas console;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("`") && console == null)
        {
            console = Instantiate(consoleRef);
        }
    }
}
