using UnityEngine;
using System.Collections;
using System;

public class NEWEmoCloneAbilities : CloneAbilities {
	
	public event Action OnSpikes;
	public event Action wasShot;
	public event Action ressurect;
	
	private NEWEmoCloneBasicMovement emoMovement;
	private NEWEmoCloneAnimation emoAnimation;
	
	public float guardJumpForce = 500;
	private bool isDead;
	
	// Use this for initialization
	public override void Start () {
		this.emoMovement = this.GetComponent<NEWEmoCloneBasicMovement>();
		this.emoAnimation = this.GetComponent<NEWEmoCloneAnimation>();
		
		this.OnSpikes = (() => {});
		this.wasShot = (() => {});
		this.isDead = false;
		
		base.Start();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public override void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Spike")
		{
			if(this.isDead)
				return;
			gameObject.layer = LayerMask.NameToLayer("Blocks");
			this.isDead = true;
			this.emoMovement.enabled = false;
			this.emoAnimation.enabled = false;
			this.OnSpikes();
			this.enabled = false;
			dialog.HazardInteraction("SPIKES");
			StartCoroutine(IsKinematicDelay());
		}
		else if(col.gameObject.tag == "Security")
		{
			//Debug.Log("EMOCLONE SMASHED BY GUARD!");	
			//SHOULD THIS BE HERE ??!!!
			if(col.gameObject.GetComponent<SecurityGuardBehaviour>().direction < 0)
				this.rigidbody.AddForce (Quaternion.AngleAxis (180f + 50, Vector3.back) * (Vector3.right * guardJumpForce));
			else this.rigidbody.AddForce (Quaternion.AngleAxis (-50, Vector3.back) * (Vector3.right * guardJumpForce));
			dialog.HazardInteraction("SECURITY");
			//this.rigidbody.AddForce (Quaternion.AngleAxis (180f + 30, Vector3.back) * (Vector3.right * 50000));
		}

		else base.OnCollisionEnter(col);
			
//		if (col.gameObject.tag == "Security") {
//			if (!this.isfighting) {
//				this.isfighting = true;
//				this.GetComponent<NEWCloneBasicMovement> ().enabled = false;
//				this.GetComponent<NEWCloneAnimation> ().enabled = false;
//			
//				this.securityGuard = col.gameObject.transform.parent.gameObject;
//				Debug.Log ("CREATED SECURITY GUARD: " + this.securityGuard.name);
//				this.securityGuard.SetActiveRecursively (false);
//				Debug.Log("VOU LANÇAR START FIGHT");
//				this.StartedFighting ();	
//			}
//		} else {
//			base.OnCollisionEnter (col);	
//		}
	}
	
	IEnumerator IsKinematicDelay() {
		yield return new WaitForSeconds(0.5f);
		rigidbody.isKinematic = true;
	}
	
	public override void BeingShot()
	{
		//Debug.Log("EMOCLONE DIED ON SHOT!");
		if(this.isDead)
			return;
		this.isDead = true;
		this.emoMovement.enabled = false;
		this.emoAnimation.enabled = false;
		this.wasShot();
		this.enabled = false;
		dialog.HazardInteraction("TURRET");
	}
	
	public void Ressurect()
	{
//		Debug.Log("EMO ABILITES RESSURECT");
		this.isDead = false;
		this.ressurect();
	//	this.emoAnimation.UpdateAnimation();
	}
	
	public override void OnEnable()
	{
		if(this.isDead)
			this.enabled = false;
	}
	
}
