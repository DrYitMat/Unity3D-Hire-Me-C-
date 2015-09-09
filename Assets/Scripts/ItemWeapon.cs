using UnityEngine;
using System.Collections;

public class ItemWeapon : Item {

	private static float DMG_MODIFIER = .25f;

	private float baseDamage = 1f;

	public float BaseDamage {
		get {
			return baseDamage;
		}
		set {
			if (value > 0)
				baseDamage = value;
			else
				Debug.Log ("Value must be greater than 0");
		}
	}

	private float leveledDamage = 1f;

	public float LeveledDamage {
		get {
			return leveledDamage;
		}
		set {
			if (value > 0)
				leveledDamage = value;
			else
				Debug.Log ("Value must be greater than 0");
		}
	}

	private float baseAttackSpeed = 1f;

	public float BaseAttackSpeed {
		get {
			return baseAttackSpeed;
		}
		set {
			if (value > 0)
				baseAttackSpeed = value;
			else
				Debug.Log ("Value must be greater than 0");
		}
	}

	private Weapons weaponType;

	public Weapons WeaponType {
		get {
			return weaponType;
		}
		set { 
			weaponType = value;
		}
	}

	private string weaponName;

	public string WeaponName {
		get {
			return weaponName;
		}
		set {
			weaponName = value;
		}
	}

	private static ItemType baseItemType = ItemType.Weapon;

	public ItemWeapon(string wepName, float dmg, float attkSpeed, int lvlReq, bool wepUnique, Weapons wepType) : base(wepName, baseItemType, lvlReq, wepUnique, dmg){
		WeaponName = wepName;
		WeaponType = wepType;
		BaseDamage = dmg;
		BaseAttackSpeed = attkSpeed;
	}

}
