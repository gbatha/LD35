using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class ShapeShifterController : MonoBehaviour {
	//audio
	[SerializeField]
	AudioClip solidClip;
	[SerializeField]
	AudioClip liquidClip;
	[SerializeField]
	AudioClip gasClip;

	AudioSource sfxSolid;
	AudioSource sfxLiquid;
	AudioSource sfxGas;

	//level specific variables
	[SerializeField]
	int maxShifts = 5;
	int shiftsLeft;

	//state variables
	public float solidSpeed = 10.0f;
	public float liquidSpeed = 6f;
	public float gasSpeed = 2f;

	public float velocityDampingSolid = 5000f;
	public float velocityDampingLiquid = 1f;
	public float velocityDampingGas = .5f;

	//public physics
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;

	//internal physics
	float speed = 10.0f;
	float damping = 5000f;

	//shape physical state variables
	public ShapeMode shape = ShapeMode.Solid;
	float gravityMultiplier = 1f;

	[SerializeField]
	TextMesh numberText;
	[SerializeField]
	Transform leafAnchor;

	[SerializeField]
	ParticleSystem waterParticles;
	[SerializeField]
	GameObject waterBody;
	[SerializeField]
	ParticleSystem gasParticles;
	[SerializeField]
	GameObject solidSprite;
	[SerializeField]
	public CapsuleCollider solidCollider;
	[SerializeField]
	public SphereCollider liquidCollider;
	[SerializeField]
	public CapsuleCollider gasCollider;


	void Awake () {
		GetComponent<Rigidbody> ().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;

		//if we put in practically infinity shifts, just get rid of the thought bubble
		if (maxShifts >= 999) {
			GameObject.Find ("Thought Bubble").SetActive (false);
		}
	}

	void Start(){
		sfxSolid = Utils.AddAudio (gameObject, solidClip, false, false, 1f);
		sfxLiquid = Utils.AddAudio (gameObject, liquidClip, false, false, 0.8f);
		sfxGas = Utils.AddAudio (gameObject, gasClip, false, false, 0.8f);
//		SwitchShape (ShapeMode.Solid, false);
//
//		setShiftsLeft (maxShifts);
		Respawn();
	}

	void Respawn(){
		//change shapes twice to force a state change
		SwitchShape (ShapeMode.Liquid, false);
		SwitchShape (ShapeMode.Solid, false);
		setShiftsLeft (maxShifts);
		transform.position = GameObject.FindGameObjectWithTag ("Respawn").transform.position;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha1) && shape != ShapeMode.Solid) {
			SwitchShape (ShapeMode.Solid);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && shape != ShapeMode.Liquid) {
			SwitchShape (ShapeMode.Liquid);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && shape != ShapeMode.Gas) {
			SwitchShape (ShapeMode.Gas);
		}
	}

	void FixedUpdate () {
		if (grounded || shape == ShapeMode.Gas) {
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0f);

			if (shape == ShapeMode.Gas) {
				targetVelocity.y = Input.GetAxis ("Vertical");
			}

			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;
			//if we're gas and the player isn't inputting, make the damping even harder
			bool playerInput = (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) != Vector2.zero) ? true : false;

			float ourDamping = (shape != ShapeMode.Solid && !playerInput) ? velocityDampingGas / 2f : damping;
			targetVelocity = Vector3.Lerp (GetComponent<Rigidbody> ().velocity, targetVelocity, Time.deltaTime * ourDamping);

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = 0;
			GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump
			if (canJump && Input.GetButton("Jump")) {
				GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		}

		//animate the leaf!!
		float rotZ = 0f;
		Vector3 vel = GetComponent<Rigidbody> ().velocity;
		rotZ = Utils.map (vel.x, -solidSpeed, solidSpeed, 269.7f, 360.89f);
		leafAnchor.localEulerAngles = new Vector3 (leafAnchor.localEulerAngles.x, leafAnchor.localEulerAngles.y, rotZ);

		// We apply gravity manually for more tuning control
		if(!GetComponent<Rigidbody>().useGravity)
			GetComponent<Rigidbody>().AddForce(new Vector3 (0, -calculateGravity() * GetComponent<Rigidbody>().mass, 0));

		grounded = false;
	}

	void OnCollisionStay () {
		grounded = true;    
	}

	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * calculateGravity());
	}

	//returns gravity based on the current state
	float calculateGravity(){
		if (shape == ShapeMode.Gas) {
			return -.2f;
		} else {
			return gravity;
		}
	}

	void setShiftsLeft(int val){
		shiftsLeft = val;
		numberText.text = shiftsLeft.ToString();
	}

	//pass in +1 to shift up, -1 to shift down
	//solid = 0, liquid = 1, gas = 2
	void SwitchShapeBy(int amount){
		int newShape = Mathf.Clamp( (int)shape + amount, 0, 2);
		//make sure we're actually changing
		if(newShape != (int)shape){
			SwitchShape ((ShapeMode)newShape);
		}
	}

	void SwitchShape(ShapeMode shapeIn, bool subtractFromMax = true){
		if (shape != shapeIn) {
			//deactivate everything
			if (shapeIn != ShapeMode.Liquid) {
				Utils.PlayParticleSystem (waterParticles, false);
				waterBody.SetActive (false);
			}
			if (shapeIn != ShapeMode.Gas)
				Utils.PlayParticleSystem (gasParticles, false);
			if (shapeIn != ShapeMode.Solid)
				solidSprite.SendMessage ("setTargetScale", Vector3.zero);

			switch (shapeIn) {
			case ShapeMode.Solid:
				speed = solidSpeed;
				damping = velocityDampingSolid;
				solidSprite.SendMessage ("setTargetScale", Vector3.one);

				solidCollider.enabled = true;
				liquidCollider.enabled = false;
				gasCollider.enabled = false;
				if(subtractFromMax) sfxSolid.Play ();
				break;
			case ShapeMode.Liquid:
				speed = liquidSpeed;
				damping = velocityDampingLiquid;
				Utils.PlayParticleSystem (waterParticles, true);
				waterBody.SetActive (true);

				solidCollider.enabled = false;
				liquidCollider.enabled = true;
				gasCollider.enabled = false;
				if(subtractFromMax) sfxLiquid.Play ();
				break;
			case ShapeMode.Gas:
			//jump!
				Vector3 velocity = GetComponent<Rigidbody> ().velocity;
				GetComponent<Rigidbody> ().velocity = new Vector3 (velocity.x, CalculateJumpVerticalSpeed () * 0.15f, velocity.z);

				speed = gasSpeed;
				damping = velocityDampingGas;
				Utils.PlayParticleSystem (gasParticles, true);

				solidCollider.enabled = false;
				liquidCollider.enabled = false;
				gasCollider.enabled = true;
				if(subtractFromMax) sfxGas.Play ();
				break;
			}

			//set!
			shape = shapeIn;
			if (subtractFromMax) {
				setShiftsLeft (shiftsLeft - 1);
				if (shiftsLeft < 0) {
					Respawn ();
				}
			}
		}
	}
}

public enum ShapeMode{ Solid = 0, Liquid = 1, Gas = 2 };