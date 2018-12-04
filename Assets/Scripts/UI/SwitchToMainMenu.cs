﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoMenu()
	{
		SceneManager.LoadScene("Scenes/MainMenu");
	}
	
	public void RestartGame()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("Scenes/SampleScene");
	}
}
