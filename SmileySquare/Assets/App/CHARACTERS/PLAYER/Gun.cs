using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour {
	public GameObject bullet;
	public GameObject rocket;
	[Range(0,2)]public float gunOffset=1.6f;
	[Range(0,2)]public float doubleGunOffset=1.2f;
	[Range(0,2)]public float COOLDOWN=0.22f;
	[Range(0,100)]public float TURBO_TIME=45f;
	private bool turbo;
	private bool doubleCannon;
	private float cooldownTimer;

	//ObjectPool
	private List<GameObject> pool;

	void Start () { 
		pool=new List<GameObject>(); 
		for(int i=0;i<10;i++){
			GameObject nbu = (GameObject)Instantiate(bullet,Vector3.zero,bullet.transform.rotation);
			nbu.SetActive (false); pool.Add(nbu); 
		}
		this.turbo = false; cooldownTimer = COOLDOWN; 
	}
	
	void FixedUpdate () {
//		if (Input.GetMouseButton(0) ) { 
//			if(cooldownTimer >= COOLDOWN){ this.shoot(); if(this.turbo==false){ cooldownTimer=0; } }
//			cooldownTimer = cooldownTimer + Time.fixedDeltaTime; 
//		}
//		else{ cooldownTimer=COOLDOWN; }
		if(cooldownTimer >= COOLDOWN){ this.shoot(); 
		if(this.turbo==false){ cooldownTimer=0; } }
		cooldownTimer = cooldownTimer + Time.fixedDeltaTime; 
	}

	private void shoot(){
		if(this.doubleCannon==false){
			GameObject newBullet=this.getBullet();
			Vector3 shootPos=new Vector3(transform.position.x,transform.position.y+gunOffset,0f);
			newBullet.SetActive(true); newBullet.transform.position=shootPos; 
			if(this.turbo==true){newBullet.GetComponent<AudioSource>().enabled=false;} 
		}else{
			//Bullet1
			Vector3 shootPos=new Vector3(transform.position.x-doubleGunOffset,transform.position.y+gunOffset,0f);
			GameObject newBullet=this.getBullet();
			newBullet.SetActive(true); newBullet.transform.position=shootPos; 
			//Bullet2
			Vector3 shootPos2=new Vector3(transform.position.x+doubleGunOffset,transform.position.y+gunOffset,0f);
			GameObject newBullet2=this.getBullet();
			newBullet2.SetActive(true); newBullet2.transform.position=shootPos2; 
		}
	}

	private GameObject getBullet(){
		foreach (GameObject bu in pool){
			if(!bu.activeInHierarchy){ return bu;}
		}
		GameObject nbu = (GameObject)Instantiate(bullet,Vector3.zero,bullet.transform.rotation);
		nbu.SetActive (false); pool.Add(nbu);
		return nbu;
	}

	public void resetFlags(){
		this.turbo = false; this.doubleCannon = false; 
	}

	public void setRapidfire(){ 
		this.resetFlags();
		this.turbo = true; this.StartCoroutine (this.resetTurbo());
	}

	public IEnumerator resetTurbo(){ yield return new WaitForSeconds(TURBO_TIME); this.turbo = false; }
	public IEnumerator resetDc(){ yield return new WaitForSeconds(TURBO_TIME); this.doubleCannon = false; }

	public void setdoubleCannon(){ 
		this.resetFlags();
		this.doubleCannon = true; this.StartCoroutine (this.resetDc());
	}

	public void shootRocket(){
		Vector3 shootPos=new Vector3(transform.position.x,transform.position.y+gunOffset,0f);
		Instantiate(rocket,shootPos,bullet.transform.rotation);
		cooldownTimer = -1.2f;
	}
}
