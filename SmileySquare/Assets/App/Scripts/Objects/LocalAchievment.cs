using UnityEngine;
using System.Collections;

public class LocalAchievment {
	private string id;
	private string name;
	[SerializeField]
	private string description;
	private string gpsId;
	private int unlockValue;
	private int valueType;

	public LocalAchievment(string p_id,string p_gpsId, string p_name, int p_unlockValue, string p_description, int p_valueType){
		this.id = p_id; this.gpsId = p_gpsId; this.name = p_name; this.description = p_description;
		this.unlockValue = p_unlockValue;  this.valueType= p_valueType;
	}

	public LocalAchievment(string p_id, string p_name, int p_unlockValue, string p_description, int p_valueType){
		this.id = p_id;  this.name = p_name; this.description = p_description;
		this.unlockValue = p_unlockValue;  this.valueType= p_valueType;
	}

	public LocalAchievment(string p_id){ this.id = p_id; }

	public LocalAchievment(){}

	//id
	public string getId(){ return this.id;}
	public void setId(string p_id){ this.id = p_id; }
	//Name
	public void setName(string p_Name){ this.name = p_Name; }
	public string getName(){ return this.name; }
	//description
	public void setDescription(string p_description){ this.description = p_description; }
	public string getDescription(){ return this.description; }
	//Google Play
	public void setGpsId(string p_gpsId){ this.gpsId = p_gpsId; }
	public string getGpsId(){ return this.gpsId; }
	// Unlock Value
	public void setUnlockValue(int p_unlockValue){ this.unlockValue = p_unlockValue; }
	public int getUnlockValue(){ return this.unlockValue; }
	//Value type
	public void setValueType(int p_ValueType){ this.valueType = p_ValueType; }
	public int getValueType(){ return this.valueType; }

	public override bool Equals (object obj){
		LocalAchievment ach = (LocalAchievment)obj;
		return this.id.Equals(ach.getId());
	}

	public override int GetHashCode (){ return this.id.GetHashCode(); }

}
