using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class map : MonoBehaviour {
	public GameObject info;

	private Color32 activeColor; // when mouse is inside the continent
	private Color32 inactiveColor;
	private Color32 curColor;
	private SpriteRenderer spriteRenderer;
	private Text info_text = null;
	//public SortedDictionary<GameObject, int> dict = new SortedDictionary<GameObject, int>(); // (prefabed_object, cost)
	public List<GameObject> icons = new List<GameObject> ();
	private  int infrastructure=0;

	// Use this for initialization
	void Start () {
		curColor = new Color32 (255,0,0,255);
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.color = curColor;

		infrastructure=0;
		info_text = info.GetComponent<Text> ();
		info_text.text = (int)(100*infrastructure/255.0f)+"%"; // "Infrastructure="+
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (Input.GetMouseButtonDown (0)) // button values are 0 for left button, 1 for right button, 2 for the middle button.
		{
			//Debug.Log ("Clicked");
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			//Debug.Log(pos.x);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
			if(hitInfo)
			{
				// Here you can check hitInfo to see which collider has been hit, and act appropriately.
				Debug.Log( hitInfo.transform.gameObject.name );
				//tex = GetComponent<SpriteRenderer>().sprite.texture;
				//Vector2 hitpoint = hitInfo.point;//The point in world space where the ray hit the collider's surface.
				//Debug.Log("hitpoint.pos=("+hitpoint.x+","+hitpoint.y+")");
				//Vector2 posOnImage = transform.InverseTransformPoint(hitpoint);
				//Debug.Log("posOnImage.pos=("+posOnImage.x+","+posOnImage.y+")");
				//Color color = tex.GetPixel(posOnImage.x*100+345,posOnImage.y*100+160);
				//Debug.Log("color=("+color.r.x+","+color.g.y+","+color.b+","+color.b+")");


			}
		}
		*/
	}

	void OnMouseEnter()
	{

	}
	void OnMouseExit()
	{

	}

	void OnMouseOver()
	{

	}

	void OnMouseDrag()
	{

	}
	void OnMouseDown() {

	}
	public int getInfrastructure()
	{
		return infrastructure;
	}


	public void addInfrastructure(int value)
	{
		infrastructure += value;
		if (infrastructure > 255) infrastructure = 255;
		if (infrastructure < 0)   infrastructure = 0;
		Debug.Log ("infrastructure=" + infrastructure);
		int r = curColor.r-value;
		int g = curColor.g;
		int b = curColor.b+value;
		if (r > 255) r = 255;
		if (r < 0)	 r = 0;
		if (b > 255) b = 255;
		if (b < 0)   b = 0;
		curColor = new Color32 ((byte)r,(byte)g,(byte)b,(byte)255);
		//Debug.Log (gameObject.name + "curColor = " + curColor);
		spriteRenderer.color = curColor;

		info_text.text = (int)(100*infrastructure/255.0f)+"%";// "Infrastructure="+
		info_text.CrossFadeAlpha (0.0f,0.0f,false);
		info_text.CrossFadeAlpha (1.0f,0.5f,false);
	}
	void OnMouseUp() {

	}
}
