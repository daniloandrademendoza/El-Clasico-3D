using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FCBarcelonaPlayerScript : MonoBehaviour {
    private float playerSpeed;
    private float soccerBallSpeed;
   // private float shootSoccerBall;
  //  private float soccerBallSpeedStop;
   // private float soccerBallMove;
    private string playerName;
    private string minName;
    private GameObject player;
    private GameObject player2;
    private GameObject realMadridPlayer;
    private GameObject barcelonaPlayer;
    private Rigidbody theRB;
    private float minDistance;
    private string[] playerNamesBarcelona = { "Messi", "Suarez", "Coutinho", "Rakitic", "Vidal", "Sergio", "Roberto", "Pique", "Umtiti", "Alba", "TerStegen" };
    private string[] playerNamesRealMadrid = { "Isco", "Bale", "Benzema", "Modric", "Kroos", "Casemiro", "Marcelo", "Varane", "Ramos", "Carvajal", "Courtois" };
    private int playerRealMadridStringInt;
    private float minXorZBetweenPlayers;
    public Text halfTimeText;
    private int halfTimeInt;
    private float playerSpeedFast;
    //Rigidbody playerRigidBody;
    // private bool done;
    // Use this for initialization
    void Start() {
        playerSpeed = 100f; //30   300 fast
        playerSpeedFast = 150f;
        soccerBallSpeed = .01f; //.01
      //  soccerBallSpeedStop = 0f;
        theRB = GetComponent<Rigidbody>();
       // soccerBallMove = 10f;
        minDistance = 1000f;
        //i = 0;
        minXorZBetweenPlayers = 5f;
        //shootSoccerBall = 30f;
        playerRealMadridStringInt = 0;
        halfTimeInt = 48;
       // playerRigidBody = this.GetComponent<Rigidbody>();
        //  done = false;
    }

    // Update is called once per frame
    void Update() {
       // Debug.Log(this.gameObject.name);
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.Z))
            {
                theRB.velocity = new Vector3(theRB.velocity.x, 0f, playerSpeedFast);
                Debug.Log("W");
                Debug.Log(playerSpeedFast);
            }
            else
            {
                theRB.velocity = new Vector3(theRB.velocity.x, 0f, playerSpeed);
            }
           // Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.Z))
            {
                theRB.velocity = new Vector3(-playerSpeedFast, 0f, theRB.velocity.z);
                Debug.Log("A");
                Debug.Log(playerSpeedFast);
            }
            else
            {
                theRB.velocity = new Vector3(-playerSpeed, 0f, theRB.velocity.z);
            }
           // Debug.Log("A");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if(Input.GetKey(KeyCode.Z))
            {
                theRB.velocity = new Vector3(theRB.velocity.x, 0f, -playerSpeedFast);
                Debug.Log("S");
                Debug.Log(playerSpeedFast);
            }
            else
            {
                theRB.velocity = new Vector3(theRB.velocity.x, 0f, -playerSpeed);
            }
           // Debug.Log("S");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.Z))
            {
                theRB.velocity = new Vector3(playerSpeedFast, 0f, theRB.velocity.z);
                Debug.Log("D");
                Debug.Log(playerSpeedFast);
                // Debug.Log("D");
            }
            else
            {
                theRB.velocity = new Vector3(playerSpeed, 0f, theRB.velocity.z);
            }
           
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
                else if (Input.GetKey(KeyCode.E))
                {
                    soccerBall.drag = 0.00001f;//0.0001
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
                    soccerBall.drag = 0.00001f;
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
                    soccerBall.drag = 0.00001f;
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
                    soccerBall.drag = 0.00001f;
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
                    soccerBall.drag = 0.00001f;
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
                    soccerBall.drag = 0.00001f;
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
                    soccerBall.drag = 0.00001f;
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
                    soccerBall.drag = 0.000001f;
                    soccerBall.AddForce((-transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);

                }
                else
                {
                    soccerBall.drag = 2f;
                    soccerBall.AddForce((-transform.forward - transform.right) * soccerBallSpeed, ForceMode.Impulse);
                }
            }

            if (collision.gameObject.transform.position.x >= -437 && collision.gameObject.transform.position.x < -144.26 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                playerRealMadridStringInt = 1;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
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
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                      //  Debug.Log("In2");
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            else if (collision.gameObject.transform.position.x >= 148.46 && collision.gameObject.transform.position.x < 441.2 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                playerRealMadridStringInt = 9;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }

            else if (collision.gameObject.transform.position.x >= -437 && collision.gameObject.transform.position.x < -144.26 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                playerRealMadridStringInt = 2;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
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
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        //  Debug.Log("In2");
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            else if (collision.gameObject.transform.position.x >= 148.46 && collision.gameObject.transform.position.x < 441.2 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                playerRealMadridStringInt = 6;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x - 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }

            else if (collision.gameObject.transform.position.x >= -437 && collision.gameObject.transform.position.x < -144.26 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                playerRealMadridStringInt = 9;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
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
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        //  Debug.Log("In2");
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            else if (collision.gameObject.transform.position.x >= 148.46 && collision.gameObject.transform.position.x < 441.2 && collision.gameObject.transform.position.z > 235 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                playerRealMadridStringInt = 1;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }

            else if (collision.gameObject.transform.position.x >= -437 && collision.gameObject.transform.position.x < -144.26 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                playerRealMadridStringInt = 6;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
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
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        //  Debug.Log("In2");
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            else if (collision.gameObject.transform.position.x >= 148.46 && collision.gameObject.transform.position.x < 441.2 && collision.gameObject.transform.position.z < -231 && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                playerRealMadridStringInt = 2;
                for (int a = 0; a < 11; a++)
                {
                    if (playerRealMadridStringInt != a)
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = false;
                    }
                    else
                    {
                        realMadridPlayer = GameObject.Find(playerNamesRealMadrid[a]);
                        realMadridPlayer.GetComponent<RealMadridPlayerScript>().enabled = true;
                        playerName = "SoccerBall";
                        player = GameObject.Find(playerName);
                        player.transform.position = new Vector3(realMadridPlayer.transform.position.x + 20, 4f, realMadridPlayer.transform.position.z);
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
            }
            //corners
            if ((((collision.gameObject.transform.position.x <= -445f) && (collision.gameObject.transform.position.z <= -45f && collision.gameObject.transform.position.z >= -232.7f)) || ((collision.gameObject.transform.position.x <= -445f) && (collision.gameObject.transform.position.z <= 235.83f && collision.gameObject.transform.position.z >= 48.71f))) && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt)
            {
                collision.gameObject.transform.position = new Vector3(-371.64f, 4f, -12.9f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[0]);
                barcelonaPlayer.transform.position = new Vector3(-118f, 0f, 19f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[1]);
                barcelonaPlayer.transform.position = new Vector3(-176f, 0f, 95f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[2]);
                barcelonaPlayer.transform.position = new Vector3(-181f, 0f, -64f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[3]);
                barcelonaPlayer.transform.position = new Vector3(-259f, 0f, -57f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[4]);
                barcelonaPlayer.transform.position = new Vector3(-260f, 0f, 94f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[5]);
                barcelonaPlayer.transform.position = new Vector3(-319f, 0f, 20f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[6]);
                barcelonaPlayer.transform.position = new Vector3(-392f, 0f, -73f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[7]);
                barcelonaPlayer.transform.position = new Vector3(-393f, 0f, -12f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[8]);
                barcelonaPlayer.transform.position = new Vector3(-389.7f, 0f, 49.6f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[9]);
                barcelonaPlayer.transform.position = new Vector3(-388.6f, 0f, 111f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[10]);
                barcelonaPlayer.transform.position = new Vector3(-430.8f, 0f, 4.4f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[0]);
                realMadridPlayer.transform.position = new Vector3(-361f, 0f, -13.7f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[1]);
                realMadridPlayer.transform.position = new Vector3(-373.2f, 0f, 49.5f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[2]);
                realMadridPlayer.transform.position = new Vector3(-377f, 0f, -72f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[3]);
                realMadridPlayer.transform.position = new Vector3(-303.7f, 0f, 20.4f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[4]);
                realMadridPlayer.transform.position = new Vector3(-374.3f, 0f, 111f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[5]);
                realMadridPlayer.transform.position = new Vector3(-243.6f, 0f, -53.3f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[6]);
                realMadridPlayer.transform.position = new Vector3(-167.8f, 0f, -63.4f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[7]);
                realMadridPlayer.transform.position = new Vector3(13.8f, 0f, 3.1f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[8]);
                realMadridPlayer.transform.position = new Vector3(-157.8f, 0f, 97.8f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[9]);
                realMadridPlayer.transform.position = new Vector3(-246.8f, 0f, 95.1f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[10]);
                realMadridPlayer.transform.position = new Vector3(439.5f, 0f, 3.4f);
            }
            else if ((((collision.gameObject.transform.position.x >= 445f) && (collision.gameObject.transform.position.z <= -43.8f && collision.gameObject.transform.position.z >= -230.5f)) || ((collision.gameObject.transform.position.x >= 445f) && (collision.gameObject.transform.position.z <= 235.9f && collision.gameObject.transform.position.z >= 51.1f))) && System.Convert.ToInt32(halfTimeText.text) < halfTimeInt) 
            {
                collision.gameObject.transform.position = new Vector3(397.1f, 4f, 71.3f); //
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[0]);
                barcelonaPlayer.transform.position = new Vector3(208f, 0f, 1f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[1]);
                barcelonaPlayer.transform.position = new Vector3(242.4f, 0f, 153.3f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[2]);
                barcelonaPlayer.transform.position = new Vector3(246f, 0f, -143f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[3]);
                barcelonaPlayer.transform.position = new Vector3(-31f, 0f, -133f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[4]);
                barcelonaPlayer.transform.position = new Vector3(-28f, 0f, 148f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[5]);
                barcelonaPlayer.transform.position = new Vector3(-136f, 0f, 3f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[6]);
                barcelonaPlayer.transform.position = new Vector3(-317f, 0f, -207f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[7]);
                barcelonaPlayer.transform.position = new Vector3(-323f, 0f, -67f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[8]);
                barcelonaPlayer.transform.position = new Vector3(-335f, 0f, 103f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[9]);
                barcelonaPlayer.transform.position = new Vector3(-355f, 0f, 203f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[10]);
                barcelonaPlayer.transform.position = new Vector3(-432.6f, 0f, 3.6f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[0]);
                realMadridPlayer.transform.position = new Vector3(-287f, 0f, -10f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[1]);
                realMadridPlayer.transform.position = new Vector3(-257f, 0f, 155f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[2]);
                realMadridPlayer.transform.position = new Vector3(-280f, 0f, -156f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[3]);
                realMadridPlayer.transform.position = new Vector3(-13f, 0f, -139f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[4]);
                realMadridPlayer.transform.position = new Vector3(-11f, 0f, 145f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[5]);
                realMadridPlayer.transform.position = new Vector3(-93f, 0f, 4f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[6]);
                realMadridPlayer.transform.position = new Vector3(327f, 0f, -208f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[7]);
                realMadridPlayer.transform.position = new Vector3(260.3f, 0f, -80.5f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[8]);
                realMadridPlayer.transform.position = new Vector3(256f, 0f, 91f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[9]);
                realMadridPlayer.transform.position = new Vector3(326f, 0f, 210f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[10]);
                realMadridPlayer.transform.position = new Vector3(407.5f, 0f, 72.2f);//
            }
            else if ((((collision.gameObject.transform.position.x <= -445f) && (collision.gameObject.transform.position.z <= -45f && collision.gameObject.transform.position.z >= -232.7f)) || ((collision.gameObject.transform.position.x <= -445f) && (collision.gameObject.transform.position.z <= 235.83f && collision.gameObject.transform.position.z >= 48.71f))) && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                collision.gameObject.transform.position = new Vector3(-394.3f, 4f, -68.9f); //
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[0]);
                barcelonaPlayer.transform.position = new Vector3(-176f, 0f, -3f); //
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[1]);
                barcelonaPlayer.transform.position = new Vector3(-225f, 0f, 162f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[2]);
                barcelonaPlayer.transform.position = new Vector3(-240f, 0f, -169f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[3]);
                barcelonaPlayer.transform.position = new Vector3(81f, 0f, -128f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[4]);
                barcelonaPlayer.transform.position = new Vector3(72f, 0f, 163f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[5]);
                barcelonaPlayer.transform.position = new Vector3(69f, 0f, 15f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[6]);
                barcelonaPlayer.transform.position = new Vector3(329.2f, 0f, -207f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[7]);
                barcelonaPlayer.transform.position = new Vector3(324.7f, 0f, -74.9f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[8]);
                barcelonaPlayer.transform.position = new Vector3(332.7f, 0f, 83.5f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[9]);
                barcelonaPlayer.transform.position = new Vector3(329f, 0f, 212f);//
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[10]);
                barcelonaPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[0]);
                realMadridPlayer.transform.position = new Vector3(294f, 0f, 1f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[1]);
                realMadridPlayer.transform.position = new Vector3(288f, 0f, 146f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[2]);
                realMadridPlayer.transform.position = new Vector3(279f, 0f, -140f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[3]);
                realMadridPlayer.transform.position = new Vector3(44f, 0f, -133f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[4]);
                realMadridPlayer.transform.position = new Vector3(43f, 0f, 159f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[5]);
                realMadridPlayer.transform.position = new Vector3(44f, 0f, 12f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[6]);
                realMadridPlayer.transform.position = new Vector3(-315.3f, 0f, -206f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[7]);
                realMadridPlayer.transform.position = new Vector3(-243f, 0f, -83f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[8]);
                realMadridPlayer.transform.position = new Vector3(-250.3f, 0f, 95.2f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[9]);
                realMadridPlayer.transform.position = new Vector3(-354.3f, 0f, 203.1f);//
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[10]);
                realMadridPlayer.transform.position = new Vector3(-407.2f, 0f, -69.7f);//
            }
            else if ((((collision.gameObject.transform.position.x >= 445f) && (collision.gameObject.transform.position.z <= -43.8f && collision.gameObject.transform.position.z >= -230.5f)) || ((collision.gameObject.transform.position.x >= 445f) && (collision.gameObject.transform.position.z <= 235.9f && collision.gameObject.transform.position.z >= 51.1f))) && System.Convert.ToInt32(halfTimeText.text) > halfTimeInt)
            {
                collision.gameObject.transform.position = new Vector3(361.1f, 4f, 38.4f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[0]);
                barcelonaPlayer.transform.position = new Vector3(34.7f, 0f, 5.9f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[1]);
                barcelonaPlayer.transform.position = new Vector3(204f, 0f, 90f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[2]);
                barcelonaPlayer.transform.position = new Vector3(220f, 0f, -55f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[3]);
                barcelonaPlayer.transform.position = new Vector3(307f, 0f, -80f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[4]);
                barcelonaPlayer.transform.position = new Vector3(295f, 0f, 116f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[5]);
                barcelonaPlayer.transform.position = new Vector3(302f, 0f, 8f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[6]);
                barcelonaPlayer.transform.position = new Vector3(373f, 0f, -105f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[7]);
                barcelonaPlayer.transform.position = new Vector3(379.4f, 0f, -31.7f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[8]);
                barcelonaPlayer.transform.position = new Vector3(383f, 0f, 36f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[9]);
                barcelonaPlayer.transform.position = new Vector3(382f, 0f, 100f);
                barcelonaPlayer = GameObject.Find(playerNamesBarcelona[10]);
                barcelonaPlayer.transform.position = new Vector3(439.6f, 0f, 2.4f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[0]);
                realMadridPlayer.transform.position = new Vector3(350f, 0f, 38f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[1]);
                realMadridPlayer.transform.position = new Vector3(362.7f, 0f, 101.6f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[2]);
                realMadridPlayer.transform.position = new Vector3(356.6f, 0f, -33.1f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[3]);
                realMadridPlayer.transform.position = new Vector3(351.5f, 0f, -103.7f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[4]);
                realMadridPlayer.transform.position = new Vector3(270.6f, 0f, 116.1f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[5]);
                realMadridPlayer.transform.position = new Vector3(281.1f, 0f, 8.7f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[6]);
                realMadridPlayer.transform.position = new Vector3(282.2f, 0f, -78f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[7]);
                realMadridPlayer.transform.position = new Vector3(202f, 0f, -54f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[8]);
                realMadridPlayer.transform.position = new Vector3(-27f, 0f, 3f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[9]);
                realMadridPlayer.transform.position = new Vector3(184f, 0f, 89.7f);
                realMadridPlayer = GameObject.Find(playerNamesRealMadrid[10]);
                realMadridPlayer.transform.position = new Vector3(-428.6f, 0f, 5.5f);
            }
        }


    }
        }
	
