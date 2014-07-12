using UnityEngine;
using System.Collections;
using System.Timers;

public class SecurityGuardAnimation : MonoBehaviour {
	
	private SecurityGuardBehaviour securityGuard;
	private OTAnimatingSprite sprite;
	// Use this for initialization
	void Start () {
		securityGuard = gameObject.GetComponent<SecurityGuardBehaviour>();	
		sprite = gameObject.GetComponent<OTAnimatingSprite>();
		securityGuard.ChangeWalkingAnimation += this.changeWalkingAnimation;
		securityGuard.StartHit += this.HitClone;
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	void changeWalkingAnimation(int direction) {
		// must make more defensive
		if(direction == 1) {
			sprite.PlayLoop("WalkR");
		} else {
			sprite.PlayLoop("WalkL");	
		}
	}
	
	void HitClone(int direction) {
		if(direction == 1) {
			sprite.PlayOnce("SwingR");
		} else {
			sprite.PlayOnce("SwingL");	
		}
	}
}
