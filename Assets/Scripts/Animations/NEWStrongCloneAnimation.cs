using UnityEngine;
using System.Collections;

public class NEWStrongCloneAnimation : NEWCloneAnimation {

	private bool isFighting;
	
	public override void Awake()
	{
		base.Awake();
		isFighting = false;
	}
	
	public override void groundChanged()
	{
		if(!isFighting)
			base.groundChanged();
	}
	
	public override void Start()
	{
		base.Start();
		this.gameObject.GetComponent<NEWStrongCloneAbilities>().StartedFighting += this.StartedFight;	
	}
	
	public void StartedFight() 
	{
		//Debug.Log("STARTED FIGHTING ON ANIMATION!");
		if(!isFighting)
		{
			OTAnimationFrameset frameset = gameObject.GetComponent<OTAnimatingSprite>().animation.GetFrameset("porrada");
			int n = frameset.frameNumbers[0];
			OTContainer container = frameset.container;
			Vector2 size = container.GetFrame(n).size;
//			gameObject.transform.Translate(0f, size.y / 2 - Mathf.Abs(cloneMovement.bottomBoundary), 0f);
			gameObject.transform.Translate(0f, 0.1f, 0f); // TODO forma mais elegante
			
			this.isFighting = true;
			sprite.Play("porrada");
		}
	}
	
	public override void UpdateAnimation ()
	{
		if (!isFighting) {
			base.UpdateAnimation();
		}
	}
	
	public void OnDisable()
	{
		//Debug.Log("FIGHTING ON ANIMATION? "+ this.isFighting);
		//sprite.Play("Idle" + (isLeft ? "L" : "R"));
		UpdateAnimation();

	}
}
