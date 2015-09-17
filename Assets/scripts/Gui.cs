using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gui : MonoBehaviour {

	Text txt;
	public int currentWater;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text>();
		txt.text = "Water: "+ currentWater;
	}
	
	// Update is called once per frame
	void Update () {
		currentWater = WaterManager.water;
		txt.text = "Water: "+ currentWater;
	}
}
