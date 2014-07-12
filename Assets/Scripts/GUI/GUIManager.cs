using UnityEngine;
using System.Collections;
using System;

public class GUIManager : MonoBehaviour
{
	
	protected IGUI myActiveGUI;

	// Use this for initialization
	void Start ()
	{
		myActiveGUI = GUIDisplay.Instance;
		GUIDied.Instance.OkClicked += this.ReloadLevel;
		GUIDied.Instance.CancelClicked += this.LoadLevelSelection;
		CloneManager.Instance.MainDied += this.MainCloneDied;
//		GUIAchievements.Instance.OkClicked += this.LoadNextlevel;
		GUIAchievements.Instance.OkClicked += this.ReloadLevel;
		GUIAchievements.Instance.CancelClicked += this.LoadLevelSelection;
		
		//initialize every door callback
		GameObject[] doorsInLevel = GameObject.FindGameObjectsWithTag ("Door");
		foreach (GameObject go in doorsInLevel) {
			go.GetComponent<DoorReached> ().FinishedLevel += LevelFinished;	
		}
		
		FreeCamController fcc = camera.GetComponent<FreeCamController> ();
		fcc.FreeCamActivated += (() => {
			this.myActiveGUI = GUIFreeCam.Instance;});
		fcc.FreeCamDeactivated += (() => {
			this.myActiveGUI = GUIDisplay.Instance;});
	}
	
	public void GameFinished ()
	{
		myActiveGUI = GUIHighScores.Instance;	
	}
	
	public virtual void LevelFinished ()
	{
		Debug.Log ("FINISHED LEVEL CALLBACK");
		CloneManager.Instance.mainClone.GetComponent<NEWCloneBasicMovement> ().enabled = false;
		GUIAchievements.Instance.UpdateAchievements();
		myActiveGUI = GUIAchievements.Instance;
	}
	
	public virtual void MainCloneDied ()
	{
		GUIDied.Instance.UpdateAchievements();
		myActiveGUI = GUIDied.Instance;	
	}
	
	public void ReloadLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);	
	}
	
	public void LoadNextlevel ()
	{
		if (Application.loadedLevel < Application.levelCount-1)
			Application.LoadLevel(Application.loadedLevel +1);
		else Application.LoadLevel(1);
	}
	
	public void LoadLevelSelection () {
		Application.LoadLevel(1);	
	}
		
	public void Update ()
	{
		if (Input.GetButtonUp ("Jump")) {
			myActiveGUI.XPressed ();
			return;
		}
		if (Input.GetButtonUp("Circle")) {
			myActiveGUI.OPressed ();	
		}
	}
	
	// MAIN DRAW FUNCTION:: FIRES GUI DRAW
	public void OnGUI ()
	{
		myActiveGUI.Draw ();	
	}
}
