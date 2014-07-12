using UnityEngine;
using System.Collections;
using System;

public class TutorialGUIManager : GUIManager {
	
	public bool isLastTutorial = false;
	
	// Use this for initialization
	void Start () {
		myActiveGUI = GUIDisplay.Instance;
		TutorialGUIDied.Instance.OkClicked += this.ReloadLevel;
		TutorialGUIDied.Instance.CancelClicked += this.LoadStartMenu;
		CloneManager.Instance.MainDied += this.MainCloneDied;
		if (isLastTutorial) {
			TutorialGUIEndTutorial.Instance.CancelClicked += LoadStartMenu;
		} else {
			TutorialGUIEndLevel.Instance.OkClicked += this.LoadNextlevel;
			TutorialGUIEndLevel.Instance.CancelClicked += this.LoadStartMenu;
		}
		
		GameObject[] doorsInLevel = GameObject.FindGameObjectsWithTag ( "Door" );
		foreach (GameObject go in doorsInLevel) {
			go.GetComponent<DoorReached> ().FinishedLevel += LevelFinished;
		}
		
		FreeCamController fcc = camera.GetComponent<FreeCamController> ();
		fcc.FreeCamActivated += (() => {
			this.myActiveGUI = GUIFreeCam.Instance;});
		fcc.FreeCamDeactivated += (() => {
			this.myActiveGUI = GUIDisplay.Instance;});
	}
	
	public override void LevelFinished ()
	{
		CloneManager.Instance.mainClone.GetComponent<NEWCloneBasicMovement> ().enabled = false;
		if (isLastTutorial) {
			myActiveGUI = TutorialGUIEndTutorial.Instance;
		} else {
			myActiveGUI = TutorialGUIEndLevel.Instance;
		}
	}
	
	public override void MainCloneDied ()
	{
		myActiveGUI = TutorialGUIDied.Instance;	
	}
	
	public void LoadStartMenu () {
		Application.LoadLevel(0);
	}
}
