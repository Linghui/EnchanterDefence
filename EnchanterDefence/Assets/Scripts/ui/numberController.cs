using UnityEngine;
using System.Collections;


public class numberController : MonoBehaviour {

	public GameObject[] numberList;
	private int width;

	void Start(){
		width = numberList[0].GetComponent<SpriteRenderer>().sprite.texture.width;
		Debug.Log ("number width " + width);
		showNumber ("1234567890");
	}

	public void showNumber(string number){
		if (number == null) {

		} else {
			for(int index = 0; index < number.Length; index++){
				string single = number.Substring(index, 1);
				int singleNum = int.Parse(single);
				GameObject numberPre = numberList[singleNum];
				GameObject numObj = Instantiate(numberPre) as GameObject;
				numObj.transform.parent = transform;

				numObj.transform.position =  new Vector2(index * 0.2f, numObj.transform.position.y);
			}

		}
	}
}
