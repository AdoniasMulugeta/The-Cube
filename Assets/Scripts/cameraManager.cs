using UnityEngine;
using System.Collections;

public class cameraManager : MonoBehaviour {
	private GameObject player;
	public Vector3 offset;

	void Start () {
		transform.rotation = Quaternion.Euler(new Vector3(40,0,0));
		offset = new Vector3(0,7,-6);
		init ();
	}
	void init(){
		if(player == null){
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}

	void Update () {
		if(player != null)
			followObject();
		GetComponent<Camera>().fieldOfView -= (Input.GetAxis("Mouse ScrollWheel")*5);
	}
	void followObject(){
		transform.position = player.transform.position + offset;
	}
}
