using UnityEngine;
using System.Collections;

public class RunContorller : MonoBehaviour {
	
	public float speed = 0.0004f;
	private Vector2 currentDir;

	// Use this for initialization
	void Start () {
		currentDir = new Vector2 (0,-2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
//		Debug.Log ("FixedUpdate");
//		transform.position = new Vector3 (transform.position.x, transform.position.y+speed,0);
		transform.Translate(currentDir * Time.deltaTime);
	}

}
