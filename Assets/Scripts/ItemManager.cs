using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Will manage and hold all items in game that can be equiped. 
/// </summary>
public class ItemManager : MonoBehaviour {

	private static int MIN_ITEM_GENERATION = 1000;

	public bool rarityMode;

	public List<GameObject> itemObjectList = new List<GameObject> ();

	public List<GameObject> itemObjectDropped = new List<GameObject> ();

	private int itemsToGenerate = MIN_ITEM_GENERATION;

	public int ItemsToGenerate {
		get {
			return itemsToGenerate;
		}
		set {
			if (value >= MIN_ITEM_GENERATION)
				itemsToGenerate = value;
			else
				Debug.Log ("Value must be greater than: " + MIN_ITEM_GENERATION);
		}
	}	

	private List<Item> itemList = new List<Item> ();

	void Init(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		if (rarityMode)
			generateItemsRare (itemsToGenerate);
		else if (!rarityMode)
			generateItems (itemsToGenerate);
	}


	/// <summary>
	/// Two ways of doing this:
	/// 
	/// A: Generate the same number of weapons, sheilds, hats etc and call it a day. 
	/// B: Have a larger number of items to generate and decide what % of this number we are going to generate of
	/// each item type. This allows for better items, are items will likely be rarer. 
	/// </summary>
	/// <param name="itemsGenerate">Items to generate.</param>
	private void generateItems(int itemsGenerate){
		Debug.Log ("Generating items...");
		generateWeapons (itemsGenerate);
		generateShields (itemsGenerate);
		generateHats (itemsGenerate);
	}


	private void generateItemsRare(int itemsGenerate){
		Debug.Log ("Calculating world smithing level...");
		float percentCounter = 0.0f; // out of 1.0
		float a = UnityEngine.Random.Range (.5f, .75f);
		percentCounter += a;
		int weaponsToGen = (int) (itemsGenerate * a);
		generateWeapons (weaponsToGen);
		a = UnityEngine.Random.Range(.1f, (1.0f - a) - .1f);
		percentCounter += a;
		int sheildsToGen = (int)(itemsGenerate * a);
		generateShields (sheildsToGen);
		Debug.Log ("Calculating world creativity level...");
		int hatsToGen = (int)(itemsGenerate * (1.0f - percentCounter));
		generateHats (hatsToGen);
	}

	private void generateWeapons(int weaponsGen){
		Debug.Log ("Forging weapons...");
		Array wpnValues = Enum.GetValues (typeof(Weapons));
		for (int a = 0; a < weaponsGen; a++) {

			string wpnName = "Default Weapon";

			Weapons wpnType = (Weapons) UnityEngine.Random.Range(0, wpnValues.Length);

			int lvl = UnityEngine.Random.Range(1,100);
			float dmg = 10;
		
			float attkSpd = 0.1f;

			switch(wpnType){
			default:
				attkSpd = 1.5f;
				dmg = UnityEngine.Random.Range(15, 15000);
				break;
			case Weapons.Bow:
				attkSpd = 3.0f;
				dmg = UnityEngine.Random.Range(30, 30000);
				break;
			case Weapons.Sword:
				attkSpd = 1.5f;
				dmg = UnityEngine.Random.Range(15, 15000);
				break;
			case Weapons.Mace:
				attkSpd = 2.0f;
				dmg = UnityEngine.Random.Range(20, 20000);
				break;
			case Weapons.Spear:
				attkSpd = 3.5f;
				dmg = UnityEngine.Random.Range(35, 35000);
				break;
			}

			ItemWeapon newWeapon = new ItemWeapon(wpnName, dmg, attkSpd, lvl, false, wpnType);
			itemList.Add(newWeapon);
		}
		//Generate weapons
	}

	private void generateShields(int shieldsGen){
		Debug.Log ("Bracing shields...");
		Array shieldTypes = Enum.GetValues (typeof(Shields));
		for (int a = 0; a < shieldsGen; a++) {
			string shldName = "Default Shield";

			Shields shldType = (Shields) UnityEngine.Random.Range(0, shieldTypes.Length);

			int lvl = UnityEngine.Random.Range(1, 100);
			float armour = 10;

			float dRate = 0.1f;

			switch(shldType) {
			default:
				dRate = .15f;
				armour = UnityEngine.Random.Range(20,20000);
				break;
			case Shields.Kite:
				dRate = .20f;
				armour = UnityEngine.Random.Range(20,20000);
				break;
			case Shields.Round:
				dRate = .15f;
				armour = UnityEngine.Random.Range(15,15000);
				break;
			case Shields.Tower:
				dRate = .25f;
				armour = UnityEngine.Random.Range(25,25000);
				break;
			}

			ItemShield newShield = new ItemShield(shldName, armour, dRate, lvl, shldType, false);
			itemList.Add(newShield);
		}
	}

	private void generateHats(int hatsGen){
		Debug.Log ("Crafting hats...");
		Array hatTypes = Enum.GetValues (typeof(Hats));
		for (int a = 0; a < hatsGen; a++) {
			string hName = "Default Hat";

			Hats hType = (Hats) UnityEngine.Random.Range(0, hatTypes.Length);

			int lvl = UnityEngine.Random.Range(1, 100);
			float armour = 5;

			switch(hType){
			default:
				armour = UnityEngine.Random.Range(5, 5000);
				break;
			case Hats.Full:
				armour = UnityEngine.Random.Range(7.5f, 75000); 
				break;
			case Hats.Helmet:
				armour = UnityEngine.Random.Range(6.25f,5000);
				break;
			case Hats.Vanity:
				armour = UnityEngine.Random.Range(5, 5000);
				break;
			}

			ItemHat newHat = new ItemHat(hName, armour, lvl, hType, false);
			itemList.Add(newHat);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
