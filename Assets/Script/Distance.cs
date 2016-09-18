using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Distance : MonoBehaviour {
    public string User = "";
    public string Password = "";
    public string StartDate = "";
    public string EndDate = "";

    public string Server_Username;
    public string Server_User_Age;
    public string Server_User_Gender;
    public string Server_User_Weight;
    public string Server_Calories;
    public string Server_Distance;

    VZServer mServer = new VZServer();

    public int Target_Time_1;
    public int Target_Time_2;
    public int Target_Distance_1;
    public int Target_Distance_2;
    public int Target_Calories;
    public int Target_Heart_Rate;
    public int Target_Speed;

    public GameObject Distance_Source;

    public GameObject Profile_Panel;
    public GameObject Name_Text;
    public GameObject Age_Text;
    public GameObject Weight_Text;
    public GameObject Total_Distance_Text;
    public GameObject Target_Distance_Text;
    public GameObject Total_Calories_Text;
    public GameObject Target_Calories_Text;
    public GameObject Total_Time_Text;
    public GameObject Target_Time_Text;

    public GameObject Workout_Panel;
    public GameObject Total_Distance;
    public GameObject Velocity;
    public GameObject Velocity_Bar;
    public GameObject Distance_Bar;
    public GameObject Time_Bar;
    public GameObject Calorie_Bar;
    public GameObject Time_Elapsed;
    public GameObject Calories;

    public GameObject Alert_Panel;
    public GameObject Alert_Text;
    public GameObject Alert_Monster1;
    public GameObject Alert_Monster2;
    public GameObject Alert_Monster3;
    public GameObject Alert_Monster4;

    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;

    public float Start_Time;
    public float Elapsed_Time;

    public float Velocity_Value;
    public float Distance_Value;

    // Use this for initialization
    void Start () {

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
        if (mXMLReader != null)
        {
            Server_Username = mXMLReader.getName();
            Server_User_Age = mXMLReader.getAge();
            Server_User_Weight = mXMLReader.getWeight();
            Server_User_Gender = mXMLReader.getGender();
            Server_Calories = mXMLReader.getSessionCal();
            Server_Distance = mXMLReader.getSessionDist();

            if (Server_User_Gender == "M") {
                if (Int32.Parse(Server_User_Age) < 15) {
                    if (Int32.Parse(Server_User_Weight) < 40) {
                        Target_Distance_1 = 300;
                        Target_Distance_2 = 600;
                        Target_Time_1 = 50;
                        Target_Time_2 = 100;
                        Target_Heart_Rate = 100;
                        Target_Speed = 10;
                        Target_Calories = 70;
                    } else {
                        Target_Distance_1 = 250;
                        Target_Distance_2 = 500;
                        Target_Time_1 = 45;
                        Target_Time_2 = 90;
                        Target_Heart_Rate = 100;
                        Target_Speed = 9;
                        Target_Calories = 60;
                    }
                } else if (Int32.Parse(Server_User_Age) > 55) {
                    if (Int32.Parse(Server_User_Weight) < 70) {
                        Target_Distance_1 = 300;
                        Target_Distance_2 = 600;
                        Target_Time_1 = 50;
                        Target_Time_2 = 100;
                        Target_Heart_Rate = 100;
                        Target_Speed = 10;
                        Target_Calories = 70;
                    } else {
                        Target_Distance_1 = 250;
                        Target_Distance_2 = 500;
                        Target_Time_1 = 45;
                        Target_Time_2 = 90;
                        Target_Heart_Rate = 100;
                        Target_Speed = 9;
                        Target_Calories = 60;
                    }
                } else {
                    if (Int32.Parse(Server_User_Weight) < 70) {
                        Target_Distance_1 = 400;
                        Target_Distance_2 = 800;
                        Target_Time_1 = 60;
                        Target_Time_2 = 120;
                        Target_Heart_Rate = 100;
                        Target_Speed = 10;
                        Target_Calories = 80;
                    } else {
                        Target_Distance_1 = 350;
                        Target_Distance_1 = 700;
                        Target_Time_1 = 50;
                        Target_Time_2 = 100;
                        Target_Heart_Rate = 100;
                        Target_Speed = 10;
                        Target_Calories = 70;
                    }
                }
            } else {
                if (Int32.Parse(Server_User_Age) < 15) {
                    if (Int32.Parse(Server_User_Weight) < 40) {
                        Target_Distance_1 = 275;
                        Target_Distance_2 = 550;
                        Target_Time_1 = 45;
                        Target_Time_2 = 90;
                        Target_Heart_Rate = 100;
                        Target_Speed = 10;
                        Target_Calories = 65;
                    } else {
                        Target_Distance_1 = 225;
                        Target_Distance_2 = 450;
                        Target_Time_1 = 40;
                        Target_Time_2 = 80;
                        Target_Heart_Rate = 100;
                        Target_Speed = 9;
                        Target_Calories = 55;
                    }
                }
                else if (Int32.Parse(Server_User_Age) > 55)
                {
                    if (Int32.Parse(Server_User_Weight) < 70)
                    {
                        Target_Distance_1 = 275;
                        Target_Distance_2 = 550;
                        Target_Time_1 = 45;
                        Target_Time_2 = 90;
                        Target_Heart_Rate = 100;
                        Target_Speed = 10;
                        Target_Calories = 65;
                    }
                    else
                    {
                        Target_Distance_1 = 225;
                        Target_Distance_2 = 445;
                        Target_Time_1 = 40;
                        Target_Time_2 = 80;
                        Target_Heart_Rate = 100;
                        Target_Speed = 9;
                        Target_Calories = 55;
                    }
                }
                else
                {
                    if (Int32.Parse(Server_User_Weight) < 70)
                    {
                        Target_Distance_1 = 375;
                        Target_Distance_2 = 750;
                        Target_Time_1 = 55;
                        Target_Time_2 = 110;
                        Target_Heart_Rate = 100;
                        Target_Speed = 10;
                        Target_Calories = 75;
                    }
                    else
                    {
                        Target_Distance_1 = 325;
                        Target_Distance_2 = 650;
                        Target_Time_1 = 45;
                        Target_Time_2 = 90;
                        Target_Heart_Rate = 100;
                        Target_Speed = 10;
                        Target_Calories = 65;
                    }
                }
            }
        }

        //      VZServer.Profiles profiles = mServer.GetProfilesByDate(cookie, DateTime.Parse(StartDate), DateTime.Parse(EndDate));
        //      foreach (var entry in profiles.profiles)
        //      {
        //         Debug.Log(entry.date);
        //      }

        Distance_Source = GameObject.Find("VZController");

        Profile_Panel = GameObject.Find("ProfilePanel");
        Name_Text = GameObject.Find("NameText");
        Age_Text = GameObject.Find("AgeText");
        Weight_Text = GameObject.Find("WeightText");
        Total_Distance_Text = GameObject.Find("TotalDistance");
        Target_Distance_Text = GameObject.Find("TargetDistance");
        Total_Calories_Text = GameObject.Find("TotalCalories");
        Target_Calories_Text = GameObject.Find("TargetCalories");
        Total_Time_Text = GameObject.Find("TotalTime");
        Target_Time_Text = GameObject.Find("TargetTime");

        Workout_Panel = GameObject.Find("WorkoutPanel");
        Total_Distance = GameObject.Find("DistanceText");
        Distance_Bar = GameObject.Find("DistanceBar");
        Velocity = GameObject.Find("VelocityText");
        Velocity_Bar = GameObject.Find("VelocityBar");
        Time_Elapsed = GameObject.Find("TimeText");
        Time_Bar = GameObject.Find("TimeBar");
        Calories = GameObject.Find("CalorieText");
        Calorie_Bar = GameObject.Find("CalorieBar");

        Alert_Panel = GameObject.Find("AlertPanel");
        Alert_Text = GameObject.Find("AlertText");
        Alert_Monster1 = GameObject.Find("AlertImage1");
        Alert_Monster2 = GameObject.Find("AlertImage2");
        Alert_Monster3 = GameObject.Find("AlertImage3");
        Alert_Monster4 = GameObject.Find("AlertImage4");

        Start_Time = Time.time;
        Elapsed_Time = 0;

        Profile_Panel.SetActive(false);
        Workout_Panel.SetActive(false);
        Alert_Panel.SetActive(false);
        Distance_Value = 0;
        Velocity_Value = Mathf.Round(Distance_Source.GetComponent<VZController>().Current_Bike_State.Speed * 10);

        Name_Text.GetComponent<Text>().text = "Username: " + Server_Username;
        Age_Text.GetComponent<Text>().text = "Age: " + Server_User_Age;
        Weight_Text.GetComponent<Text>().text = "Weight: " + Server_User_Weight + " kg";
        Total_Distance_Text.GetComponent<Text>().text = "Total: " + Server_Distance + " m";
        Target_Distance_Text.GetComponent<Text>().text = "Target for Today: " + Target_Distance_2 + " m";
        Total_Calories_Text.GetComponent<Text>().text = "Total: " + Server_Calories + " C";
        Target_Calories_Text.GetComponent<Text>().text = "Target for Today: " + Target_Calories + " C";
        Target_Time_Text.GetComponent<Text>().text = "Your Target Workout Time for Today:";
        Total_Time_Text.GetComponent<Text>().text = Target_Time_2.ToString() + " seconds";

        string url = "http://nodejs-mongodb-example-fit-zoom.0ec9.hackathon.openshiftapps.com/pagecount?fitnessdata=";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Alert_Panel.SetActive(true);
            Alert_Text.GetComponent<Text>().text = www.text;
            Debug.Log("WWW Ok!: " + www.data);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    // Update is called once per frame
    void Update () {
        mServer.Update();
        Velocity_Value = Mathf.Round(Distance_Source.GetComponent<VZController>().Current_Bike_State.Speed * 10);
        Distance_Value = Mathf.Round(Distance_Source.GetComponent<VZController>().Distance_show);
        Total_Distance.GetComponent<Text>().text = "Total Distance: " + Distance_Value.ToString() + " m";

        if (Distance_Source.GetComponent<VZController>().Distance_show < 1)
        {
            Start_Time = Time.time;
        }
        if (Distance_Source.GetComponent<VZController>().Distance_show > 0)
        {
            Elapsed_Time = Mathf.Round(Time.time - Start_Time);
            if (Distance_Source.GetComponent<VZController>().Distance_show < 5) {
                Profile_Panel.SetActive(true);
            } else {
                Profile_Panel.SetActive(false);
                Workout_Panel.SetActive(true);
            }
        }
        if (Distance_Source.GetComponent<VZController>().Distance_show > 20)
        {
//            Total_Distance.GetComponent<Text>().color = Color.green;
//            Alert_Panel.SetActive(true);
        }
        Velocity.GetComponent<Text>().text = "Current Velocity: " + Velocity_Value.ToString() + " m/s";
        Velocity_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(Velocity_Value, 10f);
        if (Distance_Value < Target_Distance_2)
        {
            Distance_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(120 * (Distance_Value / Target_Distance_2), 10f);
        } else
        {
            Distance_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 10f);
            Distance_Bar.GetComponent<Image>().color = Color.green;
        }
        if (Elapsed_Time < Target_Time_2)
        {
            Time_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(120 * (Elapsed_Time / Target_Time_2), 10f);
        }
        else
        {
            Time_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 10f);
            Time_Bar.GetComponent<Image>().color = Color.green;
        }
        if (Elapsed_Time * 0.18 < Target_Calories / 6)
        {
            Calorie_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 10f);
        }
        else if (Elapsed_Time * 0.18 < Target_Calories / 3)
        {
            Calorie_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 10f);
        }
        else if (Elapsed_Time * 0.18 < Target_Calories / 2)
        {
            Calorie_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 10f);
        }
        else if (Elapsed_Time * 0.18 < 2 * Target_Calories / 3)
        {
            Calorie_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 10f);
        }
        else if (Elapsed_Time * 0.18 < 5 * Target_Calories / 6)
        {
            Calorie_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 10f);
        }
        else if (Elapsed_Time * 0.18 < Target_Calories)
        {
            Calorie_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 10f);
        }
        else
        {
            Calorie_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 10f);
            Calorie_Bar.GetComponent<Image>().color = Color.green;
        }
        Time_Elapsed.GetComponent<Text>().text = "Elapsed Time: " + Elapsed_Time.ToString() +" s";
        Calories.GetComponent<Text>().text = "Calories Burnt: " + Elapsed_Time * 0.18 + " Calories";
        Alert_Panel.SetActive(false);

        if (Elapsed_Time > Target_Time_1 && Elapsed_Time < Target_Time_1 + 5)
        {
            Alert_Panel.SetActive(true);
            Alert_Text.GetComponent<Text>().text = "Congratulations You Just Met Your First Target Time!";
            Alert_Monster1.SetActive(true);
            Alert_Monster2.SetActive(false);
            Alert_Monster3.SetActive(false);
            Alert_Monster4.SetActive(false);
        }
        if (Elapsed_Time > Target_Time_2 && Elapsed_Time < Target_Time_2 + 5)
        {
            Alert_Panel.SetActive(true);
            Alert_Text.GetComponent<Text>().text = "Congratulations You Just Met Your Second Target Time!";
            Alert_Monster1.SetActive(true);
            Alert_Monster2.SetActive(false);
            Alert_Monster3.SetActive(false);
            Alert_Monster4.SetActive(false);
        }
        if (Distance_Value > Target_Distance_1 && Distance_Value < Target_Distance_1 + 15)
        {
            Alert_Panel.SetActive(true);
            Alert_Text.GetComponent<Text>().text = "Congratulations You Just Met Your First Target Distance!";
            Alert_Monster1.SetActive(false);
            Alert_Monster2.SetActive(true);
            Alert_Monster3.SetActive(false);
            Alert_Monster4.SetActive(false);
        }
        if (Distance_Value > Target_Distance_2 && Distance_Value < Target_Distance_2 + 15)
        {
            Alert_Panel.SetActive(true);
            Alert_Text.GetComponent<Text>().text = "Congratulations You Just Met Your Second Target Distance!";
            Alert_Monster1.SetActive(false);
            Alert_Monster2.SetActive(true);
            Alert_Monster3.SetActive(false);
            Alert_Monster4.SetActive(false);
        }
        if (Elapsed_Time * 0.18 > Target_Calories && Elapsed_Time * 0.18 < Target_Calories + 2)
        {
            Alert_Panel.SetActive(true);
            Alert_Text.GetComponent<Text>().text = "Congratulations You Just Met Your Daily Calorie Goal!";
            Alert_Monster1.SetActive(false);
            Alert_Monster2.SetActive(false);
            Alert_Monster3.SetActive(true);
            Alert_Monster4.SetActive(false);
        }

