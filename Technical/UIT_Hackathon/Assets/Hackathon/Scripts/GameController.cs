using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public int live = 0;
    public int score = 0;
    public GameObject panelGameOver;
    public GameObject objGamePlay;
    public static GameController main;
    public BoundEnemy boundEnemy;
    //
    public Text txtLive;
    public Text txtScore;
    public List<Sprite> listSprite;
	// Use this for initialization
	void Start () {
        main = this;
        UpdateLive(0);
        UpdateScore(0);
	}
	public Sprite GetSprite()
    {
        int index = Random.Range(0, listSprite.Count);
        return listSprite[index];
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
    public void GameOver()
    {
        panelGameOver.SetActive(true);
        objGamePlay.SetActive(false);
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
