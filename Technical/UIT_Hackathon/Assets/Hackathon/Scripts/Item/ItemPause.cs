using UnityEngine;
using System.Collections;
using System;

public class ItemPause : MonoBehaviour {


    public static event Action ActionOnPause;
    public static event Action ActionOnResumne;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("Item Pause")]
    public void EventOnPause()
    {
        if (ActionOnPause != null)
        {
            ActionOnPause();
        }
    }
    [ContextMenu("Item Resumne")]
    public void EventOnResumne()
    {
        if (ActionOnResumne != null)
        {
            ActionOnResumne();
        }
    }

}
