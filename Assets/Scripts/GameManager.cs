using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager Instance;
	public delegate void gameManagerEvents();
	public delegate void sceneEvents(int level);
	public static event gameManagerEvents eventPlayGame;
	public static event gameManagerEvents eventResumeGame;
	public static event gameManagerEvents eventExitToMenu;
	public static event gameManagerEvents eventPauseGame;
	public static event gameManagerEvents eventLoadMenu;
	public static event gameManagerEvents eventGameOver;
	public static event gameManagerEvents eventRestartGame;
	public static event gameManagerEvents eventlevelFinished;
	public static event gameManagerEvents eventresetLevels;
	public static event sceneEvents eventLoadLevel;

	public bool isGameOver = false;
	public bool isGamePaused = false;
	public bool isGamePlaying = false;
	public bool isOnMenu = true;	 

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
		else if(Instance != null){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	void Start () {

	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(isGamePaused){
				resumeGame();
			}
			else{
				pauseGame();
			}
		}
		if(isOnMenu)
			Time.timeScale = 1;
	}

	public void loadLevel(int level){
		if(eventLoadLevel!=null)eventLoadLevel(level);
		if(eventResumeGame !=null)eventResumeGame();
		isGamePlaying =true;
		isOnMenu = false;
	}
	public void levelFinished(){
		if(eventlevelFinished != null) eventlevelFinished();
	}
	public void playGame(){
		if(eventPlayGame != null) eventPlayGame();
		isGamePlaying =true;
		isOnMenu = false;
	}
	public void showMenu(){
		if(eventLoadMenu != null)eventLoadMenu();
		isOnMenu = true;
	}
	public void pauseGame(){
		if(eventPauseGame != null)eventPauseGame();
		isGamePaused = true;
//		print(palyerManager.Instance.value);
	}
	public void resumeGame(){
		if(eventResumeGame != null)eventResumeGame();
		if(isGameOver) gameOver();
		isGamePaused = false;
	}
	public void restartGame(){
		if(eventRestartGame != null)eventRestartGame();
		isGamePaused = false;
		isGamePlaying = true;
		isGameOver = false;
	}
	public void exitToMenu(){
		if(eventExitToMenu != null)eventExitToMenu();
		isOnMenu = true;
		isGamePlaying = false;
		isGamePaused = false;
	}
	public void gameOver(){
		if(eventGameOver != null)eventGameOver();
		isGameOver = true;
	}
	public void resetLevels(){
		if(eventresetLevels != null) eventresetLevels();
	}
	public void exitToWindows(){
		Application.Quit();
	}
	void OnEnable(){
		palyerManager.eventPlayerDied += gameOver;
		palyerManager.eventPlayerFinishedLevel += levelFinished;
	}
	void OnDisable(){
		palyerManager.eventPlayerDied -= gameOver;
		palyerManager.eventPlayerFinishedLevel -= levelFinished;
		PlayerPrefs.SetInt("unlockedLevel",SceneManager.getUnlockedLevel());
	}


}
