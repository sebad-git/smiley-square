using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Advertisements;

public class MainMenu : AdMobBanner {
	public string unityAdsID;
	public AdMobConfig intersitial;
	public AchievmentsMenu achievmentsWindow;
	public PowerUpsMenu powerUpsWindow;
	
	void Start () {
		Screen.sleepTimeout = SleepTimeout.SystemSetting;
		achievmentsWindow.gameObject.SetActive (false); 
		powerUpsWindow.gameObject.SetActive (false); 
		Advertisement.Initialize (unityAdsID, false );
		AdMobManager.createInterstitial(intersitial.AppId);
	}

	//MAIN MENU
	public void play(){ Application.LoadLevel ( GameScenes.SCENE_LOADING); }

	public void exit(){Application.Quit ();}

	public void showAchievments() { 
		achievmentsWindow.gameObject.SetActive (true); 
		this.achievmentsWindow.loadAchievments(); 
	}

	public void showPowerUps() { 
		powerUpsWindow.gameObject.SetActive (true); 
		this.powerUpsWindow.loadPowerUps();
	}

}
