using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class FinalScreen : MonoBehaviour {
	//public Text text;
	public Text text2;
	// Use this for initialization
	void Start () {
		//text.text = "";
		text2.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		//text.text = "Congratulations!  You Hydrated the whole world";
		text2.text = "The amount of water you used: "+WaterManager.water;
	}
}
