using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	public GameObject player;
	public float speed = 4f;
	
	void Start() {
		transform.LookAt(player.transform);
	}
	
	void Update () {
		if (gameObject.CompareTag(TargetGenerator.MOVING)) {
			transform.position += new Vector3(Random.Range(-1, 1), 0, Random.Range(1, 1)) * speed * Time.deltaTime;
			transform.LookAt(player.transform);
		}
	}
}
