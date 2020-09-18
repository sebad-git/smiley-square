using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Collider2D))]
[RequireComponent (typeof (SpriteRenderer))]

public class Square : Damageable {

	public SpriteRenderer next;

	private SquareHolder holderScript;
	private SpriteRenderer image;

	void Awake(){
		image = gameObject.GetComponent<SpriteRenderer>();
		holderScript = transform.root.gameObject.GetComponent<SquareHolder> ();
	}

	protected override void createDamageable(){
		if (next != null) { next.gameObject.SetActive(false); }
		this.INMORTAL = true;
	}

	protected override void die(){ }
	
	protected override void getHit(){ 
		holderScript.updateSquares ();
		image.enabled = true;
		if (next != null) { next.gameObject.SetActive(true); }
		GetComponent<Collider2D>().enabled = false;

	}
}
