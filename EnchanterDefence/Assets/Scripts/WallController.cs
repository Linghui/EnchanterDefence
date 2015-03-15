using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

	public GameObject explo;
	public int defence ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.CompareTag("enemy")){
			
			Destroy (collider.gameObject);
//			gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.5f, gameObject.transform.localScale.y,0);
			
			GameObject exploInstance = (GameObject)Instantiate (explo);
			exploInstance.transform.position = new Vector3 (collider.transform.position.x, gameObject.transform.position.y + 0.5f, 0);
			defence--;
			if(defence <= 0 ){
				Destroy(gameObject);
			}
		}
	}
}
