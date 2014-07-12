using UnityEngine;
using System.Collections;

public class BloodAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(this.transform.localScale.z <= 0.3){
		this.transform.localScale += new Vector3(0.0f, 0.0f, 0.001f);
		this.transform.Translate(0.0f, 0.0f, 0.005f);
		}
	}
}
