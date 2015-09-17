using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hint : MonoBehaviour {
	static Text txt=null;
	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
		txt.text = "The whole world is in red for lack of water. Pump every 20 water for 10 dollars.";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void displayHint(string hint)
	{
		//txt.CrossFadeAlpha (0.0f,0.0f,false);
		txt.text = hint;
		//txt.CrossFadeAlpha (1.0f, 1.0f, false);
	}
}
