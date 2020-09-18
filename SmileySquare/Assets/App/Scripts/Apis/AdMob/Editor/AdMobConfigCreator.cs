using UnityEngine;
using UnityEditor;

public class AdMobConfigCreator{

	[MenuItem ("Assets/Create/AdMob/AdMobConfig")]
	public static void createAdMobConfig () {
		AdMobConfig config = ScriptableObject.CreateInstance<AdMobConfig> ();
		ProjectWindowUtil.CreateAsset(config, "adMobConfig.asset");
	}
}
