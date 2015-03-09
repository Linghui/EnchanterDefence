using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour {
	
	public Sprite front;
	
	void Start(){
		Sprite temp = Sprite.Create (front.texture, 
		                             new Rect(0,0,front.texture.width/2,front.texture.height), 
		                             new Vector2(1, 0.5f), 
		                             front.pixelsPerUnit);
		GetComponent<SpriteRenderer> ().sprite = temp;
	}
}
