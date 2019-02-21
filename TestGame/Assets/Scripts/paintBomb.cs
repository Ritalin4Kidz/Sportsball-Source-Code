using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintBomb : MonoBehaviour {
    public float radius;
    public float power;

    public float timeTilExplosion;
    float timeS;
    public GameObject playerA;

    public ParticleSystem explosionRef;
    public Material m_paintSplat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeS += Time.deltaTime;
        if (timeS >= timeTilExplosion)
        {
            ParticleSystem explosion = Instantiate(explosionRef);
            explosion.transform.position = this.gameObject.transform.position;
            explosion.GetComponent<Renderer>().material = m_paintSplat;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.CompareTag("Ball"))
                {
                    hit.GetComponent<BallScript>().lastPlayer = playerA;
                }
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
                    hit.gameObject.GetComponent<PlayerScript>().face.GetComponent<FaceUIScript>().setPaintVision(m_paintSplat);
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
            Destroy(this.gameObject);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 explosionPos = transform.position;
        ParticleSystem explosion = Instantiate(explosionRef);
        explosion.transform.position = this.gameObject.transform.position;
        explosion.GetComponent<Renderer>().material = m_paintSplat;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.CompareTag("Ball"))
            {
                hit.gameObject.GetComponent<BallScript>().lastPlayer = playerA;
            }
            if (hit.gameObject.CompareTag("Vent"))
            {
                hit.gameObject.GetComponent<VentScript>().destroyVent();
            }
            if (hit.gameObject.GetComponent<PlayerScript>())
            {
                hit.gameObject.GetComponent<PlayerScript>().face.GetComponent<FaceUIScript>().alphaVar += 1;
                hit.gameObject.GetComponent<PlayerScript>().face.GetComponent<FaceUIScript>().setPaintVision(m_paintSplat);
                if (playerA.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().isPaintball)
                {
                    hit.gameObject.GetComponent<PlayerScript>().active = false;
                    playerA.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().sendToDead(hit.gameObject);
                    playerA.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
                }
            }
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 5.0F);
        }
        for (int i = 0; i <= collision.contacts.Length -1; i++)
        {
            if (collision.contacts[i].otherCollider.CompareTag("PlayerFace") == false && collision.contacts[i].otherCollider.CompareTag("Ball") == false && collision.contacts[i].otherCollider.CompareTag("Box") == false && collision.contacts[i].otherCollider.CompareTag("Player") == false && collision.contacts[i].otherCollider.CompareTag("Gun") == false && collision.contacts[i].otherCollider.CompareTag("Vent") == false)
            {
                var paintSplatQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                paintSplatQuad.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, 0);
                paintSplatQuad.GetComponent<Renderer>().material = m_paintSplat;
                paintSplatQuad.AddComponent<paintSplats>();
                paintSplatQuad.transform.position = new Vector3(collision.contacts[i].point.x - (0.01f * this.gameObject.transform.forward.x), collision.contacts[i].point.y - (0.01f * this.gameObject.transform.forward.y), collision.contacts[i].point.z - (0.01f * this.gameObject.transform.forward.z));
                paintSplatQuad.transform.localRotation = Quaternion.LookRotation(-collision.contacts[i].normal);
            }
        }
        Destroy(this.gameObject);
    }
}
