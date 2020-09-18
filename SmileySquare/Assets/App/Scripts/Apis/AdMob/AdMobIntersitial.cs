using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdMobIntersitial : MonoBehaviour {

	public AdMobConfig config;
	public bool initOnly=false;

	void Awake () { 
		if (initOnly==false && AdMobManager.intersitialReady () ) { AdMobManager.createInterstitial(config.AppId); }
		if( initOnly==false){AdMobManager.showIntersitial(); }
	}
}
