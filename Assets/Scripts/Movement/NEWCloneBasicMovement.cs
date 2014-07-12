using UnityEngine;
using System.Collections;
using System;

public class NEWCloneBasicMovement : MonoBehaviour
{
	public event Action groundedValueChanged;
	public event Action stopMoving;
	public event Action startMovingLeft;
	public event Action startMovingRight;
	
	public float speed = 100.0f;
	public float jumpForce = 100.0f;
	public float airModifier = 0.5f;
	public float flylag = 0.5f;
	public LayerMask groundLayer;
	public bool amMoving = false;
	private bool mygrounded = false;
	protected bool blockLeftCollision = false;
	protected bool blockRightCollision = false;
	private float prevMovement = 0;
	
	public bool grounded {
		get{ return mygrounded;} 
		set {
			if (mygrounded != value) {
				mygrounded = value; 
				this.groundedValueChanged ();
			}
		}
	}
	
	[HideInInspector]
	public float topBoundary;
	[HideInInspector]
	public float bottomBoundary;
	[HideInInspector]
	public float leftBoundary;
	[HideInInspector]
	public float rightBoundary;
	
	void Awake ()
	{
		this.rigidbody.freezeRotation = true;
		groundedValueChanged = (() => {});
		stopMoving = (() => {});
		startMovingLeft = (() => {});
		startMovingRight = (() => {});
	}
	
	// Use this for initialization
	protected virtual void Start ()
	{
		OTSprite spriteData = gameObject.GetComponent<OTSprite> ();
		BoxCollider bCollider = gameObject.GetComponent<BoxCollider> ();
		topBoundary = ((spriteData.size.y / 2) * bCollider.size.y) + (spriteData.size.y * bCollider.center.y);
		bottomBoundary = ((-spriteData.size.y / 2) * bCollider.size.y) + (spriteData.size.y * bCollider.center.y);
		leftBoundary = ((-spriteData.size.x / 2) * bCollider.size.x) + (spriteData.size.x * bCollider.center.x);
		rightBoundary = ((spriteData.size.x / 2) * bCollider.size.x) + (spriteData.size.x * bCollider.center.x);
	}
	
	// Update is called once per frame
	public virtual void Update ()
	{
		updateRaycasts ();
	
		//is the user pressing left or right (or "a & "d") on the keyboard?    
		Vector3 horMovement = Input.GetAxis ("Horizontal") * transform.right * Time.deltaTime * speed;
			
		//is the user pressing up or down (or "w" & "s") on the keyboard?
		Vector3 forwardMovement = Input.GetAxis ("Vertical") * transform.forward * Time.deltaTime * speed;		
			
		//jump if the user pressing the space key AND our character is grounded
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown("Jump")) && grounded) {
			rigidbody.AddRelativeForce (transform.up * jumpForce, ForceMode.Impulse); 
			//grounded = false;
		}
		if ((Input.GetKeyUp (KeyCode.Space) || Input.GetButtonUp("Jump")) && !grounded) {
			if (rigidbody.velocity.y > 0) {
				//rigidbody.
				rigidbody.velocity = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y * flylag, rigidbody.velocity.z);
			}
		}
			
		//Animation related stuff!
		if (horMovement.x > 0 && (!amMoving || prevMovement <= 0)) {
			amMoving =true;
			//walkRight event!
			this.startMovingRight ();
		} 
		else if (horMovement.x < 0 && (!amMoving  || prevMovement >= 0))
		{
			amMoving = true;
			//walkLeft!
			this.startMovingLeft ();
		}
		else if (horMovement.x == 0 && amMoving)
		{
			amMoving = false;
			this.stopMoving (); //stopWalking!
		}
		
		prevMovement = horMovement.x;
		
		if (!grounded) {
			horMovement *= airModifier;
			//forwardMovement *= airModifier;
		}
		
		// don't move is there is lext to a block
		if ( horMovement.x > 0 && blockRightCollision == true || 
			 horMovement.x < 0 && blockLeftCollision == true ) {
			horMovement.x = 0;
		}

		//move our character
		transform.Translate (horMovement);
		
		//Debug.Log(rigidbody.velocity.y);
	}
	
	protected virtual void updateRaycasts ()
	{
		
		//	grounded = false;
		int groundMask = 1 << groundLayer;
		groundMask = ~groundMask;
		
		RaycastHit hit;
		
		// checking down collisions
		if (Physics.Raycast (new Vector3 (transform.position.x + (leftBoundary * 0.8f),
										 transform.position.y, 
										 transform.position.z + 5f), // TODO -> explicitar o que é o 5F
							new Vector3 (0, -1, 0), out hit, Mathf.Abs (bottomBoundary) + 0.1f, groundMask) || // WARNING: "+1f" should be more flexible
			Physics.Raycast (new Vector3 (transform.position.x + (rightBoundary * 0.8f),
										 transform.position.y, 
										 transform.position.z + 5f), 
							 new Vector3 (0, -1, 0), out hit, Mathf.Abs (bottomBoundary) + 0.1f, groundMask)) { // WARNING: "+1f" should be more flexible
			
			// check if the object caught is from the ground layer.
			if ((1 << hit.collider.gameObject.layer & groundLayer) != 0) {
				grounded = true;
			} else {
				grounded = false;
			}
		} else
			grounded = false;
		
		
		// check collisions on the left
		if (Physics.Raycast ( new Vector3 (transform.position.x,
											transform.position.y + (bottomBoundary * 0.8f),
											transform.position.z + 5f),
								new Vector3 (1, 0, 0), out hit, Mathf.Abs (rightBoundary), groundMask) ||
			Physics.Raycast ( new Vector3 (transform.position.x,
											transform.position.y + (topBoundary * 0.8f),
											transform.position.z + 5f),
								new Vector3 (1, 0, 0), out hit, Mathf.Abs (rightBoundary), groundMask)) {
			if (( 1 << hit.collider.gameObject.layer & groundLayer) != 0) {
				blockRightCollision = true;
			} else
				blockRightCollision = false;
		} else
			blockRightCollision = false;
		
		
		// check collisions on the right
		if (Physics.Raycast ( new Vector3 (transform.position.x,
											transform.position.y + (bottomBoundary * 0.8f),
											transform.position.z + 5f),
								new Vector3 (-1, 0, 0), out hit, Mathf.Abs (leftBoundary), groundMask) ||
			Physics.Raycast ( new Vector3 (transform.position.x,
											transform.position.y + (topBoundary * 0.8f),
											transform.position.z + 5f),
								new Vector3 (-1, 0, 0), out hit, Mathf.Abs (leftBoundary), groundMask)) {
			if (( 1 << hit.collider.gameObject.layer & groundLayer) != 0) {
				blockLeftCollision = true;
			} else
				blockLeftCollision = false;
		} else
			blockLeftCollision = false;
	}
}

