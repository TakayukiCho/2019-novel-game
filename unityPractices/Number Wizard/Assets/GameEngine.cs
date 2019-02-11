using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

	[SerializeField]int max;
	[SerializeField]int min;
	int guess;
	[SerializeField]Text guessText;

	// Use this for initialization
	void Start () {
		guess = (max + min) / 2;
		guessText.text = guess.ToString();
		// max = max + 1;
	}

	public void OnPressHigher(){
		max = guess;
		guess = (min + max) / 2;
		guessText.text = guess.ToString();
	}

	public void OnPressLower(){
		min = guess;
		guess = (min + max) / 2;
		guessText.text = guess.ToString();
	}

}
