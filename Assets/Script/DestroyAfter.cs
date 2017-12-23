using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {
	public float timeToWait = 3f;
	void Start () {
		StartCoroutine(destroy(timeToWait));
	}
	IEnumerator destroy(float time){
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}

}
