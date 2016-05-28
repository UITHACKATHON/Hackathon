using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int live = 0;
    public int score = 0;
    public GameObject panelGameOver;
    public GameObject objGamePlay;
    public static GameController main;

    public Text txtLive;
    public Text txtScore;
	// Use this for initialization
	void Start () {
        main = this;
        UpdateLive(0);
        UpdateScore(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void UpdateLive(int _live)
    {
        live += _live;
        txtLive.text = live.ToString();
        if(live <= 0)
        {
            panelGameOver.SetActive(true);
            objGamePlay.SetActive(false);
        }
    }
    public void UpdateScore(int _score)
    {
        score += _score;
        txtScore.text = score.ToString();
    }
    public void btPlay()
    {
        Application.LoadLevel("Cao");
    }
}
