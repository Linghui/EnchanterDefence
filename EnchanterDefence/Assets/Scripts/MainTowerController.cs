using UnityEngine;
using System.Collections;

public class MainTowerController : MonoBehaviour {

	private Animator anim;
	private int direct = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
//		Touch touch = Input.GetTouch ();
//		bool clicked = Input.GetButton("Fire1");
//		if(Input.GetMouseButtonUp(0)){
//			direct++;
//			if(direct >= 2){
//				direct = -1;
//			}
//			Debug.Log("direct " + direct);
//		}
//
//		anim.SetInteger ("direct", direct);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnAnimationMove(){
		Debug.Log ("OnAnimationMove " + gameObject.GetComponent<Animation>().name);
	}
}
