using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
public class Danger : MonoBehaviour {

    public static Danger main;
    public Animator anim;
    public Image imageDanger;
    public List<GameObject> listEnemy;
	// Use this for initialization
	void Start () {
        main = this;
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void StartDanger()
    {
        anim.SetBool("isDanger", true);
    }
    public void EndDanger()
    {
        anim.SetBool("isDanger", false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            if(!listEnemy.Contains(col.gameObject))
            {
                listEnemy.Add(col.gameObject);
                if(listEnemy.Count > 10)
                {
                    GameController.main.GameOver();
                }
            }
        }
    }
}
