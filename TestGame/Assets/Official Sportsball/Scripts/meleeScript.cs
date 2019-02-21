using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeScript : MonoBehaviour {
     GameObject playerMelee;
    GameObject gameManager;
    bool hitting;
    // Use this for initialization
    public void setPlayer(GameObject newplayer)
    {
        playerMelee = newplayer;
    }
    public void setManager(GameObject manager)
    {
        gameManager = manager;
    }
    public void setHitting(bool a_bool)
    {
        hitting = a_bool;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hitting)
        {
            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                if (collision.gameObject.CompareTag("Ball"))
                {
                    collision.gameObject.GetComponent<BallScript>().lastPlayer = playerMelee;
                }
                if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerFace"))
                {
                    if (gameManager.GetComponent<sportsballManager>().isPaintball == false && playerMelee.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().ball.GetComponent<BallScript>().getAttached())
                    {
                        playerMelee.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                    }
                }
                if (gameManager.GetComponent<sportsballManager>().isPaintball)
                {
                    if (collision.gameObject.CompareTag("PlayerFace"))
                    {
                        collision.gameObject.GetComponent<FaceUIScript>().player.GetComponent<PlayerScript>().active = false;
                        collision.gameObject.GetComponent<FaceUIScript>().player.GetComponent<PlayerScript>().throwBomb();
                        gameManager.GetComponent<sportsballManager>().sendToDead(collision.gameObject.GetComponent<FaceUIScript>().player);
                        gameManager.GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);

                    }
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        collision.gameObject.GetComponent<PlayerScript>().active = false;
                        collision.gameObject.GetComponent<PlayerScript>().throwBomb();
                        gameManager.GetComponent<sportsballManager>().sendToDead(collision.gameObject);

                        gameManager.GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);

                    }
                }
                collision.gameObject.GetComponent<Rigidbody>().AddForce(playerMelee.transform.forward * playerMelee.GetComponent<PlayerScript>().getGunForce());
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (hitting)
        {
            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                if (collision.gameObject.CompareTag("Ball"))
                {
                    collision.gameObject.GetComponent<BallScript>().lastPlayer = playerMelee;
                }
                if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerFace"))
                {
                    if (gameManager.GetComponent<sportsballManager>().isPaintball == false && playerMelee.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().ball.GetComponent<BallScript>().getAttached())
                    {
                        playerMelee.GetComponent<PlayerScript>().GetManager().GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                    }
                }
                collision.gameObject.GetComponent<Rigidbody>().AddForce(playerMelee.transform.forward * playerMelee.GetComponent<PlayerScript>().getGunForce());
            }
        }
    }
}
