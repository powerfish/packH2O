using UnityEngine;
using System.Collections;

public class equipment : MonoBehaviour {

	public GameObject equipment_prefab;
	//public int price = 10;
	private GameObject prefabed_object = null;
	private bool bDragged = false;
	private bool bActive = false;
	private SpriteRenderer spriteRenderer = null;
	public AudioClip chaching;
	public AudioClip no;
	public AudioSource mySource;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		Color c = spriteRenderer.color;
		spriteRenderer.color = new Color (c.r, c.g, c.b, 0.5f);
		bActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		Color c = new Color (0.3f, 0.3f, 0.3f, 1.0f);

		if (equipment_prefab.name.Equals ("equipment1_prefab") && !WaterManager.bBuyable1) {
			spriteRenderer.color = c;
			bActive = false;
		} else if (equipment_prefab.name.Equals ("equipment2_prefab") && !WaterManager.bBuyable2) {
			spriteRenderer.color = c;
			bActive = false;
		} else if (equipment_prefab.name.Equals ("equipment3_prefab") && !WaterManager.bBuyable3) {
			spriteRenderer.color = c;
			bActive = false;
		}else {
			spriteRenderer.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			bActive = true;
		}

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


	void OnMouseUp() {
		if (!bDragged)
			return;

		Hint.displayHint ("Drag the equipment and drop it on a continent.");

		//Debug.Log("Drag finished!");
		Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
		if (hitInfo) {			
						GameObject continent = hitInfo.transform.gameObject;
						bool isContinent = continent.GetComponent<map> () != null;
						//Debug.Log("isContinent="+isContinent);
						if (isContinent) {
								if (equipment_prefab.name.Equals ("equipment1_prefab")) {
										continent.SendMessage ("addInfrastructure", 10);
										continent.GetComponent<map> ().icons.Add (prefabed_object);
										WaterManager.money -= 10;
										increaseMoney.minusVal = -10;
										increaseMoney.moneyMinus = true;
										EventManager.active = true;
										//mySource.clip = chaching;
										mySource.PlayOneShot (chaching, 1.0f);

										Hint.displayHint ("You just spent $10 to buy a PackH2O.");
								} else if (equipment_prefab.name.Equals ("equipment2_prefab")) {
										continent.SendMessage ("addInfrastructure", 50);
										continent.GetComponent<map> ().icons.Add (prefabed_object);
										WaterManager.money -= 50;
										increaseMoney.minusVal = -50;
										increaseMoney.moneyMinus = true;
										EventManager.active = true;
										//mySource.clip = chaching;
										mySource.PlayOneShot (chaching, 1.0f);

										Hint.displayHint ("You just spent $50 to buy a hand pump.");
								} else if (equipment_prefab.name.Equals ("equipment3_prefab")) {
										continent.SendMessage ("addInfrastructure", 200);
										continent.GetComponent<map> ().icons.Add (prefabed_object);
										WaterManager.money -= 200;
										WaterManager.amount += 1;
										AutoClick.activated = true;
										increaseMoney.minusVal = -200;
										increaseMoney.moneyMinus = true;
										EventManager.active = true;
										//mySource.clip = chaching;
										mySource.PlayOneShot (chaching, 1.0f);

										Hint.displayHint ("Greate! You just spent $200 to buy an auto pump!.");
								}

								Vector3 s = prefabed_object.transform.localScale;
								prefabed_object.transform.localScale = new Vector3 (s.x * 0.5f, s.y * 0.5f, 1.0f); 
								prefabed_object.GetComponent<SpriteRenderer> ().sortingOrder = 0;
								//mySource.PlayOneShot(chaching, 1.0f);			
						} else { // the prefabed_object is on the other gameobject with a collider
								Destroy (prefabed_object);
								Hint.displayHint ("Please drop the equipment on a continent.");
				
						} 
				}
		else { // the prefabed_object is on the ocean
			Destroy (prefabed_object);
			mySource.PlayOneShot(no, 1.0f);
			Hint.displayHint("Please drop the equipment on a continent.");
		}
		
		
		bDragged = false;

	}

	IEnumerator OnMouseDown()  
	{  
		if (bActive) {
			bDragged = true;

			Hint.displayHint ("Drag the equipment and drop it on a continent.");
			
			Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);  		
			Vector3 offset = transform.position-Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,ScreenSpace.z));  
			
			prefabed_object = (GameObject)Instantiate(equipment_prefab, transform.position, Quaternion.identity);
			
			while(Input.GetMouseButton(0))  
			{  
				Vector3 curScreenSpace =  new Vector3(Input.mousePosition.x,Input.mousePosition.y,ScreenSpace.z);     
				Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace)+offset;          
				prefabed_object.transform.position = CurPosition;  
				yield return new WaitForFixedUpdate();  
			} 	
		}
		else {
			Hint.displayHint("You do not have enough money to buy this equipment. Keep working...");	
		}
	}  

	public void toggleActive()
	{
		bActive = true;
	}
}
