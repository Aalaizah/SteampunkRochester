using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//from http://wiki.unity3d.com/index.php/AutoType
public class AutoType : MonoBehaviour {
	
	public GUIStyle skin;
	public float letterPause = 0.0001f; //time-wait before next letter is printed : type float
	//Sprite decleration
	string message = "";
	string speaker = "";
	public bool canClick = false;
	public bool choice = false;
	public bool hasClicked = false;
	public bool isMultiSpeaker = false;
	Vector3 mousePos;
	public TwineImporter1 Twine;
	public List<string> choicesList;
	public List<string> choicesLinksList;
	public List<string> speakersList;
	public List<string> contentList;

	// Use this for initialization
	void Start () {
		Twine = new TwineImporter1();
//		GUI.skin = GameGui;
		mousePos = new Vector3 (8, -4, -9);
		mouse.transform.position= mousePos;
		mouse.enabled = false;
		remy.enabled = false;
		comcast.enabled = false;
		judge.enabled = false;
		explosion.enabled = false;
		remySources = remyAudio.GetComponents<AudioSource>();
		judgeSources = judgeAudio.GetComponents<AudioSource>();
		comcastSources = comcastAudio.GetComponents<AudioSource>();


		TypeText();
	}

	// Update is called once per frame
	void Update (){
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) && canClick == true)
		{
			TypeText();
		}
		else if(Input.GetMouseButtonDown(0) && isMultiSpeaker == true)
		{
			hasClicked = true;
			canClick = false;
		}
		else if(Input.GetMouseButtonDown(1) && canClick == true)
		{

		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
        	Application.Quit();
   	 	}	

	}
	
	//Draws the text box
	void OnGUI() {
//		FontStyle bold;
		GUI.skin.box.wordWrap = true;
		if(choice == false)
		{
			//Draw the boxes for the speaker name and speakers dialogue
			GUI.Box(new Rect(Screen.width - (Screen.width-5), 3*(Screen.height/4)-5, Screen.width - 10, Screen.height/4), message,skin);
			GUI.Box(new Rect(Screen.width - (Screen.width-5), 3*(Screen.height/4)-6*(Screen.height/8), Screen.width/5, Screen.height/10), speaker,skin);
		}
		else if (choice == true)
		{
			//Here we draw the choice buttons

//			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4), Screen.width - 10, Screen.height/4/4),choicesList[0],skin))
//			{
//				Twine.TwineData.NextNode(choicesLinksList[0]);
//				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
//				StartCoroutine(createMessage());
//				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
//				choice = false;
//			}
//
//			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+Screen.height/4/4, Screen.width - 10, Screen.height/4/4),choicesList[1],skin))
//			{
//				Twine.TwineData.NextNode(choicesLinksList[1]);
//				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
//				StartCoroutine(createMessage());
//				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
//				choice = false;
//				explosion.enabled = true;
//			}
//
//			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+2*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),choicesList[2],skin))
//			{
//				Twine.TwineData.NextNode(choicesLinksList[2]);
//				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
//				StartCoroutine(createMessage());
//				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
//				choice = false;
//				explosion.enabled = true;
//			}
//
//			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+3*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),choicesList[3],skin))
//			{
//				Twine.TwineData.NextNode(choicesLinksList[3]);
//				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
//				StartCoroutine(createMessage());
//				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
//				choice = false;
//				explosion.enabled = true;
//			}	
		}
		
	}


	void TypeText () {
		TwineNode1 tempNode;
		if(Twine.TwineData.Current.LinkTitle.Count == 1)
		{
			choice = false;
			speaker = Twine.TwineData.Current.SpeakerData;
			StartCoroutine(createMessage());
            Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
		}
		else
		{	
			choice = true;
			tempNode = Twine.TwineData.Current;
			foreach (string currentChoice in Twine.TwineData.Current.Link)
			{
				Twine.TwineData.NextNode(currentChoice);
				choicesLinksList.Add(currentChoice);
				choicesList.Add (Twine.TwineData.Current.ContentData);
			}
			Twine.TwineData.Current = tempNode;
		}
	}

	IEnumerator createMessage()
	{
		canClick = false;
		message = "";
		if (Twine.TwineData.Current.Speaker.Count > 1) 
		{
			isMultiSpeaker = true;
			foreach(string speakers in Twine.TwineData.Current.Speaker)
			{
				speakersList.Add(speakers);
			}
			foreach(string content in Twine.TwineData.Current.Content)
			{
				contentList.Add(content);
			}
			for(int i = 0; i < speakersList.Count; i++)
			{
				speaker = speakersList[i];
				if (speaker == "Flossopher")
				{
					remy.enabled = true;
					remySources[Random.Range(0, remySources.Length)].Play();
					//remyAudio.Play();
				}
				if (speaker == "Comcast") 
				{
					comcast.enabled = true;
					comcastSources[Random.Range(0,comcastSources.Length)].Play();
					//comcastAudio.Play();
				}
				if (speaker == "Judge")
				{
					judge.enabled = true;
					judgeSources[Random.Range(0,judgeSources.Length)].Play();
					//judgeAudio.Play();
				}
				message = "";
				foreach (char letter in (contentList[i])) 
				{
					message += letter;
					yield return 0;
					yield return new WaitForSeconds (letterPause);
				}
				yield return StartCoroutine(waitForClick());
			}
			isMultiSpeaker = false;
			if(speakersList.Count != contentList.Count)
			{
				foreach(char letter in contentList[speakersList.Count])
				{
					message += letter;
					yield return 0;
					yield return new WaitForSeconds (letterPause);
				}
			}
			TypeText();
		}
		else
		{
			speaker = Twine.TwineData.Current.SpeakerData;
			if (speaker == "Flossopher")
			{
				remy.enabled = true;
				remySources[Random.Range(0, remySources.Length)].Play();
				//remyAudio.Play();
			}
			if (speaker == "Comcast") 
			{
				comcast.enabled = true;
				comcastSources[Random.Range(0,comcastSources.Length)].Play();
				//comcastAudio.Play();
			}
			if (speaker == "Judge")
			{
				judge.enabled = true;
				judgeSources[Random.Range(0,judgeSources.Length)].Play();
				//udgeAudio.Play();
			}
			foreach (char letter in Twine.TwineData.Current.ContentData.ToString()) 
			{
				message += letter;
				yield return 0;
				yield return new WaitForSeconds (letterPause);
			}
		}
		speakersList.Clear();
		contentList.Clear();
		choicesList.Clear ();
		choicesLinksList.Clear ();
		canClick = true;
		mouse.enabled = true;
	}

	IEnumerator waitForClick()
	{
		while(hasClicked == false)
		{
			yield return null;
		}
		hasClicked = false;
		//message = "";
		remy.enabled = false;
		comcast.enabled = false;
		judge.enabled = false;
	}
}
