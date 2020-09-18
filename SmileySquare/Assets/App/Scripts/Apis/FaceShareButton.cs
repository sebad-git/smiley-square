using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaceShareButton : FaceShare {

	public CanvasRenderer errorPopup;
	public Text message;

	protected override void initialize () { errorPopup.gameObject.SetActive (false); }

	protected override void errorLogin (){ 
		errorPopup.gameObject.SetActive (true); 
		message.text = "Oops an error has occurred.";
	}

	protected override void publishSuccess(){
		Debug.Log("MSXMSG: Share success.");
	}

	protected override void publishError(){
		errorPopup.gameObject.SetActive (true); 
		message.text = "Oops an error has occurred.";
	}
}
