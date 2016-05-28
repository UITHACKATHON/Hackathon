using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

    void Update()
    {
        //Touch();
    }
    void Touch()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Asds  asdsadas");
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

    }
    void OnMouseDown()
    {
        Debug.Log("TOuch Roi ");
        Destroy(gameObject);
    }

}
