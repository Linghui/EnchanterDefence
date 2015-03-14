using UnityEngine;
using System.Collections;

public class Angle : MonoBehaviour {

	public static float cangle(Vector2 v1, Vector2 v2){
		return cangle (v1.x, v1.y, v2.x, v2.y);
	}

	public static float cangle(float x1, float y1, float x2, float y2){
		
		if( x1 == x2){
			return 0;
		}
		
		
		
		float tan = Mathf.Atan((y1 - y2)/(x1-x2))* Mathf.Rad2Deg;
		if (x1 > x2) {
			tan += 90;
		} else {
			tan -= 90;
		}
		
//		Debug.Log ("angle tan " + tan);
		return tan;
		
		
		
	}
}
