using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (BoxCollider2D))]

public class CharController2d : MonoBehaviour {

	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;


	// Use this for initialization
	void Awake () {
		GetComponent<Rigidbody2D>().freezeRotation = true;
		GetComponent<Rigidbody2D>().gravityScale = 0f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (grounded) {
			// Calculate how fast we should be moving
			Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal"), 0f);

			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;
			Debug.Log (targetVelocity);

			// Apply a force that attempts to reach our target velocity
			Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
			Vector2 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocityChange, maxVelocityChange);
			//			velocityChange.y = 0;

			GetComponent<Rigidbody2D>().AddForce(velocityChange, ForceMode2D.Force);

			// Jump
			if (canJump && Input.GetButton("Jump")) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, CalculateJumpVerticalSpeed());
			}
		}

		// We apply gravity manually for more tuning control
		GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, -gravity * GetComponent<Rigidbody2D>().mass));

		grounded = false;
	}

	void OnCollisionStay2D () {
		grounded = true;    
	}

	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}
