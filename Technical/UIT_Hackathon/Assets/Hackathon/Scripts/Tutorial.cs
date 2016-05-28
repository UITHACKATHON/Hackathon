using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour , IPointerDownHandler
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        gameObject.SetActive(false);
        ItemPause.main.EventOnResumne();
    }
}
