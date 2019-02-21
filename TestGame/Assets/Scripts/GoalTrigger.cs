using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {
    public int PlayerGoal;
    public GameObject gameManger;
    public GameObject player1;
    public GameObject player2;
    public GameObject player1face;
    public GameObject player2face;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameManger.GetComponent<SportsballGameManager>().scoring)
            {
                if (PlayerGoal == 1)
                {
                    gameManger.GetComponent<SportsballGameManager>().team2score++;
                    if (other.GetComponent<BallScript>().lastPlayer == player1)
                    {
                        player1.GetComponent<Movement>().mvp -= 30;
                    }
                    else
                    {
                        player2.GetComponent<Movement>().mvp += 25;
                    }
                    
                    if (player1face.GetComponent<FaceUIScript>().alphaVar > 0.1f)
                    {
                        player2.GetComponent<Movement>().mvp += 25;
                    }
                }
                if (PlayerGoal == 2)
                {
                    gameManger.GetComponent<SportsballGameManager>().team1score++;
                    if (other.GetComponent<BallScript>().lastPlayer == player2)
                    {
                        player2.GetComponent<Movement>().mvp -= 30;
                    }
                    else
                    {
                        player1.GetComponent<Movement>().mvp += 25;
                    }
                    if (player2face.GetComponent<FaceUIScript>().alphaVar > 0.1f)
                    {
                        player1.GetComponent<Movement>().mvp += 25;
                    }
                }
                other.GetComponent<BallScript>().lastPlayer = null;
                //other.transform.position = new Vector3(0, 6.25f, 0);
                gameManger.GetComponent<SportsballGameManager>().startReplay();
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
           
        }
    }
}
