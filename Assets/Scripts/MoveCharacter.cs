using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	public int direction = 0;

	public float jumpHeight = 10f;
	public float speed = 2f;

	private float step = 0.0f;

	private bool canJump = true;

	private Rigidbody2D rigidBody;

	private Vector2 velocity;

	private GameObject ground;
	private Collider2D groundCol;

	// Use this for initialization
	void Start () {
		velocity = Vector2.zero;
		rigidBody = GetComponent<Rigidbody2D> ();
		ground = GameObject.FindGameObjectWithTag ("Ground");
		groundCol = ground.GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		checkInput (dt);
		checkCanJump ();
	}

	/// <summary>
	/// Using RigidBody2D for 'realistic' movement.
	/// </summary>
	/// <param name="delta">Delta.</param>
	private void checkInput(float delta){

		step = speed * delta;

		if (Input.GetKey (KeyCode.A)) {
			direction = 1;
			rigidBody.AddForce(Vector2.left * speed);
		}

		if (Input.GetKey (KeyCode.D)) {
			direction = 2;
			rigidBody.AddForce(Vector2.right * speed);
		}

		if (canJump) {
			if (Input.GetKeyDown (KeyCode.W)) {
				direction = 3;
				rigidBody.AddForce(Vector2.up * jumpHeight);
			}
		}

		direction = 0;
	}

	private void checkCanJump(){
		if (rigidBody.IsTouching (groundCol)) {
			canJump = true;
		} else {
			canJump = false;
		}
	}
}
