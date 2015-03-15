using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldBarController : MonoBehaviour {

	public Text goldText;
	private int goldCounter = 0;

	void OnTriggerEnter2D(Collider2D collider){
	
		if(collider.CompareTag("coin")){
//			Debug.Log("got");
			Destroy(collider.gameObject);
			goldCounter++;
			updateGoleText();
		}
	}

	void updateGoleText(){
		goldText.text = goldCounter+"";
	}

}
