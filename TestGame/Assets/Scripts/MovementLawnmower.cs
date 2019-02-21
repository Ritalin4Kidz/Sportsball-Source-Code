using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLawnmower : MonoBehaviour {
    public float moveSpeed;

    //public GameObject details;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    // Use this for initialization
    void Start()
    {
        //details.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    details.SetActive(true);
        //}
        //if (Input.GetKeyUp(KeyCode.Z))
        //{
        //    details.SetActive(false);
        //}

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.localPosition += new Vector3(this.transform.forward.x * Time.deltaTime * moveSpeed, 0, this.transform.forward.z * Time.deltaTime * moveSpeed);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.localPosition -= new Vector3(this.transform.forward.x * Time.deltaTime * moveSpeed, 0, this.transform.forward.z * Time.deltaTime * moveSpeed);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.localPosition += new Vector3(this.transform.right.x * Time.deltaTime * moveSpeed, 0, this.transform.right.z * Time.deltaTime * moveSpeed);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.localPosition -= new Vector3(this.transform.right.x * Time.deltaTime * moveSpeed, 0, this.transform.right.z * Time.deltaTime * moveSpeed);
            
        }
        if (Input.GetKey(KeyCode.Space) && this.GetComponent<Rigidbody>().velocity.y == 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 250, 0));
            
        }

        if (Input.GetKey(KeyCode.Escape))
            Screen.lockCursor = false;
        else
            Screen.lockCursor = true;

        yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");

        this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
