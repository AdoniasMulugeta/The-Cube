using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {	
	void OnTriggerEnter(Collider other){
		Debug.Log("coin");
		if(other.gameObject.tag == "Player"){
			Destroy(gameObject);

		}
	}
	
}
