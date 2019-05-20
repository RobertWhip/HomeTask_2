using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	
	public static Manager instance;
	public GameObject menu;
	public Button continue_;
	public Text scoreText;
	public Text time;
	public Text highScore;
	public int seconds = 60;
	
	private const string HIGH_SCORE = "high_score";
	private bool menuOpened = false;
	private bool canPlay = true;
	private static int score = 0;
	
	void Start() {
		// clean highscore
		//PlayerPrefs.SetInt(HIGH_SCORE, 0);
		score = 0;
		if (PlayerPrefs.HasKey(HIGH_SCORE))
			highScore.text = "High score: " + PlayerPrefs.GetInt(HIGH_SCORE);
		
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
		CloseMenu();
		TargetGenerator.GenerateTargets(true);
		StartCoroutine(StartTimer(seconds));
	}

	void UpdateTime(int second) {
		if (second == 0)
			time.text = "Time out!";
		else
			time.text = "Time " + second + " sec left";
	}
	
	void SaveScore() {
		if (PlayerPrefs.HasKey(HIGH_SCORE)) {
			if(PlayerPrefs.GetInt(HIGH_SCORE) < score)
				PlayerPrefs.SetInt(HIGH_SCORE, score);
		} else
			PlayerPrefs.SetInt(HIGH_SCORE, score);
		
		highScore.text = "High score: " + PlayerPrefs.GetInt(HIGH_SCORE);
	}
	
	public void AddScore(int addScore) {
		
		score += addScore;
		scoreText.text = "Score: " + score;
	}
	
	void TimeOut() {
		canPlay = false;
		TargetGenerator.GenerateTargets(false);
		OpenMenu();
	}

	void Update () {
		continue_.interactable = canPlay;
		if (canPlay && Input.GetKeyDown(KeyCode.Escape)) 
			OnEscapeClick();
	}
	
	private void OnEscapeClick(){
		if(menuOpened) {
			CloseMenu();
		} else {
			OpenMenu();
		}
	}
	
	private void OpenMenu() {
		SaveScore();
		Shooting.CanShoot(false);
		CameraController.CanRotate(false);
		menuOpened = true;
		menu.SetActive(true);
	}
	
	private void CloseMenu() {
		Shooting.CanShoot(true);
		CameraController.CanRotate(true);
		menuOpened = false;
		menu.SetActive(false);
	}
	 
	public void OnRestart() {
		 SceneManager.LoadScene(1, LoadSceneMode.Single);
	 }
	 
	public void OnContinue() {
		 OnEscapeClick();
	 }
	 
	public void OnMenuClick() {
		 SceneManager.LoadScene(0, LoadSceneMode.Single);
	 }
	 
	IEnumerator StartTimer(int seconds){
		for (int i = seconds; i > 0; i--) {
			UpdateTime(i);
			yield return new WaitForSeconds(1f);
		}
		UpdateTime(0);
		TimeOut();
	}
}
