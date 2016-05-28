using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
public enum TypeEnemy
{
    NONE = 0,
    WALK = 1,
    RUN = 2,

}
public class Enemy : MonoBehaviour {

    public TypeEnemy type;
    public Vector3 speed;
    public GameObject txtMesegbox;
    private bool isTouch = false;
    private float timeChangeDir = 0;
    private bool isPause;
	// Use this for initialization
	void Start () {
        ItemPause.ActionOnPause += Pause;
        ItemPause.ActionOnResumne += Resumne;
	}
	void Pause()
    {
        isPause = true;
    }
    void Resumne()
    {
        isPause = false;
    }
	// Update is called once per frame
	void Update () {

        if (!isPause)
        {
            Move();
        }
	}

    public virtual void OnMouseDown()
    {
        if (!isTouch && TouchController.main.isTouch)
        {
            isPause = false;
            TouchController.main.isMiss = false;
            Meseggbox();
            isTouch = true;
            
            transform.DOLocalMoveX(0, 0.3f, false).OnComplete(() => AddEnemy());
            GameController.main.UpdateScore(1);
        }
    }
    public virtual void Move()
    {
        
    }
    void AddEnemy()
    {
        speed = new Vector3(0, -6, 0);
        SpawnEnemy.main.AddEnemy(this);
    }
    public void MoveTween(float pos)
    {
        transform.DOLocalMoveY(pos, 0.3f, false);
    }
    void Meseggbox()
    {
        
        txtMesegbox.SetActive(true);
        StartCoroutine(DeMesseggBox());
    }
    IEnumerator DeMesseggBox()
    {
        yield return new WaitForSeconds(0.3f);
        txtMesegbox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bound")
        {
            GameController.main.UpdateLive(-1);
            Destroy(gameObject);
        }
    }
}
