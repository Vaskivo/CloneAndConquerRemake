using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CloneManager : MonoBehaviour {
	
	public static CloneManager Instance;
	
	public event Action MainDied = (() => {});
	public event Action<GameObject> CloneCreated = (obj) => {};
	
	public GameObject mainClone;
	public LinkedListNode<GameObject> activeClone;
	public LinkedList<GameObject> clones = new LinkedList<GameObject>();

	public GameObject fatClone;
	public GameObject strongClone;
	public GameObject emoClone;
	
	public GameObject arrowIndicator;
	public GameObject bloodExplosion;
	public GameObject creationEffect;
	private GameObject cloneToCreate;
	
	private LinkedListNode<GameObject> lastCheckpointClone;
	private GameObject lastCheckpoint;
	
//	[HideInInspector] public int fatCloneCount {get; set;}
//	[HideInInspector] public int strongCloneCount {get; set;}
//	[HideInInspector] public int emoCloneCount {get; set;}
	
//	static CloneManager ()
//	{
//		instance = new CloneManager ();
//	}
		
	
	void Awake() {
		Instance = this;
//		fatCloneCount = 0;
//		strongCloneCount = 0;
//		emoCloneCount = 0;
	}
	
	// Use this for initialization
	void Start () {
		activeClone = clones.AddLast(mainClone);
		lastCheckpointClone = clones.Last;
		lastCheckpoint = GameObject.Find("InitialCheckpoint"); //replace this with something more flexible... maybe iterate all checkpoints and choose the one with lower ID?
		RegisterInput();
//		NEWInputCatcher.Instance.PrevPressed += changeToPrevClone;
//		NEWInputCatcher.Instance.NextPressed += changeToNextClone;
//		NEWInputCatcher.Instance.KillPressed += suicideClone;
		
		//this.activateActiveClone();
		
		//logging
//		Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-LEVEL START "+Application.loadedLevelName);
	}
	
	public void RegisterInput()
	{
		NEWInputCatcher.Instance.PrevPressed += changeToPrevClone;
		NEWInputCatcher.Instance.NextPressed += changeToNextClone;
		NEWInputCatcher.Instance.KillPressed += suicideClone;
		NEWInputCatcher.Instance.CirclePressed += goToMainClone;
	}
	
	public void DeregisterInput()
	{
		NEWInputCatcher.Instance.PrevPressed -= changeToPrevClone;
		NEWInputCatcher.Instance.NextPressed -= changeToNextClone;
		NEWInputCatcher.Instance.KillPressed -= suicideClone;
		NEWInputCatcher.Instance.CirclePressed -= goToMainClone;
	}
	
	
	public void goToMainClone()
	{
		deactivateActiveClone();
		activeClone = clones.First;
		activateActiveClone();
	}
	
	
	public void createNewClone(Vector3 position)
	{
		deactivateActiveClone();
		GameObject tmp = Instantiate(cloneToCreate, Vector3.zero, Quaternion.identity) as GameObject;
		tmp.transform.position = position;
		activeClone = clones.AddLast(tmp);
		CloneCreated(tmp);
		activateActiveClone();
		activeClone.Value.GetComponent<ClonePassiveAbilities>().init();
		activeClone.Value.GetComponent<CloneDialog>().CloneBorn();
	}
	
	public void EffectThenNewClone(Vector3 position) {
		deactivateActiveClone();
		GameObject tmp = Instantiate(creationEffect, Vector3.zero, Quaternion.identity) as GameObject;
		tmp.transform.position = position;
		tmp.GetComponent<TeleportBehaviour>().destroyed += createNewClone;
	}
	
	public void createFatClone(Vector3 position) {
		cloneToCreate = fatClone;
//		fatCloneCount++;
//		Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-CLONE CREATED: FAT");
//		createNewClone(position);
		EffectThenNewClone(position);
	}
	
	public void createStrongClone(Vector3 position) {
		cloneToCreate = strongClone;
//		strongCloneCount++;
//		Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-CLONE CREATED: STRONG");
//		createNewClone(position);
		EffectThenNewClone(position);
	}
	
	public void createEmoClone(Vector3 position) {
		cloneToCreate = emoClone;
//		emoCloneCount++;
//		Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-CLONE CREATED: EMO");
//		createNewClone(position);
		EffectThenNewClone(position);
	}
	
	
	private void changeToPrevClone() {
		deactivateActiveClone();
//		activeClone = (activeClone.Previous==null ? clones.Last : activeClone.Previous); //does the same, but simpler to read
		if (activeClone.Previous == null) {
			activeClone = clones.Last;
		}
		else {
			activeClone = activeClone.Previous;
		}
		
		activateActiveClone();
	}
	
	private void changeToNextClone() {
		deactivateActiveClone();
//		activeClone = (activeClone.Next==null ? clones.First : activeClone.Next); //does the same, but simpler to read
		if (activeClone.Next == null) {
			activeClone = clones.First;
		}
		else {
			activeClone = activeClone.Next;
		}
		
		activateActiveClone();
	}
	
	public void destroyClone(GameObject clone) {
			//MainClone Died!! ...
		if(mainClone.Equals(clone))
		{
			clone.GetComponent<NEWCloneBasicMovement>().enabled = false;
			clone.GetComponent<CloneAbilities>().enabled = false;
			//clearClones(); //temporarily disabled to test checkpoints
			ReloadToLastCheckpoint();
			this.MainDied ();
			//Application.LoadLevel(0);
			return;
		}
		//Other clone died...
		string deadType = clone.GetComponent<CloneAbilities>().cloneType;
		if(clone.Equals(activeClone.Value)) {
			Camera.main.GetComponent<CameraFollowMainPlayer>().StoppedMovingAfterDeath += activeClone.Previous.Value.GetComponent<CloneDialog>().CloneDead;
			changeToPrevClone();
			deactivateActiveClone(); // TODO: refactor (activate then deactivate)
			activeClone.Value.GetComponent<CloneDialog>().lastCloneDead = deadType;
			Camera.main.GetComponent<CameraFollowMainPlayer>().waitAndSee();
		}
		//Control clone counts
//		switch(deadType)
//		{
//		case "EMO": emoCloneCount--; break;
//		case "FAT": fatCloneCount--; break;
//		case "STRONG": strongCloneCount--; break;
//		default: throw new Exception("DEAD CLONE TYPE FAILED !!");
//		}
		
		clones.Remove(clone);
		Destroy(clone);
	}
	
	public void destroyClone() {
		//GameObject blood = Instantiate(bloodExplosion, Vector3.zero, Quaternion.identity) as GameObject;
		//blood.transform.Translate(activeClone.Value.transform.position);
		
		GameObject goTmp = activeClone.Value;
		changeToPrevClone();
		clones.Remove(goTmp);
		Destroy(goTmp);
	}
	
	public void suicideClone() {
		if (!activeClone.Value.Equals(mainClone)) {
			//DialogManager.Instance.reportEvent(activeClone.Value, "SUICIDE");
//			Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-CLONE DEAD: "+activeClone.Value.GetComponent<CloneAbilities>().cloneType+", SUICIDE");
			destroyClone(activeClone.Value);
		}
	}
	
	public void activateActiveClone() {
		activeClone.Value.GetComponent<NEWCloneBasicMovement>().enabled = true;
		activeClone.Value.GetComponent<CloneAbilities>().enabled = true;
		activeClone.Value.GetComponent<NEWCloneAnimation>().enabled = true;
		activeClone.Value.GetComponent<ClonePassiveAbilities>().enabled = false;
		
		//this.arrowIndicator.transform.position = activeClone.Value.transform.position + new Vector3 (0f, 80f, 0f);
		this.arrowIndicator.GetComponent<ArrowIndicatorBehaviour>().StartIndicatingClone((GameObject) this.activeClone.Value);
		//this.arrowIndicator.active = true;
	}
	
	public void deactivateActiveClone() {
		activeClone.Value.GetComponent<NEWCloneBasicMovement>().enabled = false;
		activeClone.Value.GetComponent<CloneAbilities>().enabled = false;
		activeClone.Value.GetComponent<NEWCloneAnimation>().enabled = false;
		activeClone.Value.GetComponent<ClonePassiveAbilities>().enabled = true;
		
		this.arrowIndicator.active = false;
	}
	
	public GameObject getActiveClone(){
		return activeClone.Value;
	}
	
	
	private void clearClones()
	{
		for(int i = clones.Count; i>0; --i)
		{
			GameObject temp = clones.Last.Value;
			clones.RemoveLast();
			destroyClone(temp);
		}
	}
	
	
#region CHECKPOINTS
//** CHECKPOINT RELATED STUFF - UPDATES AND RELOADS **\\
	
	public void ReloadToLastCheckpoint()
	{
		//clean clones after last checkpoint
		while(lastCheckpointClone.Next != null)
		{
			GameObject goTemp = clones.Last.Value;
			clones.RemoveLast();
			Destroy(goTemp); //may not be safe... check to see if it's the main clone?? what happens if we die before any checkpoint is reached or any clone is created?
		}
		
		//move mainClone to last reached checkpoint
		mainClone.transform.position = (Vector2) this.lastCheckpoint.transform.position;
		
		//recheck achievements... and roll them back if need to
		
	}	
	
	public void UpdateCheckpoint(GameObject checkpoint)
	{
		if(checkpoint.GetComponent<CheckpointID>().ID > this.lastCheckpoint.GetComponent<CheckpointID>().ID)
		{	
			this.lastCheckpoint = checkpoint;
			lastCheckpointClone = clones.Last;
		}
			
		Debug.Log("UPDATED CHECKPOINT: " + this.lastCheckpoint.name);
		//update achievements here too... talk to Vasco
	}

#endregion
}
