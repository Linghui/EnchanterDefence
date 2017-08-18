using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

	public GameObject[] enimies;
	public List<GameObject> liveEnimies;

	public GameOverDialog dialog;

	public GameObject skillBullet;

	public Text timeTxt;
	public Text scoreTxt;
	public Text goldTxt;
	public Text hpTxt;

	public GameObject skillButton;

	public int hp_set;
	private int hp;


	public string clickLayer;
	public GameObject powerBar;
	public int powerEnough = 30;

	public float enemyInterval;

	private float count = 0;

	private int totalTime = 20;
	private float secondCounter = 0;
	private int scoreCounter = 0;

	private bool gameOver = false;
	
	private int powerCount = 0;

	private BarController barController;
	private RuntimePlatform platform;



	// Use this for initialization
	void Start () {
		
		timeTxt.text = getTimeStr(totalTime); 
		barController = powerBar.GetComponent<BarController> ();
		platform = Application.platform;
		hp = hp_set;
		setHp ();
	}
	
	// Update is called once per frame
	void Update () {

		uiClickDetect ();

		if(gameOver){
			return;
		}

		count += Time.deltaTime;
		if(count >= enemyInterval){
			count = 0;
			CreateEnimy();
		}

//		TimeRender ();

	}

	void uiClickDetect(){
		
		if(platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
			if(Input.touchCount > 0) {
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					checkTouch(Input.GetTouch(0).position);
				}
			}
		}else 
//		if(platform == RuntimePlatform.WindowsEditor)
		{
//			Debug.Log ("Input.mousePosition " + Input.mousePosition);
			if(Input.GetMouseButtonDown(0)) {
//				Debug.Log ("Input.mousePosition " + Input.mousePosition);
				checkTouch(Input.mousePosition);
			}
		}
	}

	
	void checkTouch(Vector3 pos){
		Vector3 wp  = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos  = new Vector2(wp.x, wp.y);
		LayerMask mask = LayerMask.NameToLayer(clickLayer);
//		Debug.Log ("mask " + mask.value);


		Collider2D[] hit = Physics2D.OverlapPointAll(touchPos);

		if (hit != null && hit.Length > 0) {

			for(int index = 0; index < hit.Length ; index++){
				if(hit[index].gameObject.layer == mask.value){
//					Debug.Log ("hit " + hit[index].gameObject.name);
					hit[index].transform.gameObject.SendMessage ("Clicked", 0, SendMessageOptions.DontRequireReceiver);
				}
			}

		} else {
//			Debug.Log("????");
		}
	}

	void TimeRender(){
		secondCounter += Time.deltaTime;
		if(secondCounter >= 1){
			secondCounter=0;
			totalTime--;
			timeTxt.text = getTimeStr(totalTime); 
			if(totalTime <= 0){
				GameOver();
			}
		}
	}

	void GameOver(){
		Debug.Log ("GameOver");
		if(!gameOver){
			gameOver = true;
			dialog.showDialog();
		}
		 

	}

	string getTimeStr(int second){
		int min = (int)Mathf.Floor( second / 60);
		int leftSecond = second - min * 60;
		string timeStr = string.Format ("{0:00}:{1:00}", min, leftSecond);

		return timeStr;
	}

	void CreateEnimy(){
		int randomIndex = Random.Range(0, enimies.Length);

		GameObject room = (GameObject)Instantiate(enimies[randomIndex]);

		float randomx = Random.Range (-5f, 5);


		room.transform.position = new Vector3(randomx, 9, 0);

	}

	public void AddScore(int score){
//		Debug.Log ("AddScore " + score);
		scoreCounter += score;
		scoreTxt.text = scoreCounter + "";
	}

	public void powerOn(int power){
		powerCount += power;
		setPower ();
	}

	private void setPower(){
		
		if (powerCount > powerEnough) {
			powerCount = powerEnough;
			skillOn (true);
		} else {
			skillOn (false);
		}
		
		barController.setupBarLength ((float)powerCount/powerEnough);
	}

	public void skillOn (bool active){
		skillButton.SetActive (active);
	}

	public void fireSkill(){
		Debug.Log ("fireSkill");
		skillButton.SetActive (true);
		powerCount = 0;
		setPower ();

		for(int index = 0 ; index < 50; index++){
			float randomx = Random.Range (-6f, 6);
			float randomy = Random.Range (-11.60f, -10f);
			GameObject bullet = Instantiate(skillBullet) as GameObject;
			bullet.transform.position = new Vector2(randomx, randomy);
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0,1,0) * 8;
		}

	}

	public void damage(int hpd){
		hp -= hpd;
		setHp ();
		if(hp <= 0){
			GameOver();
		}
	}

	void setHp(){
		hpTxt.text = hp + "";
	}

	public bool isGameOver(){
		return gameOver;
	}

}
