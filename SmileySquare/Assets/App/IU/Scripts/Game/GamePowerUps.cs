using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePowerUps : MonoBehaviour {
	public Gun playerGun;
	public GamePowerUpUI[] gamePowerUps;
	public GameGUI hud;
	public AudioClip freezeSound;
	public AudioClip bombSound;
	public AudioClip rocketSound;

	private bool created;
	private float normalSpeed;

	void Start () {hud = gameObject.GetComponent<GameGUI> (); created = false; normalSpeed = Time.timeScale; }

	public void updatePowerUps(){
		System.Collections.Generic.List<PowerUp> pwps = GameData.getPowerUps();
		Hashtable mypwps = GameData.getData().getPowerUps();
		for(int i=0;i<pwps.Count; i++){
			PowerUp pwp = pwps[i];
			int owned=(mypwps[pwp.getId()]==null)?0:(int)mypwps[pwp.getId()];
			this.gamePowerUps[i].button.interactable=( (owned>0)? true : false);
			this.gamePowerUps[i].quantity.text=owned.ToString();
			if(created==false){ 
				this.gamePowerUps[i].button.onClick.AddListener( delegate{ usePowerUp(pwp.getId()); } );
			}
		}
		if(pwps.Count>this.gamePowerUps.Length && created==false){
			Debug.LogError("MSXMSG: PowerUps UI missing. PowerUps="+pwps.Count +"PowerUps UI= "+this.gamePowerUps.Length);
		}
		this.created = true;
	}

	public void usePowerUp(string powerUp){ 
		this.hud.powerUpsMenu.gameObject.SetActive (false);
		this.execute(powerUp);
		Time.timeScale=normalSpeed;
	}
	
	public void execute(string powerUpId){ 
		if(powerUpId==PowerUps.RAPIDFIRE){
			playerGun.setRapidfire();
			GameData.unlockAchievment(Achievments.RAPIDFIRE);
			GameData.usePowerUp(powerUpId);
		}
		if(powerUpId==PowerUps.DOUBLE){
			playerGun.setdoubleCannon();
			GameData.unlockAchievment(Achievments.DOUBLE_GUN);
			GameData.usePowerUp(powerUpId);
		}
		if(powerUpId==PowerUps.BOMB){
			this.StartCoroutine(this.explodeBomb(powerUpId));
		}
		if(powerUpId==PowerUps.MULTIPLIER){ 
			hud.multiplierPowerUp();
			GameData.unlockAchievment(Achievments.MULTIPLIER);
			GameData.usePowerUp(powerUpId);
		}

		if(powerUpId==PowerUps.ROCKET){
		//	audio.clip=rocketSound;
		//	audio.Play();
			playerGun.shootRocket();
			GameData.unlockAchievment(Achievments.ROCKET);
			GameData.usePowerUp(powerUpId);
		}
		if(powerUpId==PowerUps.SLOWDOWN){
			GetComponent<AudioSource>().clip=freezeSound;
			GetComponent<AudioSource>().Play();
			this.StartCoroutine(this.slomo());
			GameData.unlockAchievment(Achievments.SLOW_DOWN);
			GameData.usePowerUp(powerUpId);
		}
	}

	private IEnumerator explodeBomb(string powerUpId){
		GetComponent<AudioSource>().clip=bombSound;
		GetComponent<AudioSource>().Play();
		Camera.main.GetComponent<ShakeCamera>().shake();
		GameData.unlockAchievment(Achievments.BOMB);
		GameData.usePowerUp(powerUpId);
		int counter = 0;
		while (counter<30) {
			SquareHolder[] enemies=GameObject.FindObjectsOfType<SquareHolder>();
			foreach(SquareHolder enemy in enemies){ enemy.kill(); }
			yield return new WaitForSeconds (0.05f);
			counter=counter+1;
		}
	}

	private IEnumerator slomo(){
		int counter = 0;
		while (counter<200) {
			SquareHolder[] enemies=GameObject.FindObjectsOfType<SquareHolder>();
			foreach(SquareHolder enemy in enemies){ enemy.slomo(); }
			yield return new WaitForSeconds (0.05f);
			counter=counter+1;
		}
	}
	
}
