using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] enimies;
	public List<GameObject> liveEnimies;

	public Text timeTxt;
	public Text scoreTxt;
	public Text goldTxt;

	public float enemyInterval;
	private float count = 0;

	private int totalTime = 70;
	private float secondCounter = 0;
	private int scoreCounter = 0;

	private bool gameOver = false;

	public int powerEnough = 30;
	private int powerCount = 0;
	public GameObject powerBar;
	private BarController barController;

	// Use this for initialization
	void Start () {
		
		timeTxt.text = getTimeStr(totalTime); 
		barController = powerBar.GetComponent<BarController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(gameOver){
			return;
		}

		count += Time.deltaTime;
		if(count >= enemyInterval){
			count = 0;
			CreateEnimy();
		}

		TimeRender ();

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
		gameOver = true;
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
		barController.setupBarLength ((float)powerCount/powerEnough);
	}
}
