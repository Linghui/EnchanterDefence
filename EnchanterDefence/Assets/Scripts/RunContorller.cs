using UnityEngine;
using System.Collections;

public class RunContorller : MonoBehaviour {
	
	public float speed;
	public GameObject explo;
	public int maxHp;
	public int hp;
	public BarController barController;

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

			gameController.AddScore(100);

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
			Destroy(gameObject);
		}

	}

}
