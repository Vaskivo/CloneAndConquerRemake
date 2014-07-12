using UnityEngine;
using System.Collections;
using System;

public class WeighScaleColliderHandler : MonoBehaviour {
	
	WeightScaleBehaviour weightScale;
	// Use this for initialization
	void Start () {
		weightScale = transform.parent.gameObject.GetComponent<WeightScaleBehaviour>();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Clone") {
			CloneAbilities comp = other.gameObject.GetComponent<CloneAbilities>();
			if (comp.cloneType == "FAT") {
				comp.OnDestroyEvent += FatCloneOnScaleDead;
				weightScale.increaseCloneOnTop();
			} else {
				comp.OnDestroyEvent += CloneOnScaleDead;
			}
			weightScale.increaseCloneOnTop();	
		}
	}
	
	public void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Clone") {
			CloneAbilities comp = other.gameObject.GetComponent<CloneAbilities>();
			if (comp.cloneType == "FAT") {
				comp.OnDestroyEvent -= FatCloneOnScaleDead;
				weightScale.reduceCloneOnTop();
			} else {
				comp.OnDestroyEvent -= CloneOnScaleDead;
			}
			weightScale.reduceCloneOnTop();	
		}
	}
	
	public void CloneOnScaleDead(GameObject clone) {
		clone.GetComponent<CloneAbilities>().OnDestroyEvent -= CloneOnScaleDead;
		weightScale.reduceCloneOnTop();
	}
	
	public void FatCloneOnScaleDead(GameObject clone) {
		clone.GetComponent<CloneAbilities>().OnDestroyEvent -= FatCloneOnScaleDead;
		weightScale.reduceCloneOnTop();
		weightScale.reduceCloneOnTop();
	}
}
