using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndZone : MonoBehaviour {
    public Canvas[] clock;


    public bool goalMode;
    public GameObject[] goals;
    // Use this for initialization
    void Start () {
		
	}
    private void Update()
    {
        if (goalMode)
        {
            for (int i = 0; i< goals.Length;i++)
            {
                if (goals[i].GetComponent<TrainingGoalScript1>().success == false)
                {
                    return;
                }
            }
            for (int i = 0; i < clock.Length; i++)
            {
                clock[i].GetComponent<TrainingTimer>().clockON = false;
            }
            goalMode = false;
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !goalMode)
        {
            for (int i = 0; i < clock.Length; i++)
            {
                clock[i].GetComponent<TrainingTimer>().clockON = false;
            }
        }
    }
}
