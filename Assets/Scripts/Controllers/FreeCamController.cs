using UnityEngine;
using System.Collections;
using System;

public class FreeCamController : MonoBehaviour {
	
	public event Action FreeCamActivated;
	public event Action FreeCamDeactivated;
	
	public CloneManager cloneManager;
	public float cameraSpeed;
	private bool isFreeActive;
	
	private float leftLimit;
	private float rightLimit;
	private float upLimit;
	private float downLimit;
	
	private bool canMove;
	public bool isTutor = false;
	
	public void Awake()
	{
		this.isFreeActive = false;
		FreeCamActivated = (() => {});
		FreeCamDeactivated = (() => {});
	}
	
	// Use this for initialization
	void Start () {
		NEWInputCatcher.Instance.FreeCamPressed += this.toggleFreeCam;
		this.enabled = false;
		this.canMove = true;
		//Debug.Log("REGISTERED INPUT FREE CAM");
		
		GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
		if(blocks.Length != 0)
		{
			leftLimit = blocks[0].transform.position.x;
			rightLimit = blocks[0].transform.position.x;
			upLimit = blocks[0].transform.position.y;
			downLimit = blocks[0].transform.position.y;
			
			foreach(GameObject go in blocks)
			{
				if(go.transform.position.x < leftLimit)
					leftLimit = go.transform.position.x;
				if(go.transform.position.x > rightLimit)
					rightLimit = go.transform.position.x;
				if(go.transform.position.y < downLimit)
					downLimit = go.transform.position.y;
				if(go.transform.position.y > upLimit)
					upLimit = go.transform.position.y;				
			}
		}
		else throw new Exception("CANNOT DEFINE FREE CAM LIMITS: LEVEL HAS NO BLOCK TAG OBJECTS");
		
		if(this.isTutor)
			GUIFreeCam.Instance.activateTutorMode();
	}
	
	public void RegisterInput()
	{
//		NEWInputCatcher.Instance.jumpPressed += this.toggleFreeCam;
		NEWInputCatcher.Instance.KillPressed += this.restartLevel;
		NEWInputCatcher.Instance.CirclePressed += this.backToLevelSelection;		
	}
	
	public void DeregisterInput()
	{
//		NEWInputCatcher.Instance.jumpPressed -= this.toggleFreeCam;
		NEWInputCatcher.Instance.KillPressed -= this.restartLevel;
		NEWInputCatcher.Instance.CirclePressed -= this.backToLevelSelection;	
	}
	
	// Update is called once per frame
	void Update () {
		//if(this.isFreeActive)
		//{
		//is the user pressin	g left or right (or "a & "d") on the keyboard?    
		if(this.canMove)
		{
			Vector3 horMovement = Input.GetAxis ("Horizontal") * transform.right * Time.deltaTime * cameraSpeed;
				
			//is the user pressing up or down (or "w" & "s") on the keyboard?
			Vector3 forwardMovement = Input.GetAxis ("Vertical") * transform.up * Time.deltaTime * cameraSpeed;
		
			if(camera.transform.position.x + horMovement.x < leftLimit || camera.transform.position.x + horMovement.x > rightLimit)
				horMovement = Vector3.zero;
			if(camera.transform.position.y + forwardMovement.y < downLimit || camera.transform.position.y + forwardMovement.y > upLimit)
				forwardMovement = Vector3.zero;
				
			camera.transform.Translate(horMovement + forwardMovement);
		}
	}
	
	
	public void toggleFreeCam()
	{	
		Debug.Log("ALTERNAR CAMERA!!");
		if(this.isFreeActive)
		{
			cloneManager.activateActiveClone();
			cloneManager.RegisterInput();
			camera.GetComponent<CameraFollowMainPlayer>().enabled = true;
			this.DeregisterInput();
			this.FreeCamDeactivated();
		}
		else {
			cloneManager.deactivateActiveClone();
			cloneManager.DeregisterInput();
			camera.GetComponent<CameraFollowMainPlayer>().enabled = false;
			GUIFreeCam.Instance.UpdateAchievements();
			this.RegisterInput();
			this.FreeCamActivated();
		}
		
		this.isFreeActive = !this.isFreeActive;
		this.enabled = !this.enabled;
	}
	
	
	public void backToLevelSelection()
	{
		this.DeregisterInput();
		this.canMove = false;
		GUIFreeCam.Instance.addConfirmationGUI(GUIConfirmBackToMenu.Instance);
		
		NEWInputCatcher.Instance.FreeCamPressed -= this.toggleFreeCam;
		NEWInputCatcher.Instance.jumpPressed += this.executeBackToLevelSelection;
		NEWInputCatcher.Instance.CirclePressed += this.cancelBackToLevelSelection;
	}
	
	public void restartLevel()
	{
		this.DeregisterInput();
		this.canMove = false;
		GUIFreeCam.Instance.addConfirmationGUI(GUIConfirmReload.Instance);
		
		NEWInputCatcher.Instance.FreeCamPressed -= this.toggleFreeCam;
		NEWInputCatcher.Instance.jumpPressed += this.executeRestartLevel;
		NEWInputCatcher.Instance.CirclePressed += this.cancelRestartLevel;
	}
	
	
	public void executeBackToLevelSelection()
	{
		GUIFreeCam.Instance.resetSecondaryGUI();
		this.canMove = true;
		Application.LoadLevel(1);
	}
	
	public void executeRestartLevel()
	{
		GUIFreeCam.Instance.resetSecondaryGUI();
		this.canMove = true;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	
	public void cancelBackToLevelSelection()
	{
		GUIFreeCam.Instance.resetSecondaryGUI();
		this.canMove = true;
		NEWInputCatcher.Instance.jumpPressed -= this.executeBackToLevelSelection;
		NEWInputCatcher.Instance.CirclePressed -= this.cancelBackToLevelSelection;
		NEWInputCatcher.Instance.FreeCamPressed += this.toggleFreeCam;
		this.RegisterInput();
	}
	
	public void cancelRestartLevel()
	{
		GUIFreeCam.Instance.resetSecondaryGUI();
		this.canMove = true;
		NEWInputCatcher.Instance.jumpPressed -= this.executeRestartLevel;
		NEWInputCatcher.Instance.CirclePressed -= this.cancelRestartLevel;
		NEWInputCatcher.Instance.FreeCamPressed += this.toggleFreeCam;
		this.RegisterInput();
	}
}