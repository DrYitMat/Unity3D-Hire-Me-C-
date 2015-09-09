using UnityEngine;
using System.Collections;

/// <summary>
/// Base class of all Items in the game. 
/// 
/// TODO: Calculate rarity based on type of weapon and player stats. 
/// </summary>
public class Item : MonoBehaviour {

	private bool equiped;

	public bool Equiped {
		get {
			return equiped;
		}
		set {
			equiped = value;
		}
	}

	private ItemType itmType;

	public ItemType ItmType {
		get {
			return itmType;
		}
		set { 
			itmType = value;
		}
	}

	private string itemName;

	public string ItemName {
		get {
			return itemName;
		}
		set {
			itemName = value;
		}
	}

	private bool unique;

	public bool Unique {
		get {
			return unique;
		}
		set {
			unique = value;
		}
	}

	private SpriteRenderer itemSpriteRender;

	public SpriteRenderer ItemSpriteRender {
		get {
			return itemSpriteRender;
		}
		set {
			itemSpriteRender = value;
		}
	}

	/// <summary>
	/// Rarity of item, used to determine how often the items drops.
	/// </summary>
	private float rarity;

	public float Rarity {
		get {
			return rarity;
		}
		set {
			if (value > 0 && value < 1.0f)
				rarity = value;
			else
				Debug.Log ("Value must be between 0 and 1");
		}
	}

	private int levelRequirement = 1;

	public int LevelRequirement {
		get { 
			return levelRequirement;
		}
		set { 
			if (value > 0)
				levelRequirement = value;
			else
				Debug.Log ("Value must be greater than 0");
		}
	}

	private float rarityStat = 10;

	public float RarityStat {
		get {
			return rarityStat;
		}
		set {
			if (value > 0)
				rarityStat = value;
			else
				Debug.Log ("Value must be greater than 0");
		}
	}

	public Item(string itName, ItemType itType, int lvlReq, bool itUnique, float rrityStat){
		ItemName = itName;
		ItmType = itType;
		LevelRequirement = lvlReq;
		Unique = itUnique;
		RarityStat = rrityStat;
		Rarity = LevelRequirement / RarityStat;
		Debug.Log ("Created " + ItmType + " " + ItemName);
	}
}
