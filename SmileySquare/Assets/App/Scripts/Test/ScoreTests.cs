using UnityEngine;
using System.Collections;

public class ScoreTests : MonoBehaviour {

	public int score;
	public int gems;

	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			GameData.updateScore(this.score,this.gems);
			PlayerData lscore = GameData.getData();
			GameData.checkAchievments(lscore);
			string text="POINTS:"+lscore.getPoints() +" TOTAL:"+lscore.getTotalPoints()+"\n";
			text= text + "GEMS:"+lscore.getGems() ;
			Debug.Log(text);
		}

		if(Input.GetKeyDown(KeyCode.S)){
			System.Collections.Generic.List<string> achs = GameData.getData().getAchievments();
			string achsLists="";
			foreach(string ach in achs){ achsLists=achsLists+"["+ach+"]; "; }
			Debug.Log(achsLists);
		}
	}

}