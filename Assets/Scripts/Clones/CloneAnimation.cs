using UnityEngine;
using System.Collections;

public class CloneAnimation : MonoBehaviour {
	
	public enum animation {IdleL, IdleR, WalkL, WalkR, JumpL, JumpR}
	
	OTAnimatingSprite sprite;
	animation currentAnimation;
	CloneBase cBase;
	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<OTAnimatingSprite>();
		cBase = gameObject.GetComponent<CloneBase>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!cBase.special) {
			// Idle Left
			if(cBase.isLeft && cBase.isOnGround && !cBase.isWalking && currentAnimation != animation.IdleL) {
				currentAnimation = animation.IdleL;
				sprite.Play("IdleL");
			}
			// Idle Right
			if(!cBase.isLeft && cBase.isOnGround && !cBase.isWalking && currentAnimation != animation.IdleR) {
				currentAnimation = animation.IdleR;
				sprite.Play("IdleR");
			}
			// Walk Left
			if(cBase.isLeft && cBase.isOnGround && cBase.isWalking && currentAnimation != animation.WalkL) {
				currentAnimation = animation.WalkL;
				sprite.Play("WalkL");
			}
			// Walk Right
			if(!cBase.isLeft && cBase.isOnGround && cBase.isWalking && currentAnimation != animation.WalkR) {
				currentAnimation = animation.WalkR;
				sprite.Play("WalkR");
			}
			// Jump Left
			if(cBase.isLeft && !cBase.isOnGround && currentAnimation != animation.JumpL) {
				currentAnimation = animation.JumpL;
				sprite.Play("JumpL");
			}
			// Jump Right
			if(!cBase.isLeft && !cBase.isOnGround && currentAnimation != animation.JumpR) {
				currentAnimation = animation.JumpR;
				sprite.Play("JumpR");
			}
		}
		
	}
}
