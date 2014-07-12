using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class MenuBehaviour : MonoBehaviour
{
	public GUIMenu guimenu;
	private enum OPTIONS
	{
		PLAY=1,
		TUTORIAL,
		QUIT
	};
	private OPTIONS selectedOption;
	private bool canSelect;
	private float vertAxis;
	
	// Use this for initialization
	void Start ()
	{
		canSelect = true;
		selectedOption = OPTIONS.PLAY;
		guimenu.PlayClicked += StartGame;
		guimenu.TutorClicked += StartTutor;
		guimenu.QuitClicked += QuitGame;
	}
	
	public void StartGame ()
	{
		Application.LoadLevel ("LevelSelection");		
	}
	
	public void StartTutor()
	{
		Application.LoadLevel("Walk n Jump");	
	}
	
	public void QuitGame ()
	{
//		Debug.Log ("EXITING APPLICATION !!");	
		Application.Quit ();
	}
	
	public void Update ()
	{
		vertAxis = Input.GetAxis ("Vertical");
		
		if (canSelect) {
			if (vertAxis > 0.2 && selectedOption > Enum.GetValues (typeof(OPTIONS)).Cast<OPTIONS> ().Min ()) {
				//Go up on menu
				canSelect = false;
				selectedOption--;
				guimenu.selectedButton((int)selectedOption);
			} 
			else if (vertAxis < -0.2 && selectedOption < Enum.GetValues (typeof(OPTIONS)).Cast<OPTIONS> ().Max ()) {
				//Go down on menu
				canSelect = false;
				selectedOption++;
				guimenu.selectedButton((int)selectedOption);
			}
		} 
		else if (Mathf.Abs (vertAxis) < 0.2) {
			canSelect = true;
		}
		
//		Debug.Log("OPTION SELECTED: " + selectedOption);
		if (Input.GetKeyDown (KeyCode.Z)|| Input.GetButtonDown("Jump")) {
			switch (selectedOption) {
			case OPTIONS.PLAY:
//				Debug.Log("SESSION ID: " + guimenu.sessionID);
				StartGame();
//				if(guimenu.sessionID != null)
//				{
//					Logger.Instance.initializeLogger(guimenu.sessionID);
//					StartGame ();
//				}
				break;
			case OPTIONS.TUTORIAL: 
				StartTutor();
				break;
			case OPTIONS.QUIT:
				QuitGame ();
				break;
			}
		}
	}			
}