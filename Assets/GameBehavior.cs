using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameBehavior : MonoBehaviour {
	public Text goldLabel;

	private int gold;
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
