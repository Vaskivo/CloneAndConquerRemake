using UnityEngine;
using System.Collections;
using System;

public class SelectionByKeyBehaviour : MonoBehaviour
{
	
	public int rowSize;
	public GameObject[] buttonsInMenu;
	public GameObject backButton;
	private GameObject selectedButton;
	private int selectedIndex;
	private bool canSelect;
	private bool backSelected;
	private bool showingAchievements;
	private float vertAxis;
	private float horAxis;
	
	
	// Use this for initialization
	void Start ()
	{
		selectedIndex = 0;
		selectedButton = buttonsInMenu [selectedIndex];
		buttonsInMenu [selectedIndex].GetComponent<ButtonBehaviour> ().selectButton ();
		canSelect = true;
		backSelected = false;
		showingAchievements = false;
//		Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-SELECTION MENU");
	}
	
	private void toggleButtons(int offset)
	{
		canSelect = false;
		buttonsInMenu [selectedIndex].GetComponent<ButtonBehaviour> ().deselectButton ();
		selectedIndex += offset;
		buttonsInMenu [selectedIndex].GetComponent<ButtonBehaviour> ().selectButton ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		vertAxis = Input.GetAxis ("Vertical");
		horAxis = Input.GetAxis ("Horizontal");
		
		if ( !showingAchievements ) { // Hammer time :(
			if (canSelect) {
				if (!backSelected) {
					if (horAxis > 0.2 && selectedIndex < buttonsInMenu.Length - 1) {
						toggleButtons(1);
					} 
					else if (horAxis < -0.2 && selectedIndex > 0) {
						toggleButtons(-1);
					}
			
					if (vertAxis > 0.2 && selectedIndex - rowSize > 0) {
						toggleButtons(-rowSize);
					} 
					else if (vertAxis < -0.2) {	
						if (selectedIndex + rowSize < buttonsInMenu.Length - 1) {
							toggleButtons(rowSize);
						} else {
							canSelect = false;
							buttonsInMenu [selectedIndex].GetComponent<ButtonBehaviour> ().deselectButton ();
							backSelected = true;
							backButton.GetComponent<ButtonBehaviour> ().selectButton ();
						}
					}
				} 
				else if (vertAxis > 0.2) {
					canSelect = false;
					buttonsInMenu [selectedIndex].GetComponent<ButtonBehaviour> ().selectButton ();
					backSelected = false;
					backButton.GetComponent<ButtonBehaviour> ().deselectButton ();
				}
			} 
			else if (Mathf.Abs (horAxis) < 0.2 && Mathf.Abs (vertAxis) < 0.2) {
				canSelect = true;		
			}
		} else {
			if(Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Circle")) {
				buttonsInMenu[selectedIndex].GetComponent<ButtonBehaviour>().leaveAchievementGUI();
				showingAchievements = false;
			}
		}
	
		//Catch confirm
		if(Input.GetKeyDown(KeyCode.Z) ||Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
		{
			if(backSelected)
				backButton.GetComponent<ButtonBehaviour>().execute();
			else {
				showingAchievements = true;
				buttonsInMenu[selectedIndex].GetComponent<ButtonBehaviour>().showAchievementGUI();
			}			
		}
	}
}
