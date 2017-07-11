using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(LineRenderer))]
public class PlaceMonster : MonoBehaviour {
	private GameBehavior gameManager;
	public GameObject monsterPrefab;
	private GameObject monster;
	public int segments = 50;
	public float xradius = 5.0f;
	public float yradius = 5.0f;
	LineRenderer line;
	// Use this for initialization
		
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameBehavior> ();
		line = gameObject.GetComponent<LineRenderer> ();
		line.SetVertexCount (segments + 1);
		line.useWorldSpace = false;
	}

	void CreatePoints(){
		float x, y, z;
		float angle = 20f;
		for (int i = 0; i < (segments + 1); i++) {
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;
			line.SetPosition (i, new Vector3 (x, 0, z));
			angle += (360f / segments);
		}
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
//	void OnMouseOver(){
//		bool hovering;
//		hovering = true;
//		if(hovering){
//			if (monster != null) {
//				CreatePoints ();
//			}
//			if (OnMouseExit()){
//				hovering = false;
//			}
//
//	}
//	}
//	bool OnMouseExit(){
//		return true;
//	}

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
		//gameManager.Gold -= monster.GetComponent<MonsterData> ().CurrentLevel.cost;
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
