using UnityEngine;
using System.Collections;

public class ItemHat : Item {
	
	private float baseArmour = 1.0f;
	
	public float BaseArmour {
		get {
			return baseArmour;
		}
		set {
			if (value > 0)
				baseArmour = value;
			else
				Debug.Log ("Base Armour has to be great");
		}
	}

	private string hatName = "Default Shield";
	
	public string HatName {
		get{
			return hatName;
		}
		set{
			hatName = value;
		}
	}
	
	private Hats hatType = Hats.Full;
	
	public Hats HatType {
		get {
			return hatType;
		}
		set {
			hatType = value;
		}
	}
	
	private static ItemType baseItemType = ItemType.Shield;
	
	public ItemHat(string htName, float bsArmour, int lvlReq, Hats htType, bool sUnique) : base(htName, baseItemType, lvlReq, sUnique, bsArmour){
		HatName = htName;
		BaseArmour = bsArmour;
		HatType = htType;
	}
}
