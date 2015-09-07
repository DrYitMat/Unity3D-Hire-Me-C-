using UnityEngine;
using System.Collections;

public class ItemShield : Item {

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

	private float deflectRate = .1f;

	public float DeflectRate {
		get{
			return deflectRate;
		}
		set{
			if (value > 0.0f && value < 1.0f)
				deflectRate = value;
			else
				Debug.Log ("Deflect rate must be greater than 1% and less than 100%"); 
		}
	}

	private string shieldName= "Default Shield";

	public string ShieldName {
		get{
			return shieldName;
		}
		set{
			shieldName = value;
		}
	}

	private Shields shieldType = Shields.Kite;

	public Shields ShieldType {
		get {
			return shieldType;
		}
		set {
			shieldType = value;
		}
	}

	private static ItemType baseItemType = ItemType.Shield;

	public ItemShield(string shldName, float bsArmour, float dfltRate, int lvlReq, Shields shldType, bool sUnique) : base(shldName, baseItemType, lvlReq, sUnique){
		ShieldName = shldName;
		BaseArmour = bsArmour;
		DeflectRate = dfltRate;
		ShieldType = shldType;
	}
}
