using UnityEngine;
using System.Collections;

public class PowerUp {
	private string id;
	private string name;
	private string description;
	private int cost;

	public PowerUp(string p_id,string p_name,string p_description, int p_Cost){
		this.id = p_id; this.name = p_name; this.description = p_description;
		this.cost = p_Cost;
	}

	public PowerUp(string p_id){ this.id = p_id; }
	
	public PowerUp(){}

	//id
	public string getId(){ return this.id;}
	public void setId(string p_id){ this.id = p_id; }
	//Name
	public void setName(string p_Name){ this.name = p_Name; }
	public string getName(){ return this.name; }
	//description
	public void setDescription(string p_description){ this.description = p_description; }
	public string getDescription(){ return this.description; }
	//Count
	public void setCost(int p_Cost){ this.cost = p_Cost; }
	public int getCost(){ return this.cost; }
	
	public override bool Equals (object obj){
		PowerUp pwp = (PowerUp)obj; return this.id.Equals(pwp.getId());
	}
	
	public override int GetHashCode (){ return this.id.GetHashCode(); }
}
