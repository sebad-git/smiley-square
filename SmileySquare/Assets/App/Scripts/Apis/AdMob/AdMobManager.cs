using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdMobManager {

	private static BannerView banner;
	private static InterstitialAd interAd;
	private static bool bannerShowing=false;
	private static AdRequest request;

	//Banner
	public static void createBanner(string appid, AdSize size, AdPosition position){
		banner = new BannerView(appid, size, position);
		if (request == null) { request = new AdRequest.Builder().Build(); }
		banner.LoadAd(request);
		bannerShowing = false;
	}

	public static void ShowBanner(){
		if ( bannerReady() ) { banner.Show(); bannerShowing=true; } 
		else { Debug.LogWarning("Banner not initialized");}
	}

	public static void HideBanner(){
		if ( bannerReady() ) {banner.Hide(); bannerShowing=false; } 
		else {Debug.LogWarning("Banner not initialized");}
	}

	//Intersitial
	public static void createInterstitial(string appid) {
		if(interAd == null){ interAd = new InterstitialAd(appid); }
		if (request == null) { request = new AdRequest.Builder().Build(); }
		interAd.LoadAd(request);
	}

	public static void loadAd() {
		if (interAd.IsLoaded()==false) { interAd.LoadAd(request);  }
	}

	public static bool showIntersitial() {
		if (interAd.IsLoaded()==false) { interAd.LoadAd(request); }
		if ( intersitialReady() ) { interAd.Show(); return true;} 
		else {Debug.LogWarning("Intersitial Ad not initialized");return false; }
	}

	public static bool bannerReady() { return (banner != null); }
	public static bool intersitialReady() { return ((interAd != null) && interAd.IsLoaded()); }
	
	public static bool isShowingBanner() {return bannerShowing; }
}
