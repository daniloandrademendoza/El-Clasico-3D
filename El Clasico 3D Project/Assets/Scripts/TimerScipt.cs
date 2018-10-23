using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScipt : MonoBehaviour {
    [SerializeField]
    private float fullTimeGame;
    private float fullTimeGamePlus;
    private float halfTimeGame;
    private float halfTimeGamePlus;
    private int minutesGame;
    private int secondsGame;
    private float timeElapsedGame;
    public Text timeGame;
    private string[] playerNamesBarcelona = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };
    private string[] playerNamesRealMadrid = { "Isco", "Bale", "Benzema", "Modric", "Kroos", "Casemiro", "Marcelo", "Varane", "Ramos", "Carvajal", "Courtois" };
    private string soccerBallString;
    private GameObject soccerPlayer;
    public Text barcelonaScoreGame;
    public Text realMadridScoreGame;
    private int barcelonaGoalsGame;
    private int realMadridGoalsGame;
    public Text halfTimeTextGame;
    // Use this for initialization
    void Start () {
        timeElapsedGame = 0f;
        halfTimeGame = 2880f;
        halfTimeGamePlus = 2900f;
        fullTimeGame = 5580f;
        minutesGame = 0;
        secondsGame = 0;
        barcelonaGoalsGame = 0;
        realMadridGoalsGame = 0;
        soccerBallString = " ";
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsedGame = timeElapsedGame + Time.smoothDeltaTime * 50;
        minutesGame = Mathf.FloorToInt(timeElapsedGame / 60f);
        secondsGame = Mathf.FloorToInt(timeElapsedGame - minutesGame * 60);
        timeGame.text = string.Format("{0:0}:{1:00}", minutesGame, secondsGame);
        halfTimeTextGame.text = minutesGame.ToString();
        if (timeElapsedGame >= halfTimeGame && timeElapsedGame < halfTimeGamePlus)
        {
            timeElapsedGame = timeElapsedGame + Time.smoothDeltaTime * 50;
            minutesGame = Mathf.FloorToInt(timeElapsedGame / 60f);
            secondsGame = Mathf.FloorToInt(timeElapsedGame - minutesGame * 60);
            timeGame.text = string.Format("{0:0}:{1:00}", minutesGame, secondsGame);
            halfTimeTextGame.text = minutesGame.ToString();
            soccerBallString = "SoccerBall";
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
            soccerBallString = playerNamesRealMadrid[0]; // move Isco
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(200f, 200f, 200f);
            soccerBallString = playerNamesBarcelona[0]; // place Messi
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(132.5f, 0f, -5.9f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[1]; // move Bale
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(300f, 300f, 300f);
            soccerBallString = playerNamesBarcelona[1]; // place Suarez
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(17f, 0f, 115.3f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[2]; // move Benzema
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(400f, 400f, 400f);
            soccerBallString = playerNamesBarcelona[2]; // place Coutinho
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(24.8f, 0f, -121.4f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[3]; // move Modric
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(500f, 500f, 500f);
            soccerBallString = playerNamesBarcelona[3]; // place Rakitic
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(163.4f, 0f, -114.3f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[4]; // move Kroos
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(600f, 600f, 600f);
            soccerBallString = playerNamesBarcelona[4]; // place Vidal
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(191f, 0f, 126.9f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[5]; // move Casemiro
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(700f, 700f, 700f);
            soccerBallString = playerNamesBarcelona[5]; // place Sergio
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(255f, 0f, 9f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[6]; // move Marcelo
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(800f, 800f, 800f);
            soccerBallString = playerNamesBarcelona[6]; // place Roberto
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(329.2f, 0f, -207f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[7]; // move Varane
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(900f, 900f, 900f);
            soccerBallString = playerNamesBarcelona[7]; // place Pique
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(324.7f, 0f, -74.9f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[8]; // move Ramos
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(1000f, 1000f, 1000f);
            soccerBallString = playerNamesBarcelona[8]; // place Umtiti
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(332.7f, 0f, 83.5f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[9]; // move Carvajal
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(1100f, 1100f, 1100f);
            soccerBallString = playerNamesBarcelona[9]; // place Alba
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(329f, 0f, 212f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[10]; // move Courtois
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(1200f, 1200f, 1200f);
            soccerBallString = playerNamesBarcelona[10]; // place TerStegen
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f);
            soccerPlayer.transform.Rotate(0f, -90f, 0f);
            soccerBallString = playerNamesRealMadrid[0]; // place Isco
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-6.2f, 0f, -40.4f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[1]; // place Bale
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-8f, 0f, 29.5f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[2]; // place Benzema
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-50.8f, 0f, -146.1f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[3]; // place Modric
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-137.4f, 0f, -95.7f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[4]; // place Kroos
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-158.5f, 0f, 133.3f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[5]; // place Casemiro
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-203f, 0f, -4f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[6]; // place Marcelo
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-315.3f, 0f, -206f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[7]; // place Varane
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-322.9f, 0f, -104.7f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[8]; // place Ramos
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-326.4f, 0f, 87.3f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[9]; // place Carvajal
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-354.3f, 0f, 203.1f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
            soccerBallString = playerNamesRealMadrid[10]; // place Courtois
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(-428.6f, 0f, 5.5f);
            soccerPlayer.transform.Rotate(0f, 90f, 0f);
        }
        else if (timeElapsedGame >= fullTimeGame && timeElapsedGame < fullTimeGamePlus)
        {
            timeElapsedGame = timeElapsedGame + Time.smoothDeltaTime * 50;
            minutesGame = Mathf.FloorToInt(timeElapsedGame / 60f);
            secondsGame = Mathf.FloorToInt(timeElapsedGame - minutesGame * 60);
            timeGame.text = string.Format("{0:0}:{1:00}", minutesGame, secondsGame);
            halfTimeTextGame.text = minutesGame.ToString();
            barcelonaGoalsGame = System.Convert.ToInt32(barcelonaScoreGame.text);
            realMadridGoalsGame = System.Convert.ToInt32(realMadridScoreGame.text);
            if (barcelonaGoalsGame > realMadridGoalsGame)
            {
                SceneManager.LoadScene("FCBarcelonaWon");
            }
            else if (realMadridGoalsGame > barcelonaGoalsGame)
            {
                SceneManager.LoadScene("RealMadridWon");
            }
            else if (barcelonaGoalsGame == realMadridGoalsGame)
            {
                SceneManager.LoadScene("Tied");
            }

        }
       
	}
}
