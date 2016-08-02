using UnityEngine;
using System;

public class VZTest : MonoBehaviour
{
   public string User = "";
   public string Password = "";
   public string StartDate = "";
   public string EndDate = "";

   VZServer mServer = new VZServer();

   void Start()
   {
//    string cookie = mServer.Login(User, Password);
	  string cookie = mServer.Login("azinicus", "test123");
//	  string cookie = "sessionid=a3kt37xluklyad1ryj43ikhib1u3nov7; expires=Sun, 23-Jul-2017 08:12:31 GMT; httponly; Max-Age=31535999; Path=/";
      Debug.Log("cookie = " + cookie);

	  Debug.Log("User = " + User);
//	  string profile = mServer.GetProfile(cookie, "azinicus", 0, null, true);
	  string profile = mServer.GetProfile(cookie, null, 0, null, false);
      Debug.Log(profile);

	  // Parse XML
	  XMLReader mXMLReader = new XMLReader(profile);
	  if(mXMLReader != null) {
		Debug.Log(mXMLReader.getName());
		Debug.Log(mXMLReader.getAge());
		Debug.Log(mXMLReader.getWeight());
		Debug.Log(mXMLReader.getGender());
		Debug.Log(mXMLReader.getSessionCal());
		Debug.Log(mXMLReader.getSessionDist());
	  }

//      VZServer.Profiles profiles = mServer.GetProfilesByDate(cookie, DateTime.Parse(StartDate), DateTime.Parse(EndDate));
//      foreach (var entry in profiles.profiles)
//      {
//         Debug.Log(entry.date);
//      }
   }

   void Update()
   {
      mServer.Update();
   }
}
