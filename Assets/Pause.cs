using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	[SerializeField]

	public Transform PauseCanvas;


	// Use this for initialization
	void Start () {
		PauseCanvas.gameObject.SetActive (false);// not pausing yet
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!PauseCanvas.gameObject.activeInHierarchy) {
				PauseGame ();
			} else {
				ContinueGame();
			}
		}

	}
	private void PauseGame(){
		Time.timeScale = 0;
		PauseCanvas.gameObject.SetActive (true);
	}
	private void ContinueGame(){
		Time.timeScale = 1;
		PauseCanvas.gameObject.SetActive(false);
	}
}
