using UnityEngine;
using System.Collections;

public class palyerManager : MonoBehaviour {
	public static palyerManager Instance; 
	public GameObject deathParticle;
	public delegate void playerEvents();
	public static event playerEvents eventPlayerDied;
	public static event playerEvents eventPlayerFinishedLevel;

	public palyerManager getInstance(){
		if(Instance == null)
			Instance = this;
		return Instance;
	}
	void Awake () {
		if(Instance == null)
			Instance = this;
		else if (Instance != null){
			Destroy(gameObject);
		}
	}
	
	void FixedUpdate () {
		transform.Translate(Input.GetAxis("Horizontal")*0.2f,0,Input.GetAxis("Vertical")*0.2f);
		if(transform.position.y < -1){
			GameManager.Instance.restartGame();
		}
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy"){
			Instantiate(deathParticle,transform.position,transform.rotation);
			if(eventPlayerDied != null)eventPlayerDied();
			Destroy(gameObject);
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Goal"){
			Invoke("playerDied",0.1f);
		}
	}
	void playerDied(){
		if(eventPlayerFinishedLevel != null)eventPlayerFinishedLevel();
	}

}
