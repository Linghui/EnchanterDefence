using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	private GameObject goldBar;
	public float speed ;

	void Start(){
		goldBar = GameObject.FindGameObjectWithTag ("gold_bar");
	}

	void Update(){

		transform.Translate ( transform.InverseTransformPoint ( goldBar.transform.position) * Time.deltaTime * speed, Space.Self);

	}
}
