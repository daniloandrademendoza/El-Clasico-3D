using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealMadridPlayerScript : MonoBehaviour {
    private float playerSpeedRM;
    private float soccerBallSpeed;
    private Rigidbody theRB;
    private string playerName;
    private string minName;
    private GameObject player;
    private GameObject player2;
    private GameObject realMadridPlayer;
    private GameObject barcelonaPlayer;
    private float minDistance;
    private string[] playerNamesRealMadrid = { "Isco", "Bale", "Benzema", "Modric", "Kroos", "Casemiro", "Marcelo", "Varane", "Ramos", "Carvajal", "Courtois" };
    private string[] playerNamesBarcelona = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };
    private float minXorZBetweenPlayers;
    private int playerRealMadridStringInt;
    public Text halfTimeText;
    private int halfTimeInt;
    // Use this for initialization
    void Start () {
        playerSpeedRM = 30f;
        soccerBallSpeed = .01f;
        theRB = GetComponent<Rigidbody>();
        minDistance = 1000f;
        minXorZBetweenPlayers = 5f;
        playerRealMadridStringInt = 0;
        halfTimeInt = 48;
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
                if (Input.GetKey(KeyCode.U))
                {
                    soccerBall.drag = 2;
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
                else if(Input.GetKey(KeyCode.O))
                {
                    soccerBall.drag = .0001f;
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
                if (Input.GetKey(KeyCode.U))
                {
                    soccerBall.drag = 2;
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
                else if(Input.GetKey(KeyCode.O))
                {
                    soccerBall.drag = .0001f;
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
                if (Input.GetKey(KeyCode.U))
                {
                    soccerBall.drag = 2;
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
                else if(Input.GetKey(KeyCode.O))
                {
                    soccerBall.drag = .0001f;
                    soccerBall.AddForce(transform.right * soccerBallSpeed, ForceMode.Impulse);
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
                if (Input.GetKey(KeyCode.U))
                {
                    soccerBall.drag = 2;
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
                else if(Input.GetKey(KeyCode.O))
                {
                    soccerBall.drag = .0001f;
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
                if (Input.GetKey(KeyCode.U))
                {
                    soccerBall.drag = 2;
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
                else if(Input.GetKey(KeyCode.O))
                {
                    soccerBall.drag = .0001f;
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
                if (Input.GetKey(KeyCode.U))
                {
                    soccerBall.drag = 2;
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
                else if(Input.GetKey(KeyCode.O))
                {
                    soccerBall.drag = .0001f;
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
                if (Input.GetKey(KeyCode.U))
                {
                    soccerBall.drag = 2;
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
                else if(Input.GetKey(KeyCode.O))
                {
                    soccerBall.drag = .0001f;
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
                if (Input.GetKey(KeyCode.U))
                {
                    soccerBall.drag = 2;
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
                else if(Input.GetKey(KeyCode.O))
                {
                    soccerBall.drag = .0001f;
                    soccerBall.AddForce((-transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                }
                else
                {
                    soccerBall.drag = 2;
                    soccerBall.AddForce((-transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                }
            }

            if (collision.gameObject.transform.position.x >= -437 && collision.gameObject.transform.position.x < -144.26 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                playerRealMadridStringInt = 9;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }

            }
            else if (collision.gameObject.transform.position.x >= -144.26 && collision.gameObject.transform.position.x < 148.46 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                //Debug.Log("In");
                playerRealMadridStringInt = 4;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        //  Debug.Log("In2");
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            else if (collision.gameObject.transform.position.x >= 148.46 && collision.gameObject.transform.position.x < 441.2 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                playerRealMadridStringInt = 1;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }

            else if (collision.gameObject.transform.position.x >= -437 && collision.gameObject.transform.position.x < -144.26 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                playerRealMadridStringInt = 6;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }

            }
            else if (collision.gameObject.transform.position.x >= -144.26 && collision.gameObject.transform.position.x < 148.46 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                //Debug.Log("In");
                playerRealMadridStringInt = 3;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        //  Debug.Log("In2");
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            else if (collision.gameObject.transform.position.x >= 148.46 && collision.gameObject.transform.position.x < 441.2 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                playerRealMadridStringInt = 2;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }


            if (collision.gameObject.transform.position.x >= -437 && collision.gameObject.transform.position.x < -144.26 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                playerRealMadridStringInt = 1;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }

            }
            else if (collision.gameObject.transform.position.x >= -144.26 && collision.gameObject.transform.position.x < 148.46 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                //Debug.Log("In");
                playerRealMadridStringInt = 4;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        //  Debug.Log("In2");
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            else if (collision.gameObject.transform.position.x >= 148.46 && collision.gameObject.transform.position.x < 441.2 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                playerRealMadridStringInt = 9;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }

            else if (collision.gameObject.transform.position.x >= -437 && collision.gameObject.transform.position.x < -144.26 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                playerRealMadridStringInt = 2;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }

            }
            else if (collision.gameObject.transform.position.x >= -144.26 && collision.gameObject.transform.position.x < 148.46 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                //Debug.Log("In");
                playerRealMadridStringInt = 3;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        //  Debug.Log("In2");
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            else if (collision.gameObject.transform.position.x >= 148.46 && collision.gameObject.transform.position.x < 441.2 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                playerRealMadridStringInt = 6;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesBarcelona[a]);
                        realMadridPlayer.GetComponent<FCBarcelonaPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }

            if ((((collision.gameObject.transform.position.x <= -445) && (collision.gameObject.transform.position.z <= -45 && collision.gameObject.transform.position.z >= -232.7)) || ((collision.gameObject.transform.position.x <= -445) && (collision.gameObject.transform.position.z <= 235.83 && collision.gameObject.transform.position.z >= 48.71))) && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                collision.gameObject.transform.position = new Vector3(-394.5f, 4f, -68.3f); //
                collision.gameObject.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[0]);
                barcelonaPlayer.transform.position = new Vector3(293f, 0f, 11f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[1]);
                barcelonaPlayer.transform.position = new Vector3(278f, 0f, 163f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[2]);
                barcelonaPlayer.transform.position = new Vector3(278f, 0f, -138f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[3]);
                barcelonaPlayer.transform.position = new Vector3(32f, 0f, -134f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[4]);
                barcelonaPlayer.transform.position = new Vector3(31f, 0f, 148f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[5]);
                barcelonaPlayer.transform.position = new Vector3(-136f, 0f, 3f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[6]);
                barcelonaPlayer.transform.position = new Vector3(-317f, 0f, -207f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[7]);
                barcelonaPlayer.transform.position = new Vector3(-245f, 0f, -86f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[8]);
                barcelonaPlayer.transform.position = new Vector3(-245f, 0f, 106f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[9]);
                barcelonaPlayer.transform.position = new Vector3(-355f, 0f, 203f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[10]);
                barcelonaPlayer.transform.position = new Vector3(-406.8f, 0f, -70f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[0]);
                realMadridPlayer.transform.position = new Vector3(-222.2f, 0f, 37.8f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[1]);
                realMadridPlayer.transform.position = new Vector3(-228f, 0f, 160f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[2]);
                realMadridPlayer.transform.position = new Vector3(-231f, 0f, -121f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[3]);
                realMadridPlayer.transform.position = new Vector3(61f, 0f, -116f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[4]);
                realMadridPlayer.transform.position = new Vector3(57f, 0f, 141f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[5]);
                realMadridPlayer.transform.position = new Vector3(-32f, 0f, 4f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[6]);
                realMadridPlayer.transform.position = new Vector3(327f, 0f, -208f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[7]);
                realMadridPlayer.transform.position = new Vector3(324f, 0f, -74f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[8]);
                realMadridPlayer.transform.position = new Vector3(329f, 0f, 81f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[9]);
                realMadridPlayer.transform.position = new Vector3(326f, 0f, 210f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[10]);
                realMadridPlayer.transform.position = new Vector3(439.5f, 0f, 3.4f);//


            }


        }
    }
}
