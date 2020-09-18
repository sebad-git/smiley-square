using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdMobBanner : MonoBehaviour {

	public AdMobConfig config;
	public bool initOnly=false;

	void Awake () { this.initialize (); }

	protected void initialize(){
		if (AdMobManager.bannerReady()==false ) { this.createBanner(); AdMobManager.HideBanner(); } 
		if( initOnly==false && AdMobManager.isShowingBanner() == false){AdMobManager.ShowBanner(); }
	}

	protected void createBanner(){
		if(AdMobManager.bannerReady()==false){
			AdSize banSize = AdSize.Banner;
				switch(config.bannerSize){
				case AdMobConfig.BannerSize.BANNER: banSize=AdSize.Banner; break;
				case AdMobConfig.BannerSize.SMART_BANNER: banSize=AdSize.SmartBanner; break;
			}
			AdPosition banPosition = AdPosition.Top;
			switch(config.bannerPosition){
				case AdMobConfig.BannerPosition.TOP: banPosition=AdPosition.Top; break;
				case AdMobConfig.BannerPosition.TOP_LEFT: banPosition=AdPosition.TopLeft; break;
				case AdMobConfig.BannerPosition.TOP_RIGHT: banPosition=AdPosition.TopRight; break;
				case AdMobConfig.BannerPosition.BOTTOM: banPosition=AdPosition.Bottom; break;
				case AdMobConfig.BannerPosition.BOTTOM_LEFT: banPosition=AdPosition.BottomLeft; break;
				case AdMobConfig.BannerPosition.BOTTOM_RIGHT: banPosition=AdPosition.BottomRight; break;
			}
			AdMobManager.createBanner(config.AppId,banSize,banPosition);
		}
	}

	void OnDestroy() {
		if (AdMobManager.bannerReady()) { AdMobManager.HideBanner(); }
	}
}
