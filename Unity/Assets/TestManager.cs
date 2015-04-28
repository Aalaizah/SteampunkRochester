using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestManager : MonoBehaviour {
	
	TwineImporter Twine;
	bool wasClicked;
	List<Interactable> interactables;
	
	// Use this for initialization
	void Start () {
		/*GameObject testInteractable = new GameObject("BlackBox");
		testInteractable.AddComponent<SpriteRenderer> ();
		test = testInteractable.AddComponent<Interactable> ();
		test.SetName ("test", "test");*/
		Twine = GameObject.Find ("TwineImporter").GetComponent<TwineImporter> ();

		//find interactables
		interactables = new List<Interactable>();
		var gs = GameObject.FindObjectsOfType<GameObject>();
		foreach(GameObject obj in gs)
		{
			var script = obj.GetComponent<Interactable>();
			if(script != null)
			{
				interactables.Add(script);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (test.selected);
		foreach(Interactable test in interactables)
		{
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
	}

	/*void OnMouseDown(){
		Debug.Log (test.selected);
		if(test.selected)
		{
			test.Progress();
		}
	}*/
}
