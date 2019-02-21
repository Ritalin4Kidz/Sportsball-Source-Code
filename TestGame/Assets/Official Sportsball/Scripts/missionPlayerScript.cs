using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class missionPlayerScript : MonoBehaviour {
    public int hp = 1;

    public AudioClip fire;

    public bool freezePitch;
    float m_moveSpeed;
    string Xaxis;
    string Yaxis;
    float bonusSpeed = 1;
    bool canJump = true;
    public GameObject m_SpawnLoc;
    public Canvas pauseScreen;
    public Canvas deathScreen;
    //Inputs
    KeyCode shoot;
    KeyCode sprint;
    KeyCode jump;
    KeyCode pause;
    bool paused;
    //Shooting
    float m_gunForce;
    Material m_paintSplat;

    int m_shots = 0;
    int m_accurateShots = 0;

    //Camera
    public Camera cam;
    float speedH = 2.0f;
    float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    string LookXaxis;
    string LookYaxis;

    //Game Manager
    // Use this for initialization
    void Start()
    {
        deathScreen.enabled = false;
        pauseScreen.enabled = false;
        m_moveSpeed = 5;
        m_gunForce = 75;
        speedH = 2.0f;
        speedV = 2.0f;
        //Xaxis = "Player1MoveX";
        //Yaxis = "Player1MoveY";
        //LookXaxis = "Player1LookX";
        //LookYaxis = "Player1LookY";
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

    public void setPaintSplat(Material a_newMaterial)
    {
        m_paintSplat = a_newMaterial;
    }

    public void SetPaused(bool a_bool)
    {
        paused = a_bool;
    }
    public bool GetPaused() { return paused; }
    public KeyCode GetJump() { return jump; }
    public string GetXaxis() { return Xaxis; }
    public string GetYaxis() { return Yaxis; }
    public void SetXAxis(string a_Axis) { Xaxis = a_Axis; }
    public void SetYAxis(string a_Axis) { Yaxis = a_Axis; }
    public void SetAxisAll(string a_AxisX, string a_AxisY, string a_AxisLookX, string a_AxisLookY) { Xaxis = a_AxisX; Yaxis = a_AxisY; LookXaxis = a_AxisLookX; LookYaxis = a_AxisLookY; }
    public void SetButtons(KeyCode a_shoot, KeyCode a_jump, KeyCode a_sprint, KeyCode a_pause) { shoot = a_shoot; jump = a_jump; sprint = a_sprint; pause = a_pause; }

    public int getShots() { return m_shots; }
    public int getAccurateShots() { return m_shots; }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            deathScreen.enabled = true;
        }
        if (!paused)
        {
            if (Input.GetKey(pause))
            {
                paused = true;
                pauseScreen.enabled = true;
                pauseScreen.GetComponent<PauseMenu>().functioning = true;
            }
                if (hp > 0)
                {
                    {
                        this.transform.localPosition += new Vector3(this.transform.forward.x * Input.GetAxis(Yaxis) * Time.deltaTime * m_moveSpeed * bonusSpeed, 0, this.transform.forward.z * Input.GetAxis(Yaxis) * Time.deltaTime * m_moveSpeed * bonusSpeed);
                    }
                    //if (this.transform.right.x * Input.GetAxis(Xaxis) * Time.deltaTime * moveSpeed != 0)
                    {
                        this.transform.localPosition += new Vector3(this.transform.right.x * Input.GetAxis(Xaxis) * Time.deltaTime * m_moveSpeed * bonusSpeed, 0, this.transform.right.z * Input.GetAxis(Xaxis) * Time.deltaTime * m_moveSpeed * bonusSpeed);
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
                        m_shots++;
                        RaycastHit other;

                        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    AudioSource.PlayClipAtPoint(fire, this.transform.position, 1.0f);
                    if (Physics.Raycast(ray, out other, 750))
                    {
                            if (other.collider.CompareTag("PlayerFace"))
                            {
                                if (other.collider.GetComponent<FaceUIScript>())
                                {
                                    if (other.collider.GetComponent<FaceUIScript>().alphaVar < 0.5f)
                                    {
                                        other.collider.GetComponent<FaceUIScript>().alphaVar += 1;
                                        other.collider.GetComponent<FaceUIScript>().setPaintVision(m_paintSplat);


                                    }
                                }
                            }
                            else if(other.collider.CompareTag("BeeSphere"))
                            {
                                Collider[] colliders = Physics.OverlapSphere(other.point, 10);
                                foreach (Collider colliderA in colliders)
                                {
                                    if (colliderA.CompareTag("BeeSphere"))
                                    {
                                    colliderA.GetComponent<BeeSphere>().TriggerFunc();
                                    }
                                }
                            other.collider.GetComponent<Rigidbody>().AddExplosionForce(5, other.point, 10);
                            }

                            if (other.collider.CompareTag("PlayerFace") == false && other.collider.CompareTag("BeeSphere") == false && other.collider.CompareTag("Guard") == false && other.collider.CompareTag("NoSplat") == false && other.collider.CompareTag("Ball") == false && other.collider.CompareTag("Vent") == false && other.collider.CompareTag("Box") == false && other.collider.CompareTag("Player") == false && other.collider.CompareTag("Gun") == false)
                            {
                                var paintSplatQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                                paintSplatQuad.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, 0);
                                paintSplatQuad.GetComponent<Renderer>().material = m_paintSplat;
                                paintSplatQuad.AddComponent<paintSplats>();
                                paintSplatQuad.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                                paintSplatQuad.transform.localRotation = Quaternion.LookRotation(-other.normal);

                            }
                            if (other.collider.CompareTag("Player") || other.collider.CompareTag("PlayerFace"))
                            {
                            
                                if (other.collider.GetComponent<missionPlayerScript>())
                                {
                                other.collider.GetComponent<Rigidbody>().freezeRotation = false;
                                other.collider.GetComponent<missionPlayerScript>().hp--;
                                }
                            else if (other.collider.GetComponent<missionAI>())
                            {
                                other.collider.GetComponent<missionAI>().hp--;
                            }
                            }
                            if (other.collider.CompareTag("Guard"))
                            {
                                if (other.collider.GetComponent<missionAI>())
                                {
                                other.collider.GetComponent<missionAI>().hp--;
                                if (other.collider.GetComponent<TargetNoGameMan>())
                                {
                                    other.collider.GetComponent<TargetNoGameMan>().setAlive(false);
                                }
                            }
                        }
                        if (other.collider.CompareTag("Vent"))
                        {
                            other.collider.GetComponent<VentScript>().destroyVent();
                        }
                        else
                        {
                                m_accurateShots++;
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
                         other.collider.GetComponent<Rigidbody>().AddForce(this.transform.forward * m_gunForce);
                     }
                     if (other.collider.CompareTag("Ball"))
                     {
                     if (other.collider.GetComponent<BallScript>())
                     {
                         other.collider.GetComponent<BallScript>().lastPlayer = this.gameObject;
                     }
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
                    }
                    if (!freezePitch)
                    {
                        pitch -= speedV * Input.GetAxis(LookYaxis);
                    }

                    this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
                }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (compareFloat(GetComponent<Rigidbody>().velocity.y, 0, 0.05f))
        {
            canJump = true;
        }
    }



}
