using UnityEngine;
using System.Collections;

public class NEWFatCloneBasicMovement : NEWCloneBasicMovement {

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	protected override void updateRaycasts ()
	{
	//	base.updateRaycasts();
		int groundMask = 1 << groundLayer;
		groundMask = ~groundMask;
		
		RaycastHit hit;
		
		// checking down collisions
		if (Physics.Raycast (new Vector3 (this.transform.position.x + (leftBoundary * 0.75f),
										 this.transform.position.y, 
										 this.transform.position.z + 5f), // TODO -> explicitar o que é o 5F
							new Vector3 (0, -1, 0), out hit, Mathf.Abs (bottomBoundary) + 0.1f, groundMask) || // WARNING: "+1f" should be more flexible
			Physics.Raycast (new Vector3 (this.transform.position.x + (rightBoundary * 0.75f),
										 this.transform.position.y, 
										 this.transform.position.z + 5f), 
							 new Vector3 (0, -1, 0), out hit, Mathf.Abs (bottomBoundary) + 0.1f, groundMask)) { // WARNING: "+1f" should be more flexible
			
			// check if the object caught is from the ground layer.
			//Debug.Log("GORDO APANHA CHAO");
			if ((1 << hit.collider.gameObject.layer & groundLayer) != 0) {
				if (grounded == false) {  // this removes some stiffness in the Fat's jump
					this.rigidbody.velocity = new Vector3(this.rigidbody.velocity.x, 0, this.rigidbody.velocity.z);
				}
				grounded = true;
				//this.rigidbody.velocity = new Vector3(this.rigidbody.velocity.x, 0, this.rigidbody.velocity.z);
			} else {
				grounded = false;
			}
		} else
			grounded = false;
		
		// check collisions on the left
		if (Physics.Raycast ( new Vector3 (transform.position.x,
											transform.position.y + (bottomBoundary * 0.75f),
											transform.position.z + 5f),
								new Vector3 (1, 0, 0), out hit, Mathf.Abs (rightBoundary), groundMask) ||
			Physics.Raycast ( new Vector3 (transform.position.x,
											transform.position.y + (topBoundary * 0.75f),
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
											transform.position.y + (bottomBoundary * 0.75f),
											transform.position.z + 5f),
								new Vector3 (-1, 0, 0), out hit, Mathf.Abs (leftBoundary), groundMask) ||
			Physics.Raycast ( new Vector3 (transform.position.x,
											transform.position.y + (topBoundary * 0.75f),
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
