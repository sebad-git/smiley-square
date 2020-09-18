using UnityEngine;
using System.Collections;

public class FallingEffect : MonoBehaviour {

	public float SPAWN_TIME=1.5f;
	public float OFFSET=3f;
	public Rigidbody2D[] sqares;

	private float timer; 

	void Start () {
		timer = SPAWN_TIME;
	}

	void Update () {
		this.timer = this.timer + Time.deltaTime;
		if (timer >= SPAWN_TIME) {
			Rigidbody2D sqare=sqares[UnityEngine.Random.Range(0,sqares.Length)];
			float xPos=transform.position.x + (Random.Range(-OFFSET,OFFSET));
			Vector3 pos=new Vector3(xPos,transform.position.y,0f);
			Instantiate(sqare,pos,transform.rotation);
			this.timer=0;
		}
	}
}
