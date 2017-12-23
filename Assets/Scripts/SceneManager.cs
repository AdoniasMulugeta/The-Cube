using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
	private static int currentLevel=1;
	private static int maxLevel = 6;
	private static int unlockedLevel=1;
	void Start(){
		int savedLevel = PlayerPrefs.GetInt("unlockedLevel");
		if(savedLevel==null || savedLevel<1){
			savedLevel=1;
		}
		unlockedLevel = savedLevel;;
		currentLevel = unlockedLevel;
	}
	public static int getCurrentLevel(){
		return currentLevel;
	}
	public static int getMaxLevel(){
		return maxLevel;
	}
	public static int getUnlockedLevel(){
		return unlockedLevel;
	}
	void OnEnable(){
		GameManager.eventExitToMenu += loadMainMenu;
		GameManager.eventPlayGame 	+= loadCurrentLevel;
		GameManager.eventRestartGame += reloadLevel;
		GameManager.eventPauseGame 	+= freezeTime;
		GameManager.eventResumeGame += unfreezeTime;
		GameManager.eventRestartGame += unfreezeTime;
		GameManager.eventPlayGame += unfreezeTime;
		GameManager.eventlevelFinished += loadNextLevel;
		GameManager.eventLoadLevel += loadLevel;
		GameManager.eventresetLevels += resetLevel;
	}
	void OnDisable(){
		GameManager.eventExitToMenu -= loadMainMenu;
		GameManager.eventPlayGame 	-= loadCurrentLevel;
		GameManager.eventRestartGame -= reloadLevel;
		GameManager.eventPauseGame 	-= freezeTime;
		GameManager.eventResumeGame -= unfreezeTime;
		GameManager.eventRestartGame -= unfreezeTime;
		GameManager.eventPlayGame 	-= unfreezeTime;
		GameManager.eventlevelFinished -= loadNextLevel;
		GameManager.eventLoadLevel -= loadLevel;
		GameManager.eventresetLevels -= resetLevel;
	}
	void freezeTime(){
		Time.timeScale = 0;
	}
	void unfreezeTime(){
		Time.timeScale = 1;
	}
	void reloadLevel(){
		loadLevel(Application.loadedLevel);
	}
	void loadMainMenu(){
		Application.LoadLevel(0);
	}
	public void loadLevel(int level){
		if(validLevel(level) && level<=unlockedLevel){
			Application.LoadLevel(level);
			currentLevel = level;
		}
		else{
			Application.LoadLevel(unlockedLevel);
		}
			
	}
	void loadCurrentLevel(){
		if(validLevel(currentLevel)){
			Application.LoadLevel(currentLevel);
		}
	}
	void loadNextLevel(){
		if(validLevel(currentLevel+1)){
			Application.LoadLevel(++currentLevel);
			unlockedLevel = currentLevel>unlockedLevel?currentLevel:unlockedLevel;
		}
	}
	bool validLevel(int level){
		if(level >=0 && level <= maxLevel){
			return true;
		}
		return false;
	}
	void resetLevel(){
		unlockedLevel = 1;
		currentLevel = 1;
	}
}
