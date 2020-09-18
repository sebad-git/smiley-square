using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour {

	public Character player;
	public GameObject gameoverEffect;
	public float gameoverWait=1.8f;
	public GameGUI gui;
	private float normalSpeed;

	void Start(){normalSpeed = Time.timeScale;}

	void OnTriggerEnter2D(Collider2D other) {
		Time.timeScale=normalSpeed;
		player.damage (player.LIFE + 10);
		GetComponent<Collider2D>().enabled = false;
		Instantiate(this.gameoverEffect,Vector3.zero,transform.rotation);
		gameObject.GetComponent<Collider2D>().enabled = false;
		this.StartCoroutine (this.showGameOver());
	}

	private IEnumerator showGameOver(){
		yield return new WaitForSeconds (gameoverWait);
		gui.showGameOver ();
	}
}
