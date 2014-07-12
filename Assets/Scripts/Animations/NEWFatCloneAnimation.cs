using UnityEngine;
using System.Collections;
using System;

public class NEWFatCloneAnimation : NEWCloneAnimation {
	
	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	
	public override void Start ()
	{
		gameObject.GetComponent<FatClonePassiveAbilities>().PlayBounceAnimation += BounceAnimation;
		base.Start();
	}
	
	public void BounceAnimation(){
		sprite.PlayOnce("bounce" + (isLeft ? "L" : "R"));
		sprite.onAnimationFinish = this.IdleAnimationAfterBounce;	
	}
	
	public void IdleAnimationAfterBounce(OTObject owner) {
		sprite.onAnimationFinish = this.IdleAnimationAfterBounce;
		sprite.PlayLoop("prone" + (isLeft ? "L" : "R"));
	}
	
	public override void OnDisable() {
		sprite.PlayLoop("prone" + (isLeft ? "L" : "R"));	
	}
	
	public override void OnEnable() {
		try{
			sprite.position += new Vector2(0, 0.1f);
			UpdateAnimation();
		}
		catch(NullReferenceException e)
		{
			Debug.Log("FIRST EXECUTION! ANIMATION ENGINE NOT YET INITIALIZED!");
		}
	}
}
