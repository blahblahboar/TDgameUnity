using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyMove : MonoBehaviour {
	[HideInInspector]
	public GameObject[] waypoints;
	private int currWaypoint = 0;
	private float lastWaypointTime;
	public float speed = 1.0f; 
	//stores the movement of the enemies


	// turns the enemies
	private void RotateIntoMoveDirection(){
		Vector3 newStart = waypoints [currWaypoint].transform.position;
		Vector3 newEnd = waypoints[currWaypoint+1].transform.position;
		Vector3 newDir = (newEnd - newStart);
		float x = newDir.x;
		float y = newDir.y;
		float rotAngle = Mathf.Atan2 (y, x) * 180 / Mathf.PI;
		GameObject sprite = (GameObject)
			gameObject.transform.Find ("Sprite").gameObject; // change the sprite
		sprite.transform.rotation = Quaternion.AngleAxis (rotAngle, Vector3.forward);
	}


	// Use this for initialization
	void Start () {
		lastWaypointTime = Time.time;
		//set the time for movement as the current time
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 startPos = waypoints [currWaypoint].transform.position; // tracks the path we're on
		Vector3 endPos = waypoints[currWaypoint+1].transform.position; //end
		float length = Vector3.Distance(startPos, endPos);
		float timeOnPath = length / speed;
		float currentTimeOnPath = Time.time - lastWaypointTime; 
		gameObject.transform.position = Vector3.Lerp (startPos, endPos, currentTimeOnPath / timeOnPath); // makes a vector that is the percentage between the position to make our current position there
		if(gameObject.transform.position.Equals(endPos)){
			if(currWaypoint  <waypoints.Length-2){ // haven't reached the end yet
				currWaypoint ++;
				lastWaypointTime = Time.time;
				RotateIntoMoveDirection ();
			}
			else{
				
				AudioSource audioSource = gameObject.GetComponent<AudioSource>();
				AudioSource.PlayClipAtPoint(audioSource.clip, gameObject.transform.position);
				Destroy(gameObject); //kill if at end
				// lower base health TODO
			}
		}
	}
}
