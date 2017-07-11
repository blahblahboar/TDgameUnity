using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	[SerializeField]

	public Transform canvas;

	// Use this for initialization
	void Start () {
		canvas.gameObject.SetActive (false);// not pausing yet
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!canvas.gameObject.activeInHierarchy) {
				PauseGame ();
			} else {
				ContinueGame();
			}
		
		}
	}
	private void PauseGame(){
		Time.timeScale = 0;
		canvas.gameObject.SetActive (true);
	}
	private void ContinueGame(){
		Time.timeScale = 1;
		canvas.gameObject.SetActive(false);
	}
}
