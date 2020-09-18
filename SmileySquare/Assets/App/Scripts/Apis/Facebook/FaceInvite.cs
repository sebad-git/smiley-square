using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
using System;
using System.Linq;
public abstract class FaceInvite : FaceBase {
	
	public string inviteMessage="";
	public int? maxFriends;
	public string inviteTitle="";
	public string inviteData ="";

	public void facebookInvite(){
		Debug.Log("FBU: inviting");
		this.StartCoroutine (this.publishCorutine());
	}

	protected override void publishAction(){
		FB.AppRequest(
			inviteMessage, null, null, null, maxFriends, 
			inviteData, inviteTitle, inviteCallback );
	}

	protected void inviteCallback (){
		Debug.Log("FBU: Invite ");
		postError = null;
		if (result != null) {
			Dictionary<string, object> responseObject = Json.Deserialize(result.Text) as Dictionary<string, object>;
			object obj = 0;
			if (responseObject.TryGetValue ("cancelled", out obj)) {
				Debug.Log ("FBU: ERROR: Request cancelled");
				this.publishError();
			} else if (responseObject.TryGetValue ("request", out obj)) {
				Debug.Log ("FBU: Invite SUCCESS");
				this.publishSuccess(); 
			}
		} else {
			Debug.Log ("FBU: Invite SUCCESS");
			this.publishSuccess();
		}
	}

}
