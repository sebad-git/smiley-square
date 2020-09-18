using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	public float WAIT_TIME=0;

	void Start () {
		this.StartCoroutine (this.loadLevel ());
	}

	private IEnumerator loadLevel(){
		yield return new WaitForSeconds (WAIT_TIME);
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex+1);
	}

}
