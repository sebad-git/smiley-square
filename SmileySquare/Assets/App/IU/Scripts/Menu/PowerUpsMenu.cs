using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PowerUpsMenu : MonoBehaviour {
	public string unityAdsFullVideo;
	public Text gemsText;
	public Text fgGemsText;
	public Button showSkippableButton;
	public Button showFullButton;
	public Button showIntersitialButton;
	public CanvasRenderer freeGemsPanel;
	public PowerUpUI[] powerUps;
	
	private bool created;
	private float updateTimer;

	public void loadPowerUps(){
		int gems = GameData.getData().getGems();
		List<PowerUp> pwps = GameData.getPowerUps();
		for(int i=0;i<pwps.Count; i++){
			PowerUp pwp = pwps[i]; 
			if(this.created==false){
				this.powerUps[i].powerName.text=pwp.getName();
				this.powerUps[i].powerDescription.text=pwp.getDescription();
				//this.powerUps[i].achievmentIcon.gameObject.SetActive(pwp.isUnlocked());
				this.powerUps[i].powerCost.text=pwp.getCost().ToString();
				this.powerUps[i].buyButton.interactable=( (pwp.getCost()>gems)? false : true );
				this.powerUps[i].buyButton.onClick.AddListener( delegate{ buyPowerUp(pwp.getId()); } );
			}
			//mypwps
			this.powerUps[i].ownPowerUps.text=GameData.getPowerUpValue(pwp.getId()).ToString();
			this.powerUps[i].buyButton.interactable=( (pwp.getCost()>gems)? false : true );
		}
		this.gemsText.text = gems.ToString ();
		this.fgGemsText.text = gems.ToString ();

		if(this.created==false){
			if(pwps.Count>powerUps.Length){
				Debug.LogError("MSXMSG: PowerUps UI missing. PowerUps="+pwps.Count +"PowerUps UI= "+powerUps.Length);
			}
			this.createButtons();
		}
		this.created=true;
	}

	//POWERUPS
	public void buyPowerUp(string type){
		GameData.buyPowerUp(type); this.loadPowerUps ();
	}

	public void showSkippableVideo() { 
		if(Advertisement.IsReady()){
			Debug.Log("MSXMSG: Video displaying.");
			Advertisement.Show(); 
			GameData.addGems(50); this.loadPowerUps();
			this.showFullButton.interactable= Advertisement.IsReady();
			this.showSkippableButton.interactable= Advertisement.IsReady(); 
		}else{
			Debug.LogError("MSXMSG: Video not ready.");
		} 
	}
	
	public void showFullVideo() { 
		if(Advertisement.IsReady()){
			Debug.Log("MSXMSG: Video displaying.");
			Advertisement.Show(unityAdsFullVideo);
			GameData.addGems(200); this.loadPowerUps();
			this.updateFGButtons();
		}else{
			Debug.LogError("MSXMSG: Video not ready.");
		}  
	}

	public void showIntersitial() { 
		if(AdMobManager.showIntersitial()){
			Debug.Log("MSXMSG: Intersitial displaying.");
			GameData.addGems(10); this.loadPowerUps();
		}else{
			Debug.LogError("MSXMSG: Intersitial not ready.");
		}
	}

	public void showFreeGemsPanel() {  freeGemsPanel.gameObject.SetActive (true); }

	private void createButtons(){
		freeGemsPanel.gameObject.SetActive (true);
		this.showSkippableButton.GetComponentInChildren<Text>().text="Watch Skipabble video (50)";
		this.showFullButton.GetComponentInChildren<Text>().text="Watch Full video (200)";
		this.showIntersitialButton.GetComponentInChildren<Text>().text="Open Advertisment (10)";
		freeGemsPanel.gameObject.SetActive (false); updateTimer=1.5f;
	}

	private void updateFGButtons(){
		AdMobManager.loadAd();
		//skippable
		this.showSkippableButton.interactable= Advertisement.IsReady();
		//full
		this.showFullButton.interactable= Advertisement.IsReady();
		//inter
		this.showIntersitialButton.interactable= AdMobManager.intersitialReady();
	}

	void Update(){
		if (freeGemsPanel.gameObject.activeSelf) { 
			updateTimer=updateTimer+Time.deltaTime;
			if(updateTimer>1f){ this.updateFGButtons(); updateTimer=0; }
		}
	}
}
