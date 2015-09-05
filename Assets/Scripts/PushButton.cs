using UnityEngine;
using System.Collections;
/// <summary>
/// Pushes the button. Will work on this later.
/// </summary>
public class PushButton : MonoBehaviour {
	private Rigidbody2D rigidBody;

	public GameObject button;

	void Start(){
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		Debug.Log (button.GetComponent<Collider2D> ());
	}

	void Update(){
		checkIfButtonPush ();
	}

	private void checkIfButtonPush(){
		if (Input.GetKeyDown (KeyCode.E)) {
			Debug.Log("E Down.");
			if(rigidBody.IsTouching(button.GetComponent<Collider2D>()))
				Debug.Log("Button Pushed");
		}
	}
}
