using UnityEngine;
using System.Collections;

public class SkillButtonController : MonoBehaviour {

	public GameController gameController;

	void Start(){
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void Clicked(){
		Debug.Log ("Clicked");
		gameController.fireSkill ();
	}
}
