//All Scripts written by Callum Hands
//Contact me through email : callum@hands.net.au
//Contact me through phone : 0439794962
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour {
    public float moveSpeed;
    public float gunForce;
    public Material paintSplat;
    public string Xaxis;
    public string Yaxis;

    public string LookXaxis;
    public string LookYaxis;
    float lastyAxis;
    float lastxAxis;
    bool canJump;
    public KeyCode shoot;
    public KeyCode sprint;
    public KeyCode jump;  
    //public GameObject details;
    public Camera cam;
    public float gunRange;
    public float hp = 100;

    public int mvp = 0;
    float bonusSpeed = 1;
    float baseFOV;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public GameObject gameManager;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    int shots = 0;
    int accurateShots = 0;
    bool zoom = false;
    // Use this for initialization
    void Start () {
        baseFOV = cam.fieldOfView;
        //details.SetActive(false);
	}
	bool compareFloat(float a, float b, float range)
    {
        float tempa = a * a;
        float tempb = b * b;
        a = tempa / a;
        b = tempb / b;
        if (a - b > range)
        {
            return false;
        }
        return true;
    }
	// Update is called once per frame
	void Update () {
        if (gameManager.GetComponent<SportsballGameManager>().paused == false)
        {
            if (hp <= 0)
            {
                SceneManager.LoadScene("levelSelect");
            }

            //if (this.transform.forward.x * Input.GetAxis(Yaxis) * Time.deltaTime * moveSpeed != 0)
            {
                this.transform.localPosition += new Vector3(this.transform.forward.x * Input.GetAxis(Yaxis) * Time.deltaTime * moveSpeed * bonusSpeed, 0, this.transform.forward.z * Input.GetAxis(Yaxis) * Time.deltaTime * moveSpeed * bonusSpeed);
            }
            //if (this.transform.right.x * Input.GetAxis(Xaxis) * Time.deltaTime * moveSpeed != 0)
            {
                this.transform.localPosition += new Vector3(this.transform.right.x * Input.GetAxis(Xaxis) * Time.deltaTime * moveSpeed * bonusSpeed, 0, this.transform.right.z * Input.GetAxis(Xaxis) * Time.deltaTime * moveSpeed * bonusSpeed);
            }
            if (Input.GetKeyDown(sprint))
            {
                bonusSpeed = 2;
            }
            if (Input.GetKeyUp(sprint))
            {
                bonusSpeed = 1;
            }
            if (Input.GetKeyDown(shoot))
            {
                shots++;
                RaycastHit other;

                Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                if (Physics.Raycast(ray, out other, gunRange))
                {
                    if (other.collider.CompareTag("PlayerFace"))
                    {
                        
                        if (other.collider.GetComponent<FaceUIScript>().alphaVar < 0.5f)
                        {
                            mvp += 1;
                            other.collider.GetComponent<FaceUIScript>().alphaVar += 1;
                        }
                    }
                    if (other.collider.CompareTag("PlayerFace") == false && other.collider.CompareTag("Ball") == false && other.collider.CompareTag("Box") == false && other.collider.CompareTag("Player") == false && other.collider.CompareTag("Gun") == false)
                    {
                        var paintSplatQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);                       
                        paintSplatQuad.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, 0);
                        paintSplatQuad.GetComponent<Renderer>().material = paintSplat;
                        paintSplatQuad.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                        paintSplatQuad.transform.localRotation = Quaternion.LookRotation(-other.normal);
                       
                    }
                    else
                    {
                        accurateShots++;
                    }
                    //if (other.collider.CompareTag("Target"))
                    //{
                    //        other.collider.GetComponent<Target>().HP -= gunForce;
                    //}
                    //else if (other.collider.CompareTag("Guard"))
                    //    {
                    //        other.collider.GetComponent<GuardAI>().HP -= gunForce;
                    //    }
                    if (other.collider.GetComponent<Rigidbody>())
                    {
                        other.collider.GetComponent<Rigidbody>().AddForce(this.transform.forward * gunForce);
                    }
                    if (other.collider.CompareTag("Ball"))
                    {
                        if (canJump == false)
                        {
                            mvp += 2;
                        }
                        mvp += 3;
                        other.collider.GetComponent<BallScript>().lastPlayer = this.gameObject;
                    }
                    //Debug.Log("Work");
                }
            }

            //if (Input.GetMouseButtonDown(1))
            //{
            //    //zoom
            //    if (!zoom)
            //    {
            //        baseFOV = Camera.main.fieldOfView;
            //        Camera.main.fieldOfView = 10;
            //        zoom = true;
            //    }
            //    else
            //    {
            //        Camera.main.fieldOfView = baseFOV;
            //        zoom = false;
            //    }
            //}
            if (Input.GetKeyDown(jump))
            {
                if (canJump)
                {
                    GetComponent<Rigidbody>().AddForce(0, 250, 0);
                    canJump = false;
                }
            }
            if (Input.GetKey(KeyCode.Escape))
                Screen.lockCursor = false;
            else
                Screen.lockCursor = true;
            //if (lastxAxis != Input.GetAxis(LookXaxis))
            {
                yaw += speedH * Input.GetAxis(LookXaxis);
                lastxAxis = Input.GetAxis(LookXaxis);
            }
            // if (lastyAxis != Input.GetAxis(LookYaxis))
            {
                pitch -= speedV * Input.GetAxis(LookYaxis);
                lastyAxis = Input.GetAxis(LookYaxis);
            }

            this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (compareFloat(GetComponent<Rigidbody>().velocity.y, 0, 0.05f))
        {
            canJump = true;
        }
    }
    public int GetAccurateShots()
    {
        return accurateShots;
    }
    public int GetShots()
    {
        return shots;
    }
}
