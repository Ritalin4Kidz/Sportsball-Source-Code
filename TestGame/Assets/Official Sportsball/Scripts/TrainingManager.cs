using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour {
    public GameObject playerRef;
    public GameObject m_playerSpawn;
    public GameObject universalGameManager;

    public string playerClass;

    GameObject player;


    // Use this for initialization
    void Start () {
        player = Instantiate(playerRef, m_playerSpawn.transform.position, Quaternion.identity);
        player.GetComponent<PlayerScript>().m_SpawnLoc = m_playerSpawn;
        player.GetComponent<PlayerScript>().SetManager(this.gameObject);
        player.GetComponent<PlayerScript>().setPaintSplat(universalGameManager.GetComponent<UniGameManager>().basesplatTeam1);
        player.GetComponent<PlayerScript>().SetTeam("Team1");
        if (!universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer)
        {
            player.GetComponent<PlayerScript>().SetAxisAll("Player1MoveX", "Player1MoveY", "Player1LookX", "Player1LookY");
            player.GetComponent<PlayerScript>().SetButtons(KeyCode.Joystick1Button2, KeyCode.Joystick1Button0, KeyCode.Joystick1Button5, KeyCode.Joystick1Button7, KeyCode.Joystick1Button4, KeyCode.Joystick1Button1);
        }
        else
        {
            player.GetComponent<PlayerScript>().SetAxisAll("Player1MoveXPC", "Player1MoveYPC", "Player1LookXPC", "Player1LookYPC");
            player.GetComponent<PlayerScript>().SetButtons(KeyCode.Mouse0, KeyCode.Space, KeyCode.LeftShift, KeyCode.Escape, KeyCode.Q, KeyCode.E);
        }
        player.GetComponent<PlayerScript>().cam.rect = (new Rect(0, 0, 1, 1));
        if (playerClass == "Regular")
        {
            player.GetComponent<PlayerScript>().setMoveSpeed(5);
            player.GetComponent<PlayerScript>().setGunForce(75);
            player.GetComponent<PlayerScript>().setFireRate(0.025f);
            player.GetComponent<PlayerScript>().setAccuracy(0.01f);
            player.GetComponent<PlayerScript>().setMaxAccuracy(0.2f);
            player.GetComponent<PlayerScript>().setAutomatic(false);
            player.GetComponent<PlayerScript>().setSpecial("Bomb");
            player.GetComponent<PlayerScript>().setCooldown(5);
        }
        else if (playerClass == "Scout")
        {
            player.GetComponent<PlayerScript>().setMoveSpeed(7);
            player.GetComponent<PlayerScript>().setGunForce(125);
            player.GetComponent<PlayerScript>().setFireRate(1.5f);
            player.GetComponent<PlayerScript>().setAccuracy(0.3f);
            player.GetComponent<PlayerScript>().setMaxAccuracy(0.7f);
            player.GetComponent<PlayerScript>().setAutomatic(false);
            player.GetComponent<PlayerScript>().setSpecial("Scope/Dash");
            player.GetComponent<PlayerScript>().setCooldown(0);
        }
        else if (playerClass == "Gunner")
        {
            player.GetComponent<PlayerScript>().setMoveSpeed(3);
            player.GetComponent<PlayerScript>().setGunForce(100);
            player.GetComponent<PlayerScript>().setFireRate(0.25f);
            player.GetComponent<PlayerScript>().setAccuracy(0.05f);
            player.GetComponent<PlayerScript>().setMaxAccuracy(0.2f);
            player.GetComponent<PlayerScript>().setAutomatic(true);
            player.GetComponent<PlayerScript>().setSpecial("Spewer");
            player.GetComponent<PlayerScript>().setCooldown(20);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
