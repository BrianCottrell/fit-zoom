using UnityEngine;
using System;
using System.IO;
using System.Xml;
using System.Text;

public class XMLReader
{
	XmlReader reader;
	string name, age, weight, gender;
	string achievementsXML;

	public XMLReader(string xml_str)
	{
		reader = XmlReader.Create(new StringReader(xml_str));
		while(reader.Read())
		{
			if(reader.Name.Equals("Name"))
			{
				name = reader.ReadElementContentAsString();
			}
			else if(reader.Name.Equals("Age"))
			{
				age = reader.ReadElementContentAsString();
			}
			else if(reader.Name.Equals("Weight"))
			{
				weight = reader.ReadElementContentAsString();
			}
			else if(reader.Name.Equals("Male"))
			{
				if(reader.ReadElementContentAsString().Equals("0")) {
					gender = "Male";
				}
				else
				{
					gender = "Female";
				}
			}
			else if(reader.Name.Equals("Achievements"))
			{
				achievementsXML = reader.ReadOuterXml();
			}
		}
	}

	public string getName()
	{
		return name;
	}

	public string getAge()
	{
		return age;
	}

	public string getWeight()
	{
		return weight;
	}

	public string getGender()
	{
		return gender;
	}

	public string getSessionCal()
	{
		XmlReader readerCal = XmlReader.Create(new StringReader(achievementsXML));
		readerCal.ReadToFollowing("TotalCalories");
		string sessionCal = readerCal.ReadElementContentAsString();
		readerCal.Close();
		return sessionCal;
	}

	public string getSessionDist()
	{
		XmlReader readerDist = XmlReader.Create(new StringReader(achievementsXML));
		readerDist.ReadToFollowing("TotalDistance");
		string sessionDist = readerDist.ReadElementContentAsString();
		readerDist.Close();
		return sessionDist;
	}
}
