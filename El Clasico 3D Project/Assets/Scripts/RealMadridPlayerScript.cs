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
        playerSpeedRM = 100f;
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

            if ((((collision.gameObject.transform.position.x <= -445f) && (collision.gameObject.transform.position.z <= -45f && collision.gameObject.transform.position.z >= -232.7f)) || ((collision.gameObject.transform.position.x <= -445f) && (collision.gameObject.transform.position.z <= 235.83f && collision.gameObject.transform.position.z >= 48.71f))) && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                collision.gameObject.transform.position = new Vector3(-394.5f, 4f, -68.3f); //
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
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
            else if ((((collision.gameObject.transform.position.x >= 445f) && (collision.gameObject.transform.position.z <= -43.8f && collision.gameObject.transform.position.z >= -230.5f)) || ((collision.gameObject.transform.position.x >= 445f) && (collision.gameObject.transform.position.z <= 235.9f && collision.gameObject.transform.position.z >= 51.1f))) && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                collision.gameObject.transform.position = new Vector3(375.7f, 4f, 52.5f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[0]);
                barcelonaPlayer.transform.position = new Vector3(360.6f, 0f, 49.4f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[1]);
                barcelonaPlayer.transform.position = new Vector3(370f, 0f, 111f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[2]);
                barcelonaPlayer.transform.position = new Vector3(372.6f, 0f, -26f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[3]);
                barcelonaPlayer.transform.position = new Vector3(374f, 0f, -101f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[4]);
                barcelonaPlayer.transform.position = new Vector3(278f, 0f, 111f); // 
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[5]);
                barcelonaPlayer.transform.position = new Vector3(257f, 0f, 2f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[6]);
                barcelonaPlayer.transform.position = new Vector3(232f, 0f, -95f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[7]);
                barcelonaPlayer.transform.position = new Vector3(-20f, 0f, 1f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[8]);
                barcelonaPlayer.transform.position = new Vector3(146f, 0f, 62f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[9]);
                barcelonaPlayer.transform.position = new Vector3(181f, 0f, 142f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[10]);
                barcelonaPlayer.transform.position = new Vector3(-432.6f, 0f, 3.6f); //
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[0]);
                realMadridPlayer.transform.position = new Vector3(42f, 0f, -1f); //
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[1]);
                realMadridPlayer.transform.position = new Vector3(216.6f, 0f, 145f); //
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[2]);
                realMadridPlayer.transform.position = new Vector3(185f, 0f, 71f); //
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[3]);
                realMadridPlayer.transform.position = new Vector3(267f, 0f, -83f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[4]);
                realMadridPlayer.transform.position = new Vector3(304f, 0f, 110f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[5]);
                realMadridPlayer.transform.position = new Vector3(293f, 0f, 1f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[6]);
                realMadridPlayer.transform.position = new Vector3(395.6f, 0f, -99.4f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[7]);
                realMadridPlayer.transform.position = new Vector3(395.2f, 0f, -25.7f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[8]);
                realMadridPlayer.transform.position = new Vector3(393.7f, 0f, 50.2f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[9]);
                realMadridPlayer.transform.position = new Vector3(399.6f, 0f, 117.2f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[10]);
                realMadridPlayer.transform.position = new Vector3(438.9f, 0f, 5.1f);//
            }
            else if ((((collision.gameObject.transform.position.x <= -445f) && (collision.gameObject.transform.position.z <= -45f && collision.gameObject.transform.position.z >= -232.7f)) || ((collision.gameObject.transform.position.x <= -445f) && (collision.gameObject.transform.position.z <= 235.83f && collision.gameObject.transform.position.z >= 48.71f))) && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                collision.gameObject.transform.position = new Vector3(-347.8f, 4f, -1.2f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[0]);
                barcelonaPlayer.transform.position = new Vector3(-335.3f, 0f, -2f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[1]);
                barcelonaPlayer.transform.position = new Vector3(-343.8f, 0f, 49.7f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[2]);
                barcelonaPlayer.transform.position = new Vector3(-347.2f, 0f, -66.4f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[3]);
                barcelonaPlayer.transform.position = new Vector3(-255f, 0f, -65.7f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[4]);
                barcelonaPlayer.transform.position = new Vector3(-347f, 0f, 107.4f); // 
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[5]);
                barcelonaPlayer.transform.position = new Vector3(-261f, 0f, 14f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[6]);
                barcelonaPlayer.transform.position = new Vector3(-137f, 0f, -49f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[7]);
                barcelonaPlayer.transform.position = new Vector3(19.5f, 0f, 5f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[8]);
                barcelonaPlayer.transform.position = new Vector3(-134f, 0f, 79f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[9]);
                barcelonaPlayer.transform.position = new Vector3(-271.1f, 0f, 103.7f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[10]);
                barcelonaPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f); //
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[0]);
                realMadridPlayer.transform.position = new Vector3(-11.7f, 0f, 1.3f); //
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[1]);
                realMadridPlayer.transform.position = new Vector3(-165f, 0f, 78f); //
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[2]);
                realMadridPlayer.transform.position = new Vector3(-160f, 0f, -57f); //
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[3]);
                realMadridPlayer.transform.position = new Vector3(-275f, 0f, -69f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[4]);
                realMadridPlayer.transform.position = new Vector3(-291f, 0f, 103f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[5]);
                realMadridPlayer.transform.position = new Vector3(-286f, 0f, 13f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[6]);
                realMadridPlayer.transform.position = new Vector3(-370.6f, 0f, -72.2f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[7]);
                realMadridPlayer.transform.position = new Vector3(-365.9f, 0f, -8.7f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[8]);
                realMadridPlayer.transform.position = new Vector3(-372.2f, 0f, 43.4f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[9]);
                realMadridPlayer.transform.position = new Vector3(-369.1f, 0f, 101.2f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[10]);
                realMadridPlayer.transform.position = new Vector3(-428.6f, 0f, 5.5f);//

            }
        }
    }
}
