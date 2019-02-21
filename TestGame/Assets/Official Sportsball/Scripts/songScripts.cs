using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class songScripts : MonoBehaviour {
    public Text songNameTxt;
    public Text artistNameTxt;
    public Text detailsText;

    float timeAlive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeAlive += Time.deltaTime;
        if (timeAlive >= 3.5f)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
	}

    public void erase()
    {
        Destroy(this.gameObject);
        Destroy(this);
    }
}
