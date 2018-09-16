using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Ball))]
public class DragLaunch : MonoBehaviour {
	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void OnDragStart(){
		// record drag start pos and time.
		if(! ball.ballInPlay){
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}
	public void OnDragEnd(){
		//record drag end  pos and time. Then launch ball.
		if(! ball.ballInPlay){
			dragEnd = Input.mousePosition;
			endTime = Time.time;
			float dragDuration = endTime - startTime;
			float launchSpeedX = ((dragEnd.x -  dragStart.x) / dragDuration)/10f;
			float launchSpeedZ = (dragEnd.y -  dragStart.y) / dragDuration;
			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
			ball.Launch(launchVelocity);
		}
		/*
		Vector3 velocity = ((dragStart - dragEnd) / (startTime - endTime));
		ball.Launch(velocity);
		*/
	}
	public void MoveStart(float xfloat){
		if(! ball.ballInPlay){
			float xPos = Mathf.Clamp ( ball.transform.position.x + xfloat, -50f, 50f ) ;
			float yPos = ball.transform.position.y ;
			float zPos = ball.transform.position.z ;
			ball.transform.position = new Vector3(xPos, yPos, zPos);
		}
	}
}