/*        Vector3 currPos = GameObject.Find("VZPlayer").transform.position;
        if (Elapsed_Time > Target_Time_2)
        {
            			Debug.Log("currPos = "+currPos.ToString());

            if (monster1 == null) monster1 = (GameObject)Instantiate(Resources.Load("Monsters/" + "Monster3"),
                new Vector3(currPos.x, (currPos.y - (float)0.471066), (currPos.z + (float)5.68649)),
                Quaternion.identity);
        }
        else if (Elapsed_Time > Target_Time_1)
        {
            			Debug.Log("currPos = "+currPos.ToString());

            if (monster2 == null) monster2 = (GameObject)Instantiate(Resources.Load("Monsters/" + "Monster2"),
                new Vector3(currPos.x, (currPos.y - (float)0.471066), (currPos.z + (float)5.68649)),
                Quaternion.identity);
        }
        else if (Distance_Value > Target_Distance_2)
        {
            			Debug.Log("currPos = "+currPos.ToString());

            if (monster3 == null) monster3 = (GameObject)Instantiate(Resources.Load("Monsters/" + "Monster1"),
                new Vector3(currPos.x, (currPos.y - (float)0.471066), (currPos.z + (float)5.68649)),
                Quaternion.identity);
        }
        else if (Distance_Value > Target_Distance_1)
        {
            			Debug.Log("currPos = "+currPos.ToString());

            if (monster4 == null) monster4 = (GameObject)Instantiate(Resources.Load("Monsters/" + "Monster4"),
                new Vector3(currPos.x, (currPos.y - (float)0.471066), (currPos.z + (float)5.68649)),
                Quaternion.identity);
        }

        if (monster1 != null)
        {
            if (monster1.transform.position.z < currPos.z)
            {
                Destroy(monster1);
            }
        }
        if (monster2 != null)
        {
            if (monster2.transform.position.z < currPos.z)
            {
                Destroy(monster2);
            }
        }
        if (monster3 != null)
        {
            if (monster3.transform.position.z < currPos.z)
            {
                Destroy(monster3);
            }
        }
        if (monster4 != null)
        {
            if (monster4.transform.position.z < currPos.z)
            {
                Destroy(monster4);
            }
        }
        */
    }
}
