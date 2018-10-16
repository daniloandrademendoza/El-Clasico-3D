using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMadridChangePlayerScript : MonoBehaviour
{
    private GameObject playerRM;
    private int selectedPlayerRM;
    private string[] playerNamesRM = { "Isco", "Bale", "Benzema", "Modric", "Kroos", "Casemiro", "Marcelo", "Varane", "Ramos", "Carvajal", "Courtois" };
    private int i;
    private int j;

    // Use this for initialization
    void Start()
    {
        selectedPlayerRM = 0;
        i = 1;
        j = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (selectedPlayerRM <= 11)
            {
                selectedPlayerRM = selectedPlayerRM + 1;
            }
            else
            {
                selectedPlayerRM = 1;
            }
            for (i = 1; i <= 11; i++)
            {
                for (j = 0; j < 11; j++)
                {
                    if (j + 1 == selectedPlayerRM)
                    {
                        playerRM = GameObject.Find(playerNamesRM[j]);
                        playerRM.GetComponent<RealMadridPlayerScript>().enabled = true;
                    }
                    else
                    {
                        playerRM = GameObject.Find(playerNamesRM[j]);
                        playerRM.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }

                }







            }
        }
    }
}
