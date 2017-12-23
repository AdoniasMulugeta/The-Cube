using UnityEngine;
using System.Collections;

public class UI_Manager : MonoBehaviour {
	public GameObject menuUI;
	public GameObject pauseUI;
	public GameObject gameOverUI;
	public GameObject levelsUI;
	public GameObject[] levelButtons;
	public delegate void UIEvents();

	void Start(){
		showMenuUI();
	}
	void OnEnable () {
		GameManager.eventPlayGame += hideMenuUI;
		GameManager.eventPauseGame += showPauseUI;
		GameManager.eventResumeGame += hidePauseUI;
		GameManager.eventLoadMenu += showMenuUI;
		GameManager.eventGameOver += showGameOverUI;
		GameManager.eventExitToMenu += showMenuUI;
		GameManager.eventRestartGame += hideGameOverUI;
		GameManager.eventRestartGame += hidePauseUI;
		GameManager.eventresetLevels += showLevelsUI;

	}
	void OnDisable(){
		GameManager.eventPlayGame -= hideMenuUI;
		GameManager.eventPauseGame -= showPauseUI;
		GameManager.eventResumeGame -= hidePauseUI;
		GameManager.eventLoadMenu -= showMenuUI;
		GameManager.eventGameOver -= showGameOverUI;
		GameManager.eventExitToMenu -= showMenuUI;
		GameManager.eventRestartGame -= hideGameOverUI;
		GameManager.eventRestartGame -= hidePauseUI;
		GameManager.eventresetLevels -= showLevelsUI;

	}
	void Update () {
		if(!GameManager.Instance.isOnMenu){
			levelsUI.SetActive(false);
		}
	}
	public void showLevelsUI(){
		levelsUI.SetActive(true);
		for(int i=0;i<SceneManager.getMaxLevel();i++){
			print("unloaked level:"+SceneManager.getUnlockedLevel());
			if(i+1 <= SceneManager.getUnlockedLevel()){
				levelButtons[i].SetActive(true);
			}
			else{
				levelButtons[i].SetActive(false);
			}
		}

		hideMenuUI();
	}
	public void hideLevelsUI(){
		levelsUI.SetActive(false);
	}
	public void showMenuUI(){
		menuUI.SetActive(true);
		hidePauseUI();
		hideGameOverUI();
		hideLevelsUI();
	}
	public void showPauseUI(){
		if(Application.loadedLevel > 0){
			pauseUI.SetActive(true);
			hideMenuUI();
			hideGameOverUI();
		}
	}
	public void showGameOverUI(){
		if(Application.loadedLevel > 0){
			gameOverUI.SetActive(true);
			hidePauseUI();
		}
	}
	public void hideMenuUI(){
		menuUI.SetActive(false);
	}
	public void hidePauseUI(){
		pauseUI.SetActive(false);
	}
	public void hideGameOverUI(){
		gameOverUI.SetActive(false);
	}
	public void togglePauseUI(){
		if(pauseUI.activeSelf){
			hidePauseUI();
		}else{
			showPauseUI();
		}
	}
		
	private void getInput(){
		if(Input.GetKeyUp(KeyCode.Escape)){
			togglePauseUI();
		}	
	}
}
