using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameBehavior : MonoBehaviour {
	public Text goldLabel;
	public Text waveLabel; //wave
	public GameObject[] nextWaveLabels; //array to store next wave
	private int gold;
	public bool gameOver = false;
	private int wave;
	public int Wave {
		get{ return wave; } // curr wave
		set {
			wave = value;
			if (gameOver == false) {
				for (int i = 0; i < nextWaveLabels.Length; i++) {
					nextWaveLabels[i].GetComponent<Animator> ().SetTrigger ("nextWave");
				}
			}
			waveLabel.text = "WAVE: " + (wave + 1);
		}

	}

	public int Gold{
		get{
			return gold;
		}
		set{
			gold = value;
			goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
		}
	}
	// Use this for initialization
	void Start () {
		Gold = 2000;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
