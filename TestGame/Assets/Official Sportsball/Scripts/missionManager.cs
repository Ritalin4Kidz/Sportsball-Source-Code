using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missionManager : MonoBehaviour {
    public GameObject playerRef;
    public GameObject m_playerSpawn;
    public GameObject universalGameManager;
    GameObject player;

    public bool isZombie;

    public GameObject[] bosses;

    public GameObject GetPlayer()
    {
        return player;
    }
    // Use this for initialization
    void Start () {
        player = Instantiate(playerRef, m_playerSpawn.transform.position, Quaternion.identity);
        player.GetComponent<missionPlayerScript>().m_SpawnLoc = m_playerSpawn;
        player.GetComponent<missionPlayerScript>().setPaintSplat(universalGameManager.GetComponent<UniGameManager>().basesplatTeam1);
        if (!universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer)
        {
            player.GetComponent<missionPlayerScript>().SetAxisAll("Player1MoveX", "Player1MoveY", "Player1LookX", "Player1LookY");
            player.GetComponent<missionPlayerScript>().SetButtons(KeyCode.Joystick1Button5, KeyCode.Joystick1Button0, KeyCode.Joystick1Button8, KeyCode.Joystick1Button7);
        }
        else
        {
            player.GetComponent<missionPlayerScript>().SetAxisAll("Player1MoveXPC", "Player1MoveYPC", "Player1LookXPC", "Player1LookYPC");
            player.GetComponent<missionPlayerScript>().SetButtons(KeyCode.Mouse0, KeyCode.Space, KeyCode.LeftShift, KeyCode.Escape);
        }
        player.GetComponent<missionPlayerScript>().cam.rect = (new Rect(0, 0, 1, 1));
        for (int i  =0; i < bosses.Length;i++)
        {
            bosses[i].GetComponent<BossScript>().player = player;
        }
    }
	
	// Update is called once per frame
	void Update () {
		//if (isZombie)
  //      {

  //      }
	}
}
