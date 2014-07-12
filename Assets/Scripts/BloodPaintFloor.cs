using UnityEngine;

public class BloodPaintFloor : MonoBehaviour {
	
	int i;
	// Use this for initialization
	void Start () {
	//print("start");
		i= 0;
	}
	
	void OnParticleCollision(GameObject other) {
	    
		print("colision");
		Particle[] emmitedParticles = other.particleEmitter.particles;
		
		int i = 0;
		
		//Se colide com o chão, devia de fazer a particula desaparecer
		foreach(Particle thisParticle in emmitedParticles)
		{
			if(thisParticle.velocity == Vector3.zero)
			{
				i++;
				//other.particleEmitter.particles[i].energy = 0.001f;
				break;
			}
		    break;			
		}
				
		other.particleEmitter.particles[i].energy = 0.001f;
	}
	
	void Update () {
		
	}
}
