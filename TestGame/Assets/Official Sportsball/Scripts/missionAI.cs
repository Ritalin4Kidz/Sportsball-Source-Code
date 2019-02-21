using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missionAI : MonoBehaviour {
    float m_moveSpeed;

    public bool pacifist;
    float bonusSpeed = 1;
    bool canJump = true;
    public int hp = 1;
    bool canFire = true;
    float timeTillfire = 0;
    public GameObject gameMange;
    //Inputs
    //Shooting
    float m_gunForce;
    public Material m_paintSplat;
    public AudioClip fire;

    public Canvas[] clocks;
    //Camera

    //Game Manager
    // Use this for initialization
    void Start()
    {
        m_moveSpeed = 5;
        m_gunForce = 75;
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


    // Update is called once per frame
    void Update()
    {
        if (pacifist && hp <= 0)
        {
            for (int i = 0; i < clocks.Length; i++)
            {
                clocks[i].GetComponent<TrainingTimer>().clockON = false;
            }
        }
        if (hp > 0 && !pacifist)
        {
            
            if (!canFire)
            {
                timeTillfire += Time.deltaTime;
                if (timeTillfire >= 2.0f)
                {
                    timeTillfire = 0;
                    canFire = true;
                }
            }
            if (canFire)
            {
                if (Vector3.Distance(this.gameObject.transform.position, gameMange.GetComponent<missionManager>().GetPlayer().transform.position) < 10)
                {
                    this.transform.LookAt(gameMange.GetComponent<missionManager>().GetPlayer().transform);
                    this.transform.position += this.transform.forward * m_moveSpeed * bonusSpeed * Time.deltaTime;
                    float scaleLimit = 4.0f;
                    float randomRadius = scaleLimit;
                    randomRadius = Random.Range(0, scaleLimit);
                    float randomAngle = Random.Range(0, 2 * Mathf.PI);

                    //Calculating the raycast direction
                    Vector3 direction = new Vector3(
                        randomRadius * Mathf.Cos(randomAngle),
                        randomRadius * Mathf.Sin(randomAngle),
                        10
                    );
                    direction = transform.TransformDirection(direction.normalized);
                    RaycastHit other;
                    AudioSource.PlayClipAtPoint(fire, this.transform.position, 1.0f);


                    //Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    if (Physics.Raycast(transform.position, direction, out other, 750))
                    {
                        if (other.collider.CompareTag("PlayerFace"))
                        {

                            if (other.collider.GetComponent<FaceUIScript>().alphaVar < 0.5f)
                            {
                                other.collider.GetComponent<FaceUIScript>().alphaVar += 1;
                            }
                        }
                        if (other.collider.CompareTag("PlayerFace") == false && other.collider.CompareTag("Ball") == false && other.collider.CompareTag("Box") == false && other.collider.CompareTag("Player") == false && other.collider.CompareTag("Gun") == false && other.collider.CompareTag("Vent") == false)
                        {
                            var paintSplatQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                            paintSplatQuad.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, 0);
                            paintSplatQuad.GetComponent<Renderer>().material = m_paintSplat;
                            paintSplatQuad.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                            paintSplatQuad.transform.localRotation = Quaternion.LookRotation(-other.normal);

                        }
                        if (other.collider.CompareTag("Vent"))
                        {
                            other.collider.GetComponent<VentScript>().destroyVent();
                        }
                        if (other.collider.CompareTag("Player") || other.collider.CompareTag("PlayerFace"))
                        {
                            if (other.collider.GetComponent<missionPlayerScript>())
                            {
                                other.collider.GetComponent<missionPlayerScript>().hp--;
                            }
                            else if (other.collider.GetComponent<missionAI>())
                            {
                                other.collider.GetComponent<missionAI>().hp--;
                            }
                        }

                        //    }
                            if (other.collider.GetComponent<Rigidbody>())
                        {
                            other.collider.GetComponent<Rigidbody>().AddForce(this.transform.forward * m_gunForce);
                        }
                        if (other.collider.CompareTag("Ball"))
                        {

                            other.collider.GetComponent<BallScript>().lastPlayer = this.gameObject;
                        }
                    }
                }
            }
        }



            
        }
}
