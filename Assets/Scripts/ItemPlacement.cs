using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemPlacement : MonoBehaviour {
	private RecieveShadows recieveShadows;

	private List<GameObject> placementObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
		recieveShadows = GetComponent<RecieveShadows> ();
		foreach (Transform a in transform) {
			Debug.Log(a.gameObject);
			placementObjects.Add(a.gameObject);
		}
		foreach (GameObject a in placementObjects) {
			recieveShadows = a.AddComponent<RecieveShadows>() as RecieveShadows;
			Debug.Log("Added shadows to: " + a.name);
		}
	}

	/// <summary>
	/// Places the item in the correct position.
	/// </summary>
	/// 
	/// TODO: add logic depending on where item is placed. 
	/// <param name="newSprite">New sprite.</param>
	public void placeItem(Sprite newSprite, ItemType itemType){
		switch (itemType) {
		case ItemType.Weapon:
			placementObjects[0].GetComponent<SpriteRenderer>().sprite = newSprite;
			// weaponLogic();
			break;

		case ItemType.Shield:
			placementObjects[1].GetComponent<SpriteRenderer>().sprite = newSprite;
			// shieldLogic();
			break;

		case ItemType.Hat:
			placementObjects[2].GetComponent<SpriteRenderer>().sprite = newSprite;
			// hatLogic();
			break;

		}
	}
}
