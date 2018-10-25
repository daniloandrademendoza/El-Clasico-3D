using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

    public static PersistentData singleton;

    public float timeElapsedGame;
    public float barcelonaGoalsGame;
    public float realMadridGoalsGame;
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

