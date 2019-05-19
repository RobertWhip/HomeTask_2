 using UnityEngine;
 using System.Collections;
 
 public class CameraController : MonoBehaviour 
 {
     private float x;
     private float y;
     private Vector3 rotateValue;
	 private static bool canRotate = true;
 
     void Update()
     {
		 if (canRotate) {
			 y = Input.GetAxis("Mouse X");
			 x = Input.GetAxis("Mouse Y");
			 rotateValue = new Vector3(x, y * -1, 0);
			 transform.eulerAngles -= rotateValue;
		 }
     }
	 
	 public static void CanRotate(bool can) {
		 canRotate = can;
	 }
	
 }