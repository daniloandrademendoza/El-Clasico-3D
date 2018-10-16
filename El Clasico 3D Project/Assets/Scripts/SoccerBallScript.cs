using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoccerBallScript : MonoBehaviour {
    public AudioClip goalClip;
    public AudioSource goalSoundSource;
    public Text fCBarcelonaScore;
    public Text realMadridScore;
    public int fCBarcelonaGoals;
    public int realMadridGoals;
    public Text halfTimeText2;
    public int halfTimeInt;
    private string playerName;
    private GameObject player;
	// Use this for initialization
	void Start () {
        goalSoundSource.clip = goalClip;
        fCBarcelonaGoals = 0;
        realMadridGoals = 0;
        halfTimeInt = 48;

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

            }
        }
	//}
}
