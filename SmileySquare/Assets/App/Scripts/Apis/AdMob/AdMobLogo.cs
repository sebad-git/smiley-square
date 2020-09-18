using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdMobLogo : AdMobBanner {
	public CanvasGroup logo;
	public float speed=0.1f;
	
	void Awake () {}
	
	void Start () {logo.alpha = 0; StartCoroutine(load()); }
	
	public IEnumerator load(){
		while(logo.alpha<1){
			logo.alpha=logo.alpha+speed;
			yield return null;
		}
		this.initialize();
		Application.LoadLevel(Application.loadedLevel+1);
	}
}
