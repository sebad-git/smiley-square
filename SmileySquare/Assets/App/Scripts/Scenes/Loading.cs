using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	public float WAIT_TIME=0;

	void Start () {
		this.StartCoroutine (this.loadLevel ());
	}

	private IEnumerator loadLevel(){
		yield return new WaitForSeconds (WAIT_TIME);
		Application.LoadLevel ((Application.loadedLevel+1));
	}

}
