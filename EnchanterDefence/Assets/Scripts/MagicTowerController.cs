using UnityEngine;
using System.Collections;

public class MagicTowerController : UpgradeController {
	
	public int power;
	public float interal;
	public GameObject fireObj;
	public GameObject shooter;
	public GameObject builder;
	public GameObject top;

	private int fireObjHeight;
	private float counter;
	private bool fire = true;
	private LineRenderer mLine;
	private Animator anim;
	private bool isFlip = false;
	private int level = 1; 

	public override void ownStart(){
		
		counter = interal;
		fireObjHeight = fireObj.GetComponent<SpriteRenderer> ().sprite.texture.height;
		anim = gameObject.GetComponent<Animator> ();
		
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

	public override void startBuild(int buildType){
		Debug.Log ("build " + buildType);
		base.uiClose ();
		// upgrade
		if(buildType == 1){
			upgrade();
		}
		// sell
		else if ( buildType == -1){
			Destroy(top);
			GameObject builderIns = Instantiate(builder) as GameObject;
			builderIns.transform.position = transform.position;
		}


	}

	void upgrade(){
		Debug.Log ("upgrade " + level++);
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

				if( angle > 30){
					faceLeft();
				} else if ( angle < -30){
					faceRight();
				} else {
					faceUp();
				}

//				Debug.Log("angle " + angle);
				
				lighting.transform.localScale = new Vector3(1, dist/2, 1);
				lighting.transform.position += new Vector3(0,dist/2,0);

				lighting.transform.RotateAround(shooter.transform.position, new Vector3(0,0,1), angle);
//				lighting.transform.Rotate( new Vector3( 0,0, angle));
				
			}
		}
	}


	void faceLeft(){
//		Debug.Log ("faceLeft");
		if(isFlip){
			flip();
		}
		anim.SetTrigger ("a2");
	}

	void faceUp(){
//		Debug.Log ("faceUp");
		anim.SetTrigger ("a1");
	}

	void faceRight(){
		//		Debug.Log ("faceRight");
		if(!isFlip){
			flip();
		}
		anim.SetTrigger ("a2");
	}

	void flip(){
		isFlip = !isFlip;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

}
