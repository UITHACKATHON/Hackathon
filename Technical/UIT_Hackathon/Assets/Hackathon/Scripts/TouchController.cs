using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TouchController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool isMiss;
    public static TouchController main;
    public GameObject txtMiss;
    public bool isTouch = true;
    void Start()
    {
        main = this;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        if(isMiss)
        {
            isTouch = false;
            Debug.Log("Miss");
            txtMiss.SetActive(true);
            StartCoroutine(HideMiss());
        }
        isMiss = true;
    }
    IEnumerator HideMiss()
    {
        yield return new WaitForSeconds(1.0f);
        txtMiss.SetActive(false);
        isTouch = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Miss");
        //throw new System.NotImplementedException();
    }
}
