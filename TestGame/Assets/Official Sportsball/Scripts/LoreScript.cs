using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoreScript : MonoBehaviour {
    public KeyCode quitBtn;
    public KeyCode LevelUp;
    public KeyCode LevelDown;
    public GameObject uniManager;

    public Text loreTxt;

    string[] lore;

    int i;
    // Use this for initialization
    void Start()
    {
        string path;
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\AchievementSaves.txt";
        if (System.IO.File.Exists(path))
        {
            List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(path));
            for (int i = 0; i < uniManager.GetComponent<UniGameManager>().achievements.Length; i++)
            {
                bool.TryParse(fileLines[i], out uniManager.GetComponent<UniGameManager>().achievements[i]);
                
            }
        }
        else
        {
            if (!System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves"))
            {
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves");
            }
            path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\SportsballSaves\\AchievementSaves.txt";
            System.IO.File.WriteAllText(path, "");
            string[] contents = new string[uniManager.GetComponent<UniGameManager>().achievements.Length];
            for (int i = 0; i < uniManager.GetComponent<UniGameManager>().achievements.Length; i++)
            {
                contents[i] = "" + uniManager.GetComponent<UniGameManager>().achievements[i];
            }
            File.WriteAllLines(path, contents);
        }
        lore = new string[5];
        if (uniManager.GetComponent<UniGameManager>().achievements[0])
        {
            lore[0] = "PAGE 1 : THE SPLIT \n The split started in December 2000, and ended March 2001. Although short, the outcome of the split was significant. \n The split occured entirely in the old Western Suburbs, after the dam was found to be illegally built on native grounds. The controversy led to a massive disagreement within the Suburbs' civilians, in which the people on the side of the dam believing that the dam should stay. To stop the Western Suburbs' council from removing the dam, the dam sided townspeople 'split' from the Western Suburbs and created their own town. The town was named 'Dam City' out of spite.";
            lore[0] += "\n Almost two years later, on April 2003, 'Dam City' closed their dam, though also voting for it to become a landmark, to stop it's destruction. In June 2007, leaked documents from Western Suburbs' offices showed that there was a plan to knock over the dam, and build a stadium there instead. This reopened the split debate, raising questions over indigenous property rights.";
            lore[0] += "\n The ensuing controversy halted the production of 'Magpie Stadium' until March 2018. The split left both towns finacially struggling, however the Western Suburbs were able to recover quickly, whilst Dam City has been struggling since it's creation. It is estimated that Dam City will go bankrupt by July 2020";
            lore[0] += "\n (17/04/2018)";
        }
        else
        {
            lore[0] = "PAGE NOT FOUND";
        }
        if (uniManager.GetComponent<UniGameManager>().achievements[1])
        {
            lore[1] = "PAGE 2 : CLOUDSIA HIGH GROUNDS \n";
            lore[1] += "The Cloudsia High Grounds were created in 2014. The High Grounds were created as a last hope for the struggling city, which was losing it's population and businesses, leading to a failing economy. The High Grounds are located in the airspace above Cloudsia, and is considered the most expensive place to live in the world. Because of this, only the richest people on Earth live in the High Grounds. However, it's tourism rates are also the highest in the world, which helps maintain the expensive costs of running the city.";
            lore[1] += "\n (18/04/2018)";
        }
        else
        {
            lore[1] = "PAGE NOT FOUND";
        }
        if (uniManager.GetComponent<UniGameManager>().achievements[2])
        {
            lore[2] = "PAGE 3 : CAULBURY - PAINTBALL & SPORTSBALL";
            lore[2] += "Caulbury's main stadium was originally built for pro paintball matches. After the death of the local scene in 2006, the stadium was left practically unused for years.";
        }
        else
        {
            lore[2] = "PAGE NOT FOUND";
        }
        if (uniManager.GetComponent<UniGameManager>().achievements[3])
        {
            lore[3] = "PAGE 4 : RUSKVILLE EXPORT TRADE";
        }
        else
        {
            lore[3] = "PAGE NOT FOUND";
        }
        if (uniManager.GetComponent<UniGameManager>().achievements[4])
        {
            lore[4] = "PAGE 5 : THE PACIFIST MOVEMENT";
        }
        else
        {
            lore[4] = "PAGE NOT FOUND";
        }


        loreTxt.text = lore[i];
    }
        // Update is called once per frame
        void Update () {
        if (Input.GetKey(quitBtn) || Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("MenuMockUp");
        }
        if (Input.GetKeyDown(LevelUp) || Input.GetKeyDown(KeyCode.D))
        {
            i++;
            if (i > lore.Length - 1)
            {
                i = 0;
            }
            loreTxt.text = lore[i];

        }
        if (Input.GetKeyDown(LevelDown) || Input.GetKeyDown(KeyCode.A))
        {
            i--;
            if (i < 0)
            {
                i = lore.Length - 1;
            }
            loreTxt.text = lore[i];
        }
    }
}
