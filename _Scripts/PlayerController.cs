using UnityEngine;
using System.Collections;



// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.


public class PlayerController : MonoBehaviour
{

	int totalJumpCounter = 0;

	// Does this script currently respond to Input?
	bool canControl = true;
	public Texture[] runTextures;
	public Texture[] jumpTexture;
	public Texture[] attackTexture;
	public	int AnimState = 1; //1 is run.2 is jump ,3 is fall , 4 is attack
	public Material playerMaterial ;
	// The character will spawn at spawnPoint's position when needed.  This could be changed via a script at runtime to implement, e.g. waypoints/savepoints.
	public Transform spawnPoint;
	public float textureSlideCounter ;
	public float runAnimationSpeed ;
	public float jumpAnimatedSpeed;
	public float attackAnimatedSpeed;
	public static bool groundPerHai;

	// Swipe and Tap stuff
	public float minMovement = 20.0f;
	private Vector2 StartPos;
	private int SwipeID = -1;
	public bool jumpButton;
	public bool DoTap = false;

	// Hit Static bool
	public static bool _Hit;


	// static score counter
	public static int scoreCounter;


	public void Start ()
	{
		scoreCounter = 0;
		_Hit = false;
		groundPerHai = true;
	}

	public void  StopPlayerAnimation ()
	{
		AnimState = -1;
	}
	public void  StopAllMovments ()
	{
		movement.runSpeed = 0;
		movement.walkSpeed = 0;
		AnimState = -1;
			
	}
		
		
	void  playAnims ()
	{
		if (AnimState == 1) {
			if (textureSlideCounter > runTextures.Length - 1)
				textureSlideCounter = 0;
				
			playerMaterial.mainTexture = runTextures [Mathf.RoundToInt (textureSlideCounter)];
			textureSlideCounter += runAnimationSpeed * Time.deltaTime;
			if (textureSlideCounter > runTextures.Length)
				textureSlideCounter = 0;
				
		}
		if (AnimState == 2) {
			totalJumpCounter = totalJumpCounter + 1;
			if (totalJumpCounter == 75) {
				PlayerPrefs.SetInt ("8", 1);
			}
			if (textureSlideCounter > jumpTexture.Length - 1)
				textureSlideCounter = 0;
			playerMaterial.mainTexture = jumpTexture [Mathf.RoundToInt (textureSlideCounter)];
			textureSlideCounter += jumpAnimatedSpeed * Time.deltaTime;
			if (textureSlideCounter > jumpTexture.Length)
				textureSlideCounter = 0;
				
			//playerMaterial.mainTexture = jumpTexture;
				
		}
		// attack animation
		if (AnimState == 4) {
			if (textureSlideCounter > attackTexture.Length - 1)
				textureSlideCounter = 0;
			
			playerMaterial.mainTexture = attackTexture [Mathf.RoundToInt (textureSlideCounter)];
			textureSlideCounter += runAnimationSpeed * Time.deltaTime;
			if (textureSlideCounter > attackTexture.Length)
				textureSlideCounter = 0;
			
		}
			
	}
	 
	public  PlatformerControllerMovement movement;

		
	public	PlatformerControllerJumping jump;
	Vector3 lastPosition;
	private CharacterController controller;
		
	// Moving platform support.
	private Transform activePlatform;
	private Vector3 activeLocalPlatformPoint;
	private Vector3 activeGlobalPlatformPoint;
	private Vector3 lastPlatformVelocity;
		
	// This is used to keep track of special effects in UpdateEffects ();
	private bool areEmittersOn = false;
		
	void  Awake ()
	{
		movement.direction = transform.TransformDirection (Vector3.forward);
		controller = GetComponent<CharacterController> ();
		Spawn ();
	}
		
	void  Spawn ()
	{
		// reset the character's speed
		movement.verticalSpeed = 0.0f;
		movement.speed = 0.0f;
			
		// reset the character's position to the spawnPoint
		//transform.position = spawnPoint.position;
			
	}
		
	void  OnDeath ()
	{
		Spawn ();
	}
		
	void  UpdateSmoothedMovementDirection ()
	{	
			
		playAnims ();
			
		float h = Input.GetAxisRaw ("Horizontal");
		h = 1;
		if (!canControl)
			h = 0.0f;
			
		movement.isMoving = Mathf.Abs (h) > 0.1f;
			
		if (movement.isMoving)
			movement.direction = new Vector3 (h, 0, 0);
			
		// Grounded controls
		if (controller.isGrounded) {
			if (AnimState == 2)
				AnimState = 1;
			// Smooth the speed based on the current target direction
			float curSmooth = movement.speedSmoothing * Time.deltaTime;
				
			// Choose target speed
			float targetSpeed = Mathf.Min (Mathf.Abs (h), 1.0f);
				
			// Pick speed modifier
			if (Input.GetButton ("Fire2") && canControl)
				targetSpeed *= movement.runSpeed;
			else {
					
				targetSpeed *= movement.walkSpeed;
			}
				
			movement.speed = Mathf.Lerp (movement.speed, targetSpeed, curSmooth);
				
			movement.hangTime = 0.0f;
		} else {
			// In air controls
			movement.hangTime += Time.deltaTime;
			if (movement.isMoving)
				movement.inAirVelocity += new Vector3 (Mathf.Sign (h), 0, 0) * Time.deltaTime * movement.inAirControlAcceleration;
		}
	}
		
