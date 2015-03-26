using UnityEngine;
using System.Collections;

public class MainBody : MonoBehaviour {

	public GameController gameController;

	void OnTriggerEnter2D(Collider2D collider){
//		Debug.Log ("OnTriggerEnter2D enemy");
		if(collider.CompareTag("enemy")){
			Destroy(collider.gameObject);
			gameController.damage(1);
		}
	}
}
