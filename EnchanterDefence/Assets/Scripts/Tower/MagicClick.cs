using UnityEngine;
using System.Collections;

public class MagicClick : MonoBehaviour {

	public MagicTowerController children;

	void Clicked(){
		children.Clicked ();
	}
}
