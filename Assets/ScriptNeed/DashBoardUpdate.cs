using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DashBoardUpdate : MonoBehaviour {
    public float speed = 0.0f;
    public string distance = "";
    public string heartRate = "";
    public string calorie = "";

    private GameObject speedObj;
    private GameObject distanceObj;
    private GameObject heartRateObj;
    private GameObject calorieObj;

    private GameObject rootObj;

    // Use this for initialization
    void Start () {
        rootObj = GameObject.Find("Canvas");
        speedObj = rootObj.transform.Find("Page_02/Scrollbar").gameObject;
        distanceObj = rootObj.transform.Find("Page_02/Distance").gameObject;
        heartRateObj = rootObj.transform.Find("Page_02/HeartRate").gameObject;
        calorieObj = rootObj.transform.Find("Page_02/Calorie").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        distance = "Distance " + "";
        heartRate = "HeartRate " + "";
        calorie = "Calorie " + "";

        distanceObj.GetComponent<Text>().text = distance;
        heartRateObj.GetComponent<Text>().text = heartRate;
        calorieObj.GetComponent<Text>().text = calorie;
    }
}
