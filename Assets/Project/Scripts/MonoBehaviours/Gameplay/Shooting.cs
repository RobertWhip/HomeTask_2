using UnityEngine;
using System.Collections;
 
public class Shooting : MonoBehaviour {
    public GameObject emitter;
    public GameObject bullet;
    public float force;
	public float reloadTime = 2f;
	
	private static bool globalCanShoot = true;
	private bool incCanShoot = true;
	
    void Update () {
        if (incCanShoot && globalCanShoot && Input.GetMouseButtonDown(0)) {
			incCanShoot = false;
			StartCoroutine(Reload(reloadTime));
			
			GetComponent<AudioSource>().Play();
            GameObject obj = Instantiate(bullet, emitter.transform.position, emitter.transform.rotation) as GameObject;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force);
            Destroy(obj, 3.0f);
        }
    }
	
	public static void CanShoot(bool can) {
		globalCanShoot = can;
	}
	
	IEnumerator Reload(float seconds) {
		yield return new WaitForSeconds(seconds);
		incCanShoot = true;
	}
}