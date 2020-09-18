using UnityEngine;
using System.Collections;

public class SqareSpawner : MonoBehaviour {

	public SquareHolder[] sqares;
	public float SPAWN_TIME=1.5f;
	public float MIN_SPEED=1.2f; 
	public float SPEED_MULTIPLIER=0.6f;
	public float INCREASE_SPEED_TIME=15f;
	//PRIVATE
	private float timer; 
	private SquareHolder currentHolder;
	//SPEED

	private float MAX_SPEED;
	private float speedTimer;

	void Start () { timer = SPAWN_TIME + 1; this.MAX_SPEED = this.MIN_SPEED; }

	void Update () {
		this.timer = this.timer + Time.deltaTime;
		this.speedTimer= this.speedTimer + Time.deltaTime;
		if (timer >= SPAWN_TIME && currentHolder==null) {
			SquareHolder holder=sqares[UnityEngine.Random.Range(0,sqares.Length)];
			currentHolder = (SquareHolder)Instantiate(holder,transform.position,transform.rotation);
			float sqareSpeed=UnityEngine.Random.Range(MIN_SPEED, MAX_SPEED);
			currentHolder.MOVE_SPEED=sqareSpeed;
			this.timer=0; 
		}
		if (this.speedTimer >= this.INCREASE_SPEED_TIME) {
			this.MAX_SPEED=this.MAX_SPEED + this.SPEED_MULTIPLIER;
			this.speedTimer=0;
		}
	}
}
