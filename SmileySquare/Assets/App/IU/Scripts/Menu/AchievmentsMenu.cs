using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AchievmentsMenu : MonoBehaviour {
	public Button forwardButton;
	public Button backButton;

	private int page;
	private List<LocalAchievment> lacs;
	private int pageSize;
	private AchievmentUI[] achievments;
	
	void Start(){
		achievments = GetComponentsInChildren<AchievmentUI>();
		this.pageSize = achievments.Length;
		lacs = GameData.getAchievments();
		this.loadAchievments();
	}
	
	public void loadAchievments(){
		if(lacs!=null){
			int from = (page*pageSize);
			int to = ((page+1)*pageSize);
			if (to > lacs.Count) {to=lacs.Count; }
			for(int a=0;a<pageSize; a++){
				this.achievments[a].gameObject.SetActive(false);
			}
			//load
			int achId = 0;
			for(int i=from;i<to; i++){
				LocalAchievment lac = lacs[i]; 
				this.achievments[achId].gameObject.SetActive(true);
				this.achievments[achId].achievmentName.text=lac.getName();
				this.achievments[achId].achievmentDescription.text=lac.getDescription();
				if(GameData.isAchievmentUnlocked(lac.getId())){
					achievments[achId].achievmentIcon.gameObject.SetActive(true);
				}
				achId=achId+1;
			}
			this.chechButtons ();
		}
	}

	private void chechButtons(){
		backButton.interactable=true;
		forwardButton.interactable=true;
		if (page <= 0) {backButton.interactable=false;; page=0; }
		if ( ( (page+1)*pageSize ) >= (lacs.Count-1)) {forwardButton.interactable=false; }
	}
	
	public void next(){
		int nextPage = page + 1; 
		if((nextPage*pageSize) <= (lacs.Count-1)){ 
			page=nextPage; this.loadAchievments();
		} 
		this.chechButtons ();
	}
	
	public void previus(){
		int prevPage = page - 1; 
		if(prevPage >= 0){ 
			page=prevPage; this.loadAchievments();
		} 
		this.chechButtons ();
	}
}
