using UnityEngine;
using System.Collections;

public class NEWStrongCloneBasicMovement : NEWCloneBasicMovement
{
	private bool isFighting;
	
	protected override void Start()
	{
		base.Start();
		isFighting = false;
		this.gameObject.GetComponent<NEWStrongCloneAbilities>().StartedFighting += this.StartedFight;
	}

	
	public void StartedFight()
	{
		this.isFighting = true;	
	}
	
	
	public void OnEnable()
	{
		if(this.isFighting)
			this.enabled = false;
	}
}