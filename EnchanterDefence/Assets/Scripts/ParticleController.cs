using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {
	
	public float deadDelay = 2f;
	// Use this for initialization
	void Start () {
		
		Destroy (gameObject, deadDelay);
		GetComponent<ParticleSystem> ().GetComponent<Renderer> ().sortingLayerName = "enemy";
	}

}
