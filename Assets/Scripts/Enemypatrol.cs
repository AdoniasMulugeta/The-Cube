using UnityEngine;
using System.Collections;

public class Enemypatrol : MonoBehaviour {

	public Transform[] patrol_points;
	private int count=0;
	public float movespeed;
	private bool forward;
	void Start () {
		transform.position=patrol_points[0].position;

	}
	

	void Update () {
		if(count == 0)forward=true;
		if(count == patrol_points.Length-1)forward=false;
		if (GetComponent<Rigidbody>().position == patrol_points [count].position) {
			if(forward){
				count++;
			}
			else
				count--;
		}
		transform.position = Vector3.MoveTowards (GetComponent<Rigidbody>().position,patrol_points[count].position,movespeed*Time.deltaTime);
	}

}
