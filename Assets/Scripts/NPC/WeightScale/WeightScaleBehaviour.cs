using UnityEngine;
using System.Collections;
using System;

public class WeightScaleBehaviour : MonoBehaviour {

	public event Action PlatformsAppear;
	public event Action PlatformsVanish;
	
	
	private OTSprite sprite;
	
	private int cloneOnTopCount;
	// Use this for initialization
	void Start () {
		cloneOnTopCount = 0;
		sprite = gameObject.GetComponent<OTSprite>();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	public void increaseCloneOnTop() {
		cloneOnTopCount++;
		if(cloneOnTopCount >= 1) {
			if (cloneOnTopCount >=2) {
				sprite.frameIndex = 5; // tmp hack
				PlatformsAppear();
			} else {
				sprite.frameIndex = 4; // hack, cough	
			}
		}
	}
	
	public void reduceCloneOnTop() {
		cloneOnTopCount--;
		if(cloneOnTopCount < 2) {
			if (cloneOnTopCount < 1) {
				sprite.frameIndex = 3; // tmp hack
			} else {
				sprite.frameIndex = 4;	
				PlatformsVanish();
			}
		}
	}
}
