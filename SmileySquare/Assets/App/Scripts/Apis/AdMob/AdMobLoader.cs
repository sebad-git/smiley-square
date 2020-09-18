using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdMobLoader : AdMobBanner {

	public float waitTime=0;
	
	void Awake () {}

	void Start () { StartCoroutine(load()); }
	
	public IEnumerator load(){
		this.initialize();
		yield return new WaitForSeconds (waitTime);
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex+1);
	}

}
