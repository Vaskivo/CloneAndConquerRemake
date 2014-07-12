using UnityEngine;
using System.Collections;

public class FatCloneAbilities : CloneAbilities {
	
	public float jumpForce = 10000;
	public float jumpDuration = 1;
		
	public override void doStuff(GameObject other) {
//		if (!turnedOn) {
//			CloneBase otherComp = other.GetComponent<CloneBase>();
//			//float otherBottom = otherComp.bottomBoundary + other.transform.position.y;
//			float otherTop = otherComp.topBoundary + other.transform.position.y;
//			if (otherTop >= gameObject.transform.position.y) {
//				other.GetComponent<CloneBase>().fatJump(jumpForce, jumpDuration);
//				gameObject.rigidbody.velocity = Vector3.zero;
//				//DialogManager.instance.reportEvent(this.gameObject, "FATJUMP", other);
//			}
//			if(cBase.isLeft) {
//				sprite.PlayOnce("ProneBounceL");
//			} else {
//				sprite.PlayOnce("ProneBounceR");	
//			}
//		}
	}
	
//	public override void activate() {
//		base.activate();
//		cBase.special = false;
//	}
	
//	public override void deactivate() {
//		base.deactivate();
//		cBase.special = true;
//		if(cBase.isLeft) {
//			sprite.Play("ProneL");
//		} else {
//			sprite.Play("ProneR");
//		}
//	}
}
