using UnityEngine;
using System.Collections;
using System;

public class NEWCloneAnimation : MonoBehaviour
{
	public Texture2D GUIIcon;
	
	protected OTAnimatingSprite sprite;
	protected NEWCloneBasicMovement cloneMovement;
	[HideInInspector] public bool isLeft;
	protected bool isMoving;
	protected bool isJumping;
	
	public virtual void Awake ()
	{
		isLeft = false;
		isMoving = false;
		isJumping = false;
	}
	
	// Use this for initialization
	public virtual void Start ()
	{
		sprite = this.GetComponent<OTAnimatingSprite> ();
		
		cloneMovement = this.GetComponent<NEWCloneBasicMovement> ();
		cloneMovement.groundedValueChanged += groundChanged;
				
		sprite.Play ("idleR");
		
		cloneMovement.startMovingLeft += this.walkLeft;
		cloneMovement.startMovingRight += this.walkRight;
		cloneMovement.stopMoving += this.stopWalking;
	}
	
	 
	//MAIN FUNCTION TO MANAGE ANIMATIONS!!
	public virtual void UpdateAnimation ()
	{
		if (isJumping)
			sprite.Play ("jump" + (isLeft ? "L" : "R"));
		else {
			if (isMoving)
				sprite.Play ("walk" + (isLeft ? "L" : "R"));
			else
				sprite.Play ("idle" + (isLeft ? "L" : "R"));
		}
	}
	
	public virtual void groundChanged ()
	{
		isJumping = !cloneMovement.grounded;
		UpdateAnimation ();
	}
	
	public virtual void walkLeft ()
	{
		isLeft = true;
		isMoving = true;
		UpdateAnimation();
	}
	
	public virtual void walkRight ()
	{
		isLeft = false;
		isMoving = true;
		UpdateAnimation();
	}
	
	public virtual void stopWalking ()
	{
		isMoving = false; 
		UpdateAnimation();
	}
	
	public virtual void OnDisable()
	{
		if(!Application.isLoadingLevel)
			sprite.Play("idle" + (isLeft ? "L" : "R"));	
	}
	
	public virtual void OnEnable() {
		try{
			if(!Application.isLoadingLevel)
				UpdateAnimation();	
		}
		catch(NullReferenceException)
		{
			Debug.Log("FIRST EXECUTION! ANIMATION ENGINE NOT YET INITIALIZED!");
		}
	}
}
