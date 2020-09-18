using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveLoadFile {

	public static bool saveFile(string filename, object obj) {
		try {
			Debug.Log("MSXMSG: Writing Stream to Disk."+ filename);
			Stream fileStream = File.Open(filename, FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(fileStream, obj);
			fileStream.Close();
			return true;
		} catch(Exception e) {
			Debug.LogWarning("MSXMSG: SaveFile(): Failed to serialize object to a file " 
			                 + filename + " (Reason: " + e.ToString() + ")");
			return false;
		}
	}
	
	public static object loadFile(string filename) {
		try {
			Stream fileStream = File.Open(filename, FileMode.Open, FileAccess.Read);
			BinaryFormatter formatter = new BinaryFormatter();
			object obj= formatter.Deserialize(fileStream);
			fileStream.Close();
			Debug.Log("MSXMSG: File "+ filename + " loaded.");
			return obj;
		} catch(Exception e) {
			Debug.LogWarning("MSXMSG: LoadFile(): Failed to deserialize a file " 
			                 + filename + " (Reason: " + e.ToString() + ")");
			return null;
		}       
	}

	public static string getDataPath(string name){
		return Application.persistentDataPath+"/"+name;
	} 
}
