using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScipt : MonoBehaviour
{
    [SerializeField]
    private float fullTimeGame;
    private float fullTimeGamePlus;
    private float halfTimeGame;
    private float halfTimeGamePlus;
    private int minutesGame;
    private int secondsGame;
    public Text timeGame;
    private string[] playerNamesBarcelona = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };
    private string[] playerNamesRealMadrid = { "Isco", "Bale", "Benzema", "Modric", "Kroos", "Casemiro", "Marcelo", "Varane", "Ramos", "Carvajal", "Courtois" };
    private string soccerBallString;
    private GameObject soccerPlayer;
    public Text barcelonaScoreGame;
    public Text realMadridScoreGame;
    public int scoresNumber;
    public Text halfTimeTextGame;
    public bool gamePaused;
    private Scene currentScene;
    // Use this for initialization
    void Start()
    {
        halfTimeGame = 2880f;
        halfTimeGamePlus = 2900f;
        fullTimeGame = 5580f;
        fullTimeGamePlus = 5600f;
        minutesGame = 0;
        secondsGame = 0;
        scoresNumber = 0;
        soccerBallString = " ";
        gamePaused = false;
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene == SceneManager.GetSceneByName("GameScene"))
        {
            PersistentData.singleton.timeElapsedGame = PersistentData.singleton.timeElapsedGame + Time.smoothDeltaTime *(48 / 5); //400;//(48/5); //50
            minutesGame = Mathf.FloorToInt(PersistentData.singleton.timeElapsedGame / 60f);
            secondsGame = Mathf.FloorToInt(PersistentData.singleton.timeElapsedGame - minutesGame * 60);
            timeGame.text = string.Format("{0:0}:{1:00}", minutesGame, secondsGame);
            halfTimeTextGame.text = minutesGame.ToString();
        }
        if (PersistentData.singleton.timeElapsedGame >= halfTimeGame && PersistentData.singleton.timeElapsedGame < halfTimeGamePlus)
        {
            if (currentScene == SceneManager.GetSceneByName("GameScene"))
            {
                PersistentData.singleton.timeElapsedGame = PersistentData.singleton.timeElapsedGame + Time.smoothDeltaTime * (48 / 5);//400;//* (48 / 5);
                minutesGame = Mathf.FloorToInt(PersistentData.singleton.timeElapsedGame / 60f);
                secondsGame = Mathf.FloorToInt(PersistentData.singleton.timeElapsedGame - minutesGame * 60);
                timeGame.text = string.Format("{0:0}:{1:00}", minutesGame, secondsGame);
                halfTimeTextGame.text = minutesGame.ToString();
            }
            soccerBallString = "SoccerBall";
            soccerPlayer = GameObject.Find(soccerBallString);
            soccerPlayer.transform.position = new Vector3(0.11f, 4f, 1.03f);
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
        }
        else if (PersistentData.singleton.timeElapsedGame >= fullTimeGame && PersistentData.singleton.timeElapsedGame < fullTimeGamePlus)
        {
            if (currentScene == SceneManager.GetSceneByName("GameScene"))
            {
                PersistentData.singleton.timeElapsedGame = PersistentData.singleton.timeElapsedGame + Time.smoothDeltaTime * (48 / 5);//400;//* (48 / 5);
                minutesGame = Mathf.FloorToInt(PersistentData.singleton.timeElapsedGame / 60f);
                secondsGame = Mathf.FloorToInt(PersistentData.singleton.timeElapsedGame - minutesGame * 60);
                timeGame.text = string.Format("{0:0}:{1:00}", minutesGame, secondsGame);
                halfTimeTextGame.text = minutesGame.ToString();
            }
            PersistentData.singleton.fCBarcelonaGoals = System.Convert.ToInt32(barcelonaScoreGame.text);
            PersistentData.singleton.realMadridGoals = System.Convert.ToInt32(realMadridScoreGame.text);
            
                PersistentData.singleton.barcelonaScores[scoresNumber] = PersistentData.singleton.fCBarcelonaGoals;
                PersistentData.singleton.realMadridScores[scoresNumber] = PersistentData.singleton.realMadridGoals;
            
            if (PersistentData.singleton.fCBarcelonaGoals > PersistentData.singleton.realMadridGoals)
            {
               // SceneManager.LoadScene("FinalScoreScene");
                SceneManager.LoadScene("BarcelonaWonScene");
            }
            else if (PersistentData.singleton.realMadridGoals > PersistentData.singleton.fCBarcelonaGoals)
            {
                SceneManager.LoadScene("RealMadridWonScene");
            }
            else if (PersistentData.singleton.fCBarcelonaGoals == PersistentData.singleton.realMadridGoals)
            {
                SceneManager.LoadScene("TieScene");
            }

        }

    }
}

