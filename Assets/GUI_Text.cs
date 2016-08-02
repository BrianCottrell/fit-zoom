using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_Text : MonoBehaviour {
    Text txt;
    private int Distance = 0;
	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Distance Traveled: " + Distance;

    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Distance Traveled: " + Distance;
        Distance++;
    }
}
