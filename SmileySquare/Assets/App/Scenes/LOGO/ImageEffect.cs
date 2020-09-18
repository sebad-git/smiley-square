using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageEffect : MonoBehaviour {
	//public
	public enum Effect{FILL=0, FADE_IN=1, FADE_OUT=3};
	public Effect effect ;
	public Image spriteImage;
	public float speed=0.1f;
	//private
	private Color fade_in;
	private Color fade_out;

	void Start () {
		fade_in = new Color(1.0f,1.0f,1.0f);
		fade_out = new Color(0f,0f,0f);
		if(effect.Equals(Effect.FILL)){spriteImage.fillAmount=0; StartCoroutine(fill()); } 
		if(effect.Equals(Effect.FADE_IN)){ spriteImage.color = fade_out; StartCoroutine(fadeIn()); }
		if(effect.Equals(Effect.FADE_OUT)){ spriteImage.color = fade_in; StartCoroutine(fadeOut()); }
	}

	public IEnumerator fill(){
		while(spriteImage.fillAmount<1.0f){
			spriteImage.fillAmount=spriteImage.fillAmount+speed;
			yield return null;
		}
	}

	public IEnumerator fadeIn(){
		while(spriteImage.color.r<fade_in.r){
			spriteImage.color = 
				new Color(spriteImage.color.r+speed,
				          spriteImage.color.g+speed,
				          spriteImage.color.b+speed);
			yield return null;
		}
	}

	public IEnumerator fadeOut(){
		while(spriteImage.color.r>fade_out.r){
			spriteImage.color = 
				new Color(spriteImage.color.r-speed,
				          spriteImage.color.g-speed,
				          spriteImage.color.b-speed);
			yield return null;
		}
	}

}
