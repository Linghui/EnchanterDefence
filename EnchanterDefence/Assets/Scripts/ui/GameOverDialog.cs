using UnityEngine;
using System.Collections;

public class GameOverDialog : MonoBehaviour {

	public float time = 2;
	public int speed = 4;
	private float count = 0;


	public void showDialog(){
		gameObject.SetActive (true);
		gameObject.transform.localScale = new Vector3 (0.2f,0.2f,1);
	}

	void Update(){
		if(!gameObject.activeSelf){
			return;
		}
		count += Time.deltaTime * speed;
		if(count >= 1){
			count =1;
		}
		gameObject.transform.localScale = new Vector3 (1, 1, 1) * count;
	}

}
