using UnityEngine;
using System.Collections;

public class RunContorller : MonoBehaviour {
	
	public float speed;
	public GameObject explo;
	public GameObject lightingExplo;
	public int maxHp;
	public int hp;
	public BarController barController;
	public int score ;
	public GameObject coin;

	private GameController gameController;
	private Sprite bloodSprite;

	// Use this for initialization
	void Start () {
		Vector3 forward = new Vector3 (0, -1, 0);
		GetComponent<Rigidbody2D>().velocity = forward * speed;

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.CompareTag("bullet")){

			Destroy (collider.gameObject);
			damage(50);

			GameObject exploInstance = (GameObject)Instantiate (explo);
			exploInstance.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0);


		} else if (collider.gameObject.CompareTag("lighting")){
			
			Destroy (collider.gameObject,0.1f);
			damage(50);
			
			GameObject exploInstance = (GameObject)Instantiate (lightingExplo);
			exploInstance.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0);
		}
	}


	void damage(int damage){
		hp -= damage;
//		BarController BarController = GameObject.FindGameObjectWithTag ("blood").GetComponent<BarController> ();
//		GameObject g = gameObject.transform.Find ("BloodBar");
//		Debug.Log ("g name " + g.name);
//		BarController BarController = gameObject.transform.Find ("BloodBar")
//			.transform.Find("blood")
//				.GetComponent<BarController>();
		barController.setupBarLength ((float)hp/maxHp);
		if (hp <= 0){
			die();
		}

	}

	void die(){

		int temp = Random.Range(0, 2);

		if( temp == 1){
			dropCoin();
		}

		Destroy(gameObject);
		gameController.AddScore(score);
		gameController.powerOn (1);
	}

	void dropCoin(){
		GameObject tc = Instantiate (coin) as GameObject;
		tc.transform.position = transform.position;
	}
}
