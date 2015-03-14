using UnityEngine;
using System.Collections;

public class MagicTowerController : MonoBehaviour {

	public int power;
	public float interal;
	private float counter;
	private bool fire = true;
	public GameObject fireObj;
	public GameObject shooter;
	private int fireObjHeight;

	private LineRenderer mLine;

	void Start(){
		counter = interal;
		fireObjHeight = fireObj.GetComponent<SpriteRenderer> ().sprite.texture.height;
//		Debug.Log ("test " + distance(0,0,3,4));
//		print ("print (Mathf.Atan(0.5));" + Mathf.Atan(1f)* Mathf.Rad2Deg);

		mLine = GetComponent<LineRenderer> ();
		mLine.sortingLayerName ="player";

	}

	void Update(){
		if(!fire){
			counter -= Time.deltaTime;
		}

		if(counter <= 0){
			counter = interal;
			fire = true;
		}


	}

	void OnTriggerStay2D(Collider2D collider){
		
		if(collider.CompareTag("enemy")){
			
			if(fire){
				fire = false;
//				shooter.transform.localScale = new Vector3(1,1,1);


				GameObject lighting = Instantiate(fireObj, 
				                                  new Vector3( shooter.transform.position.x, shooter.transform.position.y+ 0.5f ,0),
				                                  transform.rotation) as GameObject;
				
				lighting.transform.SetParent(shooter.transform);


				lighting.transform.position = shooter.transform.TransformPoint(new Vector3(0, 0.2f, 0));

//				mLine.SetPosition (0, shooter.transform.position);
//				mLine.SetPosition (1, collider.transform.position);

				float dist = Vector2.Distance(shooter.transform.position, collider.transform.position);

//				Debug.Log("dist2 " + dist);


				float angle = Angle.cangle(shooter.transform.position.x,shooter.transform.position.y, 
				                    collider.transform.position.x,collider.transform.position.y);

//				Debug.Log("angle " + angle);
				
				lighting.transform.localScale = new Vector3(1, dist/2, 1);
				lighting.transform.position += new Vector3(0,dist/2,0);

				lighting.transform.RotateAround(shooter.transform.position, new Vector3(0,0,1), angle);
//				lighting.transform.Rotate( new Vector3( 0,0, angle));
				
			}
		}
	}


}
