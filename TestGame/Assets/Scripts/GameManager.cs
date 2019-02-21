using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float playerCash;
    public string LevelToLoad;

    float lastBounty;
    // Update is called once per frame
 

    public float getLastBounty()
    {
        return lastBounty;
    }
    public void setLastBounty(float value)
    {
        lastBounty = value;
    }
}
