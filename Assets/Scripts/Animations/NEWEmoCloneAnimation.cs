using UnityEngine;
using System.Collections;
using System;

public class NEWEmoCloneAnimation : NEWCloneAnimation {
	
	private bool isDead;
	private bool isShot;
	private NEWEmoCloneAbilities emoAbilities;
	
	// Use this for initialization
	public override void Start () {
		base.Start();
		isDead = false;
		isShot = false;
		emoAbilities = this.GetComponent<NEWEmoCloneAbilities>();
		emoAbilities.wasShot += this.beenShot;
		emoAbilities.OnSpikes += this.isDying;
		emoAbilities.ressurect += this.ressurect;
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public override void UpdateAnimation()
	{
		if(this.isDead)
			if(this.isShot)
				sprite.PlayLoop("suffer" + (isLeft ? "L" : "R"));	
			else sprite.PlayLoop("prone" +(isLeft ? "L" : "R"));
		else base.UpdateAnimation();
	}
	
	public void isDying()
	{
		//Debug.Log("FELL ON SPIKES!!");
		this.isDead = true;
		UpdateAnimation();
	}
	
	public void beenShot()
	{
		this.isShot = true;	
		this.isDying();
	}
	
	public void ressurect()
	{
		this.isShot = false;
		this.isDead = false;
		UpdateAnimation();
	}
	
	public override void OnDisable()
	{
		UpdateAnimation();
	}
}
