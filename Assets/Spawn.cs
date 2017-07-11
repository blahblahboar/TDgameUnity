using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Spawn : MonoBehaviour {
	public GameObject[] waypoints; //recall the array
	public GameObject testPrefab;
	// Use this for initialization
	void Start () {
		Instantiate (testPrefab).GetComponent<EnemyMove> ().waypoints = waypoints;
		// makes a prefab and copies the waypoints from the enemymove script
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
