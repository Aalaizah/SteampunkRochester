using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestManager : MonoBehaviour {
	
	TwineImporter Twine;
	Interactable test; //List ToDo
	bool wasClicked;
	Inventory testInv;
	
	// Use this for initialization
	void Start () {
		GameObject testInteractable = new GameObject("BlackBox");
		testInteractable.AddComponent<SpriteRenderer> ();
		test = testInteractable.AddComponent<Interactable> ();
		test.SetName ("test", "test");
		test.isItem = true;
		Twine = GameObject.Find ("TwineImporter").GetComponent<TwineImporter> ();
		testInv = GameObject.Find ("Manager").GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (test.selected);
		if (test.selected) 
		{
			if(!wasClicked)
			{
				if(Input.GetMouseButtonUp(0))
				{
					wasClicked = true;
				}
			}
			else if(Input.GetMouseButtonDown(0)){
				//Debug.Log ("you clicked the left mouse button");

				test.Progress(this.testInv);
			}
		}
		if (test.taken)
		{
			if(!testInv.inventory.Contains("BlackBox"))
			{
				testInv.inventory.Add("BlackBox");
			}
		}
	}

	/*void OnMouseDown(){
		Debug.Log (test.selected);
		if(test.selected)
		{
			test.Progress();
		}
	}*/
}
