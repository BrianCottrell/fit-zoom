using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button_1 : MonoBehaviour
{
    private GameObject obj;
    // Use this for initialization
    void Start () {
        obj = GameObject.Find("IsPress");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            obj.GetComponent<isPress>().IsPressed++;
        }
        
    }


        
        
    
}
