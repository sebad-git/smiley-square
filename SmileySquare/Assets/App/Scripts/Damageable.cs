using UnityEngine;
using System.Collections;

public abstract class Damageable : MonoBehaviour {
	public GameObject hitEffect;
	public float LIFE=100f;
	public bool INMORTAL;
	[HideInInspector]public bool dead;

	void Start () { this.createDamageable(); }
	
	public void damage(float damageValue){
		if (INMORTAL == false) {
			float newLife = this.LIFE - damageValue;
			this.LIFE = (newLife < 0) ? 0 : newLife;
			if (this.LIFE <= 0) {this.dead=true; this.die(); }
			else{ this.getHit(); }
		}else{
			this.getHit();
		}
	}

	protected abstract void createDamageable();
	protected abstract void die();
	protected abstract void getHit();
}
