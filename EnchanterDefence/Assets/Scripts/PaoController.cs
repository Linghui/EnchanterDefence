using UnityEngine;
using System.Collections;

public class PaoController : MonoBehaviour {

	public GameObject shooter;
	public GameObject bullet;
	public GameObject hitter;
	public GameObject imgObj;
	public bool isFlip;
	
	public float interval;
	private float intervalCounter = 0f;
	private bool fire = true;
	public float bulletSpeed;


	private Animator anim;

	void Start(){
		if(isFlip){
			flip();
		}
		anim = imgObj.GetComponent<Animator>();
	}
	
	void Update(){
		
		if(!fire){
			intervalCounter -= Time.deltaTime;
		}
		
		if(intervalCounter <= 0){
			intervalCounter = interval;
			fire = true;
		}
	}

	
	void OnTriggerStay2D(Collider2D collider){
		
		if(collider.CompareTag("enemy") && fire){
			fire = false;

			anim.SetTrigger("f");

			GameObject bulletIns = Instantiate(bullet) as GameObject;
			bulletIns.transform.position = shooter.transform.position;

			GameObject hitterIns = Instantiate(hitter) as GameObject;
			hitterIns.transform.position = collider.gameObject.transform.position;
			
			
			//			Debug.Log("bullet.transform.position " + shooter.transform.position);
			//			Debug.Log("bullet.transform.position " + collider.transform.position);
			
			
			Vector3 td = shooter.transform.InverseTransformPoint(collider.transform.position);
			//			Debug.Log("td " + td);
			
			Vector2 dirc = Vector2.MoveTowards(new Vector2(0,0), td,1);
			//			Debug.Log("dirc " + dirc);
			bulletIns.GetComponent<Rigidbody2D>().velocity = dirc * bulletSpeed;
			
			
			float angle = Angle.cangle(shooter.transform.position, collider.transform.position);
			bulletIns.transform.Rotate(new Vector3(0,0,angle));

		}
	}
	
	void flip(){

		Vector3 theScale = imgObj.transform.localScale;
		theScale.x *= -1;
		imgObj.transform.localScale = theScale;
		
	}
}
