using UnityEngine;
using System.Collections;

public class EmoCloneAbilities : CloneAbilities {

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public override void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Spike") {
			gameObject.layer = LayerMask.NameToLayer("Blocks");
			cBase.movable = false;
			cBase.special = true;
			if(cBase.isLeft) {
				gameObject.GetComponent<OTAnimatingSprite>().Play("ProneL");	
			} else {
				gameObject.GetComponent<OTAnimatingSprite>().Play("ProneR");	
			}
		} else { // to do the default
			base.OnCollisionEnter(col);	
		}
	}
	
	public override void BeingShot ()
	{
		gameObject.GetComponent<CloneBasicMovement>().enabled = false;
		sprite.PlayLoop("prone"+ (cBase.isLeft ? "L" : "R"));
	}
}
