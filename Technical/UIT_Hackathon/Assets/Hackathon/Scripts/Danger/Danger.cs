using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class Danger : MonoBehaviour {

    public Image imageDanger;
    private float speed = 0.1f;
    private Color32 color;
    private float timeChange;
	// Use this for initialization
	void Start () {
        color = imageDanger.color;
	}
	
	// Update is called once per frame
	void Update () {
        StartDanger();
	}
    float a = 0;
    void StartDanger()
    {
        if(timeChange > 1)
        {
            color = new Color32(color.r, color.g, color.b, 0);
            timeChange -= Time.deltaTime;
        }
        if (timeChange < 0)
        {
            color = new Color32(color.r, color.g, color.b, 1);
            //a -= speed * Time.deltaTime;
            timeChange += Time.deltaTime;
            //imageDanger.color = Color32.Lerp(imageDanger.color, color, speed);
        }
        imageDanger.color = Color32.Lerp(imageDanger.color, color, speed);
    }
}
