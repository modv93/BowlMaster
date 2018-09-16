using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
	public Text standingDisplay;

	private GameManager gameManager;
	private bool ballOutOfPlay  = false;
	private int lastSettledCount = 10;
	private	int lastStandingCount = -1;
	private float lastChangeTime;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(standingDisplay){
			standingDisplay.text = CountStanding().ToString();
		}
		if(ballOutOfPlay){
			CheckStanding();
			standingDisplay.color = Color.red;
		}else{
			standingDisplay.color = Color.green;
		}
	}
	void OnTriggerExit (Collider collider){
		if (collider.gameObject.name == "Ball"){
			ballOutOfPlay = true;
		}
	}
	void CheckStanding(){
		int currentStanding = CountStanding();
		if(currentStanding != lastStandingCount){
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		if((Time.time - lastChangeTime) >= 3f){
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled(){
		int standing = CountStanding();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;
		gameManager.Bowls(pinFall);
		lastStandingCount = -1;
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding(){
		int countOfStandingPins = 0;
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if(pin && pin.IsStanding()){//pin exists and is standing 
				countOfStandingPins++;
			}
		}
		return countOfStandingPins;
	}
	public void Reset(){
		lastSettledCount = 10;
	}
}
