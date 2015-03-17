using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//encapsulates all of the twine nodes which were imported via importer(1?)
public class TwineData
{
	public List<TwineNode> Data = new List<TwineNode>();
	TwineNode current;
	
	public TwineData(List <string> data)
	{
		for(int i = 0; i < data.Count; i++)
		{
			TwineNode twineNode = new TwineNode(data[i]);
			Data.Add(twineNode);
			
			if(i == 0)
			{
				current = twineNode;
			}
		}
	}
	public TwineData(List <string> data, string[] split)
	{
		for(int i = 0; i < data.Count; i++)
		{
			TwineNode twineNode = new TwineNode(data[i], split);
			Data.Add(twineNode);
			
			if(i == 0)
			{
				current = twineNode;
			}
		}
	}
	
	//go to next node
	public void NextNode()
	{
		for(int i = 0; i < Data.Count; i++)
		{
			if(current.LinkData == Data[i].Passage)
			{
				current = Data[i];
			}
		}
	}
	
	//go to specific node
	public void NextNode(string link)
	{
		for(int i = 0; i < Data.Count; i++)
		{
			if(link.Trim() == Data[i].Passage.Trim())
			{
				current = Data[i];
				break;
			}
		}
	}
	
	public TwineNode Current
	{
		get
		{
			return current;
		}
		set
		{
			current = value;
		}
	}
}