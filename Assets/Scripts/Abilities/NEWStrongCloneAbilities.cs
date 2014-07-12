using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NEWStrongCloneAbilities : CloneAbilities
{
	public event Action StartedFighting;
	
	private bool isfighting;
	private GameObject securityGuard;
	
	// Use this for initialization
	public override void Start ()
	{
		this.securityGuard = null;
		this.isfighting = false;
		
		base.Start ();
	}
	
	public override void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Security") {
			if (!this.isfighting) {
				this.isfighting = true;
				this.GetComponent<NEWCloneBasicMovement> ().enabled = false;
				this.GetComponent<NEWStrongCloneAnimation> ().enabled = false;
			
				this.securityGuard = col.gameObject.transform.parent.gameObject;
				//Debug.Log ("CREATED SECURITY GUARD: " + this.securityGuard.name);
				this.securityGuard.SetActiveRecursively (false);
				//Debug.Log("VOU LANÇAR START FIGHT");
				this.StartedFighting ();
				dialog.HazardInteraction ("SECURITY");
			}
		} else {
			base.OnCollisionEnter (col);	
		}
	}
	
	protected override void OnDestroy ()
	{
		//reactivate security guard
		if (this.securityGuard != null)
			this.securityGuard.SetActiveRecursively (true);

		base.OnDestroy ();
		
	}
	
	//	public override void doStuff(GameObject other) {
//		if (!turnedOn && !isFighting) {
//			CloneBase otherComp = other.GetComponent<CloneBase>();
//			float otherTop = otherComp.topBoundary + other.transform.position.y;
//			if (otherTop >= gameObject.transform.position.y) {
//				other.gameObject.rigidbody.velocity = Vector3.zero;
//				if(cBase.isLeft) {
//					other.GetComponent<CloneBase>().strongThrow(throwForce, throwDuration, 180f - throwAngle);
//				} else {
//					other.GetComponent<CloneBase>().strongThrow(throwForce, throwDuration, throwAngle);
//				}
//			}
//		}
//	}
	
}
