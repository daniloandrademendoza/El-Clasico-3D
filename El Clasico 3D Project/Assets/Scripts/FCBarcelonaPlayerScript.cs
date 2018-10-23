using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCBarcelonaPlayerScript : MonoBehaviour {
    private float playerSpeed;
    private float soccerBallSpeed;
    private float soccerBallSpeedStop;
    private float soccerBallMove;
    private string playerName;
     private string minName;
    private GameObject player;
    private GameObject player2;
    private Rigidbody theRB;
     private double minDistance;
    private string[] playerNamesBarcelona = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };

    // Use this for initialization
    void Start () {
        playerSpeed = 50f;
        soccerBallSpeed = 20f;
        soccerBallSpeedStop = 0f;
        theRB = GetComponent<Rigidbody>();
        soccerBallMove = 10f;
        minDistance = 1000f;
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
            if(collision.gameObject.name == "SoccerBall")
            {
           
                Rigidbody soccerBall = collision.gameObject.GetComponent<Rigidbody>();
                if(this.transform.position.x < collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z)<50)
                {
                Debug.Log("IN1");
                if (Input.GetKeyDown(KeyCode.Q))
                     {
                    Debug.Log("IN");
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 1; i < 11; i++)
                    {
                        playerName = playerNamesBarcelona[i];
                        player = GameObject.Find(playerName);
                        if (System.Math.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.z - player.transform.position.z, 2)) < minDistance && this.transform.position.x < player.transform.position.x && Mathf.Abs(this.transform.position.z - player.transform.position.z) < 50)
                        {
                            minDistance = System.Math.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.z - player.transform.position.z, 2));
                            minName = playerName;
                        }
                        else
                        {
                            player.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                        }
                    }
                    playerName = "Soccer Ball";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x - 1, 0f, player2.transform.position.z);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                     }
                    else
                    {
                        soccerBall.AddForce(transform.up * soccerBallSpeed, ForceMode.Impulse);
                    }
                }
                else if (this.transform.position.x > collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z) < 50)
                {
                  
                    soccerBall.AddForce(-transform.up * soccerBallSpeed, ForceMode.Impulse);
             
                }
                else if (this.transform.position.z < collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < 50)
                {
                  
                    soccerBall.AddForce(transform.right * soccerBallSpeed, ForceMode.Impulse);
              
                }
                else if (this.transform.position.z > collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < 50)
                {
                 
                    soccerBall.AddForce(-transform.right * soccerBallSpeed, ForceMode.Impulse);
         
                }
                else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
                {
                   
                    soccerBall.AddForce((transform.right + transform.up) * soccerBallSpeed, ForceMode.Impulse);
             
                }
                else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
                {
                  
                    soccerBall.AddForce((-transform.right + transform.up) * soccerBallSpeed, ForceMode.Impulse);

                }
                else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
                {
                 
                    soccerBall.AddForce((- transform.up - transform.right) * soccerBallSpeed, ForceMode.Impulse);
            
                }
                else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
                {
                   
                    soccerBall.AddForce((-transform.up + transform.right) * soccerBallSpeed, ForceMode.Impulse);

                }
            }
        }
	}
