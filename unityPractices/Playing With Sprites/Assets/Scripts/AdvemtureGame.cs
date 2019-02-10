using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvemtureGame : MonoBehaviour {

	[SerializeField] Text TextComponent;
	[SerializeField] State startingState;

	State state;

	// Use this for initialization
	void Start () {
		state = startingState;
		TextComponent.text = state.GetStoryText();
	}

	// Update is called once per frame
	void Update () {
		ManageState();
	}

	private void ManageState()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			state = state.getNextState(0);
		} else if(Input.GetKeyDown(KeyCode.Alpha2)) {
			state = state.getNextState(1);
		}

		TextComponent.text = state.GetStoryText();
	}
}
