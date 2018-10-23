using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoccerBallScript : MonoBehaviour {
    public AudioClip goalClip;
    public AudioSource goalSoundSource;
    public Text fCBarcelonaScore;
    public Text realMadridScore;
    private int fCBarcelonaGoals;
    private int realMadridGoals;
    public Text halfTimeText2;
    private int halfTimeInt;
    private string playerName;
    private GameObject soccerPlayer;
    private string soccerBallString;
    private string[] playerNamesBarcelona = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };
    private string[] playerNamesRealMadrid = { "Isco", "Bale", "Benzema", "Modric", "Kroos", "Casemiro", "Marcelo", "Varane", "Ramos", "Carvajal", "Courtois" };
    // Use this for initialization
    void Start () {
        goalSoundSource.clip = goalClip;
        fCBarcelonaGoals = 0;
        realMadridGoals = 0;
        halfTimeInt = 48;
        soccerBallString = " ";

	}
	
	// Update is called once per frame
	//void Update () {
		void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "GoalLeft" && System.Convert.ToInt32(halfTimeText2.text)<halfTimeInt)
            {
                goalSoundSource.Play();
                realMadridGoals = realMadridGoals + 1;
                realMadridScore.text = realMadridGoals.ToString();
                soccerBallString = "SoccerBall";
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
                soccerBallString = playerNamesBarcelona[0]; // place Messi
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-7.7f, 0f, -5.9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[1]; // place Suarez
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(17f, 0f, 115.3f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[2]; // place Coutinho
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(24.8f, 0f, -121.4f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[3]; // place Rakitic
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(163.4f, 0f, -114.3f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[4]; // place Vidal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(191f, 0f, 126.9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[5]; // place Sergio
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(255f, 0f, 9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[6]; // place Roberto
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329.2f, 0f, -207f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[7]; // place Pique
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(324.7f, 0f, -74.9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[8]; // place Umtiti
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(332.7f, 0f, 83.5f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[9]; // place Alba
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329f, 0f, 212f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[10]; // place TerStegen
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[0]; // place Isco
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-6.2f, 0f, -40.4f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[1]; // place Bale
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-8f, 0f, 29.5f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[2]; // place Benzema
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-50.8f, 0f, -146.1f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[3]; // place Modric
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-137.4f, 0f, -95.7f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[4]; // place Kroos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-158.5f, 0f, 133.3f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[5]; // place Casemiro
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-203f, 0f, -4f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[6]; // place Marcelo
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-315.3f, 0f, -206f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[7]; // place Varane
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-322.9f, 0f, -104.7f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[8]; // place Ramos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-326.4f, 0f, 87.3f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[9]; // place Carvajal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-354.3f, 0f, 203.1f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[10]; // place Courtois
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-428.6f, 0f, 5.5f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
        }
            else if(collision.gameObject.name == "GoalRight" && System.Convert.ToInt32(halfTimeText2.text) < halfTimeInt)
            {
                goalSoundSource.Play();
                fCBarcelonaGoals = fCBarcelonaGoals + 1;
                fCBarcelonaScore.text = fCBarcelonaGoals.ToString();
            }
            else if(collision.gameObject.name == "GoalLeft" && System.Convert.ToInt32(halfTimeText2.text) > halfTimeInt)
            {
                goalSoundSource.Play();
                fCBarcelonaGoals = fCBarcelonaGoals + 1;
                fCBarcelonaScore.text = fCBarcelonaGoals.ToString();
                soccerBallString = "SoccerBall";
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
                soccerBallString = playerNamesBarcelona[0]; // place Messi
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(132.5f, 0f, -5.9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[1]; // place Suarez
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(17f, 0f, 115.3f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[2]; // place Coutinho
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(24.8f, 0f, -121.4f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[3]; // place Rakitic
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(163.4f, 0f, -114.3f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[4]; // place Vidal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(191f, 0f, 126.9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[5]; // place Sergio
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(255f, 0f, 9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[6]; // place Roberto
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329.2f, 0f, -207f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[7]; // place Pique
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(324.7f, 0f, -74.9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[8]; // place Umtiti
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(332.7f, 0f, 83.5f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[9]; // place Alba
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329f, 0f, 212f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[10]; // place TerStegen
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[0]; // place Isco
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-6.2f, 0f, -40.4f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[1]; // place Bale
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-8f, 0f, 29.5f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[2]; // place Benzema
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-50.8f, 0f, -146.1f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[3]; // place Modric
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-137.4f, 0f, -95.7f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[4]; // place Kroos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-158.5f, 0f, 133.3f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[5]; // place Casemiro
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-203f, 0f, -4f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[6]; // place Marcelo
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-315.3f, 0f, -206f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[7]; // place Varane
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-322.9f, 0f, -104.7f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[8]; // place Ramos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-326.4f, 0f, 87.3f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[9]; // place Carvajal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-354.3f, 0f, 203.1f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[10]; // place Courtois
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-428.6f, 0f, 5.5f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
            }   
            else if(collision.gameObject.name == "GoalRight" && System.Convert.ToInt32(halfTimeText2.text) > halfTimeInt)
            {
                goalSoundSource.Play();
                realMadridGoals = realMadridGoals + 1;
                realMadridScore.text = realMadridGoals.ToString();
                soccerBallString = "SoccerBall";
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
                soccerBallString = playerNamesBarcelona[0]; // place Messi
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(11f, 0f, -21f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[1]; // place Suarez
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(11.9f, 0f, 38.4f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[2]; // place Coutinho
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(24.8f, 0f, -121.4f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[3]; // place Rakitic
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(163.4f, 0f, -114.3f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[4]; // place Vidal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(191f, 0f, 126.9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[5]; // place Sergio
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(255f, 0f, 9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[6]; // place Roberto
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329.2f, 0f, -207f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[7]; // place Pique
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(324.7f, 0f, -74.9f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[8]; // place Umtiti
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(332.7f, 0f, 83.5f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[9]; // place Alba
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329f, 0f, 212f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[10]; // place TerStegen
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f);
                soccerPlayer.transform.Rotate(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[0]; // place Isco
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-110f, 0f, 0.5f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[1]; // place Bale
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-51.8f, 0f, 111.2f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[2]; // place Benzema
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-50.8f, 0f, -146.1f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[3]; // place Modric
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-137.4f, 0f, -95.7f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[4]; // place Kroos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-158.5f, 0f, 133.3f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[5]; // place Casemiro
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-203f, 0f, -4f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[6]; // place Marcelo
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-315.3f, 0f, -206f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[7]; // place Varane
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-322.9f, 0f, -104.7f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[8]; // place Ramos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-326.4f, 0f, 87.3f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[9]; // place Carvajal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-354.3f, 0f, 203.1f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[10]; // place Courtois
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-428.6f, 0f, 5.5f);
                soccerPlayer.transform.Rotate(0f, -90f, 0f);
        }
        }
	//}
}
