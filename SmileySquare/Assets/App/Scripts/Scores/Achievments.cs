using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Achievments {

	public const int TYPE_SCORE = 0;
	public const int TYPE_TOTAL = 1;
	public const int TYPE_NO_HIT = 2;
	public const int TYPE_POWERUP = 4;
	
	public const string FIRST_TRY ="ft";
	public const string LAZY ="lt";
	public const string BEGINNER ="beginner";
	public const string GOOD ="good";
	public const string EXCELENT ="ex";
	public const string MASTER ="master";
	public const string DEFENDER ="def";
	
	public const string LAZY_HIGHSCORE ="ltHS";
	public const string BEGINNER_HIGHSCORE ="beginnerHS";
	public const string GOOD_HIGHSCORE ="goodHS";
	public const string EXCELENT_HIGHSCORE ="exHS";
	public const string MASTER_HIGHSCORE ="masterHS";
	public const string DEFENDER_HIGHSCORE ="defHS";
	
	public const string BAD_AIM ="ba1";
	public const string HORRIBLE_AIM ="ba2";
	
	public const string RAPIDFIRE ="p1";
	public const string MULTIPLIER ="p2";
	public const string DOUBLE_GUN ="p3";
	public const string ROCKET ="p4";
	public const string BOMB ="p5";
	public const string SLOW_DOWN ="p6";
	
	public const string COLOR_RED ="red";
	public const string COLOR_GREEN ="green";
	public const string COLOR_GRAY ="gray";
	public const string COLOR_ORANGE ="orange";

	private List<LocalAchievment> achievments = null;

	public List<LocalAchievment> getAchievments() { return this.achievments; }

	public Achievments(){
		this.achievments = new List<LocalAchievment> (); 
		//First Try
		achievments.Add(  new LocalAchievment (FIRST_TRY, "First Try",  200, "Get a score of 200.",TYPE_SCORE ) );
		//Lazy
		achievments.Add( new LocalAchievment (LAZY, "Lazy Try" , 500, "Get a score of 500.",TYPE_SCORE ));
		//Beginner
		achievments.Add( new LocalAchievment (BEGINNER, "Beginner", 1000, "Get a score of 1.000.",TYPE_SCORE ) );
		//Bad Aim
		//achievments.Add( new LocalAchievment (BAD_AIM, "Bad Aim" , 200, "Shoot 200 smiles without hitting anything.",TYPE_NO_HIT) );
		//Good
		achievments.Add( new LocalAchievment (GOOD, "Good Enough",3000, "Get a score of 3.000.",TYPE_SCORE ) );
		//Excelent
		achievments.Add( new LocalAchievment (EXCELENT, "Excelent",6000, "Get a score of 6.000.",TYPE_SCORE ) );
		//Game Master
		achievments.Add( new LocalAchievment (MASTER, "Game Master",10000, "Get a score of 10.000.",TYPE_SCORE ) );
		//Defender
		achievments.Add( new LocalAchievment (DEFENDER, "Defender", 50000 , "Get a score of 50.000.",TYPE_SCORE) );
		//Horrible Aim
		//achievments.Add( new LocalAchievment (HORRIBLE_AIM, "Horrible Aim" , 200, "Shoot 1000 smiles without hitting anything.",TYPE_NO_HIT) );
		//		//Color Red
		//		achievments.add( new LocalAchievment (COLOR_RED, "Red Fury" ,1000,"Defeat 1000 red faces.",TYPE_COLOR) );
		//		//Color Green
		//		achievments.add( new LocalAchievment (COLOR_GREEN, "Green Smile" ,500,"Defeat 500 green faces.",TYPE_COLOR) );
		//		//Color Gay
		//		achievments.add( new LocalAchievment (COLOR_GRAY, "Gray " ,500,"Defeat 500 gray faces.",TYPE_COLOR) );
		//		//Color Orange
		//		achievments.add( new LocalAchievment (COLOR_ORANGE, "Orange " ,500,"Defeat 500 orange faces.",TYPE_COLOR) );
		//Powerup 1
		achievments.Add( new LocalAchievment (RAPIDFIRE, "Bang Bang",100,"Use the 'Rapidfire' Powerup" ,TYPE_POWERUP) );
		//Powerup 2
		achievments.Add( new LocalAchievment (MULTIPLIER, "Multiply",100,"Use the 'Multiplier' Powerup",TYPE_POWERUP) );
		//Powerup 3
		achievments.Add( new LocalAchievment (DOUBLE_GUN, "Doubles",100,"Use the 'Double cannon' Powerup",TYPE_POWERUP) );
		//Powerup 4
		achievments.Add( new LocalAchievment (ROCKET, "Skyrocket",100,"Use the 'Rocket' Powerup",TYPE_POWERUP) );
		//Powerup 5
		achievments.Add( new LocalAchievment (BOMB, "Bombs away" ,100,"Use the 'Smile Bomb' Powerup",TYPE_POWERUP) );
		//Powerup 6
		achievments.Add( new LocalAchievment (SLOW_DOWN, "Freeze em all" ,100,"Use the 'Freeze' Powerup",TYPE_POWERUP) );
		//LazyHighScore
		achievments.Add( new LocalAchievment (LAZY_HIGHSCORE, "Lazy Highscore",1000,"Get a Total score of 1.000.",TYPE_TOTAL ));
		//Beginner
		achievments.Add( new LocalAchievment (BEGINNER_HIGHSCORE, "Beginner Highscore",2000, "Get a score of 2.000.",TYPE_TOTAL ) );
		//Good
		achievments.Add( new LocalAchievment (GOOD_HIGHSCORE, "Good Enough Highscore",3000,"Get a Total score of 3.000.",TYPE_TOTAL ) );
		//Excelent
		achievments.Add( new LocalAchievment (EXCELENT_HIGHSCORE, "Excelent Highscore",50000,"Get a Total score of 50.000.",TYPE_TOTAL ) );
		//Game Master
		achievments.Add( new LocalAchievment (MASTER_HIGHSCORE, "Game Master Highscore",150000,"Get a Total score of 150.000.",TYPE_TOTAL ) );
		//Defender
		achievments.Add( new LocalAchievment (DEFENDER_HIGHSCORE, "Defender Highscore",1000000,"Get a Total score of 1.000.000.",TYPE_TOTAL) );
	}

}
