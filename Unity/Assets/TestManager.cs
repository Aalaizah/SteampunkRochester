using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestManager : MonoBehaviour {
	
	TwineImporter Twine;
	Interactable test; //List ToDo
	bool wasClicked;
	
	// Use this for initialization
	void Start () {
		GameObject testInteractable = new GameObject("BlackBox");
		testInteractable.AddComponent<SpriteRenderer> ();
		test = testInteractable.AddComponent<Interactable> ();
		test.SetName ("test", "test");
		Twine = GameObject.Find ("TwineImporter").GetComponent<TwineImporter> ();
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

				test.Progress();
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
