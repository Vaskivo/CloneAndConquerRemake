using System;
using UnityEngine;

public class NEWInputCatcher : MonoBehaviour {
	
	public static NEWInputCatcher Instance;
	
//	public event Action leftPressed;
//	public event Action rightPressed;
//	public event Action walkReleased;
	
	public event Action jumpPressed;
//	public event Action jumpReleased;
	public event Action KillPressed;
	public event Action PrevPressed;
	public event Action NextPressed;
	public event Action FatPressed;
	public event Action StrongPressed;
	public event Action EmoPressed;
	public event Action actionPressed;
	public event Action FreeCamPressed;
	public event Action CirclePressed;
	
//	private KeyCode leftButton = KeyCode.LeftArrow;
//	private KeyCode rightButton = KeyCode.RightArrow;
//	private KeyCode jumpButton = KeyCode.UpArrow;
	private KeyCode actionButton = KeyCode.Z;
	private KeyCode prevClone = KeyCode.A;
	private KeyCode nextClone = KeyCode.S;
//	private KeyCode principalClone = KeyCode.W;
	private KeyCode destroyClone = KeyCode.C;
	private KeyCode spawnFat = KeyCode.Alpha1;
	private KeyCode spawnStrong = KeyCode.Alpha2;
	private KeyCode spawnEmo = KeyCode.Alpha3;
	private KeyCode freeCam = KeyCode.F;
	
	public float orthSize;
	public float orthSizeX;
	public float orthSizeY;
	public float camRatio;
	
//	public bool isLeft;
//	public bool isRight;
//	public bool isJump;
//	public bool isAction;
//	public bool isPrevClone;
//	public bool isNextClone;
//	public bool isDestroyClone;
	
	NEWInputCatcher() {
		Instance = this;
	}
	
	void Awake() {
	//	Instance = this;
		jumpPressed = (() => {});
//		jumpReleased = (() => {});
		KillPressed = (() => {});
		PrevPressed = (() => {});
		NextPressed = (() => {});
		FatPressed = (() => {});
		StrongPressed = (() => {});
		EmoPressed = (() => {});
		CirclePressed = (() => {});
		actionPressed = (() => {});
        FreeCamPressed = (() => { });
	}
	
	// Use this for initialization
	void Start () {
//		camRatio = 1.333f;
//		orthSize = Camera.mainCamera.camera.orthographicSize;
//		orthSizeX = orthSize * camRatio;
		
		//Initialize delegates just to avoid possible unregistered call errors
//		leftPressed = (() => {});
//		rightPressed = (() => {});
//		walkReleased = (() => {});
		jumpPressed = (() => {});
//		jumpReleased = (() => {});
//		KillPressed = (() => {});
//		PrevPressed = (() => {});
//		NextPressed = (() => {});
//		FatPressed = (() => {});
//		StrongPressed = (() => {});
//		EmoPressed = (() => {});
//		actionPressed = (() => {});
//		FreeCamPressed = (() => {});
	}
	
	// Update is called once per frame
	void Update () {
		
		//Action Pressed (meaning clone selection menu)
		if(Input.GetKeyUp(actionButton) || Input.GetButtonUp("Square"))
		{
			this.actionPressed();	
		}
		
//		//Jump Pressed
//		if (Input.GetKeyDown(jumpButton)){ 
//			this.jumpPressed();
//		}
//		//Jump Released
//		if (Input.GetKeyUp(jumpButton)){ 
//			this.jumpReleased();
//		}
		
		if(Input.GetKeyUp(prevClone) || Input.GetButtonUp("Previous")) {
			//isPrevClone = true;	
			this.PrevPressed();
		}
		if(Input.GetKeyUp(nextClone) || Input.GetButtonUp("Next")) {
			//isNextClone = true;	
			this.NextPressed();
		}
		if(Input.GetKeyUp(destroyClone) || Input.GetButtonUp("Triangle")) {
			//isDestroyClone = true;
			//CloneManager.Instance.suicideClone();
			this.KillPressed();
		}
		
		if(Input.GetKeyUp(KeyCode.X) || Input.GetButtonUp("Circle"))
		{
			this.CirclePressed();	
		}
		
		if(Input.GetKeyUp(spawnFat))
		{
			this.FatPressed();
		}
		
		if(Input.GetKeyUp(spawnStrong))
		{
			this.StrongPressed();
		}
		
		if(Input.GetKeyUp(spawnEmo))
		{
			this.EmoPressed();
		}
		
		if(Input.GetKeyUp(freeCam) || Input.GetButtonUp("Start"))
		{
//			Debug.Log("APANHEI TECLA!!");
			this.FreeCamPressed();
		}
		
		if(Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown("Jump"))
		{
			this.jumpPressed();	
		}
	}
}
