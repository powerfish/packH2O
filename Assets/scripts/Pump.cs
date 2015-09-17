using UnityEngine;
using System.Collections;

public class Pump : MonoBehaviour {
//	private Vector3 target;
	public GameObject waterPump;
	// Use this for initialization
	void Start () {
		//target = waterPump.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		//Debug.Log("Pump onMouseDown");
		//WaterManager.pump=true;
	}

	void mouseClick(){
		if(Input.GetMouseButtonDown(0)){
			//WaterManager.pump=true;
		}
	}
}
