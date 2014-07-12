using UnityEngine;
using System.Collections;

public class SecurityGuardZoneBehaviour : MonoBehaviour {
	
	SecurityGuardBehaviour securityGuard;
	
	// Use this for initialization
	void Start () {
		securityGuard = transform.parent.GetComponentInChildren<SecurityGuardBehaviour>();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Security") {
			//securityGuard.direction = - securityGuard.direction;
			other.gameObject.GetComponent<SecurityGuardBehaviour>().direction = -other.gameObject.GetComponent<SecurityGuardBehaviour>().direction;
		}
	}
}
