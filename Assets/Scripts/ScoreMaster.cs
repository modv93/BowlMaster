using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {


	public static List<int> ScoreCumulative( List<int> rolls ){
		List<int> scoreList = new List<int>();
		int runningTotal = 0;
		foreach(int frameScore in ScoreFrames(rolls)){
			runningTotal += frameScore;
			scoreList.Add(runningTotal);
		}
		return scoreList;
	}

	public static List<int> ScoreFrames ( List<int> rolls ){
		List<int> frameList = new List<int>();
		// index i points to second bowl of frame, hence 
		for (int i = 1; i< rolls.Count ; i+=2){// frame step
			if (frameList.Count == 10){break;}
			if(rolls[i-1]+rolls[i] < 10){
				frameList.Add(rolls[i-1]+rolls[i]);
			}
			if(rolls.Count - i <= 1){ // ensure atleast one look ahead
				break;
			}
			if(rolls[i-1] == 10){//strike frame has  just one bowl
				i--;
				frameList.Add(10 + rolls[i+1] + rolls[i+2]); // STRIKE
			}else if (rolls[i-1]+rolls[i] == 10){ // SPARE
				frameList.Add(10 + rolls[i+1]);
			}
		}

		return frameList;
	}
}
