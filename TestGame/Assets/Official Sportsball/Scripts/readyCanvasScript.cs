using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readyCanvasScript : MonoBehaviour {
    public GameObject uniGM;
    public Image[] readyButtons;
    public Image[] player1readyNodes;
    int node1 = 1;
    bool delay1;
    public Image[] player2readyNodes;
    int node2 = 1;
    bool delay2;
    public Image[] player3readyNodes;
    int node3 = 1;
    bool delay3;
    public Image[] player4readyNodes;
    int node4 = 1;
    bool delay4;


    public Text[] playerTypes;
    public string[] playerTypeStrings;
    int[] buttonNos;
    bool[] delays;

    public Canvas startImg;
    public Canvas loadCanvas;
    public Canvas readyCanvas;
    public Canvas thisCanvas;
    public Material[] teamcolours;
    public Material[] teamSplatcolours;
    public Sprite[] teamMat;
    public Sprite[] banners;
    public string[] teamnames;
    public Image buttons1;
    public Image buttons2;
    int buttonNo1 = 0;
    int buttonNo2 = 1;
    string[] axis = new string[6];
    int playersReady;
    public Canvas options;
    // Use this for initialization
    void Start () {
        //playerAxis
        if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer)
        {
            axis[0] = "Player1MoveX";
            axis[1] = "Player1LookX";
            axis[2] = "Player2MoveX";
            axis[3] = "Player2LookX";
            axis[4] = "Player3MoveX";
            axis[5] = "Player3LookX";
        }
        else if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer)
        {
            axis[0] = "Player2MoveX";
            axis[1] = "Player2LookX";
            axis[2] = "Player3MoveX";
            axis[3] = "Player3LookX";
            axis[4] = "Player4MoveX";
            axis[5] = "Player4LookX";
        }
        playersReady = 0;
        startImg.enabled = false;
        delays = new bool[4];
        buttonNos = new int[4];
        for (int i = 0; i < 4; i++)
        {
            uniGM.GetComponent<UniGameManager>().playerReady[i] = false;
            uniGM.GetComponent<UniGameManager>().playerTeams[i] = "Team1";
            buttonNos[i] = 0;
            playerTypes[i].text = playerTypeStrings[buttonNos[i]];
            uniGM.GetComponent<UniGameManager>().playerType[i] = playerTypeStrings[buttonNos[i]];
        }
        readyButtons[0].transform.position = player1readyNodes[node1].transform.position;
        readyButtons[1].transform.position = player2readyNodes[node2].transform.position;
        readyButtons[2].transform.position = player3readyNodes[node3].transform.position;
        readyButtons[3].transform.position = player4readyNodes[node4].transform.position;
        uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
        uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
        uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
        uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
        uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
        uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
        uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
        uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
        buttons1.sprite = teamMat[buttonNo1];
        buttons2.sprite = teamMat[buttonNo2];
    }

    // Update is called once per frame
    void Update()
    {
        if (thisCanvas.enabled == true)
        {
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1MoveX") > 0 && !delay1 && !uniGM.GetComponent<UniGameManager>().playerReady[0] || uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.RightArrow) && !uniGM.GetComponent<UniGameManager>().playerReady[0])
            {
                if (node1 < player1readyNodes.Length - 1)
                {
                    node1++;
                    readyButtons[0].transform.position = player1readyNodes[node1].transform.position;
                    delay1 = true;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1MoveX") < 0 && !delay1 && !uniGM.GetComponent<UniGameManager>().playerReady[0] || uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.LeftArrow) && !uniGM.GetComponent<UniGameManager>().playerReady[0])
            {
                if (node1 > 0)
                {
                    node1--;
                    readyButtons[0].transform.position = player1readyNodes[node1].transform.position;
                    delay1 = true;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1MoveX") == 0 || uniGM.GetComponent<UniGameManager>().keyBoardPlayer)
            {
                delay1 = false;
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1LookX") < 0 || uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Q))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[0] && delays[0] == false)
                {
                    delays[0] = true;
                    buttonNos[0]--;
                    if (buttonNos[0] < 0)
                    {
                        buttonNos[0] = playerTypeStrings.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[0] = playerTypeStrings[buttonNos[0]];
                    playerTypes[0].text = playerTypeStrings[buttonNos[0]];
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1LookX") > 0 || uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.E))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[0] && delays[0] == false)
                {
                    delays[0] = true;
                    buttonNos[0]++;
                    if (buttonNos[0] > playerTypeStrings.Length - 1)
                    {
                        buttonNos[0] = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[0] = playerTypeStrings[buttonNos[0]];
                    playerTypes[0].text = playerTypeStrings[buttonNos[0]];
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1LookX") == 0 || uniGM.GetComponent<UniGameManager>().keyBoardPlayer)
            {
                delays[0] = false;
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2MoveX") > 0 && !delay2 && !uniGM.GetComponent<UniGameManager>().playerReady[1])
            {
                if (node2 < player2readyNodes.Length - 1)
                {
                    node2++;
                    readyButtons[1].transform.position = player2readyNodes[node2].transform.position;
                    delay2 = true;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1MoveX") > 0 && !delay2 && !uniGM.GetComponent<UniGameManager>().playerReady[1])
            {
                if (node2 < player2readyNodes.Length - 1)
                {
                    node2++;
                    readyButtons[1].transform.position = player2readyNodes[node2].transform.position;
                    delay2 = true;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2MoveX") < 0 && !delay2 && !uniGM.GetComponent<UniGameManager>().playerReady[1])
            {
                if (node2 > 0)
                {
                    node2--;
                    readyButtons[1].transform.position = player2readyNodes[node2].transform.position;
                    delay2 = true;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1MoveX") < 0 && !delay2 && !uniGM.GetComponent<UniGameManager>().playerReady[1])
            {
                if (node2 > 0)
                {
                    node2--;
                    readyButtons[1].transform.position = player2readyNodes[node2].transform.position;
                    delay2 = true;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2MoveX") == 0)
            {
                delay2 = false;
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1MoveX") == 0)
            {
                delay2 = false;
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2LookX") < 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[1] && delays[1] == false)
                {
                    delays[1] = true;
                    buttonNos[1]--;
                    if (buttonNos[1] < 0)
                    {
                        buttonNos[1] = playerTypeStrings.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[1] = playerTypeStrings[buttonNos[1]];
                    playerTypes[1].text = playerTypeStrings[buttonNos[1]];
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1LookX") < 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[1] && delays[1] == false)
                {
                    delays[1] = true;
                    buttonNos[1]--;
                    if (buttonNos[1] < 0)
                    {
                        buttonNos[1] = playerTypeStrings.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[1] = playerTypeStrings[buttonNos[1]];
                    playerTypes[1].text = playerTypeStrings[buttonNos[1]];
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2LookX") > 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[1] && delays[1] == false)
                {
                    delays[1] = true;
                    buttonNos[1]++;
                    if (buttonNos[1] > playerTypeStrings.Length - 1)
                    {
                        buttonNos[1] = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[1] = playerTypeStrings[buttonNos[1]];
                    playerTypes[1].text = playerTypeStrings[buttonNos[1]];
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1LookX") > 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[1] && delays[1] == false)
                {
                    delays[1] = true;
                    buttonNos[1]++;
                    if (buttonNos[1] > playerTypeStrings.Length - 1)
                    {
                        buttonNos[1] = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[1] = playerTypeStrings[buttonNos[1]];
                    playerTypes[1].text = playerTypeStrings[buttonNos[1]];
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2LookX") == 0)
            {
                delays[1] = false;
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player1LookX") == 0)
            {
                delays[1] = false;
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3MoveX") > 0 && !delay3 && !uniGM.GetComponent<UniGameManager>().playerReady[2])
            {
                if (node3 < player3readyNodes.Length - 1)
                {
                    node3++;
                    readyButtons[2].transform.position = player3readyNodes[node3].transform.position;
                    delay3 = true;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2MoveX") > 0 && !delay3 && !uniGM.GetComponent<UniGameManager>().playerReady[2])
            {
                if (node3 < player3readyNodes.Length - 1)
                {
                    node3++;
                    readyButtons[2].transform.position = player3readyNodes[node3].transform.position;
                    delay3 = true;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3MoveX") < 0 && !delay3 && !uniGM.GetComponent<UniGameManager>().playerReady[2])
            {
                if (node3 > 0)
                {
                    node3--;
                    readyButtons[2].transform.position = player3readyNodes[node3].transform.position;
                    delay3 = true;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2MoveX") < 0 && !delay3 && !uniGM.GetComponent<UniGameManager>().playerReady[2])
            {
                if (node3 > 0)
                {
                    node3--;
                    readyButtons[2].transform.position = player3readyNodes[node3].transform.position;
                    delay3 = true;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3MoveX") == 0)
            {
                delay3 = false;
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2MoveX") == 0)
            {
                delay3 = false;
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3LookX") < 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[2] && delays[2] == false)
                {
                    delays[2] = true;
                    buttonNos[2]--;
                    if (buttonNos[2] < 0)
                    {
                        buttonNos[2] = playerTypeStrings.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[2] = playerTypeStrings[buttonNos[2]];
                    playerTypes[2].text = playerTypeStrings[buttonNos[2]];
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2LookX") < 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[2] && delays[2] == false)
                {
                    delays[2] = true;
                    buttonNos[2]--;
                    if (buttonNos[2] < 0)
                    {
                        buttonNos[2] = playerTypeStrings.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[2] = playerTypeStrings[buttonNos[2]];
                    playerTypes[2].text = playerTypeStrings[buttonNos[2]];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3LookX") > 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[2] && delays[2] == false)
                {
                    delays[2] = true;
                    buttonNos[2]++;
                    if (buttonNos[2] > playerTypeStrings.Length - 1)
                    {
                        buttonNos[2] = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[2] = playerTypeStrings[buttonNos[2]];
                    playerTypes[2].text = playerTypeStrings[buttonNos[2]];
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2LookX") > 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[2] && delays[2] == false)
                {
                    delays[2] = true;
                    buttonNos[2]++;
                    if (buttonNos[2] > playerTypeStrings.Length - 1)
                    {
                        buttonNos[2] = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[2] = playerTypeStrings[buttonNos[2]];
                    playerTypes[2].text = playerTypeStrings[buttonNos[2]];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3LookX") == 0)
            {
                delays[2] = false;
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player2LookX") == 0)
            {
                delays[2] = false;
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player4LookX") < 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[3] && delays[3] == false)
                {
                    delays[3] = true;
                    buttonNos[3]--;
                    if (buttonNos[3] < 0)
                    {
                        buttonNos[3] = playerTypeStrings.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[3] = playerTypeStrings[buttonNos[3]];
                    playerTypes[3].text = playerTypeStrings[buttonNos[3]];
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3LookX") < 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[3] && delays[3] == false)
                {
                    delays[3] = true;
                    buttonNos[3]--;
                    if (buttonNos[3] < 0)
                    {
                        buttonNos[3] = playerTypeStrings.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[3] = playerTypeStrings[buttonNos[3]];
                    playerTypes[3].text = playerTypeStrings[buttonNos[3]];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player4LookX") > 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[3] && delays[3] == false)
                {
                    delays[3] = true;
                    buttonNos[3]++;
                    if (buttonNos[3] > playerTypeStrings.Length - 1)
                    {
                        buttonNos[3] = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[3] = playerTypeStrings[buttonNos[3]];
                    playerTypes[3].text = playerTypeStrings[buttonNos[3]];
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3LookX") > 0)
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[3] && delays[3] == false)
                {
                    delays[3] = true;
                    buttonNos[3]++;
                    if (buttonNos[3] > playerTypeStrings.Length - 1)
                    {
                        buttonNos[3] = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().playerType[3] = playerTypeStrings[buttonNos[3]];
                    playerTypes[3].text = playerTypeStrings[buttonNos[3]];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player4LookX") == 0)
            {
                delays[3] = false;
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3LookX") == 0)
            {
                delays[3] = false;
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player4MoveX") > 0 && !delay4 && !uniGM.GetComponent<UniGameManager>().playerReady[3])
            {
                if (node4 < player4readyNodes.Length - 1)
                {
                    node4++;
                    readyButtons[3].transform.position = player4readyNodes[node4].transform.position;
                    delay4 = true;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3MoveX") > 0 && !delay4 && !uniGM.GetComponent<UniGameManager>().playerReady[3])
            {
                if (node4 < player4readyNodes.Length - 1)
                {
                    node4++;
                    readyButtons[3].transform.position = player4readyNodes[node4].transform.position;
                    delay4 = true;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player4MoveX") < 0 && !delay4 && !uniGM.GetComponent<UniGameManager>().playerReady[3])
            {
                if (node4 > 0)
                {
                    node4--;
                    readyButtons[3].transform.position = player4readyNodes[node4].transform.position;
                    delay4 = true;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3MoveX") < 0 && !delay4 && !uniGM.GetComponent<UniGameManager>().playerReady[3])
            {
                if (node4 > 0)
                {
                    node4--;
                    readyButtons[3].transform.position = player4readyNodes[node4].transform.position;
                    delay4 = true;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player4MoveX") == 0)
            {
                delay4 = false;
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetAxis("Player3MoveX") == 0)
            {
                delay4 = false;
            }




            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[0])
                {
                    readyButtons[0].color = new Vector4(0, 0, 0, 1);
                    uniGM.GetComponent<UniGameManager>().playerReady[0] = false;
                    startImg.enabled = false;
                    playersReady--;
                    uniGM.GetComponent<UniGameManager>().playerTeams[0] = null;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.B))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[0])
                {
                    readyButtons[0].color = new Vector4(0, 0, 0, 1);
                    uniGM.GetComponent<UniGameManager>().playerReady[0] = false;
                    startImg.enabled = false;
                    playersReady--;
                    uniGM.GetComponent<UniGameManager>().playerTeams[0] = null;
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer &&Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                {
                    if (!uniGM.GetComponent<UniGameManager>().playerReady[0] && node1 != 1)
                    {
                        readyButtons[0].color = new Vector4(1, 1, 1, 1);
                        uniGM.GetComponent<UniGameManager>().playerReady[0] = true;
                        startImg.enabled = true;
                        playersReady++;
                        if (node1 == 0)
                        {
                            uniGM.GetComponent<UniGameManager>().playerTeams[0] = "Team1";
                        }
                        else if (node1 == 2)
                        {

                            uniGM.GetComponent<UniGameManager>().playerTeams[0] = "Team2";
                        }
                    }
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Space))
            {
                {
                    if (!uniGM.GetComponent<UniGameManager>().playerReady[0] && node1 != 1)
                    {
                        readyButtons[0].color = new Vector4(1, 1, 1, 1);
                        uniGM.GetComponent<UniGameManager>().playerReady[0] = true;
                        startImg.enabled = true;
                        playersReady++;
                        if (node1 == 0)
                        {
                            uniGM.GetComponent<UniGameManager>().playerTeams[0] = "Team1";
                        }
                        else if (node1 == 2)
                        {

                            uniGM.GetComponent<UniGameManager>().playerTeams[0] = "Team2";
                        }
                    }
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[1])
                {
                    readyButtons[1].color = new Vector4(0, 0, 0, 1);
                    uniGM.GetComponent<UniGameManager>().playerReady[1] = false;
                    playersReady--;
                    uniGM.GetComponent<UniGameManager>().playerTeams[1] = null;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[1])
                {
                    readyButtons[1].color = new Vector4(0, 0, 0, 1);
                    uniGM.GetComponent<UniGameManager>().playerReady[1] = false;
                    playersReady--;
                    uniGM.GetComponent<UniGameManager>().playerTeams[1] = null;
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                {
                    if (!uniGM.GetComponent<UniGameManager>().playerReady[1] && node2 != 1)
                    {
                        readyButtons[1].color = new Vector4(1, 1, 1, 1);
                        uniGM.GetComponent<UniGameManager>().playerReady[1] = true;
                        playersReady++;
                        if (node2 == 0)
                        {
                            uniGM.GetComponent<UniGameManager>().playerTeams[1] = "Team1";
                        }
                        else if (node2 == 2)
                        {

                            uniGM.GetComponent<UniGameManager>().playerTeams[1] = "Team2";
                        }
                    }
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                {
                    if (!uniGM.GetComponent<UniGameManager>().playerReady[1] && node2 != 1)
                    {
                        readyButtons[1].color = new Vector4(1, 1, 1, 1);
                        uniGM.GetComponent<UniGameManager>().playerReady[1] = true;
                        playersReady++;
                        if (node2 == 0)
                        {
                            uniGM.GetComponent<UniGameManager>().playerTeams[1] = "Team1";
                        }
                        else if (node2 == 2)
                        {

                            uniGM.GetComponent<UniGameManager>().playerTeams[1] = "Team2";
                        }
                    }
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick3Button1))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[2])
                {
                    readyButtons[2].color = new Vector4(0, 0, 0, 1);
                    uniGM.GetComponent<UniGameManager>().playerReady[2] = false;
                    playersReady--;
                    uniGM.GetComponent<UniGameManager>().playerTeams[2] = null;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[2])
                {
                    readyButtons[2].color = new Vector4(0, 0, 0, 1);
                    uniGM.GetComponent<UniGameManager>().playerReady[2] = false;
                    playersReady--;
                    uniGM.GetComponent<UniGameManager>().playerTeams[2] = null;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                {
                    if (!uniGM.GetComponent<UniGameManager>().playerReady[2] && node3 != 1)
                    {
                        readyButtons[2].color = new Vector4(1, 1, 1, 1);
                        uniGM.GetComponent<UniGameManager>().playerReady[2] = true;
                        playersReady++;
                        if (node3 == 0)
                        {
                            uniGM.GetComponent<UniGameManager>().playerTeams[2] = "Team1";
                        }
                        else if (node3 == 2)
                        {

                            uniGM.GetComponent<UniGameManager>().playerTeams[2] = "Team2";
                        }
                    }

                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                {
                    if (!uniGM.GetComponent<UniGameManager>().playerReady[2] && node3 != 1)
                    {
                        readyButtons[2].color = new Vector4(1, 1, 1, 1);
                        uniGM.GetComponent<UniGameManager>().playerReady[2] = true;
                        playersReady++;
                        if (node3 == 0)
                        {
                            uniGM.GetComponent<UniGameManager>().playerTeams[2] = "Team1";
                        }
                        else if (node3 == 2)
                        {

                            uniGM.GetComponent<UniGameManager>().playerTeams[2] = "Team2";
                        }
                    }

                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick4Button1))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[3])
                {
                    readyButtons[3].color = new Vector4(0, 0, 0, 1);
                    uniGM.GetComponent<UniGameManager>().playerReady[3] = false;
                    playersReady--;
                    uniGM.GetComponent<UniGameManager>().playerTeams[3] = null;
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick3Button1))
            {
                if (uniGM.GetComponent<UniGameManager>().playerReady[3])
                {
                    readyButtons[3].color = new Vector4(0, 0, 0, 1);
                    uniGM.GetComponent<UniGameManager>().playerReady[3] = false;
                    playersReady--;
                    uniGM.GetComponent<UniGameManager>().playerTeams[3] = null;
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick4Button0))
            {
                {
                    if (!uniGM.GetComponent<UniGameManager>().playerReady[3] && node4 != 1)
                    {
                        readyButtons[3].color = new Vector4(1, 1, 1, 1);
                        uniGM.GetComponent<UniGameManager>().playerReady[3] = true;
                        playersReady++;
                        if (node4 == 0)
                        {
                            uniGM.GetComponent<UniGameManager>().playerTeams[3] = "Team1";
                        }
                        else if (node4 == 2)
                        {

                            uniGM.GetComponent<UniGameManager>().playerTeams[3] = "Team2";
                        }
                    }
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                {
                    if (!uniGM.GetComponent<UniGameManager>().playerReady[3] && node4 != 1)
                    {
                        readyButtons[3].color = new Vector4(1, 1, 1, 1);
                        uniGM.GetComponent<UniGameManager>().playerReady[3] = true;
                        playersReady++;
                        if (node4 == 0)
                        {
                            uniGM.GetComponent<UniGameManager>().playerTeams[3] = "Team1";
                        }
                        else if (node4 == 2)
                        {

                            uniGM.GetComponent<UniGameManager>().playerTeams[3] = "Team2";
                        }
                    }
                }
            }



            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                if (node1 == 0)
                {
                    buttonNo1--;
                    if (buttonNo1 < 0)
                    {
                        buttonNo1 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node1 == 2)
                {
                    buttonNo2--;
                    if (buttonNo2 < 0)
                    {
                        buttonNo2 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.J))
            {
                if (node1 == 0)
                {
                    buttonNo1--;
                    if (buttonNo1 < 0)
                    {
                        buttonNo1 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node1 == 2)
                {
                    buttonNo2--;
                    if (buttonNo2 < 0)
                    {
                        buttonNo2 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                if (node1 == 0)
                {
                    buttonNo1++;
                    if (buttonNo1 > teamcolours.Length - 1)
                    {
                        buttonNo1 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node1 == 2)
                {
                    buttonNo2++;
                    if (buttonNo2 > teamcolours.Length - 1)
                    {
                        buttonNo2 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.K))
            {
                if (node1 == 0)
                {
                    buttonNo1++;
                    if (buttonNo1 > teamcolours.Length - 1)
                    {
                        buttonNo1 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node1 == 2)
                {
                    buttonNo2++;
                    if (buttonNo2 > teamcolours.Length - 1)
                    {
                        buttonNo2 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick2Button4))
            {
                if (node2 == 0)
                {
                    buttonNo1--;
                    if (buttonNo1 < 0)
                    {
                        buttonNo1 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node2 == 2)
                {
                    buttonNo2--;
                    if (buttonNo2 < 0)
                    {
                        buttonNo2 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick2Button5))
            {
                if (node2 == 0)
                {
                    buttonNo1++;
                    if (buttonNo1 > teamcolours.Length - 1)
                    {
                        buttonNo1 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node2 == 2)
                {
                    buttonNo2++;
                    if (buttonNo2 > teamcolours.Length - 1)
                    {
                        buttonNo2 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick3Button4))
            {
                if (node3 == 0)
                {
                    buttonNo1--;
                    if (buttonNo1 < 0)
                    {
                        buttonNo1 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node3 == 2)
                {
                    buttonNo2--;
                    if (buttonNo2 < 0)
                    {
                        buttonNo2 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick3Button5))
            {
                if (node3 == 0)
                {
                    buttonNo1++;
                    if (buttonNo1 > teamcolours.Length - 1)
                    {
                        buttonNo1 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node3 == 2)
                {
                    buttonNo2++;
                    if (buttonNo2 > teamcolours.Length - 1)
                    {
                        buttonNo2 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick4Button4))
            {
                if (node4 == 0)
                {
                    buttonNo1--;
                    if (buttonNo1 < 0)
                    {
                        buttonNo1 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node4 == 2)
                {
                    buttonNo2--;
                    if (buttonNo2 < 0)
                    {
                        buttonNo2 = teamcolours.Length - 1;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick4Button5))
            {
                if (node4 == 0)
                {
                    buttonNo1++;
                    if (buttonNo1 > teamcolours.Length - 1)
                    {
                        buttonNo1 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
                    uniGM.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
                    buttons1.sprite = teamMat[buttonNo1];
                }
                else if (node4 == 2)
                {
                    buttonNo2++;
                    if (buttonNo2 > teamcolours.Length - 1)
                    {
                        buttonNo2 = 0;
                    }
                    uniGM.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
                    uniGM.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
                    buttons2.sprite = teamMat[buttonNo2];
                }
            }
            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick1Button6))
            {
                readyCanvas.enabled = true;
                thisCanvas.enabled = false;
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Backspace))
            {
                readyCanvas.enabled = true;
                thisCanvas.enabled = false;
            }

            if (!uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Joystick1Button7) && uniGM.GetComponent<UniGameManager>().playerReady[0])
            {
                loadCanvas.enabled = true;
                uniGM.GetComponent<UniGameManager>().players = playersReady;
                if (uniGM.GetComponent<UniGameManager>().aiIsPlaying)
                {
                    uniGM.GetComponent<UniGameManager>().aiPlayers = 4 - playersReady;
                }
                else
                {
                    uniGM.GetComponent<UniGameManager>().aiPlayers = 0;
                }
                uniGM.GetComponent<UniGameManager>().TournamentMode = false;
                uniGM.GetComponent<UniGameManager>().seasonModeOn = false;
                loadCanvas.GetComponent<LoadMap>().started = true;
                thisCanvas.enabled = false;
            }
            else if (uniGM.GetComponent<UniGameManager>().keyBoardPlayer && Input.GetKeyDown(KeyCode.Return) && uniGM.GetComponent<UniGameManager>().playerReady[0])
            {
                loadCanvas.enabled = true;
                uniGM.GetComponent<UniGameManager>().players = playersReady;
                if (uniGM.GetComponent<UniGameManager>().aiIsPlaying)
                {
                    uniGM.GetComponent<UniGameManager>().aiPlayers = 4 - playersReady;
                }
                else
                {
                    uniGM.GetComponent<UniGameManager>().aiPlayers = 0;
                }
                uniGM.GetComponent<UniGameManager>().TournamentMode = false;
                uniGM.GetComponent<UniGameManager>().seasonModeOn = false;
                loadCanvas.GetComponent<LoadMap>().started = true;
                thisCanvas.enabled = false;
            }
        }
    }
}
