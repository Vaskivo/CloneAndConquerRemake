using UnityEngine;
using System.Collections;
using System;

public class FatClonePassiveAbilities : ClonePassiveAbilities {

	public float throwForce = 20000;
	
	public event Action PlayBounceAnimation = (() => {});
	
	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public override void doStuff(GameObject target)
	{
		if (this.enabled) {
			Vector3 relativePosition = gameObject.transform.InverseTransformPoint(target.transform.position);
			if (relativePosition.y > 0) {
				//Debug.Log("THROWING CLONE!");
				target.rigidbody.velocity = Vector3.zero;
				target.rigidbody.AddForce(Vector3.up * throwForce);
				PlayBounceAnimation();
			}
		}
	}
}
