using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    string team;
    public AudioClip fire;
    //MVP
    int m_mvpPoints;
    string playerName;
    //Movement
    float m_moveSpeed;
    float bonusSpeed = 1;
    bool canJump = true;

    bool canFire = true;
    float timeTillfire = 0;

    float fireRate;

    public GameObject m_SpawnLoc;

    public bool active;
    //Inputs
    //Shooting
    float m_gunForce;
    Material m_paintSplat;

    int m_shots = 0;
    int m_accurateShots = 0;

    bool automaticGun;

    public bool canScoreEuro;
    //Camera

    //Game Manager
    public GameObject gameManager;

    public GameObject face;
    public GameObject gun;
    // Use this for initialization
    //stats
    int goals = 0;
    public void addGoals()
    {
        goals++;
    }
    public int GetGoals()
    {
        return goals;
    }
    int ownGoals = 0;
    public void addOwnGoals()
    {
        ownGoals++;
    }
    public int GetOwnGoals()
    {
        return ownGoals;
    }
    int kills = 0;
    int defuses = 0;
    int plants = 0;
    public int GetKills()
    {
        return kills;
    }
    public int GetDefuses()
    {
        return defuses;
    }
    public int GetPlants()
    {
        return plants;
    }
    public string getPlayerName()
    {
        return playerName;
    }
    public void setPlayerName(string NewName)
    {
        playerName = NewName;
    }
    public void toggleRenderer()
    {
        gun.GetComponent<Renderer>().enabled = !gun.GetComponent<Renderer>().enabled;
        face.GetComponent<Renderer>().enabled = !face.GetComponent<Renderer>().enabled;
        this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled;
    }
    public void setMoveSpeed(float speed)
    {
        m_moveSpeed = speed;
    }
    public void setGunForce(float force)
    {
        m_gunForce = force;
    }
    public void setFireRate(float speed)
    {
        fireRate = speed;
    }
    public void setAutomatic(bool newBool)
    {
        automaticGun = newBool;
    }
    void Start () {
        //m_moveSpeed = 5;
        //m_gunForce = 75;
        active = true;
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

    public string GetTeam()
    {
        return team;
    }
    public void SetTeam(string a_Team)
    {
        team = a_Team;
    }
    public int GetMVPPoints()
    {
        return m_mvpPoints;
    }
    public void SetMVPPoints(int a_newValue)
    {
        m_mvpPoints = a_newValue;
    }
    public void AddMVPPoints(int a_newValue)
    {
        m_mvpPoints += a_newValue;
    }
    public void setPaintSplat(Material a_newMaterial)
    {
        m_paintSplat = a_newMaterial;
    }


    public GameObject GetManager()
    {
        return gameManager;
    }
    public void SetManager(GameObject a_Manager)
    {
        gameManager = a_Manager;
    }


    public int getShots() { return m_shots; }
    public int getAccurateShots() { return m_accurateShots; }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<sportsballManager>().GetInplay() && active == true && !gameManager.GetComponent<sportsballManager>().isPaintball)
        {
            this.gameObject.transform.LookAt(gameManager.GetComponent<sportsballManager>().ball.transform);
            {
                
            }
            if (!canFire)
            {
                timeTillfire += Time.deltaTime;
                if (timeTillfire >= 2.0f && timeTillfire >= fireRate)
                {
                    timeTillfire = 0;
                    canFire = true;
                }
            }
            if (Vector3.Distance(gameManager.GetComponent<sportsballManager>().ball.transform.position, this.gameObject.transform.position) > 50)
            {
                bonusSpeed = 2;
            }
            if (Vector3.Distance(gameManager.GetComponent<sportsballManager>().ball.transform.position, this.gameObject.transform.position) < 50)
            {
                bonusSpeed = 1;
            }
            if ( Vector3.Distance(gameManager.GetComponent<sportsballManager>().ball.transform.position, this.gameObject.transform.position) < 20 && canFire)
            {
                canFire = false;
                m_shots++;
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
                AudioSource.PlayClipAtPoint(fire, this.transform.position, 1.0f);
                

                //Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                if (Physics.Raycast(transform.position, direction, out other, 750))
                {
                    if (other.collider.CompareTag("PlayerFace"))
                    {

                        if (other.collider.GetComponent<FaceUIScript>().alphaVar < 0.5f)
                        {
                            m_mvpPoints += 1;
                            other.collider.GetComponent<FaceUIScript>().alphaVar += 1;
                            if (other.collider.GetComponent<FaceUIScript>().player.GetComponent<PlayerScript>())
                            {
                                gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " . - " + other.collider.GetComponent<FaceUIScript>().player.GetComponent<PlayerScript>().getPlayerName());
                            }
                            else if (other.collider.GetComponent<FaceUIScript>().player.GetComponent<AI>())
                            {
                                gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " . - " + other.collider.GetComponent<FaceUIScript>().player.GetComponent<AI>().getPlayerName());
                            }
                        }
                    }
                    if (other.collider.CompareTag("PlayerFace") == false && other.collider.CompareTag("Ball") == false && other.collider.CompareTag("Box") == false && other.collider.CompareTag("Player") == false && other.collider.CompareTag("Gun") == false)
                    {
                        var paintSplatQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        paintSplatQuad.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, 0);
                        paintSplatQuad.GetComponent<Renderer>().material = m_paintSplat;
                        paintSplatQuad.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                        paintSplatQuad.transform.localRotation = Quaternion.LookRotation(-other.normal);

                    }
                    else
                    {
                        m_accurateShots++;
                    }

                    //    }
                    if (other.collider.GetComponent<Rigidbody>())
                    {
                        other.collider.GetComponent<Rigidbody>().AddForce(this.transform.forward * m_gunForce);
                    }
                    if (other.collider.CompareTag("Player") || other.collider.CompareTag("PlayerFace"))
                    {
                        if (gameManager.GetComponent<sportsballManager>().isPaintball == false)
                        {
                            if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().getAttached())
                            {
                                gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                            }
                        }
                        if (other.collider.GetComponent<AI>())
                        {
                            if (gameManager.GetComponent<sportsballManager>().isPaintball)
                            {
                                other.collider.GetComponent<AI>().active = false;
                                gameManager.GetComponent<sportsballManager>().sendToDead(other.collider.gameObject);
                                gameManager.GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
                            }
                            gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " . " + other.collider.GetComponent<AI>().getPlayerName());
                        }
                        if (other.collider.GetComponent<PlayerScript>())
                        {
                            if (gameManager.GetComponent<sportsballManager>().isPaintball)
                            {
                                other.collider.GetComponent<PlayerScript>().active = false;
                                other.collider.GetComponent<PlayerScript>().throwBomb();
                                gameManager.GetComponent<sportsballManager>().sendToDead(other.collider.gameObject);
                               
                                gameManager.GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
                            }
                            gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " . " + other.collider.GetComponent<PlayerScript>().getPlayerName());
                        }
                    }
                    if (other.collider.CompareTag("Ball"))
                    {
                        if (canJump == false)
                        {
                            m_mvpPoints += 2;
                        }
                        m_mvpPoints += 3;
                        other.collider.GetComponent<BallScript>().lastPlayer = this.gameObject;
                        if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().getAttached())
                        {
                            gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                        }

                    }
                }
            }
            for (int j = 0; j < 4; j++ )
            { 
                if (gameManager.GetComponent<sportsballManager>().getPlayer(j) != this.gameObject && Vector3.Distance(gameManager.GetComponent<sportsballManager>().getPlayer(j).transform.position, this.gameObject.transform.position) < 1)
                {
                    if (canJump)
                    {
                        GetComponent<Rigidbody>().AddForce(0, 250, 0);
                        canJump = false;
                    }
                }
                if (gameManager.GetComponent<sportsballManager>().getPlayer(j) != this.gameObject && Vector3.Distance(gameManager.GetComponent<sportsballManager>().getPlayer(j).transform.position, this.gameObject.transform.position) < 10)
                {
                    //this.gameObject.transform.LookAt(gameManager.GetComponent<sportsballManager>().getPlayer(j).transform);
                    //if (Vector3.Distance(gameManager.GetComponent<sportsballManager>().ball.transform.position, this.gameObject.transform.position) > 10)
                    //{
                    //    this.gameObject.transform.LookAt(-gameManager.GetComponent<sportsballManager>().getPlayer(j).transform.forward);
                    //}
                }
            }


            this.transform.position += this.transform.forward * m_moveSpeed * bonusSpeed * Time.deltaTime;
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
