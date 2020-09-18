using UnityEngine;
using System.Collections;

public class SquareHolder : MonoBehaviour {
	[HideInInspector]public float MOVE_SPEED;
	public int hiddenSqares;  
	public GameObject destroyEffect;
	public Sprite frozen;

	void FixedUpdate () {
		transform.Translate (-Vector2.up * this.MOVE_SPEED * Time.deltaTime);
	}

	public void updateSquares(){
		this.hiddenSqares = this.hiddenSqares - 1;
		if(this.hiddenSqares<=0){
			Instantiate(destroyEffect,transform.position,transform.rotation);
			Destroy(gameObject);
		}
	}

	public void kill(){
		Instantiate(destroyEffect,transform.position,transform.rotation);
		Destroy(gameObject);
	}

	public void slomo(){ 
		SpriteRenderer[] cubes = gameObject.GetComponentsInChildren<SpriteRenderer> ();
		foreach(SpriteRenderer srender in cubes){ srender.sprite=frozen; }
		this.MOVE_SPEED=0.06f; 
	}

}
