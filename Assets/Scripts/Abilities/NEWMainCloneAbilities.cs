using UnityEngine;
using System.Collections;

public class NEWMainCloneAbilities : CloneAbilities
{
	private NEWCloneBasicMovement mainMovement;
	
	private GameObject selectionMenu;
	
	public override void Start ()
	{
		this.mainMovement = this.GetComponent<NEWCloneBasicMovement>();
		
//		NEWInputCatcher.Instance.FatPressed += this.createFatClone;
//		NEWInputCatcher.Instance.StrongPressed += this.createStrongClone;		
//		NEWInputCatcher.Instance.EmoPressed += this.createEmoClone;
//		NEWInputCatcher.Instance.actionPressed += this.toggleSelectionMenu;
		
		foreach (Transform child in transform) {
			if(child.name == "cloneMenu") {
				selectionMenu = child.gameObject;
				break;
			}
		}
	
		selectionMenu.active = false;
		base.Start();
	}
	
	
	public void toggleSelectionMenu()
	{

		if(this.selectionMenu.active)
		{
			this.mainMovement.enabled = true;
			this.selectionMenu.active = false;
			NEWInputCatcher.Instance.actionPressed += this.toggleSelectionMenu;
			//Debug.Log ("SELECTION MENU - Deactivate");
		}
		else 
		{
			this.mainMovement.enabled = false;
			this.selectionMenu.active = true;
			NEWInputCatcher.Instance.actionPressed -= this.toggleSelectionMenu;
			//Debug.Log ("SELECTION MENU - Activate");
		}
	}
	
	
	public void createFatClone ()
	{
		//getNewClonePosition();
		CloneManager.Instance.createFatClone (getNewClonePosition());
	}
	
	public void createStrongClone ()
	{
		CloneManager.Instance.createStrongClone (getNewClonePosition());
	}
	
	public void createEmoClone ()
	{
		CloneManager.Instance.createEmoClone (getNewClonePosition());
	}
	
	private Vector3 getNewClonePosition() {
		bool isLeft = gameObject.GetComponent<NEWCloneAnimation>().isLeft;
		int groundMask = 1 << gameObject.GetComponent<NEWCloneBasicMovement>().groundLayer;
		groundMask = ~groundMask;
		RaycastHit hit;
		
		if( Physics.Raycast(transform.position + new Vector3(0f,0f,5f), 
							isLeft ? Vector3.left : Vector3.right,
							out hit,
							1f,
							groundMask)) {
			gameObject.GetComponent<NEWCloneAnimation>().isLeft = !isLeft;
			return transform.position + ( (isLeft ? Vector3.right : Vector3.left) * 1f );	
		}
		return transform.position + ( (isLeft ? Vector3.left : Vector3.right) * 1f );
	}
	
	public override void OnEnable ()
	{
		NEWInputCatcher.Instance.FatPressed += this.createFatClone;
		NEWInputCatcher.Instance.StrongPressed += this.createStrongClone;		
		NEWInputCatcher.Instance.EmoPressed += this.createEmoClone;
		NEWInputCatcher.Instance.actionPressed += this.toggleSelectionMenu;
		
		base.OnEnable();
	}
	
	public override void OnDisable ()
	{
		NEWInputCatcher.Instance.FatPressed -= this.createFatClone;
		NEWInputCatcher.Instance.StrongPressed -= this.createStrongClone;		
		NEWInputCatcher.Instance.EmoPressed -= this.createEmoClone;
		
		if(this.selectionMenu != null)
				this.selectionMenu.active = false;
	
		NEWInputCatcher.Instance.actionPressed -= this.toggleSelectionMenu;
		
		base.OnDisable();
	}
}
