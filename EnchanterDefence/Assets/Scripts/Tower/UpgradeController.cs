using UnityEngine;
using System.Collections;

public abstract class UpgradeController : MonoBehaviour {
	
	public GameObject circlePre;
	public GameObject circleIns;
	private bool cShow = false;
	
	void Start(){
		
		GameObject circle = Instantiate(circlePre) as GameObject;
		circle.transform.SetParent (transform);
		circle.transform.position = transform.position;
		circleIns = circle;
		
		
		BuildController[] list = gameObject.GetComponentsInChildren<BuildController> ();
		Debug.Log ("AreaController " + list.Length);
		for(int index=0; index < list.Length ; index++){
			list[index].setTop(this);
		}
		
		circleIns.SetActive (false);


	}

	public abstract void ownStart ();

	public void Clicked(){
		//		Debug.Log ("UpgradeController clicked");
		toggleUI ();
	}
	
	public void toggleUI(){
		if (cShow) {
			uiClose();
		} else {
			uiShow();
		}
	}
	
	public void uiClose(){
		Debug.Log ("ui close");
		cShow = false;
		circleIns.SetActive (false);
	}
	
	public void uiShow(){
		Debug.Log ("ui uiShow");
		cShow = true;
		//		createUI.transform.localScale = Vector2 (0.1f, 0.1f);
		circleIns.SetActive (true);
	}

	public abstract void startBuild(int buildType);
}
