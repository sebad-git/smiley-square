using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour {
	public const string TAG="Hud";
	public CanvasRenderer gameOverMenu;
	public CanvasRenderer pauseMenu;
	public CanvasRenderer quitMenu;
	public CanvasRenderer powerUpsMenu;
	public Text goScoreText;
	public Text goBestScoreText;
	public Text goTotalScoreText;
	public Text goGemsText;
	public Text goTotalGemsText;
	public Text scoreText;
	public Text gemsText;
	public FaceShareButton shareButton;
	public int scoreMultiplier=10;
	private int score;
	private int gems;
	private float normalSpeed;
	private GamePowerUps powerUps;
	private bool duplicateScore;

	private static GameGUI gui;

	void Start () {
		this.gameOverMenu.gameObject.SetActive (false);
		this.pauseMenu.gameObject.SetActive (false);
		this.quitMenu.gameObject.SetActive (false);
		powerUpsMenu.gameObject.SetActive (false);
		powerUps = gameObject.GetComponent<GamePowerUps> ();
		normalSpeed=Time.timeScale;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		duplicateScore = false;
	}
	
	public void retry(){Time.timeScale=normalSpeed; Application.LoadLevel ( GameScenes.SCENE_LOADING); }

	public void exit(){Time.timeScale=normalSpeed; Application.LoadLevel ( GameScenes.SCENE_MENU); }

	public void addScore(){ 
		this.gems = gems + (1 * ( (duplicateScore==true) ? 2 : 1) );
		this.score = this.score + ( this.scoreMultiplier * ( (duplicateScore==true) ? 2 : 1) ); 
		this.scoreText.text = this.score.ToString ();
		this.gemsText.text = this.gems.ToString ();
	}

	public void showGameOver(){ 
		GameData.updateScore(this.score,this.gems);
		PlayerData lscore = GameData.getData();
		GameData.checkAchievments(lscore);
		this.gameOverMenu.gameObject.SetActive (true);
		this.goScoreText.text = this.goScoreText.text+ " " + this.score.ToString ();
		this.goBestScoreText.text = this.goBestScoreText.text + " " + lscore.getPoints().ToString();
		this.goTotalScoreText.text = this.goTotalScoreText.text + " " + lscore.getTotalPoints().ToString();
		this.goGemsText.text = this.goGemsText.text+ " " + this.gems ;
		this.goTotalGemsText.text =this.goTotalGemsText.text+ " " + lscore.getGems();
		this.shareButton.shareMessage = "I have a score of "+this.score.ToString()+" in Smiley Square.";
		Time.timeScale=0;
	}

	public void pauseGame(){ 
		this.pauseMenu.gameObject.SetActive (true);
		Screen.sleepTimeout = SleepTimeout.SystemSetting;
		Time.timeScale=0;
	}

	public void continueGame(){ 
		this.pauseMenu.gameObject.SetActive (false);
		Time.timeScale=normalSpeed;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	public void showPowerUps(){ 
		if (this.powerUpsMenu.gameObject.activeSelf) {
			this.powerUpsMenu.gameObject.SetActive (false);
			Time.timeScale=normalSpeed;
		} else {
			this.powerUpsMenu.gameObject.SetActive (true);
			powerUps.updatePowerUps();
			Time.timeScale=0;
		}
	}

	public static GameGUI getHud(){
		if(gui==null){ gui = GameObject.FindGameObjectWithTag(TAG).GetComponent<GameGUI>();} 
		return gui;
	}

	public void multiplierPowerUp(){ 
		this.StartCoroutine (this.duplicate());
	}

	private IEnumerator duplicate(){ 
		this.duplicateScore = true;
		yield return new WaitForSeconds (15);
		this.duplicateScore = false;
	}
}
