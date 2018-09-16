using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDislpayTest {
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}
	[Test]
	public void T01Bowl1 () {
		int[] rolls = {1};
		string rollString = "1";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}	
	[Test]
	public void T01Bowl23 () {
		int[] rolls = {2,3};
		string rollString = "23";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T01Bowl234 () {
		int[] rolls = {2,3,4};
		string rollString = "234";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T03Bowl2345 () {
		int[] rolls = {2,3,4,5};
		string rollString = "2345";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04Bowl23456 () {
		int[] rolls = {2,3,4,5,6};
		string rollString = "23456";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05Bowl234561 () {
		int[] rolls = {2,3,4,5,6,1};
		string rollString = "234561";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T06Bowl2345612 () {
		int[] rolls = {2,3, 4,5, 6,1, 2};
		string rollString = "2345612";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07BowlX1 () {
		int[] rolls = {10, 1};
		string rollString = "X01";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T07BowlX12 () {
		int[] rolls = {10};
		string rollString = "X0";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T08Bowl19 () {
		int[] rolls = {1, 9};
		string rollString = "1/";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T09Bowl123455 () {
		int[] rolls = {1,2, 3,4, 5,5};
		string rollString = "12345/";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T10SpareBonus () {
		int[] rolls = {1,2, 3,5, 5,5, 3,3};
		string rollString = "12355/33";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T11SpareBonus2 () {
		int[] rolls = {1,2, 3,5, 5,5, 3,3, 7,1, 9,1, 6};
		string rollString = "12355/33719/6";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T12StrikeBonus () {
		int[] rolls = { 10, 3,4};
		string rollString = "X034";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T13StrikeBonus3 () {
		int[] rolls = { 1,2, 3,4, 5,4, 3,2, 10, 1,3, 3,4};
		string rollString = "12345432X01334";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T14MultiStrikes () {
		int[] rolls = { 10, 10, 2,3};
		string rollString = "X0X023";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T15MultiStrikes3 () {
		int[] rolls = { 10, 10, 2,3, 10, 5,3};
		string rollString = "X0X023X053";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T16TestGutterGame () {
		int[] rolls = { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0};
		string rollString = "00000000000000000000";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T18TestAllStrikes () {
		int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,10,10};
		string rollString = "X0X0X0X0X0X0X0X0X0XXX";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T20SpareInLastFrame () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,7};
		string rollString = "1111111111111111111/7";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	[Test]
	public void T21SpareInLastFrame () {
		int[] rolls = { 10, 9,1, 9,1, 9,1, 9,1, 7,0, 9,0, 10, 8,2, 1,9,8};
		string rollString = "X09/9/9/9/7090X08/1/8";
		Assert.AreEqual (rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}