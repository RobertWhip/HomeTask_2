using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject hole;
	
	void OnCollisionEnter(Collision collision)
    {
        GetComponent<ParticleSystem>().Play();
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<AudioSource>().Play();
		
		
		if(collision.gameObject.CompareTag(TargetGenerator.STILL)) {
			Manager.instance.AddScore(5);
			Destroy(collision.gameObject);
			return;
		} else if (collision.gameObject.CompareTag(TargetGenerator.MOVING)) {
			Manager.instance.AddScore(10);
			Destroy(collision.gameObject);
			return;
		}
		GameObject obj = Instantiate(hole, transform.position, transform.rotation) as GameObject;
		Destroy(obj, 3f);
    }
}
