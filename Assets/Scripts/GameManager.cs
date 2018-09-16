using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private List <int> rolls = new List<int>();
	private PinSetter pinSetter;
	private ScoreDisplay scoreDisplay;
	private Ball ball;
	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
		scoreDisplay =  GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	// Update is called once per frame
	public void Bowls (int pinFall){
		try{
			rolls.Add(pinFall);
			ball.Reset();
			ActionMaster.Action nextAction = ActionMaster.NextAction(rolls);
			pinSetter.PerformAction(nextAction);
		}catch{
			Debug.Log("There is some problem in performing action");
		}
		try{
			scoreDisplay.FillRollCard(rolls);	
			scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
		}
		catch{
			Debug.Log("There's an error while fiiling the score card");
		}
	}
}
