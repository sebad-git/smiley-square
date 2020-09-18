using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D)) ]
[RequireComponent (typeof(AudioSource)) ]

public class Character : Damageable {

	public const string TAG="Player";
	public float MOVE_SPEED=15f;
	public float MOBILE_SPEED = 70f;
	//public SpriteRenderer graphic;
	public Animator graphic;
	private float X_AXIS;
	private Gun gun;

	//Flags
	private bool MOBILE;
	private bool locked;

	protected override void createDamageable () {
		this.MOBILE=SystemInfo.deviceType==DeviceType.Handheld;	
		if (this.MOBILE == true) {this.MOVE_SPEED=this.MOBILE_SPEED; }
		gun = gameObject.GetComponent<Gun> ();
	}

	void FixedUpdate () {
		if(this.dead==false && this.locked==false){
			this.readInput(); this.move();
		}
	}

	private void readInput(){ X_AXIS=(MOBILE ? Input.acceleration.x : Input.GetAxis("Horizontal")); }

	private void move(){
			float horizontalSpeed = (this.X_AXIS * this.MOVE_SPEED);
			GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeed, 0);
			//int direction = Mathf.RoundToInt(this.X_AXIS*10); 
			//graphic.SetInteger("state",direction);
	}
	
	protected override void die(){graphic.SetTrigger ("fail"); gun.enabled = false; GetComponent<AudioSource>().Stop(); }

	protected override void getHit(){ }

	public void lockPlayer(bool p_locked){ this.locked = p_locked; }

	public static GameObject getPlayer(){ return GameObject.FindGameObjectWithTag(TAG);} 

	public static Gun getPlayerGun(){ return GameObject.FindGameObjectWithTag(TAG).GetComponent<Gun>(); } 

}
