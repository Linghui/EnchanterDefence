using UnityEngine;
using System.Collections;

public class BuildController : MonoBehaviour {

	private UpgradeController top;
	public int towerType;

	void Clicked(){
//		Debug.Log ("BuildController Clicked");
		top.startBuild (towerType);
	}

	public void setTop(UpgradeController inTop){
		top = inTop;
	}

}
