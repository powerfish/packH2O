using UnityEngine;
using System.Collections;

public class AutoClick : MonoBehaviour {

	public static bool activated;
	public static bool auto;
	public static bool animate;
	// Use this for initialization
	void Start () {
		activated = false;
		auto = false;
		animate = false;
		//StartCoroutine (wait ());
	}
	
	// Update is called once per frame
	void Update () {
		if(activated){
			StartCoroutine(pump());
		}
	}

	IEnumerator wait(){
		//Debug.Log ("inside");
		yield return new WaitForSeconds(5.0f);
		//Debug.Log ("after");
	}

	IEnumerator pump()
	{
			activated = false;
			//Debug.Log ("WillWait");
			wait ();
			//Debug.Log ("Waited");
			yield return new WaitForSeconds(3.0f);
			animate = true;
			WaterManager.water+=WaterManager.amount;
		WaterManager.waterPlaceHolder+=WaterManager.amount;
			activated = true;
	}
}
