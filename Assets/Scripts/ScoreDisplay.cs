using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	public Text[] rollTexts, frameTexts;
	// Use this for initialization

	public void FillRollCard(List<int> rolls){
		//Debug.Log(rolls);
		string scoreString = FormatRolls(rolls);
		for (int i = 0; i < scoreString.Length ; i++){
			//Debug.Log(rolls[i]);
			rollTexts[i].text = scoreString[i].ToString();
		}
	}

	public void FillFrames(List<int> frames){
		for (int i = 0; i < frames.Count ; i++){
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls(List<int> rolls){
		string output = "";
		int counter = 0;
		/*for (int i = 0; i < rolls.Count; i++) {
			int box = output.Length + 1;							// Score box 1 to 21 

			if (rolls[i] == 0) {									// Always enter 0 as -
				output += "-";
			} else if (box % 2 == 0 && rolls[i-1]+rolls[i] == 10) {	// SPARE anywhere
				output += "/";	
			} else if (box >= 19 && rolls[i] == 10)	{				// STRIKE in frame 10
				output += "X";
			} else if (rolls[i] == 10) {							// STRIKE in frame 1-9
				output += "X";
			} else {
				output += rolls[i].ToString();						// Normal 1-9 bowl
			}
		}return output;
		*/
		// My solution but Ben fucked it up in action master by adding additional zeros for strikes
		for (int i = 0; i < rolls.Count ; i++){
			counter++;
			if( rolls[i] == 10 ){
				if(counter >= 19){ // If we are in the last frames
					output += "X";
					continue;
				}
				if(counter % 2 != 0){ // Strikes
					output += "X0";
					counter++;
					continue;
				}else{
					output += "/";
					continue;
				}
			}
			if(counter % 2 == 0 || counter == 21){
				if(rolls[i-1] + rolls[i] == 10){
					output += "/";
					continue;
				}
			}
			output += rolls[i].ToString();
		}return output;

	} 
}

