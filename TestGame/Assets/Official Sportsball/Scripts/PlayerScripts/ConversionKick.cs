using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConversionKick : MonoBehaviour {
    public GameObject ball;
    bool ballKicked;
    float pitch;
    float yaw;
    float power;

    public string AxisLookX;
    public string AxisMoveX;
    public string AxisLookY;

    public Vector3 gravity;

    public KeyCode shoot;

    public GameObject cameraObj;

    bool delay;
    
    public Image powerBar;


    public void setAxis (string axisX1, string axisX2, string axisY)
    {
        AxisLookX = axisX1;
        AxisLookY = axisY;
        AxisMoveX = axisX2;
    }
	// Use this for initialization
	void Start () {
        ballKicked = false;
        power = 1;
        delay = false;
        ball.GetComponent<Rigidbody>().isKinematic = true;
        transform.LookAt(ball.transform);
    }
	
	// Update is called once per frame
	void Update ()
    {
        powerBar.fillAmount = power / 10;
            if (!ballKicked)
            {
                if (Input.GetAxis(AxisLookX) > 0)
                {
                    cameraObj.transform.Translate(Vector3.right * 5 * Time.deltaTime);
                    cameraObj.transform.LookAt(ball.transform);
                }
                else if (Input.GetAxis(AxisLookX) < 0)
                {
                    cameraObj.transform.Translate(Vector3.right * -5 * Time.deltaTime);
                    cameraObj.transform.LookAt(ball.transform);
                }
            if (Input.GetAxis(AxisLookY) > 0)
            {
                cameraObj.transform.Translate(Vector3.up * 5 * Time.deltaTime);
                cameraObj.transform.LookAt(ball.transform);
            }
            else if (Input.GetAxis(AxisLookY) < 0)
            {
                cameraObj.transform.Translate(Vector3.up * -5 * Time.deltaTime);
                cameraObj.transform.LookAt(ball.transform);
            }
            else if (Input.GetAxis(AxisMoveX) > 0 && delay == false)
            {
                delay = true;
                power++;
                if (power > 10)
                {
                    power = 10;
                }
            }
            else if (Input.GetAxis(AxisMoveX) < 0 && delay == false)
            {
                delay = true;
                power--;
                if (power <= 0)
                {
                    power = 1;
                }
            }
            else if (Input.GetAxis(AxisMoveX) == 0)
            {
                delay = false;
            }

            if (Input.GetKeyDown(shoot))
            {
                //Physics.gravity = gravity;
                ballKicked = true;
                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.GetComponent<Rigidbody>().AddForce(cameraObj.transform.forward * power * 10);
            }
        }
    }
}
