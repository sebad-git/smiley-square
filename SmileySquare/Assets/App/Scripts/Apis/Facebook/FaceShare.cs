using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using Facebook.MiniJSON;

public abstract class FaceShare : FaceBase {

	public string shareMessage="";
	public string shareCaption="";
	public string shareImageUrl="";
	public string shareLinkUrl="";

	public void facebookShare(){
		Debug.Log("FBU: sharing");
		this.StartCoroutine (this.publishCorutine());
	}

	protected override void publishAction(){
/*
		FB.Feed(linkCaption:shareCaption,
		        picture:shareImageUrl,
		        linkName:shareMessage,
		        link:shareLinkUrl,
		        callback:baseCallback);
				*/
	}

}
