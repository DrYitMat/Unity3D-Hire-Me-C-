using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

	private static Vector3 BASE_SPAWN_POS = new Vector3 (0, 0, 0);

	private GameObject player;
	private ItemManager itemManager;

	private ItemPlacement itemPlacer;

	private Rigidbody2D rigidBody;

	private Vector3 spawnPosition = BASE_SPAWN_POS;

	public Vector3 SpawnPosition {
		get {
			return spawnPosition;
		}
		set {
			spawnPosition = value;
		}
	}

	private Stats mobStats;

	public Stats MobStats {
		get { 
			return mobStats;
		}
		set {
			mobStats = value;
		}
	}	

	private string mobName;

	public string MobName {
		get {
			return mobName;
		}
		set {
			mobName = value;
		}
	}

	private AttackTypes attackType;

	public AttackTypes AttackType {
		get {
			return attackType;
		}
		set {
			attackType = value;
		}
	}

	private MobTypes mobType;

	public MobTypes MobType {
		get {
			return mobType;
		}
		set {
			mobType = value;
		}
	}	

	private bool canPickUpItems = true;

	public bool CanPickUpItems {
		get {
			return canPickUpItems;
		}
		set {
			canPickUpItems = value;
		}
	}

	private bool canSeePlayer = false;

	public bool CanSeePlayer {
		get {
			return canSeePlayer;
		}
		set {
			canSeePlayer = value;
		}
	}

	private float step = 0.0f;

	public Mob(string mbName, Stats stats, bool pickUp, AttackTypes attkType, MobTypes mbType){
		MobName = mbName;
		MobStats = stats;
		CanPickUpItems = pickUp;
		AttackType = attkType;
		MobType = mbType;
		player = GameObject.FindGameObjectWithTag ("Player");
		itemManager = GameObject.FindGameObjectWithTag ("ItemManager").GetComponent<ItemManager> ();
		itemPlacer = new ItemPlacement ();
	}

	// Check distance between player and mob, if distance <= Range, launch attack. 
	private void Attack(){
		if (player != null) {
			if (Vector3.Distance (transform.position, player.transform.position) <= MobStats.Range) {
				switch (AttackType) {
				default:
					break;
				case AttackTypes.Melee:
					Debug.Log("Melee attack");
					break;
				case AttackTypes.Bow:
					Debug.Log("Bow attack");
					break;
				case AttackTypes.Magic:
					Debug.Log("Magic attack");
					break;
				}
			} else {
				Vector3.MoveTowards(transform.position, player.transform.position, step);
			}
		}
	}

	private void PickUpWeapons() {
		if (itemManager != null) {
			float closestDist = float.MaxValue;
			GameObject closestObject = itemManager.itemObjectDropped[0];
			foreach (GameObject a in itemManager.itemObjectDropped) {
				float newDist = Vector3.Distance(transform.position, a.transform.position);
				if(newDist < closestDist) {
					closestDist = newDist;
					closestObject = a;
				}
			}
			Vector3.MoveTowards(transform.position, closestObject.transform.position, step);
		}
	}


	void Update(){
		step = Time.deltaTime * MobStats.MovementSpeed;
		if (MobStats.Alive) {
			if (CanSeePlayer)
				Attack ();
			else
				PickUpWeapons ();
		}
	}
}
