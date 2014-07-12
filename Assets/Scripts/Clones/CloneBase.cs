using UnityEngine;
using System.Collections;
using System;

public class CloneBase : MonoBehaviour {
	
	public Texture2D GUIIcon;
	
	public event Action CloneDied;

	// movement data
	private int moveDirX;
	private int moveDirY;
	private float jumpStart;
	private Vector3 movement;
	private Transform thisTransform;
	
	// collision boundaries
	[HideInInspector] public float topBoundary;
	[HideInInspector] public float bottomBoundary;
	[HideInInspector] public float leftBoundary;
	[HideInInspector] public float rightBoundary;
	
	// collision data
	public bool isLeft = false;
	public bool isWalking = false;
	public bool isOnGround = false;
	public bool isJumping = false;
	public bool collidesOnTheLeft = false;
	public bool collidesOnTheRight = false;
	//public LayerMask groundLayer;
	// there's gonna be more.
	
//	public bool dying = false;
	
	// for "special" clone states (throwing, platform, stagger, etc)
	public bool special = false;
	public bool movable = true;
	
	// other clones stuff
	private bool isFatJumping = false;
	private float fatJumpDuration = 0f;
	private float fatJumpStart = 0f;
	private bool isStrongThrowed = false;
	private float strongThrowDuration = 0f;
	private float strongThrowStart = 0f;
	
	
	//private Vector3 spawnPoint;
	public void OnDestroy()
	{
		this.CloneDied();	
	}
	
	//private bool turnedOn = true;	
	
	void Awake(){
		thisTransform = transform;
		this.CloneDied = (() => {});
	}
	
	// Use this for initialization
	void Start () {
		//spawnPoint = thisTransform.position;
		
		OTSprite spriteData = gameObject.GetComponent<OTSprite>();
		BoxCollider bCollider = gameObject.GetComponent<BoxCollider>();
		topBoundary = ((spriteData.size.y / 2) * bCollider.size.y ) + (spriteData.size.y * bCollider.center.y);
		bottomBoundary = ((-spriteData.size.y / 2) * bCollider.size.y ) + (spriteData.size.y * bCollider.center.y);
		leftBoundary = ((-spriteData.size.x / 2) * bCollider.size.x ) + (spriteData.size.x * bCollider.center.x);
		rightBoundary = ((spriteData.size.x / 2) * bCollider.size.x ) + (spriteData.size.x * bCollider.center.x);
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (dying) {
//			CloneManager.Instance.destroyClone(gameObject);	
//		}
		
//		updateRaycasts();
	}
		
	// The smart way to do this would be using the data from collider attached to this GO
	
//	void updateRaycasts() {
//		
//		isOnGround = false;
//		collidesOnTheLeft = false;
//		collidesOnTheRight = false;
//		
//		int groundMask = 1 << groundLayer;
//		groundMask = ~groundMask;
//		
//		RaycastHit hit;
//		
//		// checking down collisions
//		if (Physics.Raycast( new Vector3(thisTransform.position.x + (leftBoundary * 0.8f),
//										 thisTransform.position.y, 
//										 thisTransform.position.z + 5f),  // TODO -> explicitar o que é o 5F
//							new Vector3(0, -1, 0), out hit, Mathf.Abs(bottomBoundary) + 1f, groundMask) || // WARNING: "+1f" should be more flexible
//			Physics.Raycast( new Vector3(thisTransform.position.x + (rightBoundary * 0.8f),
//										 thisTransform.position.y, 
//										 thisTransform.position.z + 5f), 
//							 new Vector3(0, -1, 0), out hit, Mathf.Abs(bottomBoundary) + 1f, groundMask)) { // WARNING: "+1f" should be more flexible
//			
//			// check if the object caught is from the ground layer.
//			if ((1 << hit.collider.gameObject.layer & groundLayer) != 0) {
//				isOnGround = true;
//				if (isStrongThrowed) {
//					isStrongThrowed = false;
//					gameObject.rigidbody.velocity = Vector3.zero;
//				}
//			}
//			
//		}
//		// checking left collisions
//		if (Physics.Raycast( new Vector3(thisTransform.position.x, 
//										 thisTransform.position.y + topBoundary - 5f, 
//										 thisTransform.position.z + 5f), 
//							 Vector3.left, out hit, Mathf.Abs(leftBoundary), groundMask) || 
//			Physics.Raycast(new Vector3(thisTransform.position.x, 
//										thisTransform.position.y + bottomBoundary + 5f, 
//										thisTransform.position.z + 5f), 
//							Vector3.left, out hit, Mathf.Abs(leftBoundary), groundMask)){
//			if ((1 << hit.collider.gameObject.layer & groundLayer) != 0) {
//			collidesOnTheLeft = true;
//				if (isStrongThrowed) {
//					isStrongThrowed = false;
//					gameObject.rigidbody.velocity = Vector3.zero;
//				}
//			}
//		}
//		// checking right collisions
//		if (Physics.Raycast( new Vector3(thisTransform.position.x, 
//										 thisTransform.position.y + topBoundary - 5f, 
//										 thisTransform.position.z + 5f), 
//							 Vector3.right, out hit, Mathf.Abs(rightBoundary), groundMask) || 
//			Physics.Raycast(new Vector3(thisTransform.position.x, 
//										thisTransform.position.y + bottomBoundary + 5f, 
//										thisTransform.position.z + 5f), 
//							Vector3.right, out hit, Mathf.Abs(rightBoundary), groundMask)){
//			if ((1 << hit.collider.gameObject.layer & groundLayer) != 0) {
//			collidesOnTheRight = true;
//				if (isStrongThrowed) {
//					isStrongThrowed = false;
//					gameObject.rigidbody.velocity = Vector3.zero;
//				}
//			}
//		}		
//	}
	
	public void fatJump(float jumpForce, float duration) {
		isJumping = false;
		isFatJumping = true;
		fatJumpDuration = duration;
		fatJumpStart = Time.realtimeSinceStartup;
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.rigidbody.AddForce(Vector3.up * jumpForce);
	}
	
	public void strongThrow(float throwforce, float duration, float angle) {
		isStrongThrowed	= true;
		strongThrowDuration = duration;
		strongThrowStart = Time.realtimeSinceStartup;
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.rigidbody.AddForce(Quaternion.AngleAxis(-angle, Vector3.back) * (Vector3.right * throwforce));
	}
	
//	public void activate() {
//		turnedOn = true;	
//	}
//	
//	public void deactivate() {
//		turnedOn = false;
//	}
	
//	void OnTriggerEnter(Collider other) {
//		if (other.gameObject.tag.Equals("Clone")) {
//			other.gameObject.GetComponent<CloneAbilities>().doStuff(this.gameObject);	
//		}
//		if (other.gameObject.tag.Equals("Spike")) {
//			dying = true;
//		}
//	}
}
