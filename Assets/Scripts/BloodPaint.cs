using UnityEngine;

public class BloodPaint : MonoBehaviour {
	
	int i;
	public GameObject BloodDrop;
	// Use this for initialization
	void Start () {
	//print("start");
		i= 0;
	}
	
	void OnParticleCollision(GameObject other) {
	    
		//print("Particle Collision");
		
		Particle[] emmitedParticles = other.particleEmitter.particles;
		
		foreach(Particle thisParticle in emmitedParticles)
		{
			if(thisParticle.velocity == Vector3.zero)
			{
				Vector3 pos = thisParticle.position;
				pos.z = 1;
				GameObject bDrop = Instantiate(BloodDrop, pos, Quaternion.identity) as GameObject;
				bDrop.transform.RotateAround(Vector3.right, 90f);
				//other.particleEmitter.
				break;
			}
				
			
		}
				
			//GameObject particle = Instantiate(particleHit, thisParticle.position, Quaternion.identity) as GameObject;
         //particle.particleEmitter.Emit();	
		
		/*print("onparticlecollision");
		Rigidbody body = other.rigidbody;
		print(other.rigidbody.position);
		Vector3 pos = body.rigidbody.position;
		pos.x = pos.x + 1;
		
		GameObject blooddrop = Instantiate(BloodDrop, Vector3.zero, Quaternion.identity) as GameObject;
		blooddrop.transform.position = pos;*/
	}
	
	// Update is called once per frame
	void Update () {
	
		//print("hello world");
		
	}
}
