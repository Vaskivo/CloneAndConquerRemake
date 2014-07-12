using UnityEngine;
using System.Collections;
using System;

public class TeleportBehaviour : MonoBehaviour {

	public event Action<Vector3> destroyed = (Vector3 obj) => {};
	
	// Use this for initialization
	void Start () {
		DestroyObject(gameObject, 1f);
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
	
	void OnDestroy() {
		destroyed(transform.position);	
	}
}
