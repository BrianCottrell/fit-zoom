using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour, IPointerClickHandler
{
    private GameObject Canvas;
    // Use this for initialization
    void Start () {
        Canvas = GameObject.Find("Canvas");

    }

    public void OnPointerClick(PointerEventData eventData)
    {      
        Application.LoadLevel(0);
    }
}
