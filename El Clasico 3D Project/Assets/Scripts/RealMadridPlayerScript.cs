using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMadridPlayerScript : MonoBehaviour {
    private float playerSpeedRM;
    private float soccerBallSpeed;
    private Rigidbody theRB;
    private string playerName;
    private string minName;
    private GameObject player;
    private GameObject player2;
    private float minDistance;
    private string[] playerNamesRealMadrid = { "Isco", "Bale", "Benzema", "Modric", "Kroos", "Casemiro", "Marcelo", "Varane", "Ramos", "Carvajal", "Courtois" };
    private float minXorZBetweenPlayers;
    // Use this for initialization
	void Start () {
        playerSpeedRM = 30f;
        soccerBallSpeed = .01f;
        theRB = GetComponent<Rigidbody>();
        minDistance = 1000f;
        minXorZBetweenPlayers = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.I))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, 0f, playerSpeedRM);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            theRB.velocity = new Vector3(-playerSpeedRM, 0f, theRB.velocity.z);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, 0f, -playerSpeedRM);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            theRB.velocity = new Vector3(playerSpeedRM, 0f, theRB.velocity.z);
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
           // Debug.Log("Collided with Soccer Ball");
            Rigidbody soccerBall = collision.gameObject.GetComponent<Rigidbody>();
            Rigidbody playerRigidBody = this.GetComponent<Rigidbody>();
            if (this.transform.position.z < collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < minXorZBetweenPlayers)//Up
            {
                minDistance = 1000f;
                //for (int j = 0; j < 11; j++)
                //{
                //    if (this.gameObject.name == playerNamesBarcelona[j])
                //    {
                //        k = j;
                //    }
                //}
                //this.gameObject.name = playerNamesBarcelona[k];
                if (Input.GetKey(KeyCode.O))
                {
                   // Debug.Log(this.gameObject.name);
                    // Debug.Log("Up");
                    //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    // this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesRealMadrid[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.z < player.transform.position.z && Mathf.Abs(this.transform.position.x - player.transform.position.x) < minXorZBetweenPlayers && Mathf.Abs(this.transform.position.z - player.transform.position.z) < minDistance) //Right
                        {
                            //Debug.Log("In");
                            //this.gameObject.name != playerName
                            minDistance = Mathf.Abs(this.transform.position.z - player.transform.position.z);
                            minName = playerName;
                            //  Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x, 4f, player2.transform.position.z - 20);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<RealMadridPlayerScript>().enabled = false;
                    //Debug.Log(this.gameObject.name);
                    player2.GetComponent<RealMadridPlayerScript>().enabled = true;
                  //  Debug.Log(player2.name);
                }
                else
                {
                    soccerBall.AddForce(transform.forward * soccerBallSpeed, ForceMode.Impulse);
                }
            }

            else if (this.transform.position.z > collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < minXorZBetweenPlayers) // Left
            {
                minDistance = 1000f;
                //for (int j = 0; j < 11; j++)
                //{
                //    if (this.gameObject.name == playerNamesBarcelona[j])
                //    {
                //        k = j;
                //    }
                //}
                //this.gameObject.name = playerNamesBarcelona[k];
                if (Input.GetKey(KeyCode.O))
                {
                    //Debug.Log("Down");
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    //this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesRealMadrid[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.z > player.transform.position.z && Mathf.Abs(this.transform.position.x - player.transform.position.x) < minXorZBetweenPlayers && Mathf.Abs(this.transform.position.z - player.transform.position.z) < minDistance)//Left
                        {
                            //this.gameObject.name != playerName
                            minDistance = Mathf.Abs(this.transform.position.z - player.transform.position.z);
                            minName = playerName;
                            //  Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x, 4f, player2.transform.position.z + 20);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<RealMadridPlayerScript>().enabled = false;
                    player2.GetComponent<RealMadridPlayerScript>().enabled = true;
                }
                else
                {
                    soccerBall.AddForce(-transform.forward * soccerBallSpeed, ForceMode.Impulse);
                }

            }

            else if (this.transform.position.x < collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z) < minXorZBetweenPlayers)
            {
                minDistance = 1000f;
                //for (int j = 0; j < 11; j++)
                //{
                //    if (this.gameObject.name == playerNamesBarcelona[j])
                //    {
                //        k = j;
                //    }
                //}
                //this.gameObject.name = playerNamesBarcelona[k];
                if (Input.GetKey(KeyCode.O))
                {
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    // this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesRealMadrid[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.x < player.transform.position.x && Mathf.Abs(this.transform.position.z - player.transform.position.z) < minXorZBetweenPlayers && Mathf.Abs(this.transform.position.x - player.transform.position.x) < minDistance)
                        {
                            //this.gameObject.name != playerName
                            minDistance = Mathf.Abs(this.transform.position.x - player.transform.position.x);
                            minName = playerName;
                            //Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x - 20, 4f, player2.transform.position.z);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    //  Debug.Log(this.gameObject.name);
                    this.GetComponent<RealMadridPlayerScript>().enabled = false;
                    // Debug.Log(player2.name);
                    player2.GetComponent<RealMadridPlayerScript>().enabled = true;
                    //   Debug.Log("enabled");
                }
                else
                {
                    soccerBall.AddForce(transform.right * soccerBallSpeed, ForceMode.Impulse);
                }

            }

            else if (this.transform.position.x > collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z) < minXorZBetweenPlayers)
            {
                minDistance = 1000f;
                if (Input.GetKey(KeyCode.O))
                {
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    // this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesRealMadrid[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.x > player.transform.position.x && Mathf.Abs(this.transform.position.z - player.transform.position.z) < minXorZBetweenPlayers && Mathf.Abs(this.transform.position.x - player.transform.position.x) < minDistance)
                        {
                            //this.gameObject.name != playerName
                            minDistance = Mathf.Abs(this.transform.position.x - player.transform.position.x);
                            minName = playerName;
                            //Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x + 20, 4f, player2.transform.position.z);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<RealMadridPlayerScript>().enabled = false;
                    // Debug.Log(this.gameObject.name);
                    player2.GetComponent<RealMadridPlayerScript>().enabled = true;
                    //Debug.Log(player2.name);
                }
                else
                {
                    soccerBall.AddForce(-transform.right * soccerBallSpeed, ForceMode.Impulse);
                }
            }
            else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
            {
                minDistance = 1000f;
                if (Input.GetKey(KeyCode.O))
                {
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    // this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesRealMadrid[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.x < player.transform.position.x && this.transform.position.z < player.transform.position.z && Mathf.Sqrt(((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x)) + ((player.transform.position.z - this.transform.position.z) * (player.transform.position.z - this.transform.position.z))) < minDistance)
                        {
                            //this.gameObject.name != playerName
                            minDistance = Mathf.Sqrt(((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x)) + ((player.transform.position.z - this.transform.position.z) * (player.transform.position.z - this.transform.position.z)));

                            minName = playerName;
                            //Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x - 20, 4f, player2.transform.position.z - 20);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<RealMadridPlayerScript>().enabled = false;
                    // Debug.Log(this.gameObject.name);
                    player2.GetComponent<RealMadridPlayerScript>().enabled = true;
                    // Debug.Log(player2.name);
                }
                else
                {
                    soccerBall.AddForce((transform.right + transform.forward) * soccerBallSpeed, ForceMode.Impulse);
                }
            }
            else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
            {
                minDistance = 1000f;
                if (Input.GetKey(KeyCode.O))
                {
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesRealMadrid[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.x < player.transform.position.x && this.transform.position.z > player.transform.position.z && Mathf.Sqrt(((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x)) + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) < minDistance)
                        {
                            //this.gameObject.name != playerName
                            minDistance = Mathf.Sqrt(((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x)) + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z)));
                            minName = playerName;
                            //Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x - 20, 4f, player2.transform.position.z - 20);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<RealMadridPlayerScript>().enabled = false;
                    //  Debug.Log(this.gameObject.name);
                    player2.GetComponent<RealMadridPlayerScript>().enabled = true;
                    //  Debug.Log(player2.name);
                }
                else
                {
                    soccerBall.AddForce((transform.right - transform.forward) * soccerBallSpeed, ForceMode.Impulse);
                }
            }
            else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
            {

                minDistance = 1000f;
                if (Input.GetKey(KeyCode.O))
                {
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesRealMadrid[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.x > player.transform.position.x && this.transform.position.z < player.transform.position.z && Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x)) + ((player.transform.position.z - this.transform.position.z) * (player.transform.position.z - this.transform.position.z))) < minDistance)
                        {
                            //this.gameObject.name != playerName
                            minDistance = Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x)) + ((player.transform.position.z - this.transform.position.z) * (player.transform.position.z - this.transform.position.z)));
                            minName = playerName;
                            //Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x - 20, 4f, player2.transform.position.z - 20);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<RealMadridPlayerScript>().enabled = false;
                    //  Debug.Log(this.gameObject.name);
                    player2.GetComponent<RealMadridPlayerScript>().enabled = true;
                    //  Debug.Log(player2.name);
                }

                else
                {
                    soccerBall.AddForce((transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                }
            }
            else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
            {
                minDistance = 1000f;
                if (Input.GetKey(KeyCode.O))
                {
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesRealMadrid[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.x > player.transform.position.x && this.transform.position.z > player.transform.position.z && Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x)) + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) < minDistance)
                        {
                            //this.gameObject.name != playerName
                            minDistance = Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x)) + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z)));
                            minName = playerName;
                            //Debug.Log(minName);
                        }

                    }
                    playerName = "SoccerBall";
                    player = GameObject.Find(playerName);
                    player2 = GameObject.Find(minName);
                    player.transform.position = new Vector3(player2.transform.position.x + 20, 4f, player2.transform.position.z + 20);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<RealMadridPlayerScript>().enabled = false;
                    //  Debug.Log(this.gameObject.name);
                    player2.GetComponent<RealMadridPlayerScript>().enabled = true;
                    //  Debug.Log(player2.name);
                }
                else
                {
                    soccerBall.AddForce((-transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                }
            }
        }
    }
}
