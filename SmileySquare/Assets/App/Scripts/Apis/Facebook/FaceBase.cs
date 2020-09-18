using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public abstract class FaceBase : MonoBehaviour {

	public int loginTimeout = 300;

	protected string loginMessage;
	protected string postError;

	void Start () {
		//FB.Init(OnInitComplete, OnHideUnity);
		this.initialize();
	}

	protected void OnInitComplete() { 
		/*
		Debug.Log("FB.Init completed: Is user logged in? " + FB.IsLoggedIn); 
		*/
		}
	protected void OnHideUnity(bool isGameShown) { 
		/*
		Debug.Log("Is game showing? " + isGameShown); 
		*/
		}

	
	protected void facebookLogin() {
		/*
		FB.LogInWithReadPermissions("public_profile,email,user_friends", LoginCallback);
		*/
	}
	
	/*
	private void LoginCallback(IResult result){
		if (result.Error != null) { loginMessage = "Error Response:\n" + result.Error; } 
		else if (!FB.IsLoggedIn) { loginMessage = "Login cancelled by Player"; }
		else { loginMessage = "Login was successful!"; }
		Debug.Log("FBU: "+loginMessage);
	}
	*/

/*
	protected void baseCallback(ILoginResult result){
		postError = null;
		if (!String.IsNullOrEmpty (result.Error)){
			postError = "Error Response:" + result.Error;
			Debug.Log("FBU: "+postError);
			this.publishError(); 
		}
		else { 
			Debug.Log("FBU: SUCCESS ="+result.Text); 
			this.publishSuccess();
		}
	}
*/
	protected IEnumerator publishCorutine(){
		/*
		if(FB.IsLoggedIn==false){ Debug.Log("FBU: logging in"); this.facebookLogin();  }
		int counter = 0; 
		bool loggedIn=false;
		while( (counter<loginTimeout) && loggedIn==false){
			counter=counter+1;
			Debug.Log("FBU: Time "+(counter/60).ToString()+"/"+(loginTimeout/60).ToString());
			loggedIn=FB.IsLoggedIn;
			if(loggedIn==false){ yield return new WaitForSeconds(1f); }
			else{yield return null; }
		}
		if (loggedIn) {
			this.publishAction();
		}else{
			postError="Login Timeout.";
			Debug.Log("FBU: Login Timeout."); 
			this.publishError(); 
		}
		*/
		yield return null;
	}
	
	//ABSTRACT
	protected abstract void initialize();
	protected abstract void errorLogin ();
	protected abstract void publishAction();
	protected abstract void publishSuccess();
	protected abstract void publishError();

}
