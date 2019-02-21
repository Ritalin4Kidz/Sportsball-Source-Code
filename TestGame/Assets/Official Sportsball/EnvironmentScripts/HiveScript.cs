using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveScript : MonoBehaviour {
    public Material[] beePicsArray;

    public float radius;
    public float power;

    public GameObject playerA;
    public ParticleSystem explosionRef;


    public float hp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnDestroy()
    {
        ParticleSystem explosion = Instantiate(explosionRef);
        explosion.transform.position = this.gameObject.transform.position;
        int beePic = Random.Range(0, beePicsArray.Length);
        explosion.GetComponent<Renderer>().material = beePicsArray[beePic];
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Hive"))
            {
                Destroy(hit.gameObject);
            }
            if (hit.gameObject.CompareTag("Vent"))
            {
                hit.gameObject.GetComponent<VentScript>().destroyVent();
            }
            if (hit.gameObject.GetComponent<PlayerScript>())
            {
                hit.gameObject.GetComponent<PlayerScript>().face.GetComponent<FaceUIScript>().alphaVar += 1;
                hit.gameObject.GetComponent<PlayerScript>().face.GetComponent<FaceUIScript>().setPaintVision(beePicsArray[beePic]);
                if (playerA.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().isPaintball)
                {
                    hit.gameObject.GetComponent<PlayerScript>().active = false;
                    playerA.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().sendToDead(hit.gameObject);
                    playerA.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
                }
            }
            if (hit.gameObject.GetComponent<AI>() && hit.gameObject.GetComponent<AI>().GetManager().GetComponent<sportsballManager>().isPaintball)
            {
                hit.gameObject.GetComponent<AI>().active = false;
                hit.gameObject.GetComponent<AI>().GetManager().GetComponent<sportsballManager>().sendToDead(hit.gameObject);
                hit.gameObject.GetComponent<AI>().GetManager().GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
            }
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 5.0F);
        }
    }
}
