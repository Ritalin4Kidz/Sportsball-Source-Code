using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutScene : MonoBehaviour {
    public RawImage screen;
    MovieTexture MT;
    bool startedPlay;
    Canvas loadScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startedPlay)
        {

            if (!MT.isPlaying)
            {
                loadScreen.GetComponent<LoadMap>().started = true;
                loadScreen.enabled = true;
                Destroy(this.gameObject);
            }
        }
	}
    public void setLoad(Canvas a_Load)
    {
        loadScreen = a_Load;
    }
    public void videoChange(MovieTexture a_MT)
    {
        screen.texture = a_MT;
        MT = (MovieTexture)screen.texture;
        MT.Play();
        startedPlay = true;
    }
}
