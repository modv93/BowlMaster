using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    // public 
    public Vector3 launchVelocity;
	public bool ballInPlay = false;

    
    // private
    private Vector3 ballStartPOS;
	private Rigidbody ballBody;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		ballStartPOS = this.transform.position;
		ballBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		ballBody.useGravity = false; //turn gravity off
		//Launch (launchVelocity);

	}

	public void Launch (Vector3 velocity)//launches the ball with the velocity provided
	{	
		ballInPlay = true;
		ballBody.useGravity = true;//turn gravity on, when input is retrieved
		ballBody.velocity = velocity;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Reset(){

		ballInPlay = false;
		this.transform.position = ballStartPOS;
		this.transform.rotation = Quaternion.identity;
		ballBody.velocity = Vector3.zero;
		ballBody.angularVelocity = Vector3.zero;
		ballBody.useGravity = false;
	}

}
