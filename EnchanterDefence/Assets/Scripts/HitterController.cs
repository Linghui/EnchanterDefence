using UnityEngine;
using System.Collections;

public class HitterController : MonoBehaviour {

	public GameObject invBullet;

	void OnTriggerStay2D(Collider2D collider){
		if(collider.CompareTag("bomb")){
//			Debug.Log ("hitter got it");
			Destroy(collider.gameObject);

			Destroy(gameObject);

			GameObject ins = Instantiate(invBullet) as GameObject;
			ins.transform.position = gameObject.transform.position;
		}

	}
}
