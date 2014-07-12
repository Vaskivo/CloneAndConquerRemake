using UnityEngine;
using System.Collections;

public class MainCloneAbilitiesColliderHandler : CloneAbilitesColliderHandler {

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public override void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Checkpoint")
		{
			//Call CloneManager to update checkpoint info
			CloneManager.Instance.UpdateCheckpoint(other.gameObject);
		}
		
		else base.OnTriggerEnter(other);
//		if (other.gameObject.tag == "Clone") {
//			//Debug.Log("APANHEI TRIGGER COM: " + other.gameObject.name + "\nCHAMO-ME "+ this.gameObject.transform.parent.gameObject.name);
//			other.gameObject.GetComponent<ClonePassiveAbilities>().doStuff(this.gameObject.transform.parent.gameObject);
//			//gameObject.transform.parent.gameObject.GetComponent<ClonePassiveAbilities>().doStuff(other.gameObject);	
//		}
	}
}
