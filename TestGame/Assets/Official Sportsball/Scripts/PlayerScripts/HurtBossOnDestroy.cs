using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBossOnDestroy : MonoBehaviour {
    public GameObject boss;
    // Use this for initialization
    private void OnDestroy()
    {
        boss.GetComponent<BossScript>().SetHP(boss.GetComponent<BossScript>().GetHP() - 1);
    }
}
