using UnityEngine;
using System.Collections;

public class AdMobConfig : ScriptableObject {

	public string AppId = null;
	public enum BannerSize{ BANNER=0, SMART_BANNER=1 };
	public enum BannerPosition{ TOP=0, TOP_LEFT=1, TOP_RIGHT=2, BOTTOM=3, BOTTOM_LEFT=4, BOTTOM_RIGHT=5 };
	public BannerSize bannerSize;
	public BannerPosition bannerPosition;
}
