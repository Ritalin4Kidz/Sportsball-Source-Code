using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Target : MonoBehaviour {
    public float HP = 100;

    public float bounty;

    public GameObject gameManage;
    bool dead;
    public GameObject[] nodes;
    public int lastNode;

    public GameObject returnArea;

    public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0 && !dead) //once dead, exit is open and player is rewarded with the bounty.
        {
            Debug.Log("Dead");
            dead = true;
            gameManage.GetComponent<GameManager>().playerCash += bounty;
            gameManage.GetComponent<GameManager>().setLastBounty(bounty);
            returnArea.SetActive(true);
        }
        if (!dead)
        {
            Wander();
        }
	}



    public void Wander() //simple node paths
    {
        if (lastNode == nodes.Length - 1)
        {
            this.transform.LookAt(nodes[0].transform);
        }
        else
        { 
            this.transform.LookAt(nodes[lastNode + 1].transform);
        }
        this.transform.localPosition += this.transform.forward * moveSpeed * Time.deltaTime;
    }
}
