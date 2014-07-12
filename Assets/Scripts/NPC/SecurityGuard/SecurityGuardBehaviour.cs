using UnityEngine;
using System.Collections;
using System;

public class SecurityGuardBehaviour : MonoBehaviour {
	
	public event Action<int> ChangeWalkingAnimation = (obj) => {};
	public event Action<int> StartHit;
	//public event Action<int> HitAnimation;
	
	public float speed = 200;
	public float hitDuration = 1f;
	public bool hitting = false;
	
	private int mydirection;	
	public int direction { 
		get { return mydirection; } 
		set {
			mydirection = value;
			ChangeWalkingAnimation(mydirection);
			}
	}
	// Left = -1, Right = 1
	//public int direction {get; set;}
	// Use this for initialization
	void Start () {
		direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hitting) {
			transform.Translate(Vector3.right * direction * Time.deltaTime * speed);	
		}
	}
	
	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Clone") 
		{
			//Debug.Log("GUARDA COLIDIU COM: " + col.gameObject.name); //corrigir aqui!!
			
			if(this.gameObject.active)
			{
				hitting = true;
				StartCoroutine("HittingCoroutine");
			}
		}
	}
	
	IEnumerator HittingCoroutine()
	{	
		StartHit(direction);
	    yield return new WaitForSeconds(hitDuration);		
	    ChangeWalkingAnimation(direction);
		hitting = false;
	}
	
	public void OnDisable()
	{
		StopCoroutine("HittingCoroutine");
		hitting = false;
	}
}
