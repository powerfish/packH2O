using UnityEngine;
using System.Collections;

public class WaterManager : MonoBehaviour {
	public static int water;
	public static bool pump;
	public static int amount;
	public static int money;
	public static int price1=10;
	public static int price2=50;
	public static int price3=200;
	public static int waterPlaceHolder;
	public int moneyAdd;
	public AudioClip madeIt;
	public AudioSource mySource;

	bool hitMark;
	public static bool bBuyable1 = false;
	public static bool bBuyable2 = false;
	public static bool bBuyable3 = false;

	//private bool bBuyable1_triggered = false;
	//private bool bBuyable2_triggered = false;
	//private bool bBuyable3_triggered = false;

	// Use this for initialization
	void Start () {
		pump= false;
		water = 0;
		amount = 1;
		money = 0;
		moneyAdd = 1;
		hitMark=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(pump)
		{
			Increase.pumpIt = true;
			water+=amount;
			waterPlaceHolder+=amount;
			//Debug.Log(water);
			pump = false;
		}

		if(waterPlaceHolder>=20){
			waterPlaceHolder -= 20;
			money+=10;
			mySource.PlayOneShot(madeIt, 1.0f);
			//EventManager.active = true;
			increaseMoney.addVal = 10;
			increaseMoney.moneyAdd = true;
		}

		bBuyable1 = money >= price1 ? true : false;
		bBuyable2 = money >= price2 ? true : false;
		bBuyable3 = money >= price3 ? true : false;


		if (bBuyable3) { // && !bBuyable3_triggered
			Hint.displayHint ("Congratulations! You have enough money to buy an auto bump.");
			//bBuyable3_triggered = true;
		} else if (bBuyable2 ) { //&&!bBuyable2_triggered
			Hint.displayHint ("Congratulations! You have enough money to buy a hand bump.");
			//bBuyable2_triggered = true;
		} else if (bBuyable1 ) { ///&&!bBuyable1_triggered
			Hint.displayHint ("Congratulations! You have enough money to buy a PackH2O.");
			//bBuyable1_triggered = true;
		}

		/*
		if (money < price1)	bBuyable1_triggered = false;
		if (money < price2)	bBuyable2_triggered = false;
		if (money < price3)	bBuyable3_triggered = false;
		*/

	}
}
