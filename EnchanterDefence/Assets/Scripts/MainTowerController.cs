using UnityEngine;
using System.Collections;

public class MainTowerController : MonoBehaviour {

	private Animator anim;
	private int direct = 0;
	public GameObject shooter;
	public GameObject left_shooter;
	public GameObject right_shooter;
	public GameObject fireBullet;
	public float interval;
	private float intervalCounter = 0f;
	private bool fire = true;
	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
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

	void FixedUpdate(){
//		Touch touch = Input.GetTouch ();
//		bool clicked = Input.GetButton("Fire1");
//		if(Input.GetMouseButtonUp(0)){
//			direct++;
//			if(direct >= 2){
//				direct = -1;
//			}
//			Debug.Log("direct " + direct);
//		}
//
//		anim.SetInteger ("direct", direct);
	}

	void OnTriggerStay2D(Collider2D collider){

		if(collider.CompareTag("enemy") && fire){
			fire = false;

			GameObject bullet = Instantiate(fireBullet) as GameObject;


//			Debug.Log("bullet.transform.position " + shooter.transform.position);
//			Debug.Log("bullet.transform.position " + collider.transform.position);


			Vector3 td = shooter.transform.InverseTransformPoint(collider.transform.position);
//			Debug.Log("td " + td);

			Vector2 dirc = Vector2.MoveTowards(new Vector2(0,0), td,1);
//			Debug.Log("dirc " + dirc);
			bullet.GetComponent<Rigidbody2D>().velocity = dirc * bulletSpeed;


			float angle = Angle.cangle(shooter.transform.position, collider.transform.position);
			bullet.transform.Rotate(new Vector3(0,0,angle));

			if(angle > 20){
				anim.SetTrigger("a2");
				bullet.transform.position = left_shooter.transform.position;
			} else if (angle < -20){
				anim.SetTrigger("a3");
				bullet.transform.position = right_shooter.transform.position;
			} else {
				anim.SetTrigger("a1");
				bullet.transform.position = shooter.transform.position;
			}
		}
	}


}
