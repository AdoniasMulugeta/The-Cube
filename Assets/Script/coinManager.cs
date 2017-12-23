using UnityEngine;
using System.Collections;

public class coinManager : MonoBehaviour {
	public float degreeToRotate;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.up,degreeToRotate);
	}
}
