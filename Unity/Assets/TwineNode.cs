using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TwineNode
{
	string passage;
	List<string> content = new List<string>();
	List<string> speaker = new List<string>();
	List<string> linkTitles = new List<string>();
	List<string> links = new List<string>();
	//strings containing the different commands and the necessary parameters for the min order to add the commands to the parser
	string itmReq = ""; //name of item required
	string itmGain = ""; //gain the listed item
	string itmRem = ""; //name of item to be removed
	string emotnUp = ""; //name of character whose happiness will be upped by 1
	string emotnDwn = ""; //name of character whose happiness will be downed by 1
	string emotnReqChar = ""; //name of the character who has an emotional requirement
	string emotnReqInt = ""; //integer representing the appropriate happiness needed 
	string nextPassage;
	bool itmTaken;

	//getters and setters for the various attributes in the 
	public string Passage {get{return passage;} set{passage = value;}}
	public List<string> Content {get{return content;} set{content = value;}}
	public List<string> Speaker {get{return speaker;} set{speaker = value;}}
	public List<string> LinkTitle {get{return linkTitles;}}
	public List<string> Link{get{ return links;}}
	public string itemsReq{ get { return itmReq; } }
	public string ItemsGain{ get { return itmGain; } }
	public string ItemRem{get{return itmRem;}}
	public string EmotnUp{ get {return emotnUp;}}
	public string EmotnDwn{ get {return emotnDwn;}}
	public string EmotnReqChar{get{return emotnReqChar;}}
	public string EmotnReqInt{get{return emotnReqInt;}}
	
	public string ContentData
	{
		get
		{
			if(content.Count > 1)
			{
				foreach(string s in content)
				{
					return s;
				}
				return null;
			}
			else
			{
				return content[0];
			}
		}
	}
	
	public string SpeakerData
	{
		get
		{
			if(speaker.Count >= 1)
			{
				foreach(string s in speaker)
				{
					return s;
				}
				return null;
			}
			else
			{
				return "";
			}
		}
	}
	
	public string LinkTitleData
	{
		get
		{
			if(linkTitles.Count > 1)
			{
				foreach(string s in linkTitles)
				{
					return s;
				}
				return null;
			}
			else
			{
				return linkTitles[0];
			}
		}
	}
	
	public string LinkData
	{
		get{
			foreach(string s in links)
			{
				return s;
			}
			return null;
		}
	}

	
	public string NextPassage {get{return nextPassage;} set{nextPassage = value;}}
	
	public TwineNode(string data)
	{
		if (data.IndexOf("[[") != -1)
		{
			int startTitle = data.IndexOf("[[") + 2;
			int endTitle = data.IndexOf("|");
			linkTitles.Add(data.Substring(startTitle, endTitle - startTitle));
			int startLink = data.IndexOf("|") + 1;
			int endLink = data.IndexOf("]]");
			links.Add(data.Substring(startLink, endLink - startLink));
		}
		if (data.Length == 0)
		{
			Debug.Log("Blank: " + data);
		}
		if (data.IndexOf("::") != -1)
		{
			int startPassage = data.IndexOf("::") + 2;
			passage = data.Substring(startPassage);
		}
		else if (data.IndexOf("[[") == -1 && data.Length != 0)
		{
			speaker.Add("");
			content.Add(data);
		}
	}
	
	public TwineNode(string data, string[] split)
	{
		if (data.IndexOf("[[") != -1)
		{
			string[] choicesSplit = {"[["};
			string[] choices = data.Split(choicesSplit, StringSplitOptions.RemoveEmptyEntries);
			if(choices.Length > 2)
			{
				for(int i = 1; i < choices.Length; i++)
				{
					int endTitle = choices[i].IndexOf("|");
					linkTitles.Add(choices[i].Substring(0, endTitle));
					int startLink = choices[i].IndexOf("|") + 1;
					int endLink = choices[i].IndexOf("]]");
					if (endLink != -1)
					{
						links.Add(choices[i].Substring(startLink, endLink - startLink));
					}
					else
					{
						links.Add(choices[i].Substring(startLink));
					}
				}
			}
			else
			{
				int startTitle = data.IndexOf("[[") + 2;
				int endTitle = data.IndexOf("|");
				linkTitles.Add(data.Substring(startTitle, endTitle - startTitle));
				int startLink = data.IndexOf("|") + 1;
				int endLink = data.IndexOf("]]");
				links.Add(data.Substring(startLink, endLink - startLink));
			}
		}
		if (data.IndexOf ("[[") == -1)
		{
			linkTitles.Add (" ");
			links.Add(" ");
		}
		if (data.Length == 0)
		{
			
		}
		if (data.IndexOf ("::") != -1 /*&& data.IndexOf("[[") != -1*/)
		{
			int startPassage;
			int startItem = 0;
			//checks various different commands

			//item required command
			if(data.IndexOf("itemReq--") !=-1)
			{
				startItem = data.IndexOf("itemReq--")+10;
				while(data[startItem] != '\n' && data[startItem] != '\r')
				{
					itmReq += data[startItem];
					startItem++;
				}
				//Debug.Log(itmReq);
			}

			//gain an item command
			if(data.IndexOf("itemGain--") != -1){
				startItem = data.IndexOf("itemGain--")+11;
				while(data[startItem] != '\n' && data[startItem] != '\r')
				{
					itmGain += data[startItem];
					startItem++;
				}
			}

			//lose/use an item command
			if(data.IndexOf("itemRem--") !=-1){
				startItem = data.IndexOf("itemRem--")+10;
				while(data[startItem] != '\n' && data[startItem] != '\r')
				{
					itmRem += data[startItem];
					startItem++;
				}
			}

			//a character is happier with the player
			if(data.IndexOf("happyUp--") != -1)
			{
				startItem = data.IndexOf("happyUp--")+10;
				while(data[startItem] != '\n' && data[startItem] != '\r')
				{
					emotnUp += data[startItem];
					startItem++;
				}
				emotnUp = emotnUp.Trim();
			}

			//a player is less happy with the player
			if(data.IndexOf("happyDwn--") != -1)
			{
				startItem = data.IndexOf("happyDwn--")+11;
				while(data[startItem] != '\n' && data[startItem] != '\r')
				{
					emotnDwn += data[startItem];
					startItem++;
				}
				emotnDwn = emotnDwn.Trim();
			}

			//character has to have a certain happiness for the option
			if(data.IndexOf ("happyReq--") != -1)
			{
				//character required
				startItem = data.IndexOf("happyReq--") +11;
				while(data[startItem] != ':')
				{
					emotnReqChar += data[startItem];
					startItem++;
				}
				startItem++;
				//happiness required for that character
				while(data[startItem] != '\n' && data[startItem] != '\r'){
					emotnReqInt += data[startItem];
					startItem++;
				}

				emotnReqChar = emotnReqChar.Trim();
				emotnReqInt = emotnReqInt.Trim();
			}

			startPassage = data.IndexOf ("::") + 3;

			int endPassage = data.IndexOf ("\n");
			passage = data.Substring (startPassage, endPassage - 2);
			//Debug.Log(passage);

			string tempContent;
			
			int endContent = data.IndexOf ("[[");
			if(endContent != -1 && startItem !=0)
			{
				//Debug.Log("Theres an item requirement for this node!");
				tempContent = data.Substring(startItem,endContent-startItem);
			}
			else if(endContent != -1)
			{
				tempContent = data.Substring(endPassage,endContent-endPassage);
			}
			else
			{
				tempContent = data.Substring(endPassage);
			}

			string[] temp = tempContent.Split (split, StringSplitOptions.RemoveEmptyEntries);
			if (temp.Length >= 2 && (temp.Length%2) == 0)
			{
				int startSpeaker = temp[0].IndexOf("\r\n")+1;
				for(int i = 0; i < temp.Length; i+=2)
				{
					speaker.Add(temp[i].Substring(startSpeaker));
					content.Add(temp[i+1]);
				}
			} 
			else if(temp.Length >= 2)
			{
				int startSpeaker = temp[0].IndexOf("\r\n")+1;
				int i;
				for(i = 0;i < (temp.Length - 1); i+=2)
				{
					speaker.Add(temp[i].Substring(startSpeaker));
					content.Add(temp[i+1]);
				}
				content.Add(temp[i]);
			}
			else 
			{
				content.Add(tempContent);
			}
		}

	}
}