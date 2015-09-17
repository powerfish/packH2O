using UnityEngine;
using System.Collections;

public class animation_trigger : MonoBehaviour {

	Animator anim;

	void Start() {

		anim = GetComponent<Animator>();

	}

	void OnMouseDown(){

		anim.SetTrigger ("trig");
		WaterManager.pump = true;
	}

	void Update(){
		if(AutoClick.animate==true){
			anim.SetTrigger("trig");
			Increase.pumpIt = true;
			AutoClick.animate = false;
		}
	}
}
