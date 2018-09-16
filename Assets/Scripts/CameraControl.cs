using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	public Ball ball;
	private Vector3 offset;
	private bool ballFound;
	// Use this for initialization
	void Start () {
		if(ball){
			offset = transform.position - ball.transform.position;
			ballFound = true;
		}
		else{
			Debug.LogWarning("Ball is missing in inspector");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(ball.transform.position.z < 1829f && ballFound){//We are using the balls transform so that the main camera s=doesn't stop moving.
			transform.position = offset + ball.transform.position;
		}
		
	}
}
