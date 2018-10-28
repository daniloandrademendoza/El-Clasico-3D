using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCBarcelonaPlayerScript : MonoBehaviour {
    private float playerSpeed;
    private float soccerBallSpeed;
  //  private float soccerBallSpeedStop;
   // private float soccerBallMove;
    private string playerName;
    private string minName;
    private GameObject player;
    private GameObject player2;
    private Rigidbody theRB;
    private float minDistance;
    private string[] playerNamesBarcelona = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };
   // private int i;
    private float minXorZBetweenPlayers;
   // private bool done;
    // Use this for initialization
    void Start() {
        playerSpeed = 30f;
        soccerBallSpeed = 10f;
      //  soccerBallSpeedStop = 0f;
        theRB = GetComponent<Rigidbody>();
       // soccerBallMove = 10f;
        minDistance = 1000f;
        //i = 0;
        minXorZBetweenPlayers = 10f;
      //  done = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, 0f, playerSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            theRB.velocity = new Vector3(-playerSpeed, 0f, theRB.velocity.z);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, 0f, -playerSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            theRB.velocity = new Vector3(playerSpeed, 0f, theRB.velocity.z);
        }
        else
        {
            theRB.velocity = new Vector3(0f, 0f, 0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SoccerBall")
        {
            int k = 100;
            //for (int j = 0; j < 11; j++)
            //{
            //    if (this.gameObject.name == playerNamesBarcelona[j])
            //    {
            //        k = j;
            //    }
            //}
            //this.gameObject.name = playerNamesBarcelona[k];
            Rigidbody soccerBall = collision.gameObject.GetComponent<Rigidbody>();
            if (this.transform.position.z < collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < minXorZBetweenPlayers)//Right
            {
                for (int j = 0; j < 11; j++)
                {
                    if (this.gameObject.name == playerNamesBarcelona[j])
                    {
                        k = j;
                    }
                }
                this.gameObject.name = playerNamesBarcelona[k];
                if (Input.GetKey(KeyCode.Q))
                {
                    Debug.Log("Right");
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
                        player = GameObject.Find(playerName);
                        if (this.gameObject.name != playerName && this.transform.position.z < player.transform.position.z && Mathf.Abs(this.transform.position.x - player.transform.position.x) < minXorZBetweenPlayers && Mathf.Abs(this.transform.position.z - player.transform.position.z)< minDistance) //Right
                        {
                            minDistance = Mathf.Abs(this.transform.position.z - player.transform.position.z);
                            minName = playerName;
                            Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x, 4f, player2.transform.position.z - 10);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                }
                else
                {
                    soccerBall.AddForce(transform.forward * soccerBallSpeed, ForceMode.Impulse);
                }
            }

            else if (this.transform.position.z > collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < minXorZBetweenPlayers) // Left
            {
                for (int j = 0; j < 11; j++)
                {
                    if (this.gameObject.name == playerNamesBarcelona[j])
                    {
                        k = j;
                    }
                }
                this.gameObject.name = playerNamesBarcelona[k];
                if (Input.GetKey(KeyCode.Q))
                {
                    Debug.Log("Left");
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
                        player = GameObject.Find(playerName);
                        if (this.gameObject.name != playerName && this.transform.position.z > player.transform.position.z && Mathf.Abs(this.transform.position.x - player.transform.position.x) < minXorZBetweenPlayers && Mathf.Abs(this.transform.position.z - player.transform.position.z) < minDistance)//Left
                        {
                            minDistance = Mathf.Abs(this.transform.position.z - player.transform.position.z);
                            minName = playerName;
                            Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x, 4f, player2.transform.position.z + 10);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                }
                else
                {
                    soccerBall.AddForce(-transform.forward * soccerBallSpeed, ForceMode.Impulse);
                }

            }

            //else if (this.transform.position.z < collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < 50)
            //{
            //for (int j = 0; j < 11; j++)
            //{
            //    if (this.gameObject.name == playerNamesBarcelona[j])
            //    {
            //        k = j;
            //    }
            //}
            //this.gameObject.name = playerNamesBarcelona[k];
            //if (Input.GetKey(KeyCode.Q))
            //{

            //    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
            //    for (int i = 0; i < 11; i++)
            //    {

            //        playerName = playerNamesBarcelona[i];
            //        player = GameObject.Find(playerName);
            //        if (this.transform.position.x < player.transform.position.x && Mathf.Abs(this.transform.position.z - player.transform.position.z) < 50)
            //        {
            //            minName = playerName;
            //            Debug.Log(minName);
            //        }

            //    }
            //    playerName = "SoccerBall";
            //    player = GameObject.Find(playerName);
            //    player2 = GameObject.Find(minName);
            //    player.transform.position = new Vector3(player2.transform.position.x-10, 4f, player2.transform.position.z);
            //    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
            //}
            //else
            //    {
            //    soccerBall.AddForce(transform.right * soccerBallSpeed, ForceMode.Impulse);
            //    }

            //}
            //else if (this.transform.position.z > collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < 50)
            //{

            //    soccerBall.AddForce(-transform.right * soccerBallSpeed, ForceMode.Impulse);

            //}
            //else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
            //{

            //    soccerBall.AddForce((transform.right + transform.up) * soccerBallSpeed, ForceMode.Impulse);

            //}
            //else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
            //{

            //    soccerBall.AddForce((-transform.right + transform.up) * soccerBallSpeed, ForceMode.Impulse);

            //}
            //else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
            //{

            //    soccerBall.AddForce((- transform.up - transform.right) * soccerBallSpeed, ForceMode.Impulse);

            //}
            //else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
            //{

            //    soccerBall.AddForce((-transform.up + transform.right) * soccerBallSpeed, ForceMode.Impulse);

            //}
        }
        }
	}
