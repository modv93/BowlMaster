using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;

	private Ball ball;
	private Animator animator;
	private PinCounter pinCounter;

//	ActionMaster actionMaster = new ActionMaster();
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		animator = GetComponent<Animator>();
		//standingDisplay = GameObject.FindObjectOfType<Text>();
		/*if(text){
			text.text = CountStanding().ToString();
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RaisePins(){
		Debug.Log("Raising pins");
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding();
		}
	}

	public void LowerPins(){
		Debug.Log("Lowering pins");
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
				pin.Lower();
		}
	}
	public void RenewPins(){
		Debug.Log("Renewing pins");
		Instantiate(pinSet, new Vector3(0f,60f,1829f), Quaternion.identity);
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Reset();
		}
	}


	public void PerformAction(ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		}
		else if (action == ActionMaster.Action.Reset){
			pinCounter.Reset();
			animator.SetTrigger("resetTrigger");
		}
		else if (action == ActionMaster.Action.EndTurn){
			pinCounter.Reset();
			animator.SetTrigger("resetTrigger");
		}
		else if (action == ActionMaster.Action.EndGame){
			throw new UnityException ("Don't knoww what the fuck to do here");
		}
		ball.Reset();
	}

}