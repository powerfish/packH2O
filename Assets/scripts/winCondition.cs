using UnityEngine;
using System.Collections;

public class winCondition : MonoBehaviour {

	public GameObject Africa;
	public GameObject Asia;
	public GameObject Australia;
	public GameObject Europe;
	public GameObject NorthAmerica;
	public GameObject SouthAmerica;

	private map Africa_map;
	private map Asia_map;
	private map Australia_map;
	private map Europe_map;
	private map NorthAmerica_map;
	private map SouthAmerica_map;

	// Use this for initialization
	void Start () {
		Africa_map = Africa.GetComponent<map>();
		Asia_map = Asia.GetComponent<map>();
		Australia_map = Australia.GetComponent<map>();
		Europe_map = Europe.GetComponent<map>();
		NorthAmerica_map = NorthAmerica.GetComponent<map>();
		SouthAmerica_map = SouthAmerica.GetComponent<map>();
	}
	
	// Update is called once per frame
	void Update () {
		int AfricaVal =Africa_map.getInfrastructure();
		int AsiaVal = Asia_map.getInfrastructure();
		int AustraliaVal = Australia_map.getInfrastructure();
		int NorthVal = NorthAmerica_map.getInfrastructure();
		int SouthVal = SouthAmerica_map.getInfrastructure();
		int EuropeVal = Europe_map.getInfrastructure();
	 if(	AfricaVal>=255 &&
			AsiaVal>=255 && 
		   AustraliaVal>=255 &&
			   EuropeVal>=255 &&
		   NorthVal>=255 &&
		   SouthVal>=255 )
		{
			// win 
			Application.LoadLevel ("Victory");
		}

	}
}
