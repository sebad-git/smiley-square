using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class Rocket : MonoBehaviour {

	public float SPEED=1.2f;
	public float DESTROY_AFTER=2.5f;
	
	void Start () {GetComponent<Collider2D>().isTrigger = true; Destroy (gameObject,DESTROY_AFTER); }
	
	void Update () { transform.Translate (Vector2.up * SPEED * Time.deltaTime); }
	
	void OnTriggerEnter2D(Collider2D other) {
		SquareHolder holder = other.transform.root.gameObject.GetComponent<SquareHolder>();
		if (holder != null) {
			holder.kill();
			GetComponent<Collider2D>().enabled = false; Destroy(gameObject); 
		}
	}
	
	
}
