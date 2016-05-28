using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text txtScore;
    public Text txtHightScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetTxt(int score, int hightScore)
    {
        txtScore.text = score.ToString();
        txtHightScore.text = hightScore.ToString();
    }
}
