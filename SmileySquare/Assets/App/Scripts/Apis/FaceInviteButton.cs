using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaceInviteButton : FaceInvite {

	public CanvasRenderer errorPopup;
	public Text message;
	public PowerUpsMenu powerups;
	
	protected override void initialize () { 
		errorPopup.gameObject.SetActive (false); 
		this.GetComponent<Button>().GetComponentInChildren<Text>().text="Invite Friends on Facebook (150)";
	}
	
	protected override void errorLogin (){ 
		errorPopup.gameObject.SetActive (true); 
		message.text = "Oops an error has occurred.";
	}
	
	protected override void publishSuccess(){
		Debug.Log("FBU: invite success.");
		GameData.addGems(150); powerups.loadPowerUps();
	}
	
	protected override void publishError(){
		Debug.Log("FBU: invite error: "+this.postError);
		errorPopup.gameObject.SetActive (true); 
		message.text = "Request Cancelled.";
	}
	
}
