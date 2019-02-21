using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class LoadMap : MonoBehaviour {
    public Canvas originalScreen;
    public GameObject networkObj;
    public Image background;
    float seconds;
    public Text tipBar;

    public GameObject uniGame;

    public bool started;
	// Use this for initialization
	void Start ()
        {
        started = false;
        int rand = Random.Range(0, 54);
        switch (rand)
        {
            case 0:
                tipBar.text = "Tip : Hit your opponent in the face to shortly blind them!";
                break;
            case 1:
                tipBar.text = "Tip : Some maps have boundary limits. If a ball lands there, the players and ball are reset";
                break;
            case 2:
                tipBar.text = "Trivia : Sportsball was founded 10/03/2018 by Simon S. Sports";
                break;
            case 3:
                tipBar.text = "Trivia : Sportsball is popular in 0 countries worldwide!";
                break;
            case 4:
                tipBar.text = "Tip : Shoot the ball into your opposition's goal to score, higher score wins!";
                break;
            case 5:
                tipBar.text = "Trivia : Sportsball uses paintball guns to avoid controversy & lawsuits";
                break;
            case 6:
                tipBar.text = "Tip : Sportsball guns have an infinite supply, you can shoot as much as you want";
                break;
            case 7:
                tipBar.text = "Tip : You can run & jump as much as you want, it won't affect your accuracy";
                break;
            case 8:
                tipBar.text = "Tip : Replays can be skipped if someone presses the 'A' button";
                break;
            case 9:
                tipBar.text = "Trivia : Channel 79 currently owns all the tv rights to Sportsball, however the movie rights are owned by Universal";
                break;
            case 10:
                tipBar.text = "Pro-Tip : Knock the ball into your surroundings to try for trick shots. Afterwards you can claim to your friends it was calculated";
                break;
            case 11:
                tipBar.text = "Trivia : Simon S. Sports' inspiration for Sportsball came from his previous game 'Gunball', which was the same idea but with Glocks instead of paintball guns";
                break;
            case 12:
                tipBar.text = "Pro-Tip : Unplug your opposition's controller for a slight favourable edge!";
                break;
            case 13:
                tipBar.text = "Trivia : There are currently two professional Sportsball players, 'Red Guy' & 'Blue Guy'";
                break;
            case 14:
                tipBar.text = "Tip : Each game goes for only 5 minutes (excluding replay times)";
                break;
            case 15:
                tipBar.text = "Pro-Tip : Learn the basics of this game then ask your unaware friend to play with you for an easy win!";
                break;
            case 16:
                tipBar.text = "Trivia : The training program has been banned in 14 different countries, 12 of which have banned sportsball altogether";
                break;
            case 17:
                tipBar.text = "Tip : The MVP is the player with the most MVP points. You can score MVP points through simple means such as scoring goals";
                break;
            case 18:
                tipBar.text = "Trivia : The first ever official MVP of Sportsball was Red Guy, who scored 750 MVP points against a clueless Blue Guy (12 MVP Points)";
                break;
            case 19:
                tipBar.text = "Trivia : The highest TV audience for a Sportsball match (as of 16/03/18) is 200 people";
                break;
            case 20:
                tipBar.text = "Pro-Tip : Win the MVP award to have a better shot with scoring at bars/nightclubs";
                break;
            case 21:
                tipBar.text = "Trivia : Sportsball has had an unsuccesful campaign to be recognised by the olympics";
                break;
            case 22:
                tipBar.text = "Pro-Tip : Get a hype playlist to play during the game for increased intensity";
                break;
            case 23:
                tipBar.text = "Trivia : Blue Guy was the first player to fail a drug test, after being tested positive for cough drops in his 15-0 victory over Red Guy";
                break;
            case 24:
                tipBar.text = "Trivia : Red Guy & Blue Guy hold the record for most offical Sportsball games played, with 6 each";
                break;
            case 25:
                tipBar.text = "Tip : Shooting everywhere might be fun, but missed/wild shots will lower your end of game accuracy bonus";
                break;
            case 26:
                tipBar.text = "Tip : Use less pellets than your opponent for an effiency bonus to your end MVP score";
                break;
            case 27:
                tipBar.text = "Pro-Tip : Use your pellets to draw dicks around the field and become an instant comedian";
                break;
            case 28:
                tipBar.text = "Trivia : Blue Guy currently holds the record for most phallic images drawn in official games with 7";
                break;
            case 29:
                tipBar.text = "Tip : Use less pellets than your opponent for an effiency bonus to your end MVP score";
                break;
            case 30:
                tipBar.text = "Tip : Gun Hooking is a perfectly legitimate move";
                break;
            case 31:
                tipBar.text = "Tip : Head to Training Mode if you want to improve your skills!";
                break;
            case 32:
                tipBar.text = "Tip : Training mode also focuses on more advanced techniques!";
                break;
            case 33:
                tipBar.text = "Trivia : Despite the name, Cloudsia is mostly covered on the surface. Only the High Grounds are located in the air.";
                break;
            case 34:
                tipBar.text = "Trivia : The High Grounds take over 30% of Cloudsia's Population";
                break;
            case 35:
                tipBar.text = "Trivia : The Cloudsia High Grounds are famous for being the world's first livable city in the air.";
                break;
            case 36:
                tipBar.text = "Trivia : Cloudsia's High Grounds currently has the world's highest altitude Sportsball Stadium, beating number 2 by 5km!";
                break;
            case 37:
                tipBar.text = "Trivia : Cloudsia was founded in 1875, but the High Grounds weren't built until 2014";
                break;
            case 38:
                tipBar.text = "Trivia : Dam City Dam has been out of operation since 2003";
                break;
            case 39:
                tipBar.text = "Tip : Chompball hates both electricity & you!";
                break;
            case 40:
                tipBar.text = "Trivia : Chompball was originally the first attempt to create a living sportsball ball";
                break;
            case 41:
                tipBar.text = "Pro-Tip : Let Chompball eat you and you can become one with him";
                break;
            case 42:
                tipBar.text = "Trivia : Miss Chompball was perhaps one of the stupidest and most sterotypical ideas ever created";
                break;
            case 43:
                tipBar.text = "Pro-Tip : Win as the Jester to absolutely destroy your opponents spirits!";
                break;
            case 44:
                tipBar.text = "Tip : The Jester can place a temporary clone of themselves to fool their foes.";
                break;
            case 45:
                tipBar.text = "Trivia : The Jester only signed up to play so that they could seek attention";
                break;
            case 46:
                tipBar.text = "Pro-Tip : Clean up after your sportsball matches so that you can keep the environemnt clean & healthy!";
                break;
            case 47:
                tipBar.text = "Tip : Try out some of the Game Mutators, they change up the rules in fun & interesting ways!";
                break;
            case 48:
                tipBar.text = "Trivia : Technically placing traps is not a legal Sportsball move, but do you see any officials on field?";
                break;
            case 49:
                tipBar.text = "Trivia : Sportsball has only had 3 ball tampering incidents in the last year!";
                break;
            case 50:
                tipBar.text = "Cool-Fact : Sportsball was built around a previous, completely unrelated game scripts & assets, called 'Contract Game'";
                break;
            case 51:
                tipBar.text = "Cool-Fact : Some of Contract Game's levels have been ported over into Sportsball!";
                break;
            case 52:
                tipBar.text = "Cool-Fact : The original Sportsball prototype was created in the span of One Week!";
                break;
            case 53:
                tipBar.text = "Cool-Fact : 'Contract Game' was abandoned due to issues in building";
                break;
            default:
                tipBar.text = "Trivia : Channel 79 currently owns all the tv rights to Sportsball, however the movie rights are owned by Universal";
                break;

        }
       

    }
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            if (uniGame.GetComponent<UniGameManager>().LevelLoad == "MountainRange2")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[0];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "TownOval")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[2];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "DeadForest")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[1];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "MagpiesPark")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[3];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "WestTownie")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[4];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "Moon")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[5];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "GunHookTraining")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[6];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "AimTraining1")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[7];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "Obstacle Course")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[8];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "HighGround")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[9];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "Mission1")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[10];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "DamCity")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[11];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "MagpieStadium")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[12];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "MagpieStadiumAus")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[13];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "Ruskville")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[14];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "AirHockey")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[15];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "Caulbury")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[16];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "CaulburyPaintball")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[17];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "Sector12b")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[18];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "RuskvillePaintball")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[19];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "CaptureFlag")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[20];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "ChompBoss")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[21];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "SkiRace")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[22];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "ContractLawnMower")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[23];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "CentreSquare")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[24];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "LawnmowerSportsball")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[25];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "BeeKeeper")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[26];
            }
            else if (uniGame.GetComponent<UniGameManager>().LevelLoad == "TugOfWar")
            {
                background.material = uniGame.GetComponent<UniGameManager>().levelPics[27];
            }
            seconds += Time.deltaTime;
            if (seconds >= 3)
            {
                {
                    SceneManager.LoadScene(uniGame.GetComponent<UniGameManager>().LevelLoad);
                }

            }
        }
	}

}
