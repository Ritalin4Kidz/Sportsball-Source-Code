using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundWinCanvas : MonoBehaviour {
    public Text winText;
    public GameObject sportsballMan;
    public Image banner;
    public bool dontRS;
    float timeToSurvive = 7;
    float time;
    bool replay;
	// Use this for initialization
	void Start () {
        time = 0;
	}
    public void setAliveTime(float seconds)
    {
        timeToSurvive = seconds;
    }
    public void setReplay(bool a_Bool)
    {
        replay = a_Bool;
    }
    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= timeToSurvive / 2)
        {
            banner.transform.localPosition = new Vector3((banner.transform.localPosition.x) + ((50000 * Time.deltaTime) / timeToSurvive), banner.transform.localPosition.y, banner.transform.localPosition.z);
        }
        if (time >= timeToSurvive)
        {
            if (replay == true)
            {
                dontRS = true;
                sportsballMan.GetComponent<sportsballManager>().startReplay();
            }
            if (!dontRS)
            {
                sportsballMan.GetComponent<sportsballManager>().setRoundEnd(false);
                sportsballMan.GetComponent<sportsballManager>().bomb.GetComponent<BombScript>().destroyFlag();
                sportsballMan.GetComponent<sportsballManager>().ResetRound();
            }
            Destroy(this.gameObject);
        }
    }
}
