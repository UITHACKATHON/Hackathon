﻿using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Boss : MonoBehaviour {



    public bool isCheat;
    public TypeEnemy type;
    public Vector3 speed;
    public SpriteRenderer txtMesegbox;
    public Transform pos;
    public bool isTouch = false;
    private float timeChangeDir = 0;
    private bool isPause;
    public CircleCollider2D circleCol;
    private int countTap = 5;
    // Use this for initialization
    void Start()
    {
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
    private bool isAddList = false;
    // Update is called once per frame
    void Update()
    {

        if (!isPause && !isTouch)
        {
            Move();
        }
        if (isTouch)
        {
            if (!isAddList)
            {
                if (posTarget == null)
                {
                    posTarget = BoundEnemy.main.GetPosTarget();
                    if (posTarget == pos)
                    {
                        posTarget = BoundEnemy.main.transEnd;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, posTarget.position, 0.1f);
                    //if (posTarget != null)
                    //{
                    if (Vector3.Distance(transform.position, posTarget.position) <= 0.2f)
                    {
                        //Debug.Log("asdsaas");
                        isAddList = true;
                        speed = new Vector3(0, -0.8f, 0);
                        transform.position = posTarget.position;

                    }
                }
                //}
                //Move();
            }
        }
        if (isAddList)
        {
            Move();
        }
    }
    public Transform posTarget;
    public virtual void OnMouseDown()
    {
        if (countTap <= 0)
        {
            if (!isTouch && TouchController.main.isTouch)
            {
                posTarget = BoundEnemy.main.GetPosTarget();
                Test();
                isPause = false;
                TouchController.main.isMiss = false;
                Meseggbox();
                posTarget = BoundEnemy.main.GetPosTarget();
                //BoundEnemy.main.AddListWait(this);
            }
        }
        else
        {
            countTap--;
        }
    }
    public void Test()
    {


        if (circleCol != null)
            circleCol.isTrigger = true;

        isTouch = true;
        //if (GameController.main != null)
        transform.SetParent(GameController.main.boundEnemy.transform);
        //transform.DOLocalMoveX(0, 0.3f, false).OnComplete(() => AddEnemy());
        //MoveTweenPos(BoundEnemy.main.transEnd.localPosition, TimeMove(transform.position, BoundEnemy.main.transform.position));

        GameController.main.UpdateScore(1);


    }
    float TimeMove(Vector3 pos, Vector3 posEnd)
    {
        float distance = Vector3.Distance(posEnd, pos);
        return distance / 2.5f;
    }
    public Vector3 posEnd;
    public virtual void Move()
    {

    }
    public void MoveTweenPos(Vector3 pos, float time)
    {
        //transform.SetParent(GameController.main.boundEnemy.transform);
        transform.DOLocalMove(pos, time, false).OnComplete(() => AddEnemy());
    }
    void AddEnemy()
    {
        //speed = new Vector3(0, -6, 0);
        //SpawnEnemy.main.AddEnemy(this);
        //GameController.main.boundEnemy.AddListWait(this);
        //speed = new vector3(0, -0.8f, 0);
        //isaddlist = true;
    }

    public void MoveTween(float pos)
    {
        transform.DOLocalMoveY(pos, 0.3f, false);
    }
    void Meseggbox()
    {
        if (txtMesegbox != null)
        {
            txtMesegbox.sprite = GameController.main.GetSprite();
            txtMesegbox.gameObject.SetActive(true);
            StartCoroutine(DeMesseggBox());
        }
    }
    IEnumerator DeMesseggBox()
    {
        yield return new WaitForSeconds(0.5f);
        txtMesegbox.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bound")
        {
            speed = Vector3.zero;
        }
    }
}
