using UnityEngine;
using System.Collections;
using System;

public class NEWEmoCloneBasicMovement : NEWCloneBasicMovement {
	
	private bool isDead;
	private NEWEmoCloneAbilities emoAbilities;
	
	protected override void Start()
	{
		base.Start();
		this.isDead = false;
		this.emoAbilities = this.GetComponent<NEWEmoCloneAbilities>();
		this.emoAbilities.OnSpikes += this.turnDead;
		this.emoAbilities.wasShot += this.turnDead;
		this.emoAbilities.ressurect += this.turnAlive;
	}

	
	public void turnDead()
	{
		//Debug.Log("TURNED DEAD ON MOVEMENT!");
		this.isDead = true;	
	}
	
	public void turnAlive()
	{
		this.isDead = false;
		if(gameObject.Equals(CloneManager.Instance.getActiveClone()))
		{
			Debug.Log("ACTIVAR EMO CLONE");
			this.enabled = true;
		}
	}
	
	public override void Update()
	{
		if(!this.isDead)
		{
			base.Update();	
		}
	}
	
	public void OnEnable()
	{
		if(this.isDead)
		{
			//Debug.Log("FAILED TO ENABLE!!");
			this.enabled = false;
		}
	}

}
