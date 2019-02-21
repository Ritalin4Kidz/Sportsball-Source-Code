using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpyCamera : MonoBehaviour {
    float timeTillDestroy = 15;
    public GameObject CamObj;
    public GameObject player;
    float time;
    Image footageImg;
    public Canvas uiRef;
    RenderTexture temp;
    Canvas ui;
	// Use this for initialization
	void Start () {
        RenderTexture temp = new RenderTexture(256,256,24,RenderTextureFormat.ARGB32);
        ui = Instantiate(uiRef);
        footageImg = ui.GetComponent<SpyCameraUI>().Img;
        ui.GetComponent<Canvas>().worldCamera = player.GetComponent<PlayerScript>().cam;
        ui.GetComponent<Canvas>().planeDistance = 1.05f;
        ui.GetComponent<Canvas>().sortingOrder = 5;
        temp.anisoLevel = 0;
        CamObj.GetComponent<Camera>().targetTexture = temp;
        Material myNewMaterial = new Material(Shader.Find("UI/Default"));
        //Set Texture on the material
        myNewMaterial.SetTexture("_MainTex", temp);
        footageImg.material = myNewMaterial;
    }
	public Canvas getUI()
    {
        return ui;
    }
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= timeTillDestroy)
        {
            Destroy(ui.gameObject);
            Destroy(this.gameObject);
        }
	}
}
