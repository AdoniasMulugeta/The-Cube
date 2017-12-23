using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	public GameObject gameManager;
	// Use this for initialization
	void Awake () {
		if (!GameObject.FindGameObjectWithTag("GameManager")){
			Instantiate(gameManager,transform.position,transform.rotation);
		}
	}

}
