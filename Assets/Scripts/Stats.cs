using UnityEngine;
using System.Collections;

/// <summary>
/// Stats for both players and mobs
/// 
/// TODO: Check how the += operates when setting stats, from within class and externally 
/// IE stats.Vitality += 1 VS stats.Vitality = 1 with += in Setter
/// </summary>
public class Stats : MonoBehaviour {

	private static int MIN_STAT = 5;
	private static float LEVEL_UP_MOD = 1250.0f;
	private static float MIN_BASE_MOVEMENT_SPEED = 25.0f;
	private static float DEX_SPEED_MOD = 5.0f;
	private static float MIN_RANGE = 1.0f;
	private static int MIN_HITPOINTS = 100;
	private static float VIT_HITPOINT_MOD = 2.5f;

	private int level;

	public int Level {
		get {
			return level;
		}
		set {
			if ( value >= MIN_STAT)
				level = value;
			else
				Debug.Log ("Value must be greater than: " + MIN_STAT);
		}
	}

	private int strength = MIN_STAT;

	public int Strength {
		get {
			return strength;
		}
		set {
			if (value >= MIN_STAT)
				strength = value;
			else
				Debug.Log ("Value must be greater than: " + MIN_STAT);
		}
	}

	private int dexterity = MIN_STAT;

	/// <summary>
	/// Gets or sets the dexterity.
	/// 
	/// Dexterity also affects movement speed.  
	/// </summary>
	/// <value>The dexterity.</value>
	public int Dexterity {
		get {
			return dexterity;
		}
		set {
			if (value >= MIN_STAT) {
				dexterity = value;
				MovementSpeed = Dexterity * DEX_SPEED_MOD;  // hmmm can I call this from within here?
			}
			else
				Debug.Log ("Value must be greater than: " + MIN_STAT);
		}
	}

	private float movementSpeed = MIN_BASE_MOVEMENT_SPEED;

	/// <summary>
	/// Gets or sets the movement speed.
	/// 
	/// If equipment affect movement speed, it can be added here. 
	/// </summary>
	/// <value>The movement speed.</value>
	public float MovementSpeed {
		get { 
			return movementSpeed;
		}
		set {
			if (value >= MIN_BASE_MOVEMENT_SPEED)
				movementSpeed = value;
			else
				Debug.Log ("Value must be greater than: " + MIN_BASE_MOVEMENT_SPEED);
		}
	}

	private int intelligence = MIN_STAT;

	public int Intelligence {
		get {
			return intelligence;
		}
		set {
			if (value > 0)
				intelligence = value;
			else
				Debug.Log ("Value must be greater than: " + MIN_STAT);
		}
	}

	private int vitality = MIN_STAT;

	public int Vitality {
		get {
			return vitality;
		}
		set {
			if (value > 0) {
				vitality = value;
				HitPoints = (int) Vitality * (int) VIT_HITPOINT_MOD;
			}
			else
				Debug.Log ("Value must be greater than 0");
		}
	}

	private int hitPoints = MIN_HITPOINTS;

	/// <summary>
	/// Gets or sets the hit points.
	/// 
	/// No validation here, we will need to subtract hitPoints
	/// </summary>
	/// <value>The hit points.</value>
	public int HitPoints {
		get { 
			return hitPoints;
		}
		set {
			hitPoints = value;
			CheckAlive();
		}
	}

	private bool alive = true;

	public bool Alive {
		get {
			return alive;
		}
		set {
			alive = value;
		}
	}

	private int pointsToSpend = MIN_STAT;

	public int PointsToSpend {
		get {
			return pointsToSpend;
		}
		set { 
			if (value > 0)
				pointsToSpend = value;
			else
				Debug.Log ("Value must be greater than: " + MIN_STAT);
		}
	}

	private float experiance = 1.0f;

	/// <summary>
	/// Gets or sets the experiance. We will not validate this (currently) because we may want
	/// to subtract experiance; For example, when the player dies. 
	/// </summary>
	/// <value>The experiance.</value>
	public float Experiance {
		get {
			return experiance;
		}
		set {
			experiance += value;
		}
	}

	private float experianceToNextLevel = 1250.0f;

	public float ExperianceToNextLevel {
		get { 
			return experianceToNextLevel;
		}
		set {
			if (value > 0)
				experianceToNextLevel = value;
			else
				Debug.Log ("Value must be greater than 0");
		}
	}

	private float range = 1.0f;

	public float Range {
		get {
			return range;
		}
		set {
			if (value >= MIN_RANGE)
				range = value;
			else
				Debug.Log ("Value must be greater than: " + MIN_STAT);
		}
	}

	public Stats(int lvl, int str, int dxt, int intel, float rnge){
		Level = lvl;
		Strength = str;
		Dexterity = dxt;
		Intelligence = intel;
		Range = rnge;
	}

	public void LevelUp() {
		ExperianceToNextLevel = Level * LEVEL_UP_MOD;
		PointsToSpend = 5;
	}

	public void CheckAlive() {
		if (HitPoints > 0)
			Alive = true;
		else if (HitPoints <= 0)
			Alive = false;
	}
}
