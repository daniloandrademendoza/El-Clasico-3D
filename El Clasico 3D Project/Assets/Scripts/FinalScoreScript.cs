using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour {
    public Text barcelonaScoreGame;
    public Text realMadridScoreGame;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        barcelonaScoreGame.text = "        " + PersistentData.singleton.barcelonaScores[0].ToString();/* + "\n" + "        " + PersistentData.singleton.barcelonaScores[1].ToString() + "\n" +*/
                                 //"        " + PersistentData.singleton.barcelonaScores[2].ToString() + "\n" + "        " + PersistentData.singleton.barcelonaScores[3].ToString() + "\n" +
                                 //"        " + PersistentData.singleton.barcelonaScores[4].ToString() + "\n" + "        " + PersistentData.singleton.barcelonaScores[5].ToString() + "\n" +
                                 //"        " + PersistentData.singleton.barcelonaScores[6].ToString() + "\n" + "        " + PersistentData.singleton.barcelonaScores[7].ToString() + "\n" +
                                 //"        " + PersistentData.singleton.barcelonaScores[8].ToString() + "\n" + "        " + PersistentData.singleton.barcelonaScores[9].ToString() + "\n" +
                                 //"        " + PersistentData.singleton.barcelonaScores[10].ToString() + "\n" + "        " + PersistentData.singleton.barcelonaScores[11].ToString() + "\n" +
                                 //"        " + PersistentData.singleton.barcelonaScores[12].ToString() + "\n" + "        " + PersistentData.singleton.barcelonaScores[13].ToString() + "\n" +
                                 //"        " + PersistentData.singleton.barcelonaScores[14].ToString();
        realMadridScoreGame.text = "    " + PersistentData.singleton.realMadridScores[0].ToString();/* + "\n" + "    " + PersistentData.singleton.realMadridScores[1].ToString() + "\n" +*/
                                   //"    " + PersistentData.singleton.realMadridScores[2].ToString() + "\n" + "    " + PersistentData.singleton.realMadridScores[3].ToString() + "\n" +
                                   //"    " + PersistentData.singleton.realMadridScores[4].ToString() + "\n" + "    " + PersistentData.singleton.realMadridScores[5].ToString() + "\n" +
                                   //"    " + PersistentData.singleton.realMadridScores[6].ToString() + "\n" + "    " + PersistentData.singleton.realMadridScores[7].ToString() + "\n" +
                                   //"    " + PersistentData.singleton.realMadridScores[8].ToString() + "\n" + "    " + PersistentData.singleton.realMadridScores[9].ToString() + "\n" +
                                   //"    " + PersistentData.singleton.realMadridScores[10].ToString() + "\n" + "    " + PersistentData.singleton.realMadridScores[11].ToString() + "\n" +
                                   //"    " + PersistentData.singleton.realMadridScores[12].ToString() + "\n" + "    " + PersistentData.singleton.realMadridScores[13].ToString() + "\n" +
                                   //"    " + PersistentData.singleton.realMadridScores[14].ToString();
      //  Debug.Log(PersistentData.singleton.realMadridScores[14].ToString());











    }
}
