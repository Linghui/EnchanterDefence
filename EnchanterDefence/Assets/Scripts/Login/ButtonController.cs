using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	void startGame(){
		Debug.Log ("startGame");
		Application.LoadLevel ("GameScene");
	}

}
