using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChompScript : MonoBehaviour {
    float timeToAttack;
    float time;
    GameObject player;
    public GameObject GameMan;
    bool playerSearch;

    public void SetPlayerSearch(bool a_Search)
    {
        playerSearch = a_Search;
    }
	// Use this for initialization
	void Start () {
        time = 0;
        timeToAttack = 5;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameMan == null || GameMan.GetComponent<sportsballManager>().GetInplay())
        {
            time += Time.deltaTime;
        }
        if (time >= timeToAttack)
        {
            float power;
            if (GameMan == null)
            {
                power = 25;
            }
            else
            {
                power = 100;
            }
            GetComponent<Rigidbody>().AddForce(this.transform.forward * power);
            time = 0;
        }
        else
        {
            if (playerSearch)
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject play in players)
                {
                    if (player == null)
                    {
                        player = play;
                    }
                    else if (Vector3.Distance(play.transform.position, this.transform.position) < Vector3.Distance(player.transform.position, this.transform.position))
                    {
                        player = play;
                    }
                }
                transform.LookAt(player.transform);
            }
            else
            {
                transform.LookAt(GetComponent<BossScript>().player.transform);
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<missionPlayerScript>())
        {
            collision.gameObject.GetComponent<missionPlayerScript>().hp = 0;
        }
    }
}
