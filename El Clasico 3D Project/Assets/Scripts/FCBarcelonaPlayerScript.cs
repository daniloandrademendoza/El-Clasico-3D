using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCBarcelonaPlayerScript : MonoBehaviour {
    private float playerSpeed;
    private float soccerBallSpeed;
    private float soccerBallSpeedStop;
    private float soccerBallMove;
    //private string playerName;
    // private string minName;
    //private GameObject player;
    private Rigidbody theRB;
   // private float minDistance;

	// Use this for initialization
	void Start () {
        playerSpeed = 50f;
        soccerBallSpeed = 20f;
        soccerBallSpeedStop = 0f;
        theRB = GetComponent<Rigidbody>();
        soccerBallMove = 10f;
      //  minDistance = 1000f;
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
           // Debug.Log("Collided with Soccer Ball");
                Rigidbody soccerBall = collision.gameObject.GetComponent<Rigidbody>();
                if(this.transform.position.x < collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z)<0.3)
                {
                   // Debug.Log("1");
                    soccerBall.AddForce(transform.right * soccerBallSpeed, ForceMode.Impulse);
               //     soccerBall.AddForce(transform.right* soccerBallSpeedStop, ForceMode.Impulse);
               // collision.transform.position = new Vector3(collision.transform.position.x+soccerBallMove,collision.transform.position.y,collision.transform.position.z);
            }
                else if (this.transform.position.x > collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z) < 0.3)
                {
                    //Debug.Log("2");
                    soccerBall.AddForce(-transform.right * soccerBallSpeed, ForceMode.Impulse);
              //  soccerBall.AddForce(-transform.right * soccerBallSpeedStop, ForceMode.Impulse);
               // collision.transform.position = new Vector3(collision.transform.position.x-soccerBallMove, collision.transform.position.y, collision.transform.position.z);
            }
                else if (this.transform.position.z < collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < 0.3)
                {
                   // Debug.Log("3");
                    soccerBall.AddForce(transform.up * soccerBallSpeed, ForceMode.Impulse);
              //  soccerBall.AddForce(transform.up * soccerBallSpeedStop, ForceMode.Impulse);
              //  collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z + soccerBallMove);
            }
                else if (this.transform.position.z > collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < 0.3)
                {
                  //  Debug.Log("4");
                    soccerBall.AddForce(-transform.up * soccerBallSpeed, ForceMode.Impulse);
              //  soccerBall.AddForce(-transform.up * soccerBallSpeedStop, ForceMode.Impulse);
               // collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z - soccerBallMove);
            }
                else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
                {
                   // Debug.Log("5");
                    soccerBall.AddForce((transform.right + transform.up) * soccerBallSpeed, ForceMode.Impulse);
              //  soccerBall.AddForce((transform.right + transform.up) * soccerBallSpeedStop, ForceMode.Impulse);
              //  collision.transform.position = new Vector3(collision.transform.position.x+soccerBallMove, collision.transform.position.y, collision.transform.position.z + soccerBallMove);
            }
                else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
                {
                   // Debug.Log("6");
                    soccerBall.AddForce((transform.right - transform.up) * soccerBallSpeed, ForceMode.Impulse);
              //  soccerBall.AddForce((transform.right - transform.up) * soccerBallSpeedStop, ForceMode.Impulse);
               // collision.transform.position = new Vector3(collision.transform.position.x + soccerBallMove, collision.transform.position.y, collision.transform.position.z - soccerBallMove);
            }
                else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
                {
                    //Debug.Log("7");
                    soccerBall.AddForce((- transform.up - transform.right) * soccerBallSpeed, ForceMode.Impulse);
              //  soccerBall.AddForce((-transform.up - transform.right) * soccerBallSpeedStop, ForceMode.Impulse);
             //   collision.transform.position = new Vector3(collision.transform.position.x - soccerBallMove, collision.transform.position.y, collision.transform.position.z - soccerBallMove);
            }
                else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
                {
                   //Debug.Log("8");
                    soccerBall.AddForce((transform.up - transform.right) * soccerBallSpeed, ForceMode.Impulse);
               // soccerBall.AddForce((transform.up - transform.right) * soccerBallSpeedStop, ForceMode.Impulse);
               //collision.transform.position = new Vector3(collision.transform.position.x - soccerBallMove, collision.transform.position.y, collision.transform.position.z + soccerBallMove);
            }
            }
        }
	}
