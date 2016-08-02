using UnityEngine;
using System.Collections;

public class isPress : MonoBehaviour {
    public int IsPressed = 0;
    public bool IsOpen = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(IsPressed %2 == 0)
        {
            IsOpen = false;
        } else {
            IsOpen = true;
        }

	}
}
