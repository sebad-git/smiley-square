using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	public float DESTROY_TIME=1f;

	void Start () {
		this.StartCoroutine(this.addPoints());
	}

	private IEnumerator addPoints () {
		yield return new WaitForSeconds (DESTROY_TIME);
		GameGUI.getHud().addScore();
		Destroy (gameObject);
	}

}
