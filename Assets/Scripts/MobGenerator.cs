using UnityEngine;
using System.Collections;

public class MobGenerator : MonoBehaviour {

	private static int MIN_MOBS_GENERATE = 100;

	private int mobsToGenerate = MIN_MOBS_GENERATE;

	public int MobsToGenerate {
		get {
			return mobsToGenerate;
		}
		set {
			if (value >= MIN_MOBS_GENERATE)
				mobsToGenerate = value;
			else
				Debug.Log ("Value must be greater than: " + MIN_MOBS_GENERATE);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void GenerateMobs(){

	}
}
