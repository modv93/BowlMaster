using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float standingThreshold = 3f;
	public float pinRaiseDistance  = 40f;
	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//print(name + " " + IsStanding());
	}
	public bool IsStanding (){
		Vector3 rotationIInEuler = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(270 - rotationIInEuler.x);
		float tiltInZ = Mathf.Abs(rotationIInEuler.z);
		if(tiltInX < standingThreshold && tiltInZ < standingThreshold){
			return true;
		}return false;
	}
	public void RaiseIfStanding(){
		if(IsStanding()){
			rigidBody.useGravity = false;
			transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
			transform.Translate (new Vector3(0f, pinRaiseDistance, 0f), Space.World);
		}
	}
	public void Lower(){
		transform.Translate (new Vector3(0f, -pinRaiseDistance, 0f), Space.World);
		transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
		rigidBody.useGravity = true;
	}
	public void Reset(){
		if (rigidBody){
			rigidBody.useGravity = false;
		}
	}
}
