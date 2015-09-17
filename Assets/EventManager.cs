using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

	public GameObject crisis;
	public Button button;
	public Image img;
	public Text txt;
	public static bool active;
	public bool thisToo;
	public float timer;
	public bool canLose;
	public bool firstTime;
	public AudioSource mySource;
	public AudioClip disaster;
	public AudioClip success;
	public AudioClip siren;

	private static bool removedBags = false;
	// Use this for initialization
	void Start () {
		active = false;
		thisToo=true;
		canLose = false;
		firstTime = true;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("timer: "+timer);
		if(active==true && thisToo==true){
			timer+=(Time.deltaTime);
			if(timer>=90.0f){
				crisis.SetActive(true);
				mySource.PlayOneShot(siren, 1.0f);
				img.CrossFadeAlpha(0,4, false);
				timer = 0;
				canLose = true;

				Hint.displayHint("Oh no! There’s been a chemical spill in a nearby lake! You only have a limited time to raise enough money to help or else the area will become DEVASTATED and you will lose all of your progress!");
			}
		}
		if(canLose==true){
				thisToo = false;
				if(firstTime){
					timer = 300.0f;// 300.0f
					firstTime = false;
				}
				timer-=Time.deltaTime;
				txt.text = "Time left: :" + ((int)timer).ToString();
				if(timer<=0.0f && crisis.activeSelf==true){
						thisToo=false;
						crisis.SetActive (false);

						// player fails to handle the crisis
						// put damage to the continent;
						// remove dict.gameobjects according to values.
						mySource.PlayOneShot(disaster, 1.0f);
						GameObject obj = GameObject.FindGameObjectWithTag("Tag_NorthAmerica");
						map m = obj.GetComponent<map>();	
						List<GameObject> icons = m.icons;
						if(icons.Count>0 )
						{
							m.addInfrastructure(-300);
							foreach (var o in icons) 
							{						
								Destroy(o);		
							}
							icons.Clear();
							icons = new List<GameObject>();
						}	
					Hint.displayHint("Sorry, the infrastructure in North America is totally DEVASTATED...");
					}					
					//icons.RemoveAll();// simplely remove all 
				}
			
	}

	public void hit(){
		if(WaterManager.money >=300){
			WaterManager.money-=300;
			increaseMoney.minusVal = -300;
			mySource.PlayOneShot(success, 1.0f);
			increaseMoney.moneyMinus = true;
			crisis.SetActive(false);
			thisToo = false;

			Hint.displayHint("Wow wow wow, you just saved the North America!");
		}
		else
		{
			Hint.displayHint("You do not have enough!");
		}
	}

//	IEnumerator waiting(){
//		yield return new WaitForSeconds(90.0f);
//	}
//	IEnumerator wait(){
//		active = false;
//		waiting ();
//		yield return new WaitForSeconds (90.0f);
//	}
}
