using UnityEngine;
using System.Collections;

public class ItemWeapon : Item {

	private static float DMG_MODIFIER = .25f;

	private float baseDamage;
	private float leveledDamage;

	public float LeveledDamage {
		get {
			return leveledDamage;
		}
	}

	private float baseAttackSpeed;

	public float BaseAttackSpeed {
		get {
			return baseAttackSpeed;
		}
	}

	private int lvlRequirement;

	public int LvlRequirement {
		get {
			return lvlRequirement;
		}
	}

	private Weapons weaponType;

	public Weapons WeaponType {
		get {
			return weaponType;
		}
	}

	private string weaponName;

	public string WeaponName {
		get {
			return weaponName;
		}
	}

	private ItemType baseItemType = ItemType.Weapon;

	public ItemWeapon(string wepName, bool wepUnique, Weapons wepType, float dmg, float attkSpeed, int lvlReq) : base(weaponName, baseItemType, wepUnique){
		weaponName = wepName;
		weaponType = wepType;
		baseDamage = dmg;
		baseAttackSpeed = attkSpeed;
		lvlRequirement = lvlReq;
	}

	private float levelDamage(){
		if (lvlRequirement == null || lvlRequirement == 0)
			return 1f;
		else {
			return lvlRequirement * baseDamage * DMG_MODIFIER; 
		}
	}

}
