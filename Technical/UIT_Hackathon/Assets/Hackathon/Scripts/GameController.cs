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
    public int hightScore;
    public GameOver gamover;
    public AudioSource effect;
	// Use this for initialization
	void Start () {
        main = this;
        UpdateLive(0);
        UpdateScore(0);
        hightScore = PlayerPrefs.GetInt("HightScore");
	}
    public void TouchEnemy()
    {
        effect.Play();
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
        if(score > PlayerPrefs.GetInt("HightScore"))
        {
            hightScore = score;
            PlayerPrefs.SetInt("HightScore", hightScore);
        }
        gamover.SetTxt(score, hightScore);
    }
    public void UpdateScore(int _score)
    {
        TouchEnemy();
        score += _score;
        txtScore.text = score.ToString();
        if(score == 10)
        {
            SpawnEnemy.main.Design(1.5f, 2, 4);
        }
        if (score == 20)
        {
            SpawnEnemy.main.Design(2, 3, 5);
        }
    }
    public void btPlay()
    {
        Application.LoadLevel("Cao");
    }
}
