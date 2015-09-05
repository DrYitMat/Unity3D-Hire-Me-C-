using UnityEngine;
using System.Collections;

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

	private ItemType itemType;

	public ItemType ItemType {
		get {
			return itemType;
		}
	}

	private string itemName;

	public string ItemName {
		get {
			return itemName;
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

	private float rarity;

	public float Rarity {
		get {
			return rarity;
		}
		set {
			rarity = value;
		}
	}

	public Item(string itName, ItemType itType, bool itUnique){
		this.itemName = itName;
		this.itemType = itType;
		this.unique = itUnique;
		Debug.Log ("Created " + itemType + " " + itemName);
	}
}
