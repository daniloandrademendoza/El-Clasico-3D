using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoccerBallScript : MonoBehaviour {
    public AudioClip goalClip;
    public AudioSource goalSoundSource;
    public Text fCBarcelonaScore;
    public Text realMadridScore;
   // private int fCBarcelonaGoals;
    //private int realMadridGoals;
    public Text halfTimeText2;
    private int halfTimeInt;
    private string playerName;
    private GameObject soccerPlayer;
    private string soccerBallString;
    private string[] playerNamesBarcelona = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };
    private string[] playerNamesRealMadrid = { "Isco", "Bale", "Benzema", "Modric", "Kroos", "Casemiro", "Marcelo", "Varane", "Ramos", "Carvajal", "Courtois" };
   // private string string0;
    // Use this for initialization
    void Start () {
        goalSoundSource.clip = goalClip;
      //  fCBarcelonaGoals = 0;
       // realMadridGoals = 0;
        halfTimeInt = 48;
        soccerBallString = " ";
        // string0 = "0";
        //  fCBarcelonaScore = string0;
        realMadridScore.text = PersistentData.singleton.realMadridGoals.ToString();
        fCBarcelonaScore.text = PersistentData.singleton.fCBarcelonaGoals.ToString();
        //realMadridScore=string0;
    }
	
	// Update is called once per frame
	//void Update () {
		void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "GoalLeft" && System.Convert.ToInt32(halfTimeText2.text)<halfTimeInt)
            {
                goalSoundSource.Play();
                PersistentData.singleton.realMadridGoals = PersistentData.singleton.realMadridGoals + 1;
                realMadridScore.text = PersistentData.singleton.realMadridGoals.ToString();
            fCBarcelonaScore.text = PersistentData.singleton.fCBarcelonaGoals.ToString();
            soccerBallString = "SoccerBall";
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            soccerBallString = playerNamesBarcelona[0]; // place Messi
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-7.7f, 0f, -41.1f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[1]; // place Suarez
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-9.3f, 0f, 29.3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[2]; // place Coutinho
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-52f, 0f, -147f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[3]; // place Rakitic
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-138f, 0f, -96f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[4]; // place Vidal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-157f, 0f, 135f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[5]; // place Sergio
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-202f, 0f, -4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[6]; // place Roberto
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-317f, 0f, -207f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[7]; // place Pique
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-324f, 0f, -106f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[8]; // place Umtiti
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-327.8f, 0f, 86.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[9]; // place Alba
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-355f, 0f, 203f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[10]; // place TerStegen
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-430.8f, 0f, 4.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[0]; // place Isco
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(131f, 0f, -5f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[1]; // place Bale
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(15.1f, 0f, 115.5f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[2]; // place Benzema
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(22.9f, 0f, -120.1f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[3]; // place Modric
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(161f, 0f, -116f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[4]; // place Kroos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(189f, 0f, 127f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[5]; // place Casemiro
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(218f, 0f, 3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[6]; // place Marcelo
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(327f, 0f, -208f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[7]; // place Varane
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(324f, 0f, -74f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[8]; // place Ramos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329f, 0f, 81f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[9]; // place Carvajal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(326f, 0f, 210f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[10]; // place Courtois
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(439.5f, 0f, 3.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

        }
            else if(collision.gameObject.name == "GoalRight" && System.Convert.ToInt32(halfTimeText2.text) < halfTimeInt)
            {
                goalSoundSource.Play();
            PersistentData.singleton.fCBarcelonaGoals = PersistentData.singleton.fCBarcelonaGoals + 1;
            fCBarcelonaScore.text = PersistentData.singleton.fCBarcelonaGoals.ToString();
            realMadridScore.text = PersistentData.singleton.realMadridGoals.ToString();
            soccerBallString = "SoccerBall";
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            soccerBallString = playerNamesBarcelona[0]; // place Messi
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-116f, 0f, 3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[1]; // place Suarez
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-47f, 0f, 114f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[2]; // place Coutinho
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-52f, 0f, -147f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[3]; // place Rakitic
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-138f, 0f, -96f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[4]; // place Vidal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-157f, 0f, 135f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[5]; // place Sergio
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-202f, 0f, -4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[6]; // place Roberto
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-317f, 0f, -207f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[7]; // place Pique
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-324f, 0f, -106f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[8]; // place Umtiti
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-327.8f, 0f, 86.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[9]; // place Alba
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-355f, 0f, 203f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesBarcelona[10]; // place TerStegen
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-430.8f, 0f, 4.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[0]; // place Isco
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(11.5f, 0f, -24.2f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[1]; // place Bale
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(11.5f, 0f, 36.2f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[2]; // place Benzema
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(22.9f, 0f, -120.1f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[3]; // place Modric
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(161f, 0f, -116f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[4]; // place Kroos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(189f, 0f, 127f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[5]; // place Casemiro
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(218f, 0f, 3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[6]; // place Marcelo
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(327f, 0f, -208f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[7]; // place Varane
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(324f, 0f, -74f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[8]; // place Ramos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329f, 0f, 81f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[9]; // place Carvajal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(326f, 0f, 210f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[10]; // place Courtois
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(439.5f, 0f, 3.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
            else if(collision.gameObject.name == "GoalLeft" && System.Convert.ToInt32(halfTimeText2.text) > halfTimeInt)
            {
                goalSoundSource.Play();
            PersistentData.singleton.fCBarcelonaGoals = PersistentData.singleton.fCBarcelonaGoals + 1;
            fCBarcelonaScore.text = PersistentData.singleton.fCBarcelonaGoals.ToString();
            realMadridScore.text = PersistentData.singleton.realMadridGoals.ToString();
            soccerBallString = "SoccerBall";
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            soccerBallString = playerNamesBarcelona[0]; // place Messi
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(132.5f, 0f, -5.9f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[1]; // place Suarez
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(17f, 0f, 115.3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[2]; // place Coutinho
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(24.8f, 0f, -121.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[3]; // place Rakitic
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(163.4f, 0f, -114.3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[4]; // place Vidal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(191f, 0f, 126.9f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[5]; // place Sergio
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(255f, 0f, 9f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[6]; // place Roberto
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329.2f, 0f, -207f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[7]; // place Pique
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(324.7f, 0f, -74.9f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[8]; // place Umtiti
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(332.7f, 0f, 83.5f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[9]; // place Alba
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329f, 0f, 212f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[10]; // place TerStegen
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[0]; // place Isco
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-6.2f, 0f, -40.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[1]; // place Bale
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-8f, 0f, 29.5f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[2]; // place Benzema
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-50.8f, 0f, -146.1f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[3]; // place Modric
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-137.4f, 0f, -95.7f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[4]; // place Kroos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-158.5f, 0f, 133.3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[5]; // place Casemiro
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-203f, 0f, -4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[6]; // place Marcelo
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-315.3f, 0f, -206f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[7]; // place Varane
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-322.9f, 0f, -104.7f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[8]; // place Ramos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-326.4f, 0f, 87.3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[9]; // place Carvajal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-354.3f, 0f, 203.1f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[10]; // place Courtois
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-428.6f, 0f, 5.5f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }   
            else if(collision.gameObject.name == "GoalRight" && System.Convert.ToInt32(halfTimeText2.text) > halfTimeInt)
            {
                goalSoundSource.Play();
            PersistentData.singleton.realMadridGoals = PersistentData.singleton.realMadridGoals + 1;
           realMadridScore.text = PersistentData.singleton.realMadridGoals.ToString();
            fCBarcelonaScore.text = PersistentData.singleton.fCBarcelonaGoals.ToString();
            soccerBallString = "SoccerBall";
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            soccerBallString = playerNamesBarcelona[0]; // place Messi
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(11f, 0f, -21f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[1]; // place Suarez
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(11.9f, 0f, 38.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[2]; // place Coutinho
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(24.8f, 0f, -121.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[3]; // place Rakitic
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(163.4f, 0f, -114.3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[4]; // place Vidal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(191f, 0f, 126.9f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[5]; // place Sergio
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(255f, 0f, 9f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[6]; // place Roberto
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329.2f, 0f, -207f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[7]; // place Pique
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(324.7f, 0f, -74.9f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[8]; // place Umtiti
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(332.7f, 0f, 83.5f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[9]; // place Alba
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(329f, 0f, 212f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesBarcelona[10]; // place TerStegen
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                soccerBallString = playerNamesRealMadrid[0]; // place Isco
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-110f, 0f, 0.5f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[1]; // place Bale
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-51.8f, 0f, 111.2f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[2]; // place Benzema
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-50.8f, 0f, -146.1f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[3]; // place Modric
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-137.4f, 0f, -95.7f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[4]; // place Kroos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-158.5f, 0f, 133.3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[5]; // place Casemiro
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-203f, 0f, -4f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[6]; // place Marcelo
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-315.3f, 0f, -206f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[7]; // place Varane
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-322.9f, 0f, -104.7f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[8]; // place Ramos
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-326.4f, 0f, 87.3f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[9]; // place Carvajal
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-354.3f, 0f, 203.1f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                soccerBallString = playerNamesRealMadrid[10]; // place Courtois
                soccerPlayer = GameObject.Find(soccerBallString);
                soccerPlayer.transform.position = new Vector3(-428.6f, 0f, 5.5f);
                soccerPlayer.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
        }
	//}
}
