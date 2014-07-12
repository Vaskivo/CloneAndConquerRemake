using UnityEngine;
using System.Collections;
using System;

public class CloneAbilities : MonoBehaviour
{
	
//	protected bool turnedOn = true;
	public string cloneType;
	public GameObject deathAnimation;
	protected CloneBase cBase;
	protected OTAnimatingSprite sprite;
	protected CloneDialog dialog;
	
//	protected GameObject arrowIndic;
//	protected OTAnimatingSprite arrowsprite;
//	private int arrowplayTimes;
//	private bool amStarted = false;
	
	public event Action<GameObject> OnDestroyEvent = (go => {});
	
#if UNITY_EDITOR
    private bool isQuitting = false;
#endif
	
	public virtual void Start ()
	{
//		arrowplayTimes = 3;
//		
//		foreach (Transform child in transform) {
//			if (child.name == "arrowIndicator") {
//				arrowIndic = child.gameObject;
//				break;
//			}
//		}
//		
//		arrowIndic.active = true;
//		
//		arrowsprite = this.arrowIndic.GetComponent<OTAnimatingSprite> ();
////		arrowsprite.size = Vector2.one;
//		arrowIndic.transform.localScale = new Vector3(1,1, 1 * OT.view.sizeFactor);
//		arrowsprite.PlayOnce ("arrow");
//		arrowsprite.onAnimationFinish = this.ArrowAnimationFinished;
//		Debug.Log("ARROW STARTED");
//		
//		amStarted = true;
	}
	
	void Awake ()
	{
		//	cBase = gameObject.GetComponent<CloneBase> ();
		sprite = gameObject.GetComponent<OTAnimatingSprite> ();
		dialog = gameObject.GetComponent<CloneDialog> ();
		
//		foreach (Transform child in transform) {
//			if (child.name == "arrowIndicator") {
//				arrowIndic = child.gameObject;
//				break;
//			}
//		}
//		
//		
//		this.arrowIndic.active = true;
//		OTAnimatingSprite arrowsprite = this.arrowIndic.GetComponent<OTAnimatingSprite> ();
//		arrowsprite.PlayOnce ("arrow");
//		arrowsprite.onAnimationFinish = this.ArrowAnimationFinished;
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public virtual void doStuff (GameObject go)
	{
		// NOTHING IN HERE	
	}
	
	public string getCloneType ()
	{
		return cloneType;	
	}
	
//	public virtual void activate ()
//	{
//		turnedOn = true;	
//	}
//	
//	public virtual void deactivate ()
//	{
//		turnedOn = false;	   
//	}
	
	public virtual void OnCollisionEnter (Collision col)
	{
		switch (col.gameObject.tag) {
		case "Spike":
			//cBase.dying = true;
	//		DialogManager.Instance.cloneDied(gameObject, "SPIKE");
//			Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-CLONE DEAD: "+cloneType+", SPIKES");
			CloneManager.Instance.destroyClone (gameObject);
			break;
		case "Security":
			//cBase.dying = true;
//			DialogManager.Instance.cloneDied(gameObject, "SECURITY");
//			Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-CLONE DEAD: "+cloneType+", SECURITY");
			CloneManager.Instance.destroyClone (gameObject);
			break;
		}
//		if (col.gameObject.tag == "Spike") {
//			cBase.dying = true;	
//		}
//		if (col.gameObject.tag == "Security") {
//			cBase.dying = true;	
//		}
	}
	
	public virtual void BeingShot ()
	{
		//gameObject.GetComponent<CloneBasicMovement> ().enabled = false;
		//Logger.Instance.writeToLog(DateTime.Now.TimeOfDay+"-CLONE DEAD: "+cloneType+", TURRET");
		CloneManager.Instance.destroyClone (gameObject);
	}
	
	protected virtual void OnDestroy ()
	{
		//Debug.Log("MATARAM-ME!");
		OnDestroyEvent (this.gameObject);
		
		
		//create death animation and effects
#if UNITY_EDITOR
		if(isQuitting) {
			return;	
		}
#endif	
		if(!Application.isLoadingLevel)
		{
			GameObject tmp = Instantiate (deathAnimation, Vector3.zero, Quaternion.identity) as GameObject;
			tmp.transform.position = transform.position;
			tmp.GetComponent<CloneDeathGore> ().headless ();
		}
	}
	
	public virtual void OnEnable ()
	{
//		this.arrowIndic.active = true;
//		OTAnimatingSprite arrowsprite = this.arrowIndic.GetComponent<OTAnimatingSprite>();
//		arrowsprite.PlayOnce("arrow");
//		arrowsprite.onAnimationFinish = this.ArrowAnimationFinished;
		
//		if(amStarted)
//		{
//			this.arrowplayTimes = 3;
//			this.arrowIndic.active = true;
//			arrowIndic.transform.localScale = new Vector3(1,1, 1 * OT.view.sizeFactor);
//		//	arrowsprite.size = Vector2.one;
//			arrowsprite.PlayOnce ("arrow");
//		//	arrowsprite.onAnimationFinish = this.ArrowAnimationFinished;
//			Debug.Log("ARROW STARTED "+arrowplayTimes);
//		}
	}
	
	public virtual void OnDisable()
	{
//		if(amStarted)
//		{
//			this.arrowplayTimes = 0;
//			arrowsprite.Stop();
//			this.arrowIndic.active = false;
//		}
	}
	
//	public void ArrowAnimationFinished (OTObject owner)
//	{
//		Debug.Log("ARROW FINISHED" + arrowplayTimes);
//		
//		if (owner == arrowsprite) {
//			if(arrowplayTimes > 0)
//			{
//				arrowIndic.transform.localScale = new Vector3(1,1, 1 * OT.view.sizeFactor);
//				arrowsprite.PlayOnce("arrow");
//				arrowplayTimes--;
//			}
//			else {
//				//arrowsprite.onAnimationFinish = null;
//				this.arrowIndic.active = false;	
////				arrowplayTimes = 3;
//			}
//		}
//	}
	
	
#if UNITY_EDITOR
    void OnApplicationQuit(){
		isQuitting = true;	
	}
#endif
}
