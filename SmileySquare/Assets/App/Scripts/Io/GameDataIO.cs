using UnityEngine;
using System.Collections;

public class GameDataIO : MonoBehaviour {

	private const string SCORES_FILENAME="data.sf"; 
	
	public static PlayerData loadData(){
		string path = SaveLoadFile.getDataPath (SCORES_FILENAME);
		PlayerData scoreFile=(PlayerData)SaveLoadFile.loadFile(path);
		if(scoreFile==null){scoreFile = new PlayerData("gd1");}
		return scoreFile;
	}
	
	public static bool saveData(PlayerData scoreFile){
		string path = SaveLoadFile.getDataPath (SCORES_FILENAME);
		bool saved=SaveLoadFile.saveFile(path, scoreFile);
		return saved;
	}
}
