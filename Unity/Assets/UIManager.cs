using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	Transform canvasTransfrom;
	public GameObject MapUIPrefab;
	public GameObject PauseUIPrefab;
	public GameObject InventoryUIPrefab;

	// Use this for initialization
	void Start () {
		canvasTransfrom = GameObject.Find ("Canvas").transform;
		GameObject MapUI = (GameObject) Instantiate (MapUIPrefab);
		MapUI.transform.SetParent (canvasTransfrom, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Pause(){
		//Disable Map
		//Instantiate Pause Menu
		canvasTransfrom = GameObject.Find ("Canvas").transform;
		GameObject PauseMenu = (GameObject) Instantiate (PauseUIPrefab);
		PauseMenu.transform.SetParent (canvasTransfrom, false);
		GameObject mapUI = GameObject.Find ("MapUI(Clone)");
		Destroy (mapUI);
	}

	public void Resume(){
		canvasTransfrom = GameObject.Find ("Canvas").transform;
		GameObject pauseMenu = GameObject.Find ("PauseMenu(Clone)");
		Destroy (pauseMenu);
		GameObject mapUI = (GameObject) Instantiate (MapUIPrefab);
		mapUI.transform.SetParent (canvasTransfrom, false);
	}

	public void Inventory(){
		canvasTransfrom = GameObject.Find ("Canvas").transform;
		GameObject pauseMenu = GameObject.Find ("PauseMenu(Clone)");
		Destroy (pauseMenu);
		GameObject inventoryUI = (GameObject) Instantiate (InventoryUIPrefab);
		inventoryUI.transform.SetParent (canvasTransfrom, false);
	}

	public void Return(){
		canvasTransfrom = GameObject.Find ("Canvas").transform;
		GameObject inventory = GameObject.Find ("InventoryMenu(Clone)");
		Destroy (inventory);
		GameObject pauseMenu = (GameObject) Instantiate (PauseUIPrefab);
		pauseMenu.transform.SetParent (canvasTransfrom, false);
	}

	public void Quit(){
		Application.Quit ();
	}
}
