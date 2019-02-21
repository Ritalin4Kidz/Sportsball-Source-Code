using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour {

    //
    public Image Crosshair;
    
    public GameObject bombRef;
    public GameObject cloneRef;
    bool canPlant;
    public GameObject gun;
    bool holdingBomb;
    GameObject bomb;
    float degree;
    bool meleeing;
    public GameObject face;

    bool rugby;

    bool shielding;

    bool pacifist;

    bool jester;

    string special;
    string team;
    public AudioClip fire;
    //MVP
    int m_mvpPoints;
    bool automaticGun;
    bool spewBool;
    //Movement
    float m_moveSpeed;
    string Xaxis;
    string Yaxis;
    float bonusSpeed = 1;
    float timeTillFire;
    float timePass;
    bool canJump = true;
    public GameObject m_SpawnLoc;
    GameObject[] teleporters = new GameObject[2];
    public GameObject TeleportaRef;
    public GameObject TeleportbRef;
    bool teleportA;
    public Canvas pauseScreen;
    //Inputs
    KeyCode shoot;
    KeyCode sprint;
    KeyCode jump;
    KeyCode pause;
    KeyCode specialMove;
    KeyCode plant;
    bool paused;
    //Shooting
    float m_gunForce;
    Material m_paintSplat;
    string playerName;
    bool melee;
    public bool active;
    int m_shots = 0;
    int m_accurateShots = 0;
    public float plant_defuseTime;
    float timePD;
    int spews = 0;
    //Camera
    public Camera cam;
    float speedH;
    float speedV;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    float accuracyOffset;
    float maxOffset;
    public float scaleLimit;
    string LookXaxis;
    string LookYaxis;
    float timeAccuracy = 0.1f;
    float timepass2;
    float timepass3;
    float timepass4;
    float specialCooldown;
    float timeHeldDown;
    bool zoom = false;
    float baseFOV;
    float timeTackling = 0;
    //Game Manager
    GameObject gameManager;
    GameObject playerToTackle;
    public bool canScoreEuro;

    public GameObject spyCameraRef;
    public Material StaticMat;

    public GameObject laserTrapRef;
    public GameObject HiveRef;
    GameObject laser1;
    GameObject laser2;

    Vector3 gunPos;
    Vector3 gunRot;

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
    public void setBonusSpeed(float speed)
    {
        bonusSpeed = speed;
    }
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
    public void setLookSensitivity(float a_Sens)
    {
        speedH = a_Sens;
        speedV = a_Sens;
    }
    public string getPlayerName()
    {
        return playerName;
    }
    public void setCanPlant(bool a_Plant)
    {
        canPlant = a_Plant;
    }
    public void toggleRenderer()
    {
        gun.GetComponent<Renderer>().enabled = !gun.GetComponent<Renderer>().enabled;
        face.GetComponent<Renderer>().enabled = !face.GetComponent<Renderer>().enabled;
        this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled;
    }
    public bool getCanPlant()
    {
        return canPlant;
    }
    public float getTimePD()
    {
        return timePD;
    }
    public bool getHoldingBomb()
    {
        return holdingBomb;
    }
    public void setMeleeManager()
    {
        this.gameObject.GetComponent<meleeScript>().setManager(gameManager);
    }
    public void resetCounter()
    {
        timePD = plant_defuseTime;
    }
    public void setHoldingBomb(bool a_bool, GameObject bombHold)
    {
        holdingBomb = a_bool;
        if (a_bool == true)
        {
            bomb = bombHold;
            bomb.transform.position = gun.transform.position + gun.transform.forward;
            bomb.transform.parent = this.transform;
            bomb.GetComponent<Rigidbody>().isKinematic = true;
            //Physics.IgnoreCollision(GetComponent<Collider>(), bomb.GetComponent<Collider>());
            gun.SetActive(false);
        }
        else
        {
            bomb.transform.parent = null;
            //Physics.IgnoreCollision(GetComponent<Collider>(), bomb.GetComponent<Collider>(), false);
            bomb.GetComponent<BombScript>().canBePickedUp = true;
            bomb.GetComponent<Rigidbody>().isKinematic = false;
            gun.SetActive(true);
            bomb = null;
        }
    }
    public void throwBomb()
    {
        if (holdingBomb && bomb != null)
        {
            bomb.transform.parent = null;
            //Physics.IgnoreCollision(GetComponent<Collider>(), bomb.GetComponent<Collider>(), false);
            bomb.GetComponent<BombScript>().canBePickedUp = true;
            bomb.GetComponent<Rigidbody>().isKinematic = false;
            bomb.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * m_gunForce);
            bomb = null;
            holdingBomb = false;
            gun.SetActive(true);
        }
    }
    public void Plant()
    {
        if (canPlant && bomb !=null && holdingBomb)
        {
            timePD = plant_defuseTime;
            bomb.transform.parent = null;
            //Physics.IgnoreCollision(GetComponent<Collider>(), bomb.GetComponent<Collider>(), false);
            holdingBomb = false;
            gun.SetActive(true);
            bomb.transform.eulerAngles = Vector3.zero;
            bomb.transform.position = new Vector3(bomb.transform.position.x, 0.5f, bomb.transform.position.z);
            if (!gameManager.GetComponent<sportsballManager>().getRoundEnd())
            {
                gameManager.GetComponent<sportsballManager>().setSeconds(bomb.GetComponent<BombScript>().secondsTillExplode);
                gameManager.GetComponent<sportsballManager>().setBomb(true);
                plants++;
            }
        }
        if (gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().achievements[2] == false)
        {
            gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().achievements[2] = true;
        }
    }
    public void setPlayerName(string NewName)
    {
        playerName = NewName;
    }
    public void setMelee(bool a_bool)
    {
        melee = a_bool;
    }
    public void setJester(bool a_bool)
    {
        jester = a_bool;
    }
    public void setYaw(float a_yaw)
    {
        yaw = a_yaw;
    }
    public void setPitch(float a_pitch)
    {
        pitch = a_pitch;
    }
    public void setCooldown(float a_cooldown)
    {
        specialCooldown = a_cooldown;
    }
    public void setPacifist(bool a_bool)
    {
        pacifist = a_bool;
    }
    public void setRugby(bool a_bool)
    {
        rugby = a_bool;
    }
    public float getCooldown()
    {
        return specialCooldown;
    }
    public float getCooldownTime()
    {
        return timepass3;
    }
    public void setAccuracy(float accuracy)
    {
        accuracyOffset = accuracy;
    }
    public void setMaxAccuracy(float accuracy)
    {
        maxOffset = accuracy;
    }
    public void setMoveSpeed(float speed)
    {
        m_moveSpeed = speed;
    }
    public void setGunForce(float force)
    {
        m_gunForce = force;
    }
    public float getGunForce()
    {
        return m_gunForce;
    }
    public void setFireRate(float speed)
    {
        timeTillFire = speed;
    }
    public void setAutomatic(bool newBool)
    {
        automaticGun = newBool;
    }
    void Start () {
        gunPos = gun.transform.localPosition;
        gunRot = gun.transform.localEulerAngles;
        timePD = plant_defuseTime;
        timePass = 50;
        timepass3 = 50;
        baseFOV = cam.fieldOfView;
        this.gameObject.AddComponent<meleeScript>();
        this.gameObject.GetComponent<meleeScript>().setPlayer(this.gameObject);
        setMeleeManager();
        pauseScreen.enabled = false;
        scaleLimit = 0;
        //m_moveSpeed = 5;
        //m_gunForce = 75;
        //speedH = 2.0f;
        //speedV = 2.0f;
        //Xaxis = "Player1MoveX";
        //Yaxis = "Player1MoveY";
        //LookXaxis = "Player1LookX";
        //LookYaxis = "Player1LookY";
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
    public float GetSens()
    {
        return speedH;
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
    public void setSpecial(string a_special)
    {
        special = a_special;
    }
    public void SetPaused(bool a_bool)
    {
        paused = a_bool;
    }
    public bool GetPaused() { return paused; }
    public GameObject GetManager()
    {
        return gameManager;
    }
    public void SetManager(GameObject a_Manager)
    {
        gameManager = a_Manager;
    }
    public KeyCode GetJump() { return jump; }
    public string GetXaxis() { return Xaxis; }
    public string GetYaxis() { return Yaxis; }
    public string GetXLookaxis() { return LookXaxis; }
    public string GetYLookaxis() { return LookYaxis; }
    public void SetXAxis(string a_Axis) { Xaxis = a_Axis; }
    public void SetYAxis(string a_Axis) { Yaxis = a_Axis; }
    public void SetAxisAll(string a_AxisX, string a_AxisY, string a_AxisLookX, string a_AxisLookY) { Xaxis = a_AxisX; Yaxis = a_AxisY; LookXaxis = a_AxisLookX; LookYaxis = a_AxisLookY; }
    public void SetButtons(KeyCode a_shoot, KeyCode a_jump, KeyCode a_sprint, KeyCode a_pause, KeyCode a_special, KeyCode a_plant) { shoot = a_shoot; jump = a_jump; sprint = a_sprint; pause = a_pause; specialMove = a_special; plant = a_plant; }

    public KeyCode getShootKey() { return shoot; }
    public int getShots() { return m_shots; }
    public int getAccurateShots() { return m_accurateShots; }
    // Update is called once per frame
    void Update () {
        if (!paused && gameManager.GetComponent<sportsballManager>() && gameManager.GetComponent<sportsballManager>().GetInplay() && active == true || gameManager.GetComponent<TrainingManager>())
        {
            timePass += Time.deltaTime;
            timepass2 += Time.deltaTime;
            timepass3 += Time.deltaTime;
            
            if (scaleLimit > 0 && timepass2 > timeAccuracy)
            {
                timepass2 = 0;
                scaleLimit -= 0.02f;
            }
            if (scaleLimit < 0)
            {
                scaleLimit = 0;
            }
            if (meleeing)
            {
                meleeAttack();
            }
            if (spewBool)
            {
                timepass4 += Time.deltaTime;
                if (timepass4 > 0.1f)
                {
                    spew();
                    timepass4 = 0;
                }
            }
            if (Input.GetKey(pause))
            {
                paused = true;
                pauseScreen.enabled = true;
                pauseScreen.GetComponent<PauseMenu>().functioning = true;
            }
            {
            if (!shielding)
            {
               this.transform.localPosition += new Vector3(this.transform.forward.x * Input.GetAxis(Yaxis) * Time.deltaTime * m_moveSpeed * bonusSpeed, 0, this.transform.forward.z * Input.GetAxis(Yaxis) * Time.deltaTime * m_moveSpeed * bonusSpeed);
            }
            if (shielding)
                {
                    gun.transform.Rotate(new Vector3(0,gun.transform.eulerAngles.y,0), -Input.GetAxis(Xaxis) * Time.deltaTime * 75);
                }
            }
            if (!shielding)
            {
                this.transform.localPosition += new Vector3(this.transform.right.x * Input.GetAxis(Xaxis) * Time.deltaTime * m_moveSpeed * bonusSpeed, 0, this.transform.right.z * Input.GetAxis(Xaxis) * Time.deltaTime * m_moveSpeed * bonusSpeed);
            }
            if (Input.GetAxis(Xaxis) == 0 && Input.GetAxis(Yaxis) == 0 && scaleLimit > 0)
            {
                if (!Input.GetKey(shoot) && automaticGun)
                {
                    scaleLimit -= 0.05f;
                    if (scaleLimit > 0)
                    {
                       scaleLimit = 0;
                    }
                }
            }
            if (Input.GetKeyDown(sprint))
            {
                bonusSpeed = 2;
            }
            if (Input.GetKeyUp(sprint))
            {
                bonusSpeed = 1;
            }
            if (Input.GetKey(plant) && gameManager.GetComponent<sportsballManager>().isPaintball)
            {
                if (holdingBomb && canPlant)
                {
                    timePD -= Time.deltaTime;
                    if (timePD <= 0)
                    {
                        Plant();
                        gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " Planted The Bomb!");
                    }
                }
                else if (team != gameManager.GetComponent<sportsballManager>().bomb.GetComponent<BombScript>().teamPickup && gameManager.GetComponent<sportsballManager>().isPaintball && gameManager.GetComponent<sportsballManager>().getBomb() && Vector3.Distance(this.gameObject.transform.position, gameManager.GetComponent<sportsballManager>().bomb.transform.position) < 20)
                {
                    //Debug.Log("Reach");
                    timePD -= Time.deltaTime;
                    if (timePD <= 0)
                    {
                        gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " Defused The Bomb!");
                        gameManager.GetComponent<sportsballManager>().setBomb(false);
                        gameManager.GetComponent<sportsballManager>().setSeconds(0);
                        gameManager.GetComponent<sportsballManager>().PaintballPlayerActiveCheck(true);
                        defuses++;
                        timePD = plant_defuseTime;
                        if (gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().achievements[3] == false)
                        {
                            gameManager.GetComponent<sportsballManager>().universalGameManager.GetComponent<UniGameManager>().achievements[3] = true;
                        }
                    }
                }
            }
            if (gameManager.GetComponent<sportsballManager>().isPaintball)
            {
                if (Input.GetKeyUp(plant))
                {
                    timePD = plant_defuseTime;
                }
                if (team != gameManager.GetComponent<sportsballManager>().bomb.GetComponent<BombScript>().teamPickup && Vector3.Distance(this.gameObject.transform.position, gameManager.GetComponent<sportsballManager>().bomb.transform.position) > 2)
                {
                    timePD = plant_defuseTime;
                }
            }
            if (Input.GetKeyDown(shoot) && melee)
            {
                if (holdingBomb)
                {
                    throwBomb();
                }
                gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 90, gun.transform.localEulerAngles.z);
                degree = 90;
                meleeing = true;
                this.gameObject.GetComponent<meleeScript>().setHitting(true);
            }
            else if (Input.GetKeyDown(shoot) && rugby)
            {
                if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == this.gameObject)
                {
                    gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                    gameManager.GetComponent<sportsballManager>().ball.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * m_gunForce);
                }
                else
                {
                    if (canScoreEuro)
                    {
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<Rigidbody>().isKinematic = true;
                        gameManager.GetComponent<sportsballManager>().ball.transform.parent = this.gameObject.transform;
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().setAttached(true);
                        gameManager.GetComponent<sportsballManager>().ball.transform.position = gun.transform.position + gun.transform.forward;
                        gameManager.GetComponent<sportsballManager>().ball.transform.localScale = new Vector3(1, 1, 1);
                        gun.SetActive(false);
                        Physics.IgnoreCollision(GetComponent<Collider>(), gameManager.GetComponent<sportsballManager>().ball.GetComponent<Collider>());
                        //gameManager.GetComponent<sportsballManager>().ball.GetComponent<Collider>().enabled = false;
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().lastPlayer = this.gameObject;
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding = this.gameObject;
                    }
                }
            }
            else if (Input.GetKeyDown(shoot) && pacifist)
            {
                if (canScoreEuro)
                {
                    gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                    gameManager.GetComponent<sportsballManager>().ball.GetComponent<Rigidbody>().isKinematic = true;
                    gameManager.GetComponent<sportsballManager>().ball.transform.parent = this.gameObject.transform;
                    gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().setAttached(true);
                    gameManager.GetComponent<sportsballManager>().ball.transform.position = gun.transform.position + gun.transform.forward;
                    gameManager.GetComponent<sportsballManager>().ball.transform.localScale = new Vector3(1, 1, 1);
                    gun.SetActive(false);
                    Physics.IgnoreCollision(GetComponent<Collider>(), gameManager.GetComponent<sportsballManager>().ball.GetComponent<Collider>());
                    //gameManager.GetComponent<sportsballManager>().ball.GetComponent<Collider>().enabled = false;
                    gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().lastPlayer = this.gameObject;
                    gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding = this.gameObject;
                    gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " '");
                }
                if (holdingBomb)
                {
                    throwBomb();
                }
            }
            else if (Input.GetKeyDown(shoot) && jester)
            {
                if (holdingBomb)
                {
                    throwBomb();
                }
                string tauntString;
                int strNo = Random.Range(0, 17);
                switch (strNo)
                {
                    case 0:
                        tauntString = "Ur Mum Gay";
                        break;
                    case 1:
                        tauntString = "Ur Dad Lesbiano";
                        break;
                    case 2:
                        tauntString = "Suk My Ding Dong";
                        break;
                    case 3:
                        tauntString = "Just admit ur shite";
                        break;
                    case 4:
                        tauntString = "salty much";
                        break;
                    case 5:
                        tauntString = "lmao get phukked";
                        break;
                    case 6:
                        tauntString = "ur mad cos ur bad";
                        break;
                    case 7:
                        tauntString = "fight me irl 1v1";
                        break;
                    case 8:
                        tauntString = "holy fuck ure shit";
                        break;
                    case 9:
                        tauntString = "cant blame ping, its lan";
                        break;
                    case 10:
                        tauntString = "ezpzlemonez";
                        break;
                    case 11:
                        tauntString = "doing your mum was harder";
                        break;
                    case 12:
                        tauntString = "cry is free";
                        break;
                    case 13:
                        tauntString = "Greg Inglis is from QLD";
                        break;
                    case 14:
                        tauntString = "navy marine seals";
                        break;
                    case 15:
                        tauntString = "git gud idiotz";
                        break;
                    case 16:
                        tauntString = "your mum says hi";
                        break;
                    default:
                        tauntString = "gg no re";
                        break;


                }

                gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " : " + tauntString);
            }
            else if (Input.GetKeyDown(shoot) || Input.GetKey(shoot) && automaticGun)
            {
                if (holdingBomb)
                {
                    throwBomb();
                }
                if (timePass > timeTillFire)
                {
                    timePass = 0;
                    m_shots++;

                    float randomRadiusX = Random.Range(-scaleLimit, scaleLimit);
                    float randomRadiusY = Random.Range(-scaleLimit, scaleLimit);
                    //float randomAngle = Random.Range(0, 2 * Mathf.PI);

                    ////Calculating the raycast direction
                    //Vector3 direction = new Vector3(
                    //    randomRadius * Mathf.Cos(randomAngle),
                    //    randomRadius * Mathf.Sin(randomAngle),
                    //    10
                    //);
                    //direction = transform.TransformDirection(direction.normalized);
                    RaycastHit other;
                    Ray ray;
                    if (maxOffset == 0 || scaleLimit == 0)
                    {
                        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    }
                    else
                    { 
                        ray = cam.ViewportPointToRay(new Vector3(0.5F + randomRadiusX, 0.5F + randomRadiusY, 0));
                    }
                    scaleLimit += accuracyOffset;
                    if (scaleLimit >= maxOffset)
                    {
                        scaleLimit = maxOffset;
                    }
                    AudioSource.PlayClipAtPoint(fire, this.transform.position, 1.0f);
                    if (Physics.Raycast(ray, out other, 750))
                    {
                        if (other.collider.CompareTag("PlayerFace"))
                        {
                            if (other.collider.GetComponent<FaceUIScript>())
                            {
                                if (other.collider.GetComponent<FaceUIScript>().alphaVar < 0.5f)
                                {
                                    m_mvpPoints += 1;
                                    other.collider.GetComponent<FaceUIScript>().alphaVar += 1;
                                    other.collider.GetComponent<FaceUIScript>().setPaintVision(m_paintSplat);
                                    if (other.collider.GetComponent<FaceUIScript>().player.GetComponent<PlayerScript>())
                                    {
                                        gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " . - " + other.collider.GetComponent<FaceUIScript>().player.GetComponent<PlayerScript>().getPlayerName());
                                        if (gameManager.GetComponent<sportsballManager>().isPaintball)
                                        {
                                            other.collider.GetComponent<FaceUIScript>().player.GetComponent<PlayerScript>().active = false;
                                            other.collider.GetComponent<FaceUIScript>().player.GetComponent<PlayerScript>().throwBomb();
                                            gameManager.GetComponent<sportsballManager>().sendToDead(other.collider.GetComponent<FaceUIScript>().player);
                                            kills++;
                                            gameManager.GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
                                        }
                                    }
                                

                                }
                            }
                            if (other.collider.GetComponent<FaceAI>())
                            {
                                if (other.collider.GetComponent<FaceAI>().Player.GetComponent<AI>())
                                {
                                    gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " . - " + other.collider.GetComponent<FaceUIScript>().player.GetComponent<AI>().getPlayerName());
                                    if (gameManager.GetComponent<sportsballManager>().isPaintball)
                                    {
                                        other.collider.GetComponent<FaceAI>().Player.GetComponent<AI>().active = false;
                                        gameManager.GetComponent<sportsballManager>().sendToDead(other.collider.GetComponent<FaceAI>().Player);
                                        kills++;
                                        gameManager.GetComponent<sportsballManager>().PaintballPlayerActiveCheck(false);
                                    }
                                }
                            }
                        }
                        else if (other.collider.CompareTag("Vent"))
                        {
                            other.collider.GetComponent<VentScript>().destroyVent();
                        }
                        else if (other.collider.CompareTag("VentFix"))
                        {
                            other.collider.GetComponent<ReplenishableVent>().destroyVent();
                        }
                        else if (other.collider.CompareTag("Hive"))
                        {
                            other.collider.GetComponent<HiveScript>().hp -= m_gunForce;
                        }
                        if (other.collider.CompareTag("PlayerFace") == false && other.collider.CompareTag("Hive") == false && other.collider.CompareTag("Ball") == false && other.collider.CompareTag("Box") == false && other.collider.CompareTag("Player") == false && other.collider.CompareTag("Gun") == false && other.collider.CompareTag("Vent") == false && other.collider.CompareTag("VentFix") == false)
                        {
                            var paintSplatQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                            paintSplatQuad.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, 0);
                            paintSplatQuad.GetComponent<Renderer>().material = m_paintSplat;
                            paintSplatQuad.AddComponent<paintSplats>();
                            paintSplatQuad.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                            paintSplatQuad.transform.localRotation = Quaternion.LookRotation(-other.normal);
                            

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
                                    kills++;
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
                                    kills++;
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
            if (Input.GetKeyDown(specialMove))
            {
                if (special == "Clone" && timepass3 >= specialCooldown)
                {
                    GameObject clone = Instantiate(cloneRef, this.transform.position, this.transform.rotation);
                    clone.GetComponent<Renderer>().material = this.GetComponent<Renderer>().material;
                    timepass3 = 0;
                }
                else if (special == "Extract" && timepass3 >= specialCooldown)
                {
                    transform.position = m_SpawnLoc.transform.position;
                    timepass3 = 0;
                }
                else if (special == "LaserTrap" && timepass3 >= specialCooldown)
                {
                    if (laser1 == null)
                    {
                        RaycastHit other;

                        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                        if (Physics.Raycast(ray, out other, 750))
                        {
                            laser1 = Instantiate(laserTrapRef);
                            laser1.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                            laser1.transform.localRotation = Quaternion.LookRotation(other.normal);

                        }
                    }
                    else if (laser2 == null)
                    {
                        RaycastHit other;

                        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                        if (Physics.Raycast(ray, out other, 750))
                        {
                            laser2 = Instantiate(laserTrapRef);
                            laser2.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                            laser2.transform.localRotation = Quaternion.LookRotation(other.normal);
                            laser1.GetComponent<TrapScript>().otherTrap = laser2;
                            laser1.GetComponent<TrapScript>().createLaser();

                        }
                        timepass3 = 0;
                    }
                }
                else if (special == "SystemHack" && timepass3 >= specialCooldown)
                {
                    GameObject[] SpyCams = GameObject.FindGameObjectsWithTag("SpyCamera");
                    foreach(GameObject SpyCam in SpyCams)
                    {
                        if (SpyCam.GetComponent<SpyCamera>().player.GetComponent<PlayerScript>().GetTeam() != team)
                        {
                            SpyCam.GetComponent<SpyCamera>().getUI().GetComponent<SpyCameraUI>().Img.material = StaticMat;
                        }
                    }
                    GameObject[] Clones = GameObject.FindGameObjectsWithTag("Clone");
                    foreach (GameObject Clone in Clones)
                    {
                        Clone.GetComponent<CloneDummy>().timeTilldeath = 0;
                    }
                    timepass3 = 0;
                }
                else if (special == "SpyCamera" && timepass3 >= specialCooldown)
                {
                    RaycastHit other;

                    Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    if (Physics.Raycast(ray, out other, 750))
                    {
                        GameObject cameraSpy = Instantiate(spyCameraRef);
                        cameraSpy.GetComponent<SpyCamera>().player = this.gameObject;
                        cameraSpy.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                        cameraSpy.transform.localRotation = Quaternion.LookRotation(other.normal);

                    }
                    timepass3 = 0;
                }
                else if (special == "Hive" && timepass3 >= specialCooldown)
                {
                    RaycastHit other;

                    Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    if (Physics.Raycast(ray, out other, 750))
                    {
                        GameObject hive = Instantiate(HiveRef);
                        hive.GetComponent<HiveScript>().playerA = this.gameObject;
                        hive.transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                        hive.transform.localRotation = Quaternion.LookRotation(other.normal);

                    }
                    timepass3 = 0;
                }
                else if (special == "Teleporter")
                {
                    RaycastHit other;

                    Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    if (Physics.Raycast(ray, out other, 750))
                    {
                        if (teleporters[0] == null)
                        {
                            teleporters[0] = Instantiate(TeleportaRef);
                            teleporters[0].transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                            teleporters[0].transform.localRotation = Quaternion.LookRotation(-other.normal);
                        }
                        else if (teleporters[1] == null)
                        {
                            teleporters[1] = Instantiate(TeleportbRef);
                            teleporters[1].transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                           teleporters[1].transform.localRotation = Quaternion.LookRotation(-other.normal);
                            teleporters[1].GetComponent<TeleporterScript>().otherPortal = teleporters[0];
                            teleporters[0].GetComponent<TeleporterScript>().otherPortal = teleporters[1];
                            teleportA = true;
                        }
                        else
                        {
                            Destroy(teleporters[0]);
                            teleporters[0] = teleporters[1];
                            if (teleportA)
                            {
                                teleportA = false;
                                teleporters[1] = Instantiate(TeleportaRef);
                                teleporters[1].transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                                teleporters[1].transform.localRotation = Quaternion.LookRotation(-other.normal);
                            }
                            else
                            {
                                teleportA = true;
                                teleporters[1] = Instantiate(TeleportbRef);
                                teleporters[1].transform.position = new Vector3(other.point.x - (0.01f * this.gameObject.transform.forward.x), other.point.y - (0.01f * this.gameObject.transform.forward.y), other.point.z - (0.01f * this.gameObject.transform.forward.z));
                                teleporters[1].transform.localRotation = Quaternion.LookRotation(-other.normal);
                            }
                            teleporters[1].GetComponent<TeleporterScript>().otherPortal = teleporters[0];
                            teleporters[0].GetComponent<TeleporterScript>().otherPortal = teleporters[1];

                        }
                    }
                }
                else if (special == "Shield")
                {
                    gun.transform.localEulerAngles = new Vector3(90,0, 0);
                    gun.transform.localPosition = new Vector3(0, 0.298f, 0.996f);
                    shielding = true;
                }
                else if (special == "Tackle/Kick")
                {
                    if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == this.gameObject)
                    {
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * m_gunForce * 3);
                    }
                    else
                    {
                        GameObject[] playerTackle = GameObject.FindGameObjectsWithTag("Player");    
                        playerToTackle = playerTackle[0];
                        for (int i = 0; i < playerTackle.Length;i++)
                        {
                            if (Vector3.Distance(playerTackle[i].transform.position, this.transform.position) < Vector3.Distance(playerToTackle.transform.position, this.transform.position) || playerToTackle == this.gameObject)
                            {
                                if (playerTackle[i] != this.gameObject)
                                {
                                    playerToTackle = playerTackle[i];
                                }
                            }
                            //if (playerToTackle != this.gameObject)
                            //{
                            //    if (Vector3.Distance(playerToTackle.transform.position, this.transform.position) < 2f)
                            //    {
                            //        if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == playerToTackle)
                            //        {
                            //            gameManager.GetComponent<sportsballManager>().popUpUI(team, "Tackle Made");
                            //        }
                            //    }
                            //}
                        }
                    }
                }
                else if (special == "Throw/Hit")
                {
                    if (canScoreEuro)
                    {
                        if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().getAttached())
                        {
                            gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                        }
                        
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * m_gunForce);
                    }
                    else if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == this.gameObject)
                    {
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().unAttach();
                        gameManager.GetComponent<sportsballManager>().ball.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * m_gunForce);
                    }
                }
                else if (special == "Telekinesis" && timepass3 >= specialCooldown)
                {
                    RaycastHit other;

                    Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    if (Physics.Raycast(ray, out other, 750))
                    {
                        if (other.collider.CompareTag("Ball"))
                        {
                            other.collider.GetComponent<BallScript>().removeMotion();
                            
                            gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " " + '"' + " " + '/');


                        }
                        else if (other.collider.CompareTag("Player"))
                        {
                            other.collider.GetComponent<Rigidbody>().AddForce(0,350,0);
                            if (other.collider.GetComponent<AI>())
                            {
                                gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " " + '"' + " " + other.collider.GetComponent<AI>().getPlayerName());
                            }
                            else if (other.collider.GetComponent<PlayerScript>())
                            {
                                gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " " + '"' + " " + other.collider.GetComponent<PlayerScript>().getPlayerName());
                            }
                        }
                    }
                    timepass3 = 0;
                }
                else if (special == "Bomb" && timepass3 >= specialCooldown)
                {
                    GameObject bomb;
                    
                    bomb = Instantiate(bombRef, transform.position + (2 * transform.forward) , Quaternion.identity);
                    bomb.GetComponent<Renderer>().material = m_paintSplat;
                    bomb.GetComponent<paintBomb>().m_paintSplat = m_paintSplat;
                    bomb.GetComponent<paintBomb>().playerA = this.gameObject;
                    bomb.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0));
                    bomb.GetComponent<Rigidbody>().AddForce(150 * transform.forward);
                    gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " (");
                    timepass3 = 0;
                }
                else if (special == "Scope/Dash")
                {
                    if (!zoom)
                    {
                        baseFOV = cam.fieldOfView;
                        cam.fieldOfView = 5;
                        zoom = true;
                    }
                }
                else if (special == "Spewer" && timepass3 >= specialCooldown)
                {
                    spewBool = true;
                    timepass3 = 0;
                    gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " )");
                }
            }
            if (Input.GetKey(specialMove))
            {
                timeHeldDown += Time.deltaTime;
            }
            if (Input.GetKey(specialMove) && special == "Tackle/Kick" && playerToTackle != null)
            {
                if (Vector3.Distance(this.transform.position,playerToTackle.transform.position) > 2)
                {
                    timeTackling = 0;
                    playerToTackle.GetComponent<PlayerScript>().setBonusSpeed(1);
                    gun.transform.localPosition = gunPos;
                    gun.transform.localEulerAngles = gunRot;
                    gun.GetComponent<Collider>().enabled = true;
                }
                else if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == playerToTackle)
                {
                    timeTackling += Time.deltaTime;
                    playerToTackle.GetComponent<PlayerScript>().setBonusSpeed(0.25f);
                    gun.GetComponent<Collider>().enabled = false;
                    gun.transform.LookAt(playerToTackle.transform);
                    gun.transform.position = new Vector3(this.transform.position.x + (playerToTackle.transform.position.x - this.transform.position.x) / 2, this.transform.position.y + (playerToTackle.transform.position.y - this.transform.position.y) / 2, this.transform.position.z + (playerToTackle.transform.position.z - this.transform.position.z) / 2);
                    gun.transform.localScale = new Vector3(gun.transform.localScale.x, gun.transform.localScale.y, Vector3.Distance(this.transform.position, playerToTackle.transform.position));
                    if (timeTackling >= 3)
                    {
                        if (playerToTackle != this.gameObject)
                        {
                            if (Vector3.Distance(playerToTackle.transform.position, this.transform.position) < 2f)
                            {
                                if (gameManager.GetComponent<sportsballManager>().ball.GetComponent<BallScript>().playerHolding == playerToTackle)
                                {
                                    gameManager.GetComponent<sportsballManager>().popUpUI(team, "Tackle Made");
                                    timeTackling = 0;
                                    gun.transform.localPosition = gunPos;
                                    gun.transform.localEulerAngles = gunRot;
                                    gun.GetComponent<Collider>().enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            if (Input.GetKeyUp(specialMove))
            {
                timeTackling = 0;
                if (playerToTackle != null)
                {
                    playerToTackle.GetComponent<PlayerScript>().setBonusSpeed(1.0f);
                }
                if (special == "Scope/Dash")
                {
                        cam.fieldOfView = baseFOV;
                        zoom = false;
                    if (timeHeldDown >= 1.0f)
                    {
                        this.gameObject.GetComponent<Rigidbody>().velocity = this.transform.forward * 20;
                        gameManager.GetComponent<sportsballManager>().KillFeedSend(playerName + " +");
                    }
                }
                if (special == "Shield")
                {
                    gun.transform.localEulerAngles = new Vector3(0, 0, 0);
                    gun.transform.localPosition = new Vector3(0.4729996f, 0.298f, 0.496f);
                    shielding = false;
                }
                timeHeldDown = 0;
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
                Screen.lockCursor = !Screen.lockCursor;

            //if (lastxAxis != Input.GetAxis(LookXaxis))
            {
                yaw += speedH * Input.GetAxis(LookXaxis);
            }
            // if (lastyAxis != Input.GetAxis(LookYaxis))
            {
                pitch -= speedV * Input.GetAxis(LookYaxis);
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
        if (collision.collider.CompareTag("Ball"))
        {
            canScoreEuro = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            canScoreEuro = false;
        }
    }

    void meleeAttack()
    {
        gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, degree, gun.transform.localEulerAngles.z);
        degree -= 180 * Time.deltaTime;
        if (degree < 0)
        {
            degree = 0;
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, degree, gun.transform.localEulerAngles.z);
            meleeing = false;
            this.gameObject.GetComponent<meleeScript>().setHitting(false);
        }

    }
    private void spew()
    {
        GameObject bomb;
        bomb = Instantiate(bombRef, transform.position + (2 * transform.forward), Quaternion.identity);
        bomb.GetComponent<Renderer>().material = m_paintSplat;
        bomb.GetComponent<paintBomb>().m_paintSplat = m_paintSplat;
        bomb.GetComponent<paintBomb>().playerA = this.gameObject;
        bomb.GetComponent<paintBomb>().radius = 3;
        bomb.GetComponent<paintBomb>().power = 5;
        bomb.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0));
        bomb.GetComponent<Rigidbody>().AddForce(150 * transform.forward);
        spews++;
        if (spews > 12)
        {
            spewBool = false;
            spews = 0;
        }
    }
}
