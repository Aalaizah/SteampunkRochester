using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite hoverSprite;
    public Sprite activeSprite;
    public string id;
    public string path;
    public bool clicked;
    public bool selected;
	public bool isPerson;
	private bool hasAlreadyTalked = false;
    private bool readTwine;
    TwineImporter Twine;
    string message = "";
    string currentNode = "0";
    public bool taken = false;
    public List<string> choicesList;
    public List<string> choicesLinksList;
    public bool choice = false;
	//public List<Interactable> otherInteractables;

    //string speaker = "";

    void Start()
    {
		Debug.Log (path);
		choicesLinksList = new List<string> ();
		choicesList = new List<string> ();
		//otherInteractables = new List<Interactable> ();
        gameObject.AddComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Twine = GameObject.Find("TwineImporter").GetComponent<TwineImporter>();
        Twine.ReadTwineFile(path);
        createMessage();
    }

    public void Progress()
    {
		Debug.Log(Twine.TwineData.Current.Link[0]);
		if (!choice) 
		{
			Twine.TwineData.NextNode (currentNode);
			//Debug.Log (Twine.TwineData.Current.itemsReq);
			bool itemReq = !Twine.TwineData.Current.itemsReq.Equals ("");
			bool emotnReq = !Twine.TwineData.Current.EmotnReqChar.Equals( "");
			if (itemReq || emotnReq) 
			{
				if(itemReq)
				{
					if(!Inventory.hasItem(Twine.TwineData.Current.itemsReq))
						return;
				}
				if(emotnReq)
				{
					if(!EmotionManager.hasRequirement(Twine.TwineData.Current.EmotnReqChar,int.Parse(Twine.TwineData.Current.EmotnReqInt)))
						return;
				}
				if (!Twine.TwineData.Current.Link[0].Equals( " ")) 
				{
					currentNode = Twine.TwineData.Current.Link [0];
				}
				else
				{
					selected = false;
				}
			}
			else 
			{
				createMessage ();
				if (!Twine.TwineData.Current.Link[0].Equals( " ")) 
				{
					currentNode = Twine.TwineData.Current.Link [0];

				}
				else
				{
					selected = false;
				}
			}
    	}
	}


    void Update()
    {
		if(Twine.TwineData.Current.ItemsGain !=""){
			Inventory.addItem(Twine.TwineData.Current.ItemsGain);
		}
		if(Twine.TwineData.Current.ItemRem !=""){
			Inventory.removeItem(Twine.TwineData.Current.ItemRem);
		}
		if(Twine.TwineData.Current.EmotnDwn !=""){
			EmotionManager.updateEmotions(Twine.TwineData.Current.EmotnDwn,false);
		}
		if(Twine.TwineData.Current.EmotnUp !=""){
			EmotionManager.updateEmotions(Twine.TwineData.Current.EmotnUp,true);
		}
		if(isPerson && !hasAlreadyTalked)
		{
			TimeManager.passTime(60);
			hasAlreadyTalked = true;
		}
		if (!selected && currentNode != "0")
		{
			currentNode = "0";
			/*if(otherInteractables.Count > 0)
			{
				foreach(Interactable inter in otherInteractables)
				{
					inter.gameObject.SetActive(true);
				}
				otherInteractables.Clear();
			}*/
		}
    }

    void OnGUI()
    {
        if (selected)
        {
            GUI.skin.box.wordWrap = true;
			GUI.skin.button.wordWrap = true;

            if (choice)
            {
				//Debug.Log(choicesLinksList.Count);
				//Debug.Log(choicesList.Count);
                for (int i = 0; i < choicesLinksList.Count; i++)
                {
					currentNode = choicesLinksList[i];
					Twine.TwineData.NextNode(currentNode);

					if(choicesLinksList.Count == 1)
					{
						GUI.Box (new Rect(Screen.width - (Screen.width - 5),0,Screen.width - 10,Screen.height/4),message);

	                    if (GUI.Button(new Rect(Screen.width/2 - (Screen.width - 10)/2,Screen.height/4*i,Screen.width - 10, Screen.height / choicesLinksList.Count / choicesLinksList.Count), choicesList[i]))
	                    {
	                        createMessage();
	                        //Twine.TwineData.NextNode();
	                        choice = false;
							choicesLinksList.Clear();
							choicesList.Clear();
	                    }
					}
					else
					{
						GUI.Box (new Rect(Screen.width - (Screen.width - 5),0,Screen.width - 10,Screen.height/4),message);

						int yInc =  Screen.height / choicesLinksList.Count / choicesLinksList.Count;
						if (GUI.Button(new Rect(Screen.width/2 - (Screen.width - 10)/2,(Screen.height - (yInc * (i+1))),Screen.width - 10,yInc), choicesList[i]))
						{
							createMessage();
							//Twine.TwineData.NextNode();
							choice = false;
							choicesLinksList.Clear();
							choicesList.Clear();
						}
					}
                }
            }
			else
			{
				GUI.Box(new Rect(Screen.width - (Screen.width - 5), 3 * (Screen.height / 4) - 5, Screen.width - 10, Screen.height / 4), message);
			}
        }
    }

    void OnMouseOver()
    {
        if (!clicked)
        {
			if(hoverSprite)
            	spriteRenderer.sprite = hoverSprite;
        }
    }

    void OnMouseExit()
    {
        clicked = false;
		if(idleSprite)
        	spriteRenderer.sprite = idleSprite;
    }

    void OnMouseDown()
    {
        if (!clicked)
        {
			/*var interactables = GameObject.FindObjectsOfType<Interactable>();
			foreach(Interactable inter in interactables)
			{
				if(inter != this)
				{
					inter.gameObject.SetActive(false);
					otherInteractables.Add(inter);
				}
			}*/
            clicked = true;
			if(activeSprite)
            	spriteRenderer.sprite = activeSprite;
            selected = !selected;
            //Debug.Log(selected);
        }
    }

    void OnMouseUp()
    {
        clicked = false;
    }

    public void SetName(string pName, string pPath)
    {
        id = pName;
        path = pPath;
        spriteRenderer = GetComponent<SpriteRenderer>();

        idleSprite = Resources.Load<Sprite>(id + "Idle");
        hoverSprite = Resources.Load<Sprite>(id + "Hover");
        activeSprite = Resources.Load<Sprite>(id + "Active");

        spriteRenderer.sprite = idleSprite;
    }



    void createMessage()
    {
		EmotionManager.resetBooleans();
        message = "";

        //speaker = Twine.TwineData.Current.SpeakerData;

        foreach (char letter in Twine.TwineData.Current.ContentData.ToString())
        {
            message += letter;
            //yield return new WaitForSeconds (letterPause);
        }

        //contentList.Clear();

        TypeText();
    }
	

    void TypeText()
    {
        TwineNode tempNode;
		//Debug.Log (Twine.TwineData.Current.Link.Count);
        if (Twine.TwineData.Current.Link.Count == 1)
        {
            choice = false;
            //createMessage();
            //Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
        }
        else
        {
            choice = true;
            tempNode = Twine.TwineData.Current;
            foreach (string currentChoice in Twine.TwineData.Current.Link)
            {
				bool triggered = false;
				Twine.TwineData.NextNode(currentChoice);
				bool itemReq = !Twine.TwineData.Current.itemsReq.Equals ("");
				bool emotnReq = !Twine.TwineData.Current.EmotnReqChar.Equals( "");
				if (itemReq || emotnReq) 
				{
					if(itemReq)
					{
						if(!Inventory.hasItem(Twine.TwineData.Current.itemsReq))
							triggered = true;
					}
					if(emotnReq)
					{
						if(!EmotionManager.hasRequirement(Twine.TwineData.Current.EmotnReqChar,int.Parse(Twine.TwineData.Current.EmotnReqInt)))
							triggered=true;
					}
					if (Twine.TwineData.Current.Link.Count != 0) 
					{
						currentNode = Twine.TwineData.Current.Link [0];
					}
				}
                if(!triggered)
				{
                	choicesLinksList.Add(currentChoice);
                	choicesList.Add(Twine.TwineData.Current.ContentData);
				}
            }
            Twine.TwineData.Current = tempNode;
        }
    }
}