	void  FixedUpdate ()
	{
		// Make sure we are absolutely always in the 2D plane.
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0.2f);

		if (controller.isGrounded) {
			groundPerHai = true;
		} else {
			groundPerHai = false;

		}

	}
		
	void  ApplyJumping ()
	{
		// Prevent jumping too fast after each other
		if (jump.lastTime + jump.repeatTime > Time.time)
			return;
			
		if (controller.isGrounded) {
				
				
				
			// Jump
			// - Only when pressing the button down
			// - With a timeout so you can press the button slightly before landing		
			if (jump.enabled && Time.time < jump.lastButtonTime + jump.timeout) {
				movement.verticalSpeed = CalculateJumpVerticalSpeed (jump.height);
				movement.inAirVelocity = lastPlatformVelocity;
				SendMessage ("DidJump", SendMessageOptions.DontRequireReceiver);
				AnimState = 2;
				SoundController.Static.PlaySingleJumpSound ();
			}
		}
	}
		
	void  ApplyGravity ()
	{
		// Apply gravity


		//  if(Input.GetKeyDown(KeyCode.Mouse0))
		//  {
		//   ApplyJumping();
		//  }
		// 
			
		if (!canControl)
			jumpButton = false;
			
		// When we reach the apex of the jump we send out a message
		if (jump.jumping && !jump.reachedApex && movement.verticalSpeed <= 0.0f) {
			jump.reachedApex = true;
			SendMessage ("DidJumpReachApex", SendMessageOptions.DontRequireReceiver);
		}
			
		// if we are jumping and we press jump button, we do a double jump or
		// if we are falling, we can do a double jump to
		if ((jump.jumping && jumpButton && !jump.doubleJumping) || (!controller.isGrounded && !jump.jumping && !jump.doubleJumping && movement.verticalSpeed < -12.0f)) {
			jump.canDoubleJump = true;
			//Debug.Log("Mouse click detected single jump ");
			SoundController.Static.PlaySingleJumpSound ();
			//sGameObject.FindGameObjectWithTag("SoundController").SendMessage("PlaySingleJumpSound",SendMessageOptions.DontRequireReceiver);
		} 
			
		// if we can do a double jump, and we press the jump button, we do a double jump
		if (jump.canDoubleJump && jumpButton && !IsTouchingCeiling ()) {
			jump.doubleJumping = true;
			movement.verticalSpeed = CalculateJumpVerticalSpeed (jump.doubleJumpHeight);
			//Debug.Log("Mouse click detected double jump");
			//SoundController.Static.PlaySingleJumpSound();
			jump.canDoubleJump = false;
				
		}
		// * When jumping up we don't apply gravity for some time when the user is holding the jump button
		//   This gives more control over jump height by pressing the button longer
		bool extraPowerJump = jump.jumping && !jump.doubleJumping && movement.verticalSpeed > 0.0f && jumpButton && transform.position.y < jump.lastStartHeight + jump.extraHeight && !IsTouchingCeiling ();
			
		if (extraPowerJump)
			return;
		else if (controller.isGrounded) {
			movement.verticalSpeed = -movement.gravity * Time.deltaTime;
			jump.canDoubleJump = false;
		} else
			movement.verticalSpeed -= movement.gravity * Time.deltaTime;
			
		// Make sure we don't fall any faster than maxFallSpeed.  This gives our character a terminal velocity.
		movement.verticalSpeed = Mathf.Max (movement.verticalSpeed, -movement.maxFallSpeed);
	}
		
	float  CalculateJumpVerticalSpeed (float targetJumpHeight)
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt (2 * targetJumpHeight * movement.gravity);
	}
		
	void  DidJump ()
	{
		jump.jumping = true;
		jump.reachedApex = false;
		jump.lastTime = Time.time;
		jump.lastStartHeight = transform.position.y;
		jump.lastButtonTime = -10;
	}
	bool  wereEmittersOn;
	void  UpdateEffects ()
	{
		//	wereEmittersOn = areEmittersOn;
		//	areEmittersOn = jump.jumping && movement.verticalSpeed > 0.0f;
		// 
		//	// By comparing the previous value of areEmittersOn to the new one, we will only update the particle emitters when needed
		//	if (wereEmittersOn != areEmittersOn) {
		//		for (var emitter in GetComponentsInChildren (ParticleEmitter)) {
		//			emitter.emit = areEmittersOn;
		//		}
		//	}
	}

	void SwipeWork ()
	{
		//bool jumpButton = Input.GetKeyDown (KeyCode.Mouse0);
		jumpButton = true;

		if (canControl) {
			jump.lastButtonTime = Time.time;
		}
	}
		
	void  Update ()
	{
		if (AnimState < 0) {
			return;
		}

		if (AnimState == 4) {
			if (!PlayerController._Hit) {
				AnimState = 1;
			}
		}
		//dummy
		/*jumpButton = Input.GetKeyDown (KeyCode.Mouse0);
		if (canControl && jumpButton) {
			_Hit = true;

			jump.lastButtonTime = Time.time;
			//	PlayerAttackColliderObj.GetComponent<BoxCollider2D> ().enabled = true;
		}
		*/

		//dummy
			
		foreach (var T in Input.touches) {
			var P = T.position;
			if (T.phase == TouchPhase.Began && SwipeID == -1) {
				SwipeID = T.fingerId;
				StartPos = P;
			} else if (T.fingerId == SwipeID) {
				var delta = P - StartPos;
				if (T.phase == TouchPhase.Moved && delta.magnitude > minMovement) {
					SwipeID = -1;
					if (Mathf.Abs (delta.x) > Mathf.Abs (delta.y)) {
						jumpButton = false;
					} else {
						if (delta.y > 0) {
							// swipe up
							SwipeWork ();
						}
						jumpButton = false;
					}
				} else if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended) {
					// on tap
					_Hit = true;
					AnimState = 4;

					//jumpButton = false;
					SwipeID = -1;
				
				}
			}
		}

			
			
		UpdateSmoothedMovementDirection ();
			
		// Apply gravity
		// - extra power jump modifies gravity
		ApplyGravity ();
			
		// Apply jumping logic
		ApplyJumping ();
			
		// Moving platform support
		if (activePlatform != null) {
			Vector3 newGlobalPlatformPoint = activePlatform.TransformPoint (activeLocalPlatformPoint);
			Vector3 moveDistance = (newGlobalPlatformPoint - activeGlobalPlatformPoint);
			transform.position = transform.position + moveDistance;
			lastPlatformVelocity = (newGlobalPlatformPoint - activeGlobalPlatformPoint) / Time.deltaTime;
		} else {
			lastPlatformVelocity = Vector3.zero;	
		}
			
		activePlatform = null;
			
		// Save lastPosition for velocity calculation.
		lastPosition = transform.position;
			
		// Calculate actual motion
		Vector3 currentMovementOffset = movement.direction * movement.speed + new  Vector3 (0, movement.verticalSpeed, 0) + movement.inAirVelocity;
			
		// We always want the movement to be framerate independent.  Multiplying by Time.deltaTime does this.
		currentMovementOffset *= Time.deltaTime;
			
		// Move our character!
		movement.collisionFlags = controller.Move (currentMovementOffset);
			
		// Calculate the velocity based on the current and previous position.  
		// This means our velocity will only be the amount the character actually moved as a result of collisions.
		movement.velocity = (transform.position - lastPosition) / Time.deltaTime;
			
		// Moving platforms support
		if (activePlatform != null) {
			activeGlobalPlatformPoint = transform.position;
			activeLocalPlatformPoint = activePlatform.InverseTransformPoint (transform.position);
		}
			
		// Set rotation to the move direction	
		//if (movement.direction.sqrMagnitude > 0.01f)
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (movement.direction), Time.deltaTime * movement.rotationSmoothing);
			
		// We are in jump mode but just became grounded
		if (controller.isGrounded) {
			movement.inAirVelocity = Vector3.zero;
			if (jump.jumping) {
				jump.jumping = false;
				jump.doubleJumping = false;
				jump.canDoubleJump = false;
				SendMessage ("DidLand", SendMessageOptions.DontRequireReceiver);
					
				Vector3 jumpMoveDirection = movement.direction * movement.speed + movement.inAirVelocity;
				if (jumpMoveDirection.sqrMagnitude > 0.01f)
					movement.direction = jumpMoveDirection.normalized;
			}
		}	
			
		// Update special effects like rocket pack particle effects
		UpdateEffects ();
	}
		
	void  OnControllerColliderHit (ControllerColliderHit hit)
	{
		if (hit.moveDirection.y > 0.01f) 
			return;
			
		// Make sure we are really standing on a straight platform
		// Not on the underside of one and not falling down from it either!
		if (hit.moveDirection.y < -0.9f && hit.normal.y > 0.9f) {
			activePlatform = hit.collider.transform;	
		}
	}
		
	// Various helper functions below:
	float  GetSpeed ()
	{
		return movement.speed;
	}
		
	Vector3  GetVelocity ()
	{
		return movement.velocity;
	}
		
		
	bool  IsMoving ()
	{
		return movement.isMoving;
	}
		
	bool  IsJumping ()
	{
		return jump.jumping;
	}
		
	bool  IsDoubleJumping ()
	{
		return jump.doubleJumping;
	}
		
	bool  canDoubleJump ()
	{
		return jump.canDoubleJump;
	}
		
	bool  IsTouchingCeiling ()
	{
		return (movement.collisionFlags & CollisionFlags.CollidedAbove) != 0;
	}
		
	Vector3  GetDirection ()
	{
		return movement.direction;
	}
		
	float  GetHangTime ()
	{
		return movement.hangTime;
	}
		
	void  Reset ()
	{
		gameObject.tag = "Player";
	}
		
	void  SetControllable (bool controllable)
	{
		canControl = controllable;
	}
		
	// Require a character controller to be attached to the same game object
		
}

