using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Increase : MonoBehaviour {

	Text txt;
	public int add;
	public static bool pumpIt;
	
	// Use this for initialization
	void Start () {
		pumpIt = false;
		add = WaterManager.amount;
		txt = GetComponent<Text>();
		txt.text = "Pump for Water";
		txt.fontSize = 20;
		//txt.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("pump = "+WaterManager.pump);
		if(pumpIt == true){
			txt.transform.position = new Vector2(Random.Range (-470,-350)/100.0f,Random.Range (90,200)/100.0f); // (293,183) is the center of the Canvas
			txt.CrossFadeAlpha(1, 0, false);
			add = WaterManager.amount;
			txt.text = "+ "+ add;
			txt.CrossFadeAlpha(0, 2, false);
			pumpIt = false;
		}
		//txt.transform.position = new Vector2(300,200);
	}
}
