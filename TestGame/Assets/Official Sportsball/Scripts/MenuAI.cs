using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAI : MonoBehaviour {
    public GameObject ball;
    bool canFire = true;
    float timeTillfire = 0;
    float m_moveSpeed;
    float m_gunForce;
    public Material paintSplat;
    // Use this for initialization
    void Start () {
        m_moveSpeed = 5;
        m_gunForce = 75;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(ball.transform);
        {

        }
        if (Vector3.Distance(ball.transform.position, this.transform.position) > 20)
        {
            this.transform.position += this.transform.forward * m_moveSpeed * Time.deltaTime;
        }
        if (!canFire)
        {
            timeTillfire += Time.deltaTime;
            if (timeTillfire >= 2.0f)
            {
                timeTillfire = 0;
                canFire = true;
            }
        }
        if (Vector3.Distance(ball.transform.position, this.gameObject.transform.position) < 20 && canFire)
        {
            canFire = false;
            float scaleLimit = 2.0f;
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
            if (Physics.Raycast(transform.position, direction, out other, 750))
            {
                if (other.collider.GetComponent<Rigidbody>())
                {
                    other.collider.GetComponent<Rigidbody>().AddForce(this.transform.forward * m_gunForce);
                }
                if (other.collider.CompareTag("PlayerFace") == false && other.collider.CompareTag("Ball") == false && other.collider.CompareTag("Box") == false && other.collider.CompareTag("Player") == false && other.collider.CompareTag("Gun") == false)
                {
                    var paintSplatQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    paintSplatQuad.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, 0);
                    paintSplatQuad.GetComponent<Renderer>().material = paintSplat;
                    paintSplatQuad.AddComponent<paintSplats>();
                    paintSplatQuad.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                    paintSplatQuad.transform.localRotation = Quaternion.LookRotation(-other.normal);

                }
            }
            //this.transform.position += this.transform.forward * m_moveSpeed * Time.deltaTime;
        }
    }
    }
