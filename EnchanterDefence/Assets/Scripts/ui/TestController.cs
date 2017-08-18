using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestController : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
		text.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
