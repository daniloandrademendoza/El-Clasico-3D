using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCBarcelonaPlayerScript : MonoBehaviour {
    private float playerSpeed;
    private float soccerBallSpeed;
    private float shootSoccerBall;
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
    //Rigidbody playerRigidBody;
    // private bool done;
    // Use this for initialization
    void Start() {
        playerSpeed = 30f;
        soccerBallSpeed = .01f;
      //  soccerBallSpeedStop = 0f;
        theRB = GetComponent<Rigidbody>();
       // soccerBallMove = 10f;
        minDistance = 1000f;
        //i = 0;
        minXorZBetweenPlayers = 5f;
        shootSoccerBall = 30f;
       // playerRigidBody = this.GetComponent<Rigidbody>();
        //  done = false;
    }

    // Update is called once per frame
    void Update() {
       // Debug.Log(this.gameObject.name);
        if (Input.GetKey(KeyCode.W))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, 0f, playerSpeed);
           // Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            theRB.velocity = new Vector3(-playerSpeed, 0f, theRB.velocity.z);
           // Debug.Log("A");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, 0f, -playerSpeed);
           // Debug.Log("S");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            theRB.velocity = new Vector3(playerSpeed, 0f, theRB.velocity.z);
           // Debug.Log("D");
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
           // int k = 100;
            //for (int j = 0; j < 11; j++)
            //{
            //    if (this.gameObject.name == playerNamesBarcelona[j])
            //    {
            //        k = j;
            //    }
            //}
            //this.gameObject.name = playerNamesBarcelona[k];
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
                if (Input.GetKey(KeyCode.Q))
                {
                    soccerBall.drag = 2;
                   // Debug.Log("Up");
                   //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                   playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    // this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
                        player = GameObject.Find(playerName);
                        if (this.transform.position.z < player.transform.position.z && Mathf.Abs(this.transform.position.x - player.transform.position.x) < minXorZBetweenPlayers && Mathf.Abs(this.transform.position.z - player.transform.position.z) < minDistance) //Right
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
                    player.transform.position = new Vector3(player2.transform.position.x, 4f, player2.transform.position.z - 20);
                    playerRigidBody.constraints = RigidbodyConstraints.None;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                }
                else if(Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.0001f;
                    soccerBall.AddForce(transform.forward * soccerBallSpeed, ForceMode.Impulse);
                   
                }
                else
                {
                    soccerBall.drag = 2;
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
                if (Input.GetKey(KeyCode.Q))
                {
                    soccerBall.drag = 2;
                    //Debug.Log("Down");
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    //this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
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
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.0001f;
                    soccerBall.AddForce(-transform.forward * soccerBallSpeed, ForceMode.Impulse);
                   
                }
                else
                {
                    soccerBall.drag = 2;
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
                if (Input.GetKey(KeyCode.Q))
                {
                    soccerBall.drag = 2;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    // this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
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
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    // Debug.Log(player2.name);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                    //   Debug.Log("enabled");
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.0001f;
                    Debug.Log(soccerBall.drag);
                    soccerBall.AddForce(transform.right * soccerBallSpeed, ForceMode.Impulse);
                   
                    Debug.Log(soccerBall.drag);
                }
                else
                {
                    soccerBall.drag = 2;
                    soccerBall.AddForce(transform.right * soccerBallSpeed, ForceMode.Impulse);
                }

            }

            else if (this.transform.position.x > collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z) < minXorZBetweenPlayers)
            {
                minDistance = 1000f;
                if (Input.GetKey(KeyCode.Q))
                {
                    soccerBall.drag = 2;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    // this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
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
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    // Debug.Log(this.gameObject.name);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                    //Debug.Log(player2.name);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.0001f;
                    soccerBall.AddForce(-transform.right * soccerBallSpeed, ForceMode.Impulse);
                    
                }
                else
                {
                    soccerBall.drag = 2;
                    soccerBall.AddForce(-transform.right * soccerBallSpeed, ForceMode.Impulse);
                }
            }
            else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
            {
                minDistance = 1000f;
                if (Input.GetKey(KeyCode.Q))
                {
                    soccerBall.drag = 2;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    // this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
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
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    // Debug.Log(this.gameObject.name);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                    // Debug.Log(player2.name);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.0001f;
                    soccerBall.AddForce((transform.right + transform.forward) * soccerBallSpeed, ForceMode.Impulse);
                   
                }
                else
                {
                    soccerBall.drag = 2;
                    soccerBall.AddForce((transform.right + transform.forward) * soccerBallSpeed, ForceMode.Impulse);
                }
            }
            else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
            {
                minDistance = 1000f;
                if (Input.GetKey(KeyCode.Q))
                {
                    soccerBall.drag = 2;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
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
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    //  Debug.Log(this.gameObject.name);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                    //  Debug.Log(player2.name);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.0001f;
                    soccerBall.AddForce((transform.right - transform.forward) * soccerBallSpeed, ForceMode.Impulse);
                    
                }

                else
                {
                    soccerBall.drag = 2;
                    soccerBall.AddForce((transform.right - transform.forward) * soccerBallSpeed, ForceMode.Impulse);
                }
            }
            else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
            {

                minDistance = 1000f;
                if (Input.GetKey(KeyCode.Q))
                {
                    soccerBall.drag = 2;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
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
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    //  Debug.Log(this.gameObject.name);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                    //  Debug.Log(player2.name);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.0001f;
                    soccerBall.AddForce((transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                    
                }
                else
                {
                    soccerBall.drag = 2;
                    soccerBall.AddForce((transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                }
            }
            else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
            {
                minDistance = 1000f;
                if (Input.GetKey(KeyCode.Q))
                {
                    soccerBall.drag = 2;
                    playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    for (int i = 0; i < 11; i++)
                    {

                        playerName = playerNamesBarcelona[i];
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
                    this.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    //  Debug.Log(this.gameObject.name);
                    player2.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                    //  Debug.Log(player2.name);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.00001f;
                    soccerBall.AddForce((-transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                    
                }
                else
                {
                    soccerBall.drag = 2f;
                    soccerBall.AddForce((-transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                }
            }
        }
        }
	}
