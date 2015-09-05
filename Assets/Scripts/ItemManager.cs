using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Will manage and hold all items in game that can be equiped. 
/// </summary>
public class ItemManager : MonoBehaviour {

	public List<GameObject> itemObjectList = new List<GameObject> ();

	public int itemsToGenerate;

	private List<Item> itemList = new List<Item> ();

	void Init(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		generateItems (itemsToGenerate);
	}

	private void generateItems(int itemsGenerate){
		Debug.Log ("Calculating world smithing level...");
		float percentCounter = 0.0f; // out of 10
		float a = Random.Range (5f, 7.5f);
		percentCounter += a;
		int weaponsToGen = (int) itemsGenerate / a;
		generateWeapons (weaponsToGen);
		a = Random.Range(1f, (10f - percentCounter) - 1f);
		percentCounter += a;
		int sheildsToGen = (int)itemsGenerate / a;
		generateShields (sheildsToGen);
		Debug.Log ("Calculating world creativity level...");
		int hatsToGen = (int)itemsGenerate / (10f - percentCounter);
		generateHats (hatsToGen);
	}

	private void generateWeapons(int weaponsGen){
		Debug.Log ("Forging weapons...");
		//Generate weapons
	}

	private void generateShields(int sheildsGen){
		Debug.Log ("Bracing shields...");
		//Generate sheilds
	}

	private void generateHats(int hatsGen){
		Debug.Log ("Crafting hats...");
		//Generate hats.
	}

	// Update is called once per frame
	void Update () {
	
	}
}
