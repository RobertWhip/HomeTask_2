using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void OnClickStart() {
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
	
	public void OnClickSetting() {
		Debug.Log("Setting");
	}
	
	public void OnClickCredits() {
		Debug.Log("Credits");
	}
	
	public void OnClickExit() {
		Application.Quit();
	}
}
