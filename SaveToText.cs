using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq; 

public class SaveToText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	WriteStringLine ("TUTDone" ,0, "PlayerManagerTest.txt");
	//	WriteStringLine ("opps new line" ,1, "PlayerManagerTest.txt");
	//	WriteStringLine ("this test is for like 5" ,5, "PlayerManagerTest.txt");
		//Debug.Log (ReadStringLine("PlayerManagerTest.txt",2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
//	 public void WriteString(string NewSave, string fileName)
//	{
//	
//		string path = Application.dataPath + "/Resources/" + fileName;
//		string DirPath = Application.dataPath + "/Resources";
//	//	using (TextWriter writer = new StreamWriter(path , false)) {
//			if (!File.Exists (path)) {
//				Directory.CreateDirectory (DirPath);
//				File.CreateText (path);
//				File.WriteAllText (path, NewSave);
//				Debug.Log ("making files");
//			}
//
//			File.WriteAllText (path, "");
//			File.AppendAllText (path, NewSave);
//			//writer.WriteLine(NewSave);
//			//writer.Close();
//		//}
//	}
//	public void WriteStringLine(string NewSave,int ArrayNumber, string fileName)
//	{
//
//		string path = Application.dataPath + "/Resources/" + fileName;
//
//		string DirPath = Application.dataPath + "/Resources";
//		//using (TextWriter writer = new StreamWriter(path , false)) {
//			List<string> lines = new List<string> {};
//			for (int i=0; i< File.ReadAllLines (path).Length; i++) {
//				lines.Add (File.ReadAllLines (path) [i]);
//			}
//			for (int i=0; i< File.ReadAllLines (path).Length; i++) {
//				if (i == ArrayNumber) {
//					lines [i] = NewSave;
//				}
//			}
//			string[] RealLine = lines.ToArray ();
//			File.WriteAllLines (path, RealLine);
//
//			Debug.Log ("i wrote " + lines + " to " + path);
//			//writer.WriteLine(NewSave);
//			//writer.Close();
//
//		//}
//	}
//		public string[] ReadString( string fileName)
//		{
//			string path =Application.dataPath + "/Resources/" +fileName;
//			//Read the text from directly from the test.txt file
//			return File.ReadAllLines (path);
//		}

		 public void WriteString(string NewSave, string fileName)
		{
		
			string path = Application.dataPath + "/Resources/" + fileName;
			string DirPath = Application.dataPath + "/Resources";
		//	using (TextWriter writer = new StreamWriter(path , false)) {
			List<string> lines = new List<string> {};
			using (TextReader reader = new StreamReader(path , false)) {
			int p = 0;
			while (reader.ReadLine() != null) { p++; }
			for (int i=0; i< p; i++) {
				lines.Add (File.ReadAllLines (path) [i]);
				if (i == 50) {
					lines [i] = NewSave;
				}
			}
		}
			using (TextWriter writer = new StreamWriter(path , false)) {
			writer.WriteLine(NewSave);
			writer.Close();
		}
				//writer.WriteLine(NewSave);
				//writer.Close();
			//}
		}
	public void WriteStringLine(string NewSave,int ArrayNumber, string fileName){
		string path = Application.dataPath + "/Resources/" + fileName;

		List<string> lines = new List<string> {};
		using (TextReader reader = new StreamReader(path , false)) {
			int p = 0;
			while (reader.ReadLine() != null) { p++; }
			for (int i=0; i< p; i++) {
				lines.Add (File.ReadAllLines (path) [i]);
				if (i == ArrayNumber) {
					lines [i] = NewSave;
				}
			}
		}
		string[] RealLine = lines.ToArray ();
		string temp = "";
		for (int i=0; i< RealLine.Length; i++) {
			//Read the text from directly from the test.txt file
			temp = temp  +RealLine[i]+ "\r\n";
		}
		using (TextWriter writer = new StreamWriter(path , false)) {
			writer.WriteLine(temp);
			writer.Close();
		}
	}
	public string ReadStringLine( string fileName, int array)
	{
		string path =Application.dataPath + "/Resources/" +fileName;
		using (TextReader reader = new StreamReader(path , false)) {
			string temp = "";

			for (int i=0; i< reader.Peek(); i++) {
				//Read the text from directly from the test.txt file

				if(array == i){
					temp = reader.ReadLine();
				}
				reader.ReadLine();
			}
			reader.Close ();
			return 	temp;
		}
	}
//	public string ReadString( string fileName)
//	{
//		string path =Application.dataPath + "/Resources/" +fileName;
//		using (TextReader reader = new StreamReader(path , false)) {
//			string temp = "";
//			while (reader.Peek() >= 0) {
//			//Read the text from directly from the test.txt file
//				temp = temp  +reader.ReadLine()+ "\n";
//			}
//			reader.Close ();
//			return 	temp;
//		}
//	}
}
