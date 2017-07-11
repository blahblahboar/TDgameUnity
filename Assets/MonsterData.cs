using System.Collections;
using System.Collections.Generic; // lists
using UnityEngine;




[System.Serializable]
// apparently that lets you edit from inspector

public class MonsterLevel{
	public int cost;
	public GameObject visualization;
}


public class MonsterData : MonoBehaviour {
	public MonsterLevel currentLevel;
	public List<MonsterLevel> levels;
	// levels is our list of monster levels in unity

	void OnEnable(){
		CurrentLevel = levels [0];
			//sets currentlevel on placement of turret to first level
	}
	public MonsterLevel CurrentLevel{
		get{
			return currentLevel;
		}
		set{
			currentLevel = value;
			int currentLevelIndex = levels.IndexOf (currentLevel);
			GameObject levelVisualization = levels [currentLevelIndex].visualization;
			for (int i = 0; i < levels.Count; i++) {
				if (i == currentLevelIndex) {
					levels [i].visualization.SetActive (true);
				} else {
					levels [i].visualization.SetActive (false); // sets the level
				}
			}
		}		
	}
	public void LevelUp(){
		int currentLevelIndex = levels.IndexOf (currentLevel);
		if (currentLevelIndex < levels.Count - 1) {
			CurrentLevel = levels [currentLevelIndex + 1];
		}
		// level up unless too high
	}






	public MonsterLevel NextLevel(){ //returns the next level
		
		int currentLevelIndex = levels.IndexOf (currentLevel); // holds the current level
		int maxLevelIndex = levels.Count-1; //max level -1
		if (currentLevelIndex < maxLevelIndex) {
			return levels [currentLevelIndex + 1]; //next level
		}
		else{
			return null;		
			}
		}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
