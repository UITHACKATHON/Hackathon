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
    public CircleCollider2D circleCol;
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

        if (!isPause && !isTouch)
        {
            Move();
        }
        if(isTouch)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, GameController.main.boundEnemy.getPosEnd(), 0.1f);
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
            transform.SetParent(GameController.main.boundEnemy.transform);
            //transform.DOLocalMoveX(0, 0.3f, false).OnComplete(() => AddEnemy());
            //MoveTweenPos(GameController.main.boundEnemy.SetPosEnd());
            GameController.main.UpdateScore(1);
        }
    }
    public Vector3 posEnd;
    public virtual void Move()
    {
        
    }
    public void MoveTweenPos(Vector3 pos)
    {
        transform.SetParent(GameController.main.boundEnemy.transform);
        transform.DOLocalMove(pos, 1.0f, false).OnComplete(() => AddEnemy());
    }
    void AddEnemy()
    {
        //speed = new Vector3(0, -6, 0);
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
            speed = Vector3.zero;
        }
    }
}
