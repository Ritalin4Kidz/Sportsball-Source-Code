using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {
    public Image cooldown;
    public Image plantDefuse;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cooldown.fillAmount = this.gameObject.GetComponent<PlayerScript>().getCooldownTime()/ this.gameObject.GetComponent<PlayerScript>().getCooldown();
        plantDefuse.fillAmount = 1- this.gameObject.GetComponent<PlayerScript>().getTimePD()/this.gameObject.GetComponent<PlayerScript>().plant_defuseTime;

    }
}
