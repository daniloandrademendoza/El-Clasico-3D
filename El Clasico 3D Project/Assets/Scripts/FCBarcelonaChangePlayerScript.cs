using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FCBarcelonaChangePlayerScript : MonoBehaviour {
    private GameObject player;
    private int selectedPlayer;
    private string[] playerNames = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };
    private int i;
    private int j;
    
    // Use this for initialization
    void Start () {
        selectedPlayer = 0;
        i = 1;
        j = 0;
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.X))
        {
           // Debug.Log("Entered");
            if(selectedPlayer<=11)
            {
                selectedPlayer++;
            }
            else
            {
                selectedPlayer = 1;
            }
            for(i=1; i<=11;i++)
            { 
                    for(j=0; j<11;j++)
                    {
                        if (j + 1 == selectedPlayer)
                        {
                        //Debug.Log("Entered2");
                        Debug.Log(playerNames[j]);
                        player = GameObject.Find(playerNames[j]);
                        player.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        
                        }
                        else
                        {
                        // Debug.Log("Entered3");
                        //Debug.Log(playerNames[j]);
                        player = GameObject.Find(playerNames[j]);
                        player.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                        
                    }
                    }


                

            }
        }
	}
}
