using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMadridPlayerScript : MonoBehaviour {
    private float playerSpeedRM;
    private float soccerBallSpeed;
    private Rigidbody theRB;
	// Use this for initialization
	void Start () {
        playerSpeedRM = 50f;
        soccerBallSpeed = 20f;
        theRB = GetComponent<Rigidbody>();
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
            if (this.transform.position.x < collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z) < 0.3)
            {
               // Debug.Log("1");
                soccerBall.AddForce(transform.right * soccerBallSpeed, ForceMode.Impulse);
            }
            else if (this.transform.position.x > collision.transform.position.x && Mathf.Abs(this.transform.position.z - collision.transform.position.z) < 0.3)
            {
                //Debug.Log("2");
                soccerBall.AddForce(-transform.right * soccerBallSpeed, ForceMode.Impulse);
            }
            else if (this.transform.position.z < collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < 0.3)
            {
               // Debug.Log("3");
                soccerBall.AddForce(transform.up * soccerBallSpeed, ForceMode.Impulse);
            }
            else if (this.transform.position.z > collision.transform.position.z && Mathf.Abs(this.transform.position.x - collision.transform.position.x) < 0.3)
            {
                //Debug.Log("4");
                soccerBall.AddForce(-transform.up * soccerBallSpeed, ForceMode.Impulse);
            }
            else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
            {
               // Debug.Log("5");
                soccerBall.AddForce((transform.right + transform.up) * soccerBallSpeed, ForceMode.Impulse);
            }
            else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x < collision.transform.position.x)
            {
                //Debug.Log("6");
                soccerBall.AddForce((transform.right - transform.up) * soccerBallSpeed, ForceMode.Impulse);
            }
            else if (this.transform.position.z > collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
            {
                //Debug.Log("7");
                soccerBall.AddForce((-transform.up - transform.right) * soccerBallSpeed, ForceMode.Impulse);
            }
            else if (this.transform.position.z < collision.transform.position.z && this.transform.position.x > collision.transform.position.x)
            {
               // Debug.Log("8");
                soccerBall.AddForce((transform.up - transform.right) * soccerBallSpeed, ForceMode.Impulse);
            }
        }
    }
}
