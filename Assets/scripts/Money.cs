using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {

	Text txt;
	public int currentMoney;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text>();
		txt.text = "Money: "+ currentMoney;
	}
	
	// Update is called once per frame
	void Update () {
		currentMoney = WaterManager.money;
		txt.text = "Money: "+ currentMoney;
	}
}
