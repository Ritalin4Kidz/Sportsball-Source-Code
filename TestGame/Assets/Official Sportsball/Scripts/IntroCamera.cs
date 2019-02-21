using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroCamera : MonoBehaviour {
    public GameObject gameManager;
    public AudioClip beep;
    public GameObject[] nodes;
    public Camera camTouse;
    public Canvas Timer;
    public Text timeTxt;

    Vector3 PlaceToLook;
    public Canvas openingUIref;
    Canvas UIOpen;
    int i = 0;
    bool function;
    float timeTillswap;
    bool opening;
	// Use this for initialization
	void Start () {
        //gameManager.GetComponent<sportsballManager>().shutoffcameras();
        PlaceToLook = new Vector3(0, 0, 0);
        this.transform.position = nodes[i].transform.position;
        this.GetComponent<AudioSource>().clip = beep;
        this.GetComponent<AudioSource>().Play();
        function = true;
        opening = true;
        UIOpen = Instantiate(openingUIref);
        UIOpen.GetComponent<IntroUIScript>().Logo2.material = gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().basesplatTeam2;
        UIOpen.GetComponent<IntroUIScript>().Logo1.material = gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().basesplatTeam1;
        UIOpen.GetComponent<IntroUIScript>().TeamText1.text = gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().teamname1 + "\n" + gameManager.GetComponent<sportsballManager>().teamplayersText("Team1");
        UIOpen.GetComponent<IntroUIScript>().TeamText2.text = gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().teamname2 + "\n" + gameManager.GetComponent<sportsballManager>().teamplayersText("Team2");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && UIOpen != null || Input.GetKeyDown(KeyCode.Space) && UIOpen != null && gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer)
        {
            Destroy(UIOpen.gameObject);
            opening = false;
        }
        if (function)
        {
        gameManager.GetComponent<sportsballManager>().SetInplay(false);
        gameManager.GetComponent<sportsballManager>().shutoffcameras();
        timeTxt.text = "" + ((nodes.Length - i) - 1);
        this.transform.LookAt(PlaceToLook);
            if (opening == false)
            {
                this.transform.position += this.transform.forward * Time.deltaTime * 5;
                timeTillswap += Time.deltaTime;
                if (timeTillswap >= 0.75f)
                {
                    timeTillswap -= 0.75f;
                    i++;
                    this.GetComponent<AudioSource>().Play();
                    if (i == nodes.Length - 1)
                    {

                        gameManager.GetComponent<sportsballManager>().SetInplay(true);
                        camTouse.enabled = false;
                        gameManager.GetComponent<sportsballManager>().turnoncameras();
                        function = false;
                        Timer.enabled = false;
                        return;
                    }
                    this.transform.position = nodes[i].transform.position;
                }
            }
        }
	}
    public void playCamera(int point)
    {
        PlaceToLook = gameManager.GetComponent<sportsballManager>().ball.transform.position;
        i = point;
        gameManager.GetComponent<sportsballManager>().SetInplay(false);
        gameManager.GetComponent<sportsballManager>().shutoffcameras();
        Timer.enabled = true;
        function = true;
        camTouse.enabled = true;

    }
    public void playCamera(int point, Vector3 positionToLook)
    {
        PlaceToLook = positionToLook;
        i = point;
        gameManager.GetComponent<sportsballManager>().SetInplay(false);
        gameManager.GetComponent<sportsballManager>().shutoffcameras();
        Timer.enabled = true;
        function = true;
        camTouse.enabled = true;

    }
}

