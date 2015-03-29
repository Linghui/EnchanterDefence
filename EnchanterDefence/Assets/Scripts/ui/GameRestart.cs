using UnityEngine;
using System.Collections;

public class GameRestart : MonoBehaviour {
	
	void Clicked(){
		Debug.Log ("GameRestart Clicked");
		Application.LoadLevel ("GameScene");
	}
}
