using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : AdMobBanner {
	public string unityAdsID;
	public AdMobConfig intersitial;
	public AchievmentsMenu achievmentsWindow;
	public PowerUpsMenu powerUpsWindow;
	
	private AudioSource menuSounds;
	
	void Start () {
		this.menuSounds= GetComponent<AudioSource>();
		Screen.sleepTimeout = SleepTimeout.SystemSetting;
		achievmentsWindow.gameObject.SetActive (false); 
		powerUpsWindow.gameObject.SetActive (false); 
		Advertisement.Initialize (unityAdsID, false );
		AdMobManager.createInterstitial(intersitial.AppId);
	}

	private void PlaySelectedSound(){ this.menuSounds.Play(); }

	//MAIN MENU
	public void StartGame(){ 
		this.PlaySelectedSound();
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex+1);
	}

	public void Exit(){ this.PlaySelectedSound(); Application.Quit();}

	public void ShowAchievments() { 
		this.PlaySelectedSound();
		achievmentsWindow.gameObject.SetActive (true); 
		this.achievmentsWindow.loadAchievments(); 
	}

	public void ShowPowerUps() {
		this.PlaySelectedSound();
		powerUpsWindow.gameObject.SetActive (true); 
		this.powerUpsWindow.loadPowerUps();
	}

}
