using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdMobLoader : AdMobBanner {

	public float waitTime=0;
	
	void Awake () {}

	void Start () { StartCoroutine(load()); }
	
	public IEnumerator load(){
		this.initialize();
		yield return new WaitForSeconds (waitTime);
		Application.LoadLevel(Application.loadedLevel+1);
	}

}
