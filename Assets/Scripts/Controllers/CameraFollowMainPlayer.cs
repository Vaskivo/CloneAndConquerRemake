using UnityEngine;
using System.Collections;
using System;

public class CameraFollowMainPlayer : MonoBehaviour {
	
	public event Action StoppedMovingAfterDeath = (() => {});
	
	//private Transform thisTransform;
	private bool waiting = false;
	private bool sliding = false;
	private float slideDuration = 1f;
	//private float slideTimeStart = 0;
	private Vector3 slideDirection;
	
//	void Awake(){
//		//thisTransform = transform;	
//	}
//	
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
	// Update is called once per frame
	void Update () {
		
		if (!waiting && !sliding) {
			//Debug.Log(thisTransform.position.ToString());
			GameObject activeClone = CloneManager.Instance.activeClone.Value;
	
			camera.transform.position = new Vector3(activeClone.transform.position.x, 
													activeClone.transform.position.y + 1.5f, 
													camera.transform.position.z);
		}
		if (sliding) {
			camera.transform.Translate(slideDirection * (Time.deltaTime / slideDuration ));
		}	
	}
	
	public void waitAndSee() {
		waiting = true;
		StartCoroutine("WaitingCoroutine");
	}
	
	public void slideCamera()
	{
		sliding = true;
		slideDirection = CloneManager.Instance.activeClone.Value.transform.position - camera.transform.position;
		slideDirection.z = 0;
		slideDirection.y += 1.5f;
		slideDuration = slideDirection.magnitude / 10f;
		StartCoroutine("SlidingCoroutine");	
	}
	
	IEnumerator WaitingCoroutine() {
		yield return new WaitForSeconds(2f);
		waiting = false;
		sliding = true;
		slideDirection = CloneManager.Instance.activeClone.Value.transform.position - camera.transform.position;
		slideDirection.z = 0;
		slideDirection.y += 1.5f;
		slideDuration = slideDirection.magnitude / 10f;
		StartCoroutine("SlidingCoroutine");
	}
	
	IEnumerator SlidingCoroutine() {
		yield return new WaitForSeconds(slideDuration);
		CloneManager.Instance.activateActiveClone();
		sliding = false;
		StoppedMovingAfterDeath();
	}
}
