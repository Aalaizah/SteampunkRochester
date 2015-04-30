using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class TwineImporter : MonoBehaviour {
	
	// Use this for initialization
	public List<string> twineDataList = new List<string>();
	TwineData twineData;
	
	public TwineImporter()
	{

	}

	public void ReadTwineFile(string path)
	{
		twineDataList.Clear();
		ReadTwineData(path);
		ParseTwineData(twineDataList);
	}

	public void ReadTwineData(string path)
	{
		string temp;
		string[] file;
		string[] split = {"::"};
		
		temp = Resources.Load(path, typeof(TextAsset)).ToString();
		
		try
		{
			//parse large string by lines into an list
			file = temp.Split(split, StringSplitOptions.RemoveEmptyEntries);
			foreach (string s in file)
			{
				twineDataList.Add("::" + s);
			}
		}
		
		catch (FileNotFoundException e)
		{
			Debug.Log("The process failed: {0}" + e.ToString());
			return;
		}
	}
	
	void ShowTwineData(List <string> data)
	{
		for (int i = 0; i < data.Count; i++)
		{
			Debug.Log("Data Set "+i+": "+ data[i]);
		}
	}
	
	public void ParseTwineData(List<string> data)
	{
		string[] split = {":","\r\n"};
		twineData = new TwineData(data, split);
	}
	
	public TwineData TwineData
	{
		get
		{
			return twineData;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	}
}
