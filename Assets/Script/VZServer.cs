//////////////////////// Copyright 2016 VirZOOM ////////////////////////////

using UnityEngine;
using System.Net.Security;
using System;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;

public class VZServer
{
   //////////////////////// PUBLIC ////////////////////////////

   public delegate void Callback<T>(T response, string cookie);

   public VZServer()
   {
      mHeader.Add("Timeout", "5000");
      mHeader.Add("Method", "POST");
      mHeader.Add("ContentType", "application/json");
   }

   public void Update()
   {
      if (mRequest != null && mRequest.isDone)
      {
//         Debug.Log("Response from " + mUrl + " at " + Time());

         string response = null;
         string cookie = null;

         if (!string.IsNullOrEmpty(mRequest.error))
         {
            Debug.Log("Server error for " + mUrl);
            Debug.Log(mRequest.error);
         }
         else
         {
            response = mRequest.text;
            mRequest.responseHeaders.TryGetValue("SET-COOKIE", out cookie);
         }

         mRequest = null;

         if (mParser != null)
         {
            mParser.Parse(response, cookie, mUrl);
         }
      }
   }

   public bool IsBusy()
   {
      return (mRequest != null);
   }

   public void WaitUntilFree()
   {
      while (IsBusy())
         Update();
   }

   // Login directly with email/password, returns cookie
   public string Login(string username, string password)
   {
      string cookie = null;
      Login(username, password, (x, y) => { cookie = y; });
      WaitUntilFree();
      return cookie;
   }

   public void Login(string username, string password, Callback<string> callback)
   {
      string jsonStr = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\"}";

      WaitUntilFree();
      mParser = new StringParser(callback);
      MakeRequest(mAddr + "gb361m09/", jsonStr, null);
   }

   // Get latest submitted profile
   public string GetProfile(string cookie, string user, int id, string date, bool previous)
   {
      string r = null;
      GetProfile(cookie, user, id, date, previous, (x, y) => r = x);
      WaitUntilFree();
      return r;
   }

   public void GetProfile(string cookie, string user, int id, string date, bool previous, Callback<string> callback)
   {
      string url = mAddr;

      if (previous)
//         url += "auth_access_profile_before_date";
         url += "g84kcmb5";
      else
         url += "auth_receive_profile";

      url += "?profile_id=" + id;

      if (user != null)
      {
         if (previous)
            url += "&username=" + user;
         else
            url += "&user=" + user;
      }
     
      if (date != null)
         url += "&date=" + EscapeUrl(date);
     
      WaitUntilFree();
      mParser = new StringParser(callback);
      MakeRequest(url, null, cookie);
   }

   // Get list of profiles in date range
   public class Profile 
   {
      public string user;
      public string date;
      public int profile_id;
   }

   public class Profiles
   {
      public Profile[] profiles;
   };

   public Profiles GetProfilesByDate(string cookie, DateTime startDate, DateTime endDate)
   {
      string jsonStr = "{\"start_date\":\"" + JsonDate(startDate) + "\",\"end_date\":\"" + JsonDate(endDate) + "\"}";
      Profiles r = null;

      WaitUntilFree();
      mParser = new XmlParser<Profiles>((x, y) => r = x);
      MakeRequest(mAddr + "get_profiles_by_date_for_user/", jsonStr, cookie);
      WaitUntilFree();

      return r;
   }

   //////////////////////// PRIVATE ////////////////////////////

   interface Parser
   {
      void Parse(string response, string cookie, string url);
   }

   class XmlParser<T> : Parser
   {
      Callback<T> mCallback = null;

      public XmlParser(Callback<T> callback)
      {
         mCallback = callback;
      }

      public void Parse(string response, string cookie, string url)
      {
         T obj = default(T);

         if (response != null && response != "<empty/>")
         {
            try
            {
               using (var stream = new StringReader(response))
               {
                  var serializer = new XmlSerializer(typeof(T));
                  obj = (T)serializer.Deserialize(stream);
               }
            }
            catch (Exception ex)
            {
               Debug.Log("Deserialization error for " + url + " with " + response);
               Debug.Log(ex.Message);
               Debug.Log(ex.StackTrace);
            }
         }

         if (mCallback != null)
            mCallback(obj, cookie);
      }
   }

   class StringParser : Parser
   {
      Callback<string> mCallback = null;

      public StringParser(Callback<string> callback)
      {
         mCallback = callback;
      }

      public void Parse(string response, string cookie, string url)
      {
         if (mCallback != null)
            mCallback(response, cookie);
      }
   }

   string mAddr = "https://vznet.herokuapp.com/";
   
   string mUrl = "";
   Parser mParser = null;

   WWW mRequest = null;
   Dictionary<string, string> mHeader = new Dictionary<string, string>();

   string JsonDate(DateTime dateTime)
   {
      return dateTime.Year.ToString("0000") + "-" + dateTime.Month.ToString("00") + "-" + dateTime.Day.ToString("00") + " " + dateTime.Hour.ToString("00") + ":" + dateTime.Minute.ToString("00") + ":" + dateTime.Second.ToString("00");
   }

   string EscapeUrl(string str)
   {
      return str.Replace("\n", "\\n").Replace("\r", "\\r").Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&#39;").Replace("<", "&lt;").Replace(">","&gt;").Replace(" ", "%20");
   }

   float Time()
   {
      return UnityEngine.Time.realtimeSinceStartup;
   }

   void MakeRequest(string url, string post, string cookie)
   {
      mUrl = url;

//      Debug.Log("Request for " + mUrl + " (" + post + ") at " + Time());

      mHeader.Remove("Cookie");

      if (cookie != null)
         mHeader.Add("Cookie", cookie);

      mRequest = new WWW(url, post == null ? null : System.Text.Encoding.UTF8.GetBytes(post), mHeader);
   }
}

