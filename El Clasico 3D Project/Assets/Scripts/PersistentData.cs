using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{

    public static PersistentData singleton;

    public float timeElapsedGame;
    public int fCBarcelonaGoals;
    public int realMadridGoals;
   // public Text fCBarcelonaScore;
   // public Text realMadridScore;
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

