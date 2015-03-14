using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
	public float speed;
	public float deadDelay = 4f;
	void Start ()
	{
		Destroy (gameObject, deadDelay);
//		Vector3 forward = new Vector3 (0, 2, 0);
//		GetComponent<Rigidbody2D>().velocity = forward * speed;
	}


}
