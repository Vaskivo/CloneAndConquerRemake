using UnityEngine;
using System.Collections;

public class ArrowIndicatorBehaviour : MonoBehaviour {
	
	public int arrowplayTimes;
	private int play_counter;
	private OTAnimatingSprite arrowsprite;
	private bool amStarted = false;
	private GameObject activeClone;
	
	// Use this for initialization
	void Start () {
		this.arrowsprite = gameObject.GetComponent<OTAnimatingSprite>();
		arrowsprite.onAnimationFinish = this.ArrowAnimationFinished;
		this.amStarted = true;
		this.play_counter = this.arrowplayTimes;
		this.arrowsprite.PlayOnce("arrow");
	}
	
	public void Update()
	{
		transform.position = new Vector3(activeClone.transform.position.x, activeClone.transform.position.y + 1f, activeClone.transform.position.z - 1f);
	}
	
	public void StartIndicatingClone(GameObject clone_pointer)
	{
		this.activeClone = clone_pointer;
		gameObject.transform.position = new Vector3(activeClone.transform.position.x, activeClone.transform.position.y + 1f, activeClone.transform.position.z - 1f);
		gameObject.active = true;
	}
	
	public void ArrowAnimationFinished(OTObject owner)
	{
		if(owner == arrowsprite)
		{
			if(this.play_counter > 0)
			{	
				//Repeat animation
				this.arrowsprite.PlayOnce("arrow");
				this.play_counter--;
			}
			else
				gameObject.active = false;
		}
	}

	public void OnEnable()
	{
		if(this.amStarted)
		{
			this.play_counter = this.arrowplayTimes;
			this.arrowsprite.PlayOnce("arrow");
		}
	}
	
	public void OnDisable()
	{
		if(this.amStarted)
		{
			arrowsprite.Stop();
		}
	}
}
