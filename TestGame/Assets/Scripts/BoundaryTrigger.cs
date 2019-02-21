using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour {
    public GameObject gameManger;
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
                other.GetComponent<BallScript>().lastPlayer.GetComponent<Movement>().mvp -= 5;
                other.GetComponent<BallScript>().lastPlayer = null;
                gameManger.GetComponent<SportsballGameManager>().startReplay();
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

        }
    }
}
