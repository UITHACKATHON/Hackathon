using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TouchController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool isMiss;
    public static TouchController main;
    void Start()
    {
        main = this;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        if(isMiss)
        {
            Debug.Log("Miss");
        }
        isMiss = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Miss");
        //throw new System.NotImplementedException();
    }
}
