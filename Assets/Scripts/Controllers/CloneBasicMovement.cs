using UnityEngine;
using System.Collections;
 
public class CloneBasicMovement : MonoBehaviour
{
 
    public float speed = 100.0f;
    public float jumpForce = 100.0f;
    public float airModifier = 0.5f;
 
	private bool turnedOn = true;
	
	CloneBase cBase;
	
	public void Awake()
	{
		this.rigidbody.freezeRotation = true;
		cBase = gameObject.GetComponent<CloneBase>();
	}
	
    public void Update()
    {
		if (turnedOn && cBase.movable) {
	        //is the user pressing left or right (or "a & "d") on the keyboard?       
			float axis = Input.GetAxis("Horizontal");
			if(axis == 0) { // not pressing any direction key
				cBase.isWalking = false;	
			} else {
				if(axis < 0) { // pressing left key
					cBase.isLeft = true;
					if(cBase.collidesOnTheLeft) {
						axis = 0;
					} else {
						cBase.isWalking = true;	
					}
				} else { // pressing right key
					cBase.isLeft = false;
					if(cBase.collidesOnTheRight) {
						axis = 0;
					} else {
						cBase.isWalking = true;	
					}
				}
			}
			Vector3 horMovement = axis * transform.right * Time.deltaTime * speed;
			
			
	        //is the user pressing up or down (or "w" & "s") on the keyboard?
	        Vector3 forwardMovement = Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * speed;		
			
	       //jump if the user pressing the space key AND our character is grounded
	        if (Input.GetKeyDown(KeyCode.Space) && cBase.isOnGround)
	        {
	            rigidbody.AddRelativeForce(transform.up * jumpForce, ForceMode.Impulse);
				//grounded = false;
	        }
			if(Input.GetKeyUp(KeyCode.Space) && !cBase.isOnGround)
			{
				if(rigidbody.velocity.y > 0)
				{
					rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f, rigidbody.velocity.z);
				}
			}
			
			if(!cBase.isOnGround)
			{
				horMovement *= airModifier;
				forwardMovement *= airModifier;
			}
	 
	        //move our character
	        transform.Translate(forwardMovement + horMovement);
		}
    }
	
	public void activate() {
		turnedOn = true;	
	}
	
	public void deactivate() {
		turnedOn = false;
		cBase.isWalking = false;
	}
	
	
	//properly deactivate clone movement and animations
	public void OnDisable()
	{
		Debug.Log("Clone Desactivado!");
		this.GetComponent<OTAnimatingSprite>().Play("Idle"+ (cBase.isLeft ? "L" : "R"));
		this.GetComponent<CloneAnimation>().enabled = false;
	//	this.GetComponent<OTAnimatingSprite>().Stop();
	}
}