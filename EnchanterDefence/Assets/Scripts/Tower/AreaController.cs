using UnityEngine;
using System.Collections;

public class AreaController : UpgradeController {
	
	public GameObject tower1;
	public GameObject tower2;
	public GameObject tower3;

	public override void ownStart(){
	}
	public override void startBuild(int buildType){
		Debug.Log ("build");
		GameObject towerIns;
		if (buildType == 1) {
			towerIns = Instantiate (tower1) as GameObject;
		} else if (buildType == 2) {
			towerIns = Instantiate (tower2) as GameObject;
		} else if (buildType == 3) {
			towerIns = Instantiate (tower3) as GameObject;
		} else {
			return;
		}

		base.uiClose ();

		towerIns.transform.position = transform.position;

		Destroy (gameObject);
	}


	// do anmiation later
	void Update(){

	}

//	void OnGUI(){
//		GUI.Label (new Rect(0,0,100,1000),"0000000000000000000000000000");
//	}

//	void Update(){
//
//		if (!down && Input.GetMouseButton (0) ) {
//			down = true;
//			Debug.Log ("Update OnMouseDown");
//		}
//
//		if(down && Input.GetMouseButtonUp(0)){
//			down = false;
//			Debug.Log ("Update OnMouseDown Up");
//		}
//
//		Ray ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit hit1;  
//		LayerMask mask = LayerMask.NameToLayer("UI");  
//		if (Physics.Raycast(ray1,out hit1, Mathf.Infinity, mask.value)) {  
//			Debug.Log("clicked");
//			return;  
//		} 
//	}
//	
//	
//	void OnMouseEnter() {
//		rend.material.color = Color.red;
//	}
//	void OnMouseOver() {
//		rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
//	}
//	void OnMouseExit() {
//		rend.material.color = Color.white;
//	}
//

//	void OnMouseUpAsButton(){
//		Debug.Log ("Area OnMouseUpAsButton");
//	}

}
