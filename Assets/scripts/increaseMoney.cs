using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class increaseMoney : MonoBehaviour {

	Text txt;
	public static int addVal;
	public static bool moneyAdd;
	public static bool moneyMinus;
	public static int minusVal;
	// Use this for initialization
	void Start () {
		moneyAdd = false;
		moneyMinus = false;
		addVal = 10;
		txt = GetComponent<Text>();
		txt.text = " ";
		txt.fontSize = 20;
		minusVal = 0;
		//txt.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("pump = "+WaterManager.pump);
		if(moneyAdd == true){
			txt.color = Color.green;
			//txt.transform.position = new Vector2(,); // (293,183) is the center of the Canvas
			txt.CrossFadeAlpha(1, 0, false);
			txt.text = "+ "+ addVal;
			txt.CrossFadeAlpha(0, 2, false);
			moneyAdd = false;
		}
		if(moneyMinus == true){
			txt.color = Color.red;
			//txt.transform.position = new Vector2(,); // (293,183) is the center of the Canvas
			txt.CrossFadeAlpha(1, 0, false);
			txt.text = ""+minusVal;
			txt.CrossFadeAlpha(0, 2, false);
			moneyMinus = false;
		}
		//txt.transform.position = new Vector2(300,200);
	}
}
