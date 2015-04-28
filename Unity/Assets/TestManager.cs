using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestManager : MonoBehaviour {
	TwineImporter Twine;
	bool wasClicked;
	List<Interactable> interactables;
	GameObject map;
	GameObject root;
	
	// Use this for initialization
	void Start () {
		/*GameObject testInteractable = new GameObject("BlackBox");
		testInteractable.AddComponent<SpriteRenderer> ();
		test = testInteractable.AddComponent<Interactable> ();
		test.SetName ("test", "test");*/
		Twine = GameObject.Find ("TwineImporter").GetComponent<TwineImporter> ();
		//recurse until we find the root
		Transform cur = transform;
		while(cur.parent != null)
		{
			cur = cur.parent;
		}
		root = cur.gameObject;

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

	void OnGUI()
	{
		Rect br = new Rect(0,0,Screen.width/10, Screen.height/10);
		br.x = br.width;
		br.y = br.height;
		if(GUI.Button(br, "Relocate"))
		{
			//disable the level/root and activate the map
			root.SetActive(false);
			map.SetActive(true);
		}
	}

	public void OnLevelChange(object sender)
	{
		Debug.Log("Is this a map?... " + sender);
		map = sender as GameObject;
	}

	/*void OnMouseDown(){
		Debug.Log (test.selected);
		if(test.selected)
		{
			test.Progress();
		}
	}*/
}
