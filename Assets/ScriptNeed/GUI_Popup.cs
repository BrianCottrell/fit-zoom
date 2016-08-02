using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GUI_Popup : MonoBehaviour
{


    // You need to register your game or application in Twitter to get cosumer key and secret.
    // Go to this page for registration: http://dev.twitter.com/apps/new
    public string CONSUMER_KEY = "oBWUO1QvBV6mFrgalSshRGbCw";
    public string CONSUMER_SECRET = "KaVKvpVTr2zZ3lvazpoRO0R11XmOcx9HnkYXxvTuKP4RsZa2l8";

    // You need to save access token and secret for later use.
    // You can keep using them whenever you need to access the user's Twitter account. 
    // They will be always valid until the user revokes the access to your application.
    const string PLAYER_PREFS_TWITTER_USER_ID = "TwitterUserID";
    const string PLAYER_PREFS_TWITTER_USER_SCREEN_NAME = "TwitterUserScreenName";
    const string PLAYER_PREFS_TWITTER_USER_TOKEN = "TwitterUserToken";
    const string PLAYER_PREFS_TWITTER_USER_TOKEN_SECRET = "TwitterUserTokenSecret";

    Twitter.RequestTokenResponse m_RequestTokenResponse;
    Twitter.AccessTokenResponse m_AccessTokenResponse;


    bool openWindow = false;

    public string stringOfPin = "PIN.";
    public string stringOfTwit = "Message.";

    GameObject obj;

    // Use this for initialization
    void Start () {
        obj = GameObject.Find("IsPress");
        // Get Pin when initialize
        StartCoroutine(Twitter.API.GetRequestToken(CONSUMER_KEY, CONSUMER_SECRET,
            new Twitter.RequestTokenCallback(this.OnRequestTokenCallback)));

        LoadTwitterUserInfo();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (obj.GetComponent<isPress>().IsOpen)
        {
            openWindow = true;
        }
        else
        {
            openWindow = false;
        }
                ;
    }

    void OnGUI()
    {
        if (openWindow)
        {
            Rect rect = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 200, 400, 300);
            GUI.Window(0, rect, ShowGUI, "Twitter Login Window");
            //Make your GUI items here. Set openWindow to true when you want the pop up to appear, and false when you want it gone.
        }

        
    }

    void ShowGUI(int windowID) {


        GUI.Label(new Rect(50, 40, 200, 30), "Login Page");
        stringOfPin = GUI.TextField(new Rect(50, 80, 200, 20), stringOfPin, 25);
        stringOfTwit = GUI.TextField(new Rect(50, 110, 200, 50), stringOfTwit, 200);


        if (string.IsNullOrEmpty(CONSUMER_KEY) || string.IsNullOrEmpty(CONSUMER_SECRET))
        {
            string text = "You need to register your game or application first.\n Click this button, register and fill CONSUMER_KEY and CONSUMER_SECRET of Demo game object.";
            if (GUI.Button(new Rect(50,200,200,20), text))
            {
                Application.OpenURL("http://dev.twitter.com/apps/new");
            }
        }
        else
        {
            string text = string.Empty;

            if (!string.IsNullOrEmpty(m_AccessTokenResponse.ScreenName))
            {
                text = m_AccessTokenResponse.ScreenName + "\nClick to register with a different Twitter account";
            }

            else
            {
                text = "You need to register your game or application first.";
            }
        }

        // Button for Enter PIN and Post

        if (GUI.Button(new Rect(300, 80, 75, 30), "Enter PIN"))
        {

            openWindow = false;
            obj.GetComponent<isPress>().IsPressed++;
            StartCoroutine(Twitter.API.GetAccessToken(CONSUMER_KEY, CONSUMER_SECRET, m_RequestTokenResponse.Token, stringOfPin,
                           new Twitter.AccessTokenCallback(this.OnAccessTokenCallback)));
        }

        if (GUI.Button(new Rect(300, 130, 75, 30), "Post"))
        {

            openWindow = false;
            obj.GetComponent<isPress>().IsPressed++;
            StartCoroutine(Twitter.API.PostTweet(stringOfTwit, CONSUMER_KEY, CONSUMER_SECRET, m_AccessTokenResponse,
                           new Twitter.PostTweetCallback(this.OnPostTweet)));

            stringOfTwit = "";
        }


    }




    void LoadTwitterUserInfo()
    {
        m_AccessTokenResponse = new Twitter.AccessTokenResponse();

        m_AccessTokenResponse.UserId = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_ID);
        m_AccessTokenResponse.ScreenName = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_SCREEN_NAME);
        m_AccessTokenResponse.Token = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_TOKEN);
        m_AccessTokenResponse.TokenSecret = PlayerPrefs.GetString(PLAYER_PREFS_TWITTER_USER_TOKEN_SECRET);

        if (!string.IsNullOrEmpty(m_AccessTokenResponse.Token) &&
            !string.IsNullOrEmpty(m_AccessTokenResponse.ScreenName) &&
            !string.IsNullOrEmpty(m_AccessTokenResponse.Token) &&
            !string.IsNullOrEmpty(m_AccessTokenResponse.TokenSecret))
        {
            string log = "LoadTwitterUserInfo - succeeded";
            log += "\n    UserId : " + m_AccessTokenResponse.UserId;
            log += "\n    ScreenName : " + m_AccessTokenResponse.ScreenName;
            log += "\n    Token : " + m_AccessTokenResponse.Token;
            log += "\n    TokenSecret : " + m_AccessTokenResponse.TokenSecret;
            print(log);
        }
    }

    void OnRequestTokenCallback(bool success, Twitter.RequestTokenResponse response)
    {
        if (success)
        {
            string log = "OnRequestTokenCallback - succeeded";
            log += "\n    Token : " + response.Token;
            log += "\n    TokenSecret : " + response.TokenSecret;
            print(log);

            m_RequestTokenResponse = response;

            Twitter.API.OpenAuthorizationPage(response.Token);
        }
        else
        {
            print("OnRequestTokenCallback - failed.");
        }
    }

    void OnAccessTokenCallback(bool success, Twitter.AccessTokenResponse response)
    {
        if (success)
        {
            string log = "OnAccessTokenCallback - succeeded";
            log += "\n    UserId : " + response.UserId;
            log += "\n    ScreenName : " + response.ScreenName;
            log += "\n    Token : " + response.Token;
            log += "\n    TokenSecret : " + response.TokenSecret;
            print(log);

            m_AccessTokenResponse = response;

            PlayerPrefs.SetString(PLAYER_PREFS_TWITTER_USER_ID, response.UserId);
            PlayerPrefs.SetString(PLAYER_PREFS_TWITTER_USER_SCREEN_NAME, response.ScreenName);
            PlayerPrefs.SetString(PLAYER_PREFS_TWITTER_USER_TOKEN, response.Token);
            PlayerPrefs.SetString(PLAYER_PREFS_TWITTER_USER_TOKEN_SECRET, response.TokenSecret);
        }
        else
        {
            print("OnAccessTokenCallback - failed.");
        }
    }

    void OnPostTweet(bool success)
    {
        print("OnPostTweet - " + (success ? "succedded." : "failed."));
    }

}
