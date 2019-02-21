using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroUIScript : MonoBehaviour {
    public Image Image1;
    public Image Image2;
    public Image Logo1;
    public Image Logo2;
    public Text TeamText1;
    public Text TeamText2;
    float travelled1 = 0;
    float travelled2 = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (travelled1 < 200)
        {
            Image1.transform.position += transform.right;
            travelled1 += transform.right.x;
        }
        if (travelled2 < 200)
        {
            Image2.transform.position -= transform.right;
            travelled2 += transform.right.x;
        }
    }
}
