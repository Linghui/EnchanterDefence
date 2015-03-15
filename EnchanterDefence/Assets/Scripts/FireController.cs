using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
	public float speed;
	public float deadDelay = 4f;
	void Start ()
	{
		Destroy (gameObject, deadDelay);
	}


}
