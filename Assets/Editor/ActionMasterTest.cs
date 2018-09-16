using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {
	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	[SetUp]
	public void Setup(){
		pinFalls = new List<int>();
	}

	[Test]
	public void T00passingTest(){
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrikeEndsTurn(){
		pinFalls.Add (10);
		Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy(){
		pinFalls.Add (8);
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T03LastBallEndsGame(){
	int [] rolls = new int[20];
		for (int i =1; i<= 20; i++){
			rolls[i-1] = 1;
		}
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04Bowl28ReturnsSpareEndTurn(){
		int [] rolls = {2, 8};
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T05CheckStikrInLastFrame(){
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 ,10 };
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T06CheckStikrInLastFrame(){
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 , 1,9};
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T07RollsEndInEndGame(){
		int[] rolls = { 8,2, 7,3, 3,4, 10 ,2,8, 10 , 10 ,8, 0,10, 8,2, 9};
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T08CheckTidyOnBowl20(){
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5};
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T09CheckDooubleStrikes(){
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 , 10,10,10};
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T10CheckSpareAndStrikes(){
		int[] rolls = { 0, 10, 0, 10 };
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

}
