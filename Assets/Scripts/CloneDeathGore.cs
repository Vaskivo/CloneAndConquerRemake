using UnityEngine;
using System.Collections;

public class CloneDeathGore : MonoBehaviour {
	
	public float explosionPowerMin = 15000;
	public float explosionPowerMax = 25000;
	public float explosionRadius = 100;
	
	
	// Use this for initialization
//	void Start () {
//	}
	
	// Update is called once per frame
//	void Update () {	
//	}
	
	public void explode() {
		Vector3 tmpPosition = transform.position;
		tmpPosition = new Vector3(tmpPosition.x, tmpPosition.y, tmpPosition.z); 
		foreach (Transform child in transform) {
			Debug.Log(child.name + ' ' + child.transform.position);			 
			child.gameObject.rigidbody.AddExplosionForce(explosionPowerMax, tmpPosition, explosionRadius);
			//child.rigidbody.AddForce(Vector3.up * explosionPowerMax);
		}
		Destroy(gameObject, 2f);
	}
	
	public void headless() {
		GameObject head = null;
		foreach (Transform child in transform) {
			if(child.name == "Head") {
				head = child.gameObject;
				break;
			}
		}
		head.rigidbody.AddForce(Vector3.up * explosionPowerMax);
		Destroy (gameObject, 2f);
	}
	
	void OnApplicationQuit() {
		Destroy (gameObject);	
	}
}
