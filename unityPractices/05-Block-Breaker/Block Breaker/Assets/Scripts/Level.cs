using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	private int blockCounts = 0;

	[SerializeField] float gameSpeed;

	[SerializeField] Text scoreUI;

	int score = 0;

	void Start(){
		Time.timeScale = gameSpeed;
		scoreUI.text = 0.ToString();
	}

	public void OnBlockInstantiated(){
		blockCounts++;
	}

	public void OnBlockDestroyed(){
		score += UnityEngine.Random.Range(1, 10);
		scoreUI.text = score.ToString();
		blockCounts--;
		Time.timeScale += 0.01f;
		if(blockCounts <= 0){
			var sceneLoader = FindObjectOfType<SceneLoader>();
			sceneLoader.LoadNextScene();
		}
	}

}
