using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float SPEED=1.2f;
	public float DESTROY_AFTER=2.5f;
	private float destroyTimer;

	void Update () { 
		transform.Translate (Vector2.up * SPEED * Time.deltaTime); 
		destroyTimer = destroyTimer + Time.deltaTime;
		if(destroyTimer>=DESTROY_AFTER){destroyTimer=0; gameObject.SetActive (false);}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Damageable hitted = other.gameObject.GetComponent<Damageable>(); 
		if (hitted != null) { 
			float DAMAGE = hitted.LIFE+10; hitted.damage(DAMAGE);
			gameObject.SetActive (false);
		}
	}
}
