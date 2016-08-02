using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour, IPointerClickHandler
{
    private GameObject Canvas;

    // Use this for initialization
    void Start () {
        Canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("123");
        GameObject start = Canvas.transform.Find("Page_02").gameObject;
        GameObject close = Canvas.transform.Find("Page_01").gameObject;
        start.SetActive(true);
        close.SetActive(false);
    }
}
