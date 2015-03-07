using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

	public float interval = 0.1f;
	private float counter = 0f;
	public GameObject fire;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if(counter >= interval){
			counter = 0f;
			Instantiate (fire);
		}
	}
}
