using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData{

	[SerializeField]
	private string id;
	[SerializeField]
	private int points;
	[SerializeField]
	private int totalPoints;
	[SerializeField]
	private int gems;
	[SerializeField]
	private Hashtable powerups;
	[SerializeField]
	private List<string> achievments;

	public PlayerData(string p_id){this.id = p_id; }
	public PlayerData(){this.id = "s1"; }

	public void setPoints(int p_points){ this.points = p_points; }
	public int getPoints(){return this.points; }

	public void setTotalPoints(int p_points){ this.totalPoints = p_points; }
	public int getTotalPoints(){return this.totalPoints; }
	
	public int getGems(){return this.gems; }
	public void setGems(int p_gems){ this.gems = p_gems; }

	public void setId(string p_id){this.id = p_id;}
	public string getId(){return this.id; }
	
	public Hashtable getPowerUps(){ 
		if (this.powerups == null) {this.powerups = new Hashtable(); }
		return this.powerups;
	}

	public List<string> getAchievments(){ 
		if (this.achievments == null) {this.achievments = new List<string>(); }
		return this.achievments;
	}
}
