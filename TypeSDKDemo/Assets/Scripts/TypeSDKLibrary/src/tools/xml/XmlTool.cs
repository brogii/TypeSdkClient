using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

namespace TypeSDKTool
{
public class XmlTool 
{
		public void LoadGoodsFromXML(string fileName)
		{
			//www = new WWW("file://"+Application.dataPath+"/xml/"+fileName);
			
			//while (www.isDone != true);
			
			//Debug.Log(www.url);
			
//			string data = Resources.Load(fileName.Split('.')[0]).ToString();
//			
//			XmlDocument xmlDoc = new XmlDocument();
			
			//while(www.isDone != true);
			
		}
		static public void createTestXML()
		{
			string filePath = Application.dataPath +@"/Type_u3d/recourse/my.xml";
			if(File.Exists(filePath))
			{
				Debug.Log("error:create failed  has exit file ");
				return;
			}

			XmlDocument xmlDoc = new XmlDocument();
			XmlElement root = xmlDoc.CreateElement("root");
			XmlElement elmNew = xmlDoc.CreateElement("elms");
			elmNew.SetAttribute("ID","0");
			elmNew.SetAttribute("name","naa");

			XmlElement ele1 = xmlDoc.CreateElement("ele1");
			ele1.InnerText="ele1_value";

			XmlElement ele2 = xmlDoc.CreateElement("ele2");
			ele2.InnerText="ele2_value";
			ele2.SetAttribute("index","1");

			elmNew.AppendChild(ele1);
			elmNew.AppendChild(ele2);

			root.AppendChild(elmNew);
			xmlDoc.AppendChild(root);
			xmlDoc.Save(filePath);
			Debug.Log("create xml success :"+ filePath);
		}
		static public XmlDocument readXML(string _in_file_path)
		{


			if(!File.Exists (_in_file_path))
			{
				Debug.Log("do not exit file");
				return null;
			}
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(_in_file_path);

			Debug.Log("read xml success:"+_in_file_path);
			return xmlDoc;

		}

		static public XmlDocument readXMLBelowAsster(string _in_file_path)
		{
			_in_file_path = Application.dataPath +_in_file_path;
			return readXML(_in_file_path);
		}
}

}
