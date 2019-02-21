using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FaceUIScript : MonoBehaviour {
    public Image blindCanvas;
    public Image blindCanvas2;
    public float alphaVar;
    Material paintVision;
    float seconds;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (alphaVar > 0)
        {
            seconds += Time.deltaTime;
            if (seconds > 0.01f)
            {
                alphaVar -= 0.005f;
                seconds -= 0.01f;
            }
        }
        else
        {
            if (seconds != 0)
            {
                seconds = 0;
            }
        }
        blindCanvas.color = new Vector4(blindCanvas.color.r, blindCanvas.color.g, blindCanvas.color.b, alphaVar);
        blindCanvas2.color = new Vector4(blindCanvas2.color.r, blindCanvas2.color.g, blindCanvas2.color.b, alphaVar);
        blindCanvas.material = paintVision;
	}
    public void setPaintVision(Material a_paint)
    {
        paintVision = a_paint;
    }
}
