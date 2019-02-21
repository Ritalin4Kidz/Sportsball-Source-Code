using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHPScript : MonoBehaviour {
    public Image HPBar;
    GameObject boss;

    public GameObject GetBoss()
    {
        return boss;
    }
    public void SetBoss(GameObject bossObj)
    {
        boss = bossObj;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HPBar.fillAmount = boss.GetComponent<BossScript>().GetHP() / boss.GetComponent<BossScript>().MaxHP;

    }
}
