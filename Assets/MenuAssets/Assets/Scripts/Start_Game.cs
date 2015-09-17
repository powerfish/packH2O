using UnityEngine;
using System.Collections;

public class Start_Game : MonoBehaviour {
	
	void OnGUI(){
		
		if(GUI.Button( new Rect(Screen.width/2.5f,Screen.height/2,Screen.width/5,Screen.height/10), "Start Game"))
		{
			Application.LoadLevel(2);		
		}
		
		
	}
	
	
}