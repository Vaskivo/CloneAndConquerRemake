using UnityEngine;
using System.Collections;

public class SelectionMenuBehaviour : MonoBehaviour
{
	private OTAnimatingSprite sprite;
	private NEWMainCloneAbilities mainAbilities;
	
	private float horAxis;
	private float vertAxis;
	private string selected;
	
	
	public void Awake ()
	{
		this.selected = string.Empty;
		this.sprite = this.GetComponent<OTAnimatingSprite> ();
		sprite.Play ("None");	
	}
	
	// Use this for initialization
	void Start ()
	{
		this.mainAbilities = this.transform.parent.gameObject.GetComponent<NEWMainCloneAbilities> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Has to be done using AXIS because of the gamepad analog sticks!
		horAxis = Input.GetAxis ("Horizontal");
		vertAxis = Input.GetAxis ("Vertical");
		
		if (vertAxis > 0.5) {
//			Debug.Log ("SELECT STRONG");
			selected = "Strong";
		} 
		//has to be separated because of the gamepad analog sticks!
		if (horAxis > 0.05) {
//			Debug.Log ("SELECT EMO");
			selected = "Emo";
		} else if (horAxis < -0.05) {
//			Debug.Log ("SELECT FAT");
			selected = "Fat";
		}
		
		sprite.Play (this.selected);
		
		if(Input.GetButtonUp("Square"))
		{
			//Debug.Log("SQUARE IN SelectionMenu");
			this.mainAbilities.toggleSelectionMenu();	
		}
		
		if (Input.GetKeyUp (KeyCode.Z) || Input.GetButtonUp("Jump")) {
			this.mainAbilities.toggleSelectionMenu ();
			
			switch (this.selected) {
			case "Fat":
				this.mainAbilities.createFatClone ();
				break;
			case "Strong":
				this.mainAbilities.createStrongClone ();
				break;
			case "Emo":
				this.mainAbilities.createEmoClone ();
				break;
			}			
		}
	}
	
	public void OnEnable()
	{
		this.selected = "None";	
	}

}