using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUpText : MonoBehaviour {
    public float timeAlive;
    
    float time;

    public Text MessageText;

    public void SetString(string a_Text)
    {
        MessageText.text = a_Text;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= timeAlive)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
	}
}
