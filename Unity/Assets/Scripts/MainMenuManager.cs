using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	GameObject[] menuButtons;
	public GameObject creditsPrefab;

	public void Quit(){
		Application.Quit ();
	}
	
	public void Credits(){
		
		if(menuButtons == null)
		{
			menuButtons = GameObject.FindGameObjectsWithTag("MenuUI");
		}
		
		for(int i = 0; i < menuButtons.Length; i++)
		{
			menuButtons[i].SetActive(false);
		}
		
		creditsPrefab.SetActive (true);
	}
	
	public void CreditReturn()
	{
		creditsPrefab.SetActive (false);
		
		for(int i = 0; i < menuButtons.Length; i++)
		{
			menuButtons[i].SetActive(true);
		}
	}
	
	public void MainMenuStart(){
		//Load Main scene here
		Application.LoadLevel("MapScene");
	}
}
