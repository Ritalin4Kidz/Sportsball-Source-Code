using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyScreen : MonoBehaviour {

    public Canvas thisCanvas;
    public Canvas loadCanvas;
    public Canvas selectionCanvas;
    //public Image ready1Img;
    //public Image ready2Img;
    //public Image ready3Img;
    //public Image ready4Img;
    public Image levelImg;

    //public Canvas startImg;
    public Canvas Options;
    bool aiPlaying;

    int playersReady;
    public GameObject universalGameManager;

    public Text mapName;
    //public Text[] playerTypes;
    //public string[] playerTypeStrings;
    public Material[] levelPics;
    public string[] levels;

    //KeyCode readyBtn1;
    //KeyCode readyBtn2;
    //KeyCode readyBtn3;
    //KeyCode readyBtn4;
    public KeyCode quitBtn;
    public KeyCode LevelUp;
    public KeyCode LevelDown;
    public string LevelLoad;
    int i = 0;

    bool ready1;
    bool ready2;
    bool ready3;
    bool ready4;

    //public Material[] teamcolours;
    //public Material[] teamSplatcolours;
    //public Sprite[] teamMat;
    //public Sprite[] banners;
    //public string[] teamnames;
    //public Image buttons1;
    //public Image buttons2;
    //int buttonNo1 = 0;
    //int buttonNo2 = 1;
    //float delay1 = 0;
    //bool delayOn1 = false;
    //float delay2 = 0;
    //bool delayOn2 = false;
    //bool[] delays;
    //int[] buttonNos;


    public Image loreImage;
    public Text loreText;
    public void setAiPlaY(bool a_bool)
    {
        aiPlaying = a_bool;
    }
    public bool getAIPlay()
    {
        return aiPlaying;
    }
    // Use this for initialization
    void Start()
    {
        //delays = new bool[4];
        //buttonNos = new int[4];
        //for (int i = 0; i < 4; i++)
        //{
        //    buttonNos[i] = 0;
        //    playerTypes[i].text = playerTypeStrings[buttonNos[i]];
        //    universalGameManager.GetComponent<UniGameManager>().playerType[i] = playerTypeStrings[buttonNos[i]];
        //}
        loreImage.enabled = false;
        loreText.enabled = false;
        selectionCanvas.enabled = false;
        playersReady = 0;
        //readyBtn1 = KeyCode.Joystick1Button0;
        //readyBtn2 = KeyCode.Joystick2Button0;
        //readyBtn3 = KeyCode.Joystick3Button0;
        //readyBtn4 = KeyCode.Joystick4Button0;
        universalGameManager.GetComponent<UniGameManager>().LevelLoad = levels[0];
        levelImg.material = universalGameManager.GetComponent<UniGameManager>().levelPics[0];
        loadCanvas.enabled = false;
        mapName.text = "Mountain City Park";
        loreText.text = "Mountain City was founded in 1816 by Sir Giles Mountain. Located on the outskirts of the country side, Mountain City has been home to many sportsball competitions since the dawn of sportsball. Mountain City currently has two offical sportsball teams, the 'Spaghets' & the 'Reds'. The Reds are currently the number 1 team in the world at sportsball. (06/04/2018)";
        //startImg.enabled = false;
        Options.enabled = false;
        //universalGameManager.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
        //universalGameManager.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
        //universalGameManager.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
        //universalGameManager.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
        //universalGameManager.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
        //universalGameManager.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
        //buttons1.sprite = teamMat[buttonNo1];
        //buttons2.sprite = teamMat[buttonNo2];
    }
        void MapNameChange(int j)
        {
        switch (j)
        {
            case 0:
                mapName.text = "Mountain City Park";
                loreText.text = "Mountain City was founded in 1816 by Sir Giles Mountain. Located on the outskirts of the country side, Mountain City has been home to many sportsball competitions since the dawn of sportsball. Mountain City currently has two offical sportsball teams, the 'Spaghets' & the 'Reds'. The Reds are currently the number 1 team in the world at sportsball. (06/04/2018)";
                break;
            case 1:
                mapName.text = "South West Beach";
                loreText.text = "Home to the South West Oceans, South West Beach has been a popular tourist location for 50 years. Located at the coast of the city of Deadforest, a Sportsball stadium was built in order to drive more tourists to the city in attempts to fix it's struggling economy. So far only 4 balls have been lost into the ocean. (06/04/2018)";
                break;
            case 2:
                mapName.text = "West Townie Oval";
                loreText.text = "A small town located near the Western Suburbs. The citizens of West Townie decided to convert their barely used soccer oval into a Sportsball oval in attempts of placing their small town on the map. Their team, the 'West Townie Potatoes' was named after the town's most popular food. The oval is notable for having out of bounds areas, and no bathrooms.  (06/04/2018)";
                break;
            case 3:
                mapName.text = "Western Suburbs";
                loreText.text = "Due to the park in Western Suburbs not being built yet, all the games organised in The Western Suburbs are either played at West Townie Oval or in the streets of the Suburbs. The Western Suburbs are known for having a high population due to the cheapness & number of the apartment buildings. Magpie Stadium is currently under construction, and once built will become home to their team, the 'Westen Suburbs Magpies'. (06/04/2018)";
                break;
            case 4:
                mapName.text = "West Townie (NYC)";
                loreText.text = "West Townie was founded in 1979 by a group of western settlers. The area is quite suburbian and has a number of kids/teenagers playing Sportsball on the streets at almost all times of the day. (06/04/2018)";
                break;
            case 5:
                mapName.text = "Sector 14a";
                loreText.text = "Surrounded by mystery, it is believed that this old abandoned building was used as a testing ground for Cloudsia's transport system in the High Grounds. The location of this building is unknown, but it is theorized that kids sneak in here all the time to play Sportsball. An eastern surburbian team was made to reference this building, Known as the 'Sector 14ians' (06/04/2018)";
                break;
            case 6:
                mapName.text = "Cloudsia High Grounds";
                loreText.text = "The High Grounds of Cloudsia are not a metaphor. Located in the airspace above Cloudsia, the Cloudsia High Grounds is the world's first mobile city. The expensive costs of the city have been maintained through the high tourism rates because of it's many shopping malls, sports stadiums & fancy restaurants. (06/04/2018)";
                break;
            case 7:
                mapName.text = "Dam City Dam";
                loreText.text = "Originally a part of the Western Suburbs, Dam City became it's own town in 2001 after the split. Despite the name, the city's dam has been out of operation since 2003, however it still remains a popular street spot for Sportsball matches. A reported $2750 amount of city damages has occured at this dam since 2002. (17/04/2018)";
                break;
            case 8:
                mapName.text = "Magpie Stadium (Euro)";
                loreText.text = "After years of controversy and financial struggles, Magpies Stadium was finally built. The stadium is commonly host to a wide range of sportsball games, such as 'Euro' & 'Aus' sportsball (Caution : Contains Out Of Bound Areas) (19/04/2018)";
                break;
            case 9:
                mapName.text = "Magpie Stadium (Aus)";
                loreText.text = "After years of controversy and financial struggles, Magpies Stadium was finally built. The stadium is commonly host to a wide range of sportsball games, such as 'Euro' & 'Aus' sportsball (Caution : Contains Out Of Bound Areas) (19/04/2018)";
                break;
            case 10:
                mapName.text = "Ruskville (Euro)";
                loreText.text = "A country town in the south east, Ruskville has been a popular place to place Euro Sportsball since the introduction of the sport. (Caution : Contains Out Of Bound Areas) (20/05/2018)";
                break;
            case 11:
                mapName.text = "Air Hockey";
                loreText.text = "An Air Hockey table in the middle of Jim's Arcade.  (01/06/2018)";
                break;
            case 12:
                mapName.text = "Caulbury (Euro)";
                loreText.text = "A rainy town located at the top of the country side, Caulbury's stadium was built for the pro paintball scene. The stadium was recently upgraded to accomodate pro Euro Sportsball games. (Caution : Contains Out Of Bound Areas) (01/06/2018)";
                break;
            case 13:
                mapName.text = "Caulbury (Paintball)";
                loreText.text = "A rainy town located at the top of the country side, Caulbury's stadium was built for the pro paintball scene. The stadium was recently upgraded to accomodate pro Euro Sportsball games. (01/06/2018)";
                break;
            case 14:
                mapName.text = "Sector12b (Paintball)";
                loreText.text = "An abandoned shipping factory located around the Outskirts of Caulbury. The factory has since gained a reputation after the numerous reports of illegal Paintball games. (05/06/2018)";
                break;
            case 15:
                mapName.text = "Ruskville (Paintball)";
                loreText.text = "After seeing the success of the sport in Caulbury, Ruskville has decided to host Paintball games at it's stadium as well (10/07/2018)";
                break;
            case 16:
                mapName.text = "Mountain City Park (Capture The Flag)";
                loreText.text = "Whilst the park is more commonly used for Sportsball games, the other side of the park is a great spot to host kids parties, due to it's excellent location (23/07/2018)";
                break;
            case 17:
                mapName.text = "Eastern Park Oval (Tug Of War)";
                loreText.text = "Eastern Park is the premiere spot for hosting 'Tug Of War' Sportsball games. The 'Tug Of War' brand of sportsball was invented midway through 2018, and has been rising in popularity quite quickly, due to it's simplicity in it's rules. Have the ball in your opponents end of the field, score as time goes on. The game can be played with goals, which grants the scoring team 10 points! (30/08/2018)";
                break;
            default:
                break;
        }
    }
	// Update is called once per frame
	void Update () {
        if (thisCanvas.enabled == true)
        {
            if (Input.GetKey(quitBtn) || Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneManager.LoadScene("MenuMockUp");
            }
            //if (Input.GetKeyDown(readyBtn1))
            //{
            //    {
            //        if (!ready1)
            //        {
            //            ready1Img.color = new Vector4(1, 1, 1, 1);
            //            ready1 = true;
            //            playersReady++;
            //            startImg.enabled = true;
            //        }
            //    }

            //}
            //if (Input.GetKeyDown(readyBtn2))
            //{
            //    if (!ready2)
            //    {

            //        ready2Img.color = new Vector4(1, 1, 1, 1);
            //        ready2 = true;
            //        playersReady++;
            //    }
            //}
            //if (Input.GetKeyDown(readyBtn3))
            //{
            //    if (!ready3)
            //    {
            //        ready3Img.color = new Vector4(1, 1, 1, 1);
            //        ready3 = true;
            //        playersReady++;
            //    }
            //}
            //if (Input.GetKeyDown(readyBtn4))
            //{
            //    if (!ready4)
            //    {
            //        ready4Img.color = new Vector4(1, 1, 1, 1);
            //        ready4 = true;
            //        playersReady++;
            //    }
            //}
            if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.X))
            {
                if (loreImage.enabled == false)
                {
                    loreImage.enabled = true;
                    loreText.enabled = true;
                }
                else
                {
                    loreImage.enabled = false;
                    loreText.enabled = false;
                }
            }
            //if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            //{
            //    if (ready1)
            //    {
            //        ready1Img.color = new Vector4(0, 0, 0, 1);
            //        ready1 = false;
            //        playersReady--;
            //        startImg.enabled = false;
            //    }
            //}
            //if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            //{
            //    if (ready2)
            //    {
            //        ready2Img.color = new Vector4(0, 0, 0, 1);
            //        ready2 = false;
            //        playersReady--;
            //    }
            //}
            //if (Input.GetKeyDown(KeyCode.Joystick3Button1))
            //{
            //    if (ready3)
            //    {
            //        ready3Img.color = new Vector4(0, 0, 0, 1);
            //        ready3 = false;
            //        playersReady--;
            //    }
            //}
            //if (Input.GetKeyDown(KeyCode.Joystick4Button1))
            //{
            //    if (ready4)
            //    {
            //        ready4Img.color = new Vector4(0, 0, 0, 1);
            //        ready4 = false;
            //        playersReady--;
            //    }
            //}

            //if (Input.GetAxis("Player1MoveX") < 0)
            //{
            //    if (!delayOn1)
            //    {
            //        buttonNo1--;
            //        delayOn1 = true;
            //        if (buttonNo1 < 0)
            //        {
            //            buttonNo1 = teamcolours.Length - 1;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
            //        universalGameManager.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
            //        universalGameManager.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
            //        universalGameManager.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
            //        buttons1.sprite = teamMat[buttonNo1];
            //    }
            //}
            //if (Input.GetAxis("Player1MoveX") > 0)
            //{
            //    if (!delayOn1)
            //    {
            //        buttonNo1++;
            //        delayOn1 = true;
            //        if (buttonNo1 > teamcolours.Length - 1)
            //        {
            //            buttonNo1 = 0;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().baseTeam1 = teamcolours[buttonNo1];
            //        universalGameManager.GetComponent<UniGameManager>().basesplatTeam1 = teamSplatcolours[buttonNo1];
            //        universalGameManager.GetComponent<UniGameManager>().banner1 = banners[buttonNo1];
            //        universalGameManager.GetComponent<UniGameManager>().teamname1 = teamnames[buttonNo1];
            //        buttons1.sprite = teamMat[buttonNo1];
            //    }
            //}
            //if (Input.GetAxis("Player1MoveX") == 0)
            //{
            //    delayOn1 = false;
            //    delay1 = 0;
            //}

            //if (Input.GetAxis("Player1LookX") < 0)
            //{
            //    if (ready1 && delays[0] == false)
            //    {
            //        delays[0] = true;
            //        buttonNos[0]--;
            //        if (buttonNos[0] < 0)
            //        {
            //            buttonNos[0] = playerTypeStrings.Length - 1;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().playerType[0] = playerTypeStrings[buttonNos[0]];
            //        playerTypes[0].text = playerTypeStrings[buttonNos[0]];
            //    }
            //}

            //if (Input.GetAxis("Player1LookX") > 0)
            //{
            //    if (ready1 && delays[0] == false)
            //    {
            //        delays[0] = true;
            //        buttonNos[0]++;
            //        if (buttonNos[0] > playerTypeStrings.Length - 1)
            //        {
            //            buttonNos[0] = 0;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().playerType[0] = playerTypeStrings[buttonNos[0]];
            //        playerTypes[0].text = playerTypeStrings[buttonNos[0]];
            //    }
            //}

            //if (Input.GetAxis("Player1LookX") == 0)
            //{
            //    delays[0] = false;
            //}

            //if (Input.GetAxis("Player2MoveX") < 0)
            //{
            //    if (!delayOn2)
            //    {
            //        buttonNo2--;
            //        delayOn2 = true;
            //        if (buttonNo2 < 0)
            //        {
            //            buttonNo2 = teamcolours.Length - 1;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
            //        universalGameManager.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
            //        universalGameManager.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
            //        universalGameManager.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
            //        buttons2.sprite = teamMat[buttonNo2];
            //    }
            //}
            //if (Input.GetAxis("Player2MoveX") > 0)
            //{
            //    if (!delayOn2)
            //    {
            //        buttonNo2++;
            //        delayOn2 = true;
            //        if (buttonNo2 > teamcolours.Length - 1)
            //        {
            //            buttonNo2 = 0;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().baseTeam2 = teamcolours[buttonNo2];
            //        universalGameManager.GetComponent<UniGameManager>().basesplatTeam2 = teamSplatcolours[buttonNo2];
            //        universalGameManager.GetComponent<UniGameManager>().banner2 = banners[buttonNo2];
            //        universalGameManager.GetComponent<UniGameManager>().teamname2 = teamnames[buttonNo2];
            //        buttons2.sprite = teamMat[buttonNo2];
            //    }
            //}
            //if (Input.GetAxis("Player2MoveX") == 0)
            //{
            //    delayOn2 = false;
            //    delay2 = 0;
            //}

            //if (Input.GetAxis("Player2LookX") < 0)
            //{
            //    if (ready2 && delays[1] == false)
            //    {
            //        delays[1] = true;
            //        buttonNos[1]--;
            //        if (buttonNos[1] < 0)
            //        {
            //            buttonNos[1] = playerTypeStrings.Length - 1;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().playerType[1] = playerTypeStrings[buttonNos[1]];
            //        playerTypes[1].text = playerTypeStrings[buttonNos[1]];
            //    }
            //}

            //if (Input.GetAxis("Player2LookX") > 0)
            //{
            //    if (ready2 && delays[1] == false)
            //    {
            //        delays[1] = true;
            //        buttonNos[1]++;
            //        if (buttonNos[1] > playerTypeStrings.Length - 1)
            //        {
            //            buttonNos[1] = 0;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().playerType[1] = playerTypeStrings[buttonNos[1]];
            //        playerTypes[1].text = playerTypeStrings[buttonNos[1]];
            //    }
            //}

            //if (Input.GetAxis("Player2LookX") == 0)
            //{
            //    delays[1] = false;
            //}

            //if (Input.GetAxis("Player3LookX") < 0)
            //{
            //    if (ready3 && delays[2] == false)
            //    {
            //        delays[2] = true;
            //        buttonNos[2]--;
            //        if (buttonNos[2] < 0)
            //        {
            //            buttonNos[2] = playerTypeStrings.Length - 1;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().playerType[2] = playerTypeStrings[buttonNos[2]];
            //        playerTypes[2].text = playerTypeStrings[buttonNos[2]];
            //    }
            //}

            //if (Input.GetAxis("Player3LookX") > 0)
            //{
            //    if (ready3 && delays[2] == false)
            //    {
            //        delays[2] = true;
            //        buttonNos[2]++;
            //        if (buttonNos[2] > playerTypeStrings.Length - 1)
            //        {
            //            buttonNos[2] = 0;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().playerType[2] = playerTypeStrings[buttonNos[2]];
            //        playerTypes[2].text = playerTypeStrings[buttonNos[2]];
            //    }
            //}

            //if (Input.GetAxis("Player3LookX") == 0)
            //{
            //    delays[2] = false;
            //}

            //if (Input.GetAxis("Player4LookX") < 0)
            //{
            //    if (ready4 && delays[3] == false)
            //    {
            //        delays[3] = true;
            //        buttonNos[3]--;
            //        if (buttonNos[3] < 0)
            //        {
            //            buttonNos[3] = playerTypeStrings.Length - 1;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().playerType[3] = playerTypeStrings[buttonNos[3]];
            //        playerTypes[3].text = playerTypeStrings[buttonNos[3]];
            //    }
            //}

            //if (Input.GetAxis("Player4LookX") > 0)
            //{
            //    if (ready4 && delays[3] == false)
            //    {
            //        delays[3] = true;
            //        buttonNos[3]++;
            //        if (buttonNos[3] > playerTypeStrings.Length - 1)
            //        {
            //            buttonNos[3] = 0;
            //        }
            //        universalGameManager.GetComponent<UniGameManager>().playerType[3] = playerTypeStrings[buttonNos[3]];
            //        playerTypes[3].text = playerTypeStrings[buttonNos[3]];
            //    }
            //}

            //if (Input.GetAxis("Player4LookX") == 0)
            //{
            //    delays[3] = false;
            //}

            if (Input.GetKeyDown(LevelUp) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                i++;
                if (i > levels.Length - 1)
                {
                    i = 0;
                }
                universalGameManager.GetComponent<UniGameManager>().LevelLoad = levels[i];
                levelImg.material = levelPics[i];
                MapNameChange(i);

            }
            if (Input.GetKeyDown(LevelDown) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                i--;
                if (i < 0)
                {
                    i = levels.Length - 1;
                }
                universalGameManager.GetComponent<UniGameManager>().LevelLoad = levels[i];
                levelImg.material = levelPics[i];
                MapNameChange(i);
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.O))
            {
                Options.enabled = true;
                thisCanvas.enabled = false;

            }
            if (Input.GetKey(KeyCode.Joystick1Button7))
            {
                selectionCanvas.enabled = true;
                thisCanvas.enabled = false;
                universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer = false;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                selectionCanvas.enabled = true;
                thisCanvas.enabled = false;
                universalGameManager.GetComponent<UniGameManager>().keyBoardPlayer = true;
            }
        }
    }
}
