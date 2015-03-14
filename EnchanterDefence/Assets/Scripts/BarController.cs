using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour {
	
	public Sprite front;

	public GameObject owner;
	
	void Start(){

		setupBarLength (1f);
	}

	public void setupBarLength(float percent){
//		Debug.Log ("percent " + percent);
		if(percent < 0 ){
			percent = 0;
		} else if ( percent > 1 ){
			percent = 1;
		}
		int width = (int)(front.texture.width * percent);

//		Debug.Log ("width " + width);

		
		Sprite temp = Sprite.Create (front.texture, 
		                             new Rect(0,0,width,front.texture.height),
		                             new Vector2(0.5f/percent, 0.5f), 
		                             front.pixelsPerUnit);
		temp.name = front.name;

		GetComponent<SpriteRenderer> ().sprite = temp;
	}

}
