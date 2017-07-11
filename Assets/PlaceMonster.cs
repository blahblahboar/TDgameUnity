using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlaceMonster : MonoBehaviour {
	private GameBehavior gameManager;
	public GameObject monsterPrefab;
	private GameObject monster;

	// Use this for initialization
		
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameBehavior> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private bool spotEmpty(){
		int cost = monsterPrefab.GetComponent<MonsterData> ().levels [0].cost;
		if (monster == null && gameManager.Gold >= cost) {  // if we have an empty spot and enough money
			return true;
		} else {
			return false;
		}
	}

	void OnMouseUp(){
		if (spotEmpty ()) {
			monster = (GameObject)
				Instantiate (monsterPrefab, transform.position, Quaternion.identity);
			AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
			audioSource.PlayOneShot (audioSource.clip);

		} else if (canUpgradeMonster ()) {
			monster.GetComponent<MonsterData> ().LevelUp(); 
			AudioSource audioSource = gameObject.GetComponent<AudioSource>();
			audioSource.PlayOneShot(audioSource.clip);
		}
		gameManager.Gold -= monster.GetComponent<MonsterData> ().CurrentLevel.cost;
	}

	private bool canUpgradeMonster(){
		if (monster != null) {
			MonsterData monsterData = monster.GetComponent<MonsterData> (); // returns from data
			MonsterLevel nextLevel = monsterData.NextLevel();
			if (nextLevel != null) {
				if (gameManager.Gold  >= nextLevel.cost){
					gameManager.Gold -= monster.GetComponent<MonsterData> ().CurrentLevel.cost;
					return true; // return can upgrade
				}
			}
		}
		return false;
	}
}
