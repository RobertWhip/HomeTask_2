using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour {
	public const string STILL = "StillTarget";
	public const string MOVING = "MovingTarget";
	
	public GameObject player;
	public GameObject target;
	public float waitForMoving = 4f;
	public float waitForStill = 2f;
	public float destroyIn = 5f;
	
	public float minx, maxx;
	public float miny, maxy;
	public float minz, maxz;
	
	private static bool generateTargets = true;
	
	void Start() {
		StartCoroutine(CreateStillTargets());
		StartCoroutine(CreateMovingTargets());
	}
	
	public static void GenerateTargets(bool can) {
		generateTargets = can;
	}
	
	IEnumerator CreateStillTargets() {
		Vector3 pos = new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), Random.Range(minz, maxz));
		GameObject obj = Instantiate(target, pos, Quaternion.Euler(0, 0, 0)) as GameObject;
		obj.tag = STILL;
		obj.GetComponent<Target>().player = player;
		Destroy(obj, destroyIn);
		yield return new WaitForSeconds(waitForStill);
		if (generateTargets)
			StartCoroutine(CreateStillTargets());
	}
	
	IEnumerator CreateMovingTargets() {
		Vector3 pos = new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), Random.Range(minz, maxz));
		GameObject obj = Instantiate(target, pos, Quaternion.Euler(0, 0, 0)) as GameObject;
		obj.tag = MOVING;
		obj.GetComponent<Target>().player = player;
		Destroy(obj, destroyIn);
		
		yield return new WaitForSeconds(waitForMoving);
		if (generateTargets) 
			StartCoroutine(CreateMovingTargets());
	}
}
