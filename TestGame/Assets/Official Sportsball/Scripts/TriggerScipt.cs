using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScipt : MonoBehaviour {
    public GameObject gameManger;

    public bool isBoundaryRule;

    public bool isTennisRule;

    public float max;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Ball"))
        {
            if (gameManger.GetComponent<sportsballManager>().GetInplay())
            {
                if (other.GetComponent<BallScript>().lastPlayer != null)
                {
                    if (other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>())
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().AddMVPPoints(-2);
                    }
                    if (other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>())
                    {
                        other.GetComponent<BallScript>().lastPlayer.GetComponent<AI>().AddMVPPoints(-2);
                    }
                    other.GetComponent<BallScript>().lastPlayer = gameManger.GetComponent<sportsballManager>().getPlayer(0);
                }
                if (isBoundaryRule)
                {
                    gameManger.GetComponent<sportsballManager>().boundaryRule = true;
                    float zAxis = other.transform.position.z;
                    if (Mathf.Abs(zAxis) > max)
                    {
                        zAxis = max;
                        if (other.transform.position.z < 0)
                        {
                            zAxis = -zAxis;
                        }
                    }
                    gameManger.GetComponent<sportsballManager>().ballRespawn = new Vector3(0, 6.25f, zAxis);
                }
                else if (isTennisRule)
                {
                    if (other.GetComponent<BallScript>().lastPlayer != null)
                    {
                        if (other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team1")
                        {
                            gameManger.GetComponent<sportsballManager>().AddScoreInt("Team2", 5);
                        }
                        else if (other.GetComponent<BallScript>().lastPlayer.GetComponent<PlayerScript>().GetTeam() == "Team2")
                        {
                            gameManger.GetComponent<sportsballManager>().AddScoreInt("Team1", 5);
                        }
                    }
                }
                gameManger.GetComponent<sportsballManager>().startReplay();
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

        }
    }
}
