using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData {

	public const int POWERUP_ERROR=-1;
	public const int POWERUP_EXPENSIVE=1;
	public const int POWERUP_SUCCESS=0;
	public const int POWERUP_EMPTY=2;
	public const int POWERUP_ZERO=3;

	private static PlayerData data = null;
	private static PowerUps powerUps = null;
	private static Achievments achievments = null;

	public static PlayerData getData() { 
		if(GameData.data==null){ createData(); }
		return GameData.data; 
	}

	public static List<PowerUp> getPowerUps() { 
		if(powerUps == null ){ powerUps = new PowerUps (); }
		return powerUps.getPowerUps (); 
	}
	public static List<LocalAchievment> getAchievments() { 
		if(achievments ==null){achievments = new Achievments();}
		return achievments.getAchievments(); 
	}

	public static void save(){
		GameDataIO.saveData (GameData.data);
		GameData.data = GameDataIO.loadData ();
	}

	private static void createData(){
		GameData.data = GameDataIO.loadData();
		data.setId("sd1");
		GameData.save();
	}

	public static void updateScore(int points, int gems) {
		GameData.getData().setTotalPoints( (data.getTotalPoints()+points) );
		if (points > GameData.getData().getPoints()) { GameData.getData().setPoints(points); }
		GameData.getData().setGems( (GameData.getData().getGems()+ gems) );
		GameData.save();
	}

	public static void addGems(int gems) {
		GameData.getData().setGems( (GameData.getData().getGems()+ gems) );
		GameData.save();
	}

	//ACHIEVMENTS
	public static bool unlockAchievment(string aId){
		if (GameData.getData().getAchievments().Contains(aId) == false ) {
			GameData.getData().getAchievments().Add(aId);
			return true;
		}
		return false;
	}

	public static bool isAchievmentUnlocked(string aId){
		return GameData.getData().getAchievments().Contains (aId);
	}

	public static void checkAchievments(int score,int totalScore ){ 
		foreach(LocalAchievment lac in getAchievments()){
			//Normal Score
			if(lac.getValueType()==Achievments.TYPE_SCORE){
				if (score >= lac.getUnlockValue()) { GameData.unlockAchievment(lac.getId()); }
			}
			//Total Score
			if(lac.getValueType()== Achievments.TYPE_TOTAL){
				if (totalScore >= lac.getUnlockValue()) { GameData.unlockAchievment(lac.getId()); }
			}
		}
		GameData.save();
	}
	
	public static void checkAchievments(PlayerData lscore){ 
		checkAchievments (lscore.getPoints(), lscore.getTotalPoints());
	}

	public static int buyPowerUp(string p_id) {
		int index = GameData.getPowerUps().IndexOf(new PowerUp(p_id));
		//Not found
		if(index<0){ Debug.LogWarning("MSXMSG: Powerup not Found."); return POWERUP_ERROR; }
		PowerUp pw = GameData.getPowerUps()[index];
		//Buy and save
		return GameData.addPowerUp(pw.getCost(), pw.getId());
	}
	
	private static int addPowerUp(int p_cost, string pw){
		int gems = GameData.getData().getGems ();
		if (p_cost <= gems) { 
			gems = gems - p_cost;
			object value=GameData.getData().getPowerUps()[pw];
			if(value==null){ GameData.getData().getPowerUps().Add(pw,1); }
			else{ GameData.getData().getPowerUps()[pw] =( ((int)value)+1 ); }
			GameData.getData().setGems(gems);
			GameData.save();
			return POWERUP_SUCCESS;
		}
		Debug.LogWarning("MSXMSG: Too expensive."); return POWERUP_EXPENSIVE; 
	}

	public static int usePowerUp(string p_id) {
		object value=GameData.getData().getPowerUps()[p_id];
		if(value!=null){ 
			if(((int)value)>0){
				GameData.getData().getPowerUps()[p_id] =( ((int)value)-1 ); 
				GameData.save();
				return POWERUP_SUCCESS;
			}
			else{ return POWERUP_ZERO; }
		}
		return POWERUP_EMPTY;
	}

	public static int getPowerUpValue(string id){
		object oValue = GameData.getData().getPowerUps()[id];
		if (oValue == null) {return 0;} return (int)oValue;
	}
}
