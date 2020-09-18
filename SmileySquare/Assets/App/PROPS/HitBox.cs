using UnityEngine;
using System.Collections;

public abstract class HitBox : MonoBehaviour {

	public float DAMAGE=5f;
	public bool KILL_ON_TOUCH=false;
	public bool USE_ROOT=true;

	void OnTriggerEnter2D(Collider2D other) {
		Damageable hitted = null;
		if(USE_ROOT==true){ hitted=other.transform.root.gameObject.GetComponent<Damageable>(); }
		else{ hitted=other.gameObject.GetComponent<Damageable>();  }
		if (hitted != null) { this.onHit(hitted); }
	}

	protected abstract void onHit(Damageable hitted);
}
