using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DialogManager : MonoBehaviour {
	
	public static DialogManager Instance;
	//private UnityEngine.Random rand;
	private System.Random rand;
	
	void Awake () {
		Instance = this;
		//rand = new UnityEngine.Random();
		rand = new System.Random(Time.frameCount);
	}
	
	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
		
	public void CloneCloneInteraction(GameObject performer, GameObject other) {
		// randomize if someone talks
		// if someone talks
		//		randomize wich clone talks
		//		selected clone.talk(other)
	}
	
	// for spikes, security guards and turrets
	// tambem nao vou usar isto!
	public void CloneHazardInteraction(GameObject clone, string hazardName) {
		// depends on a lot of stuff
	}
}
