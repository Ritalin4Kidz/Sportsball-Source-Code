using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossScript : MonoBehaviour {
    public float MaxHP;
    float hp;
    public Canvas BossUIRef;
    public GameObject player;

    public Canvas[] clocks;
    Canvas ui;
    public float GetHP()
    {
        return hp;
    }
    public void SetHP(float health)
    {
        hp = health;
    }
    // Use this for initialization
    void Start () {
        hp = MaxHP;
        ui = Instantiate(BossUIRef);
        ui.GetComponent<BossHPScript>().SetBoss(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            for (int i = 0; i < clocks.Length;i++)
            {
                clocks[i].GetComponent<TrainingTimer>().clockON = false;
            }
            Destroy(ui.gameObject);
            Destroy(this.gameObject);
        }
	}
}
