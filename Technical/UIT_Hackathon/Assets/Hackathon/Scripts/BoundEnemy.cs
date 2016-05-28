using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoundEnemy : MonoBehaviour {

    public float speedMove;
    public List<Enemy> listWait;
    public SpawnEnemy spawnEnemy;
    private float timeDestroy = 0;
    public BoxCollider2D box;
    public Transform transEnd;// = Vector3.zero;

    public static BoundEnemy main;
    
	// Use this for initialization
	void Start () {
        main = this;
        transEnd.localPosition = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
        if (listWait.Count > 0)
        {
            //transEnd.localPosition = new Vector3(0, listWait[listWait.Count - 1].transform.localPosition.y + 0.2f, 0);
            //transEnd.localPosition = listWait[listWait.Count - 1].pos.localPosition;
        }
        if(listWait.Count <= 0)
        {
            //transEnd.localPosition = Vector3.zero;
        }

	}
    public Transform GetPosTarget()
    {
        if(listWait.Count > 0)
        {
            return listWait[listWait.Count - 1].pos;
        }
        return transEnd;
    }
    public void AddListWait(Enemy enemy)
    {
        if(!listWait.Contains(enemy))
        {
            listWait.Add(enemy);
            BoxSlow.main.SetLenghtBox(listWait.Count);
            if (listWait.Count > 12)
            {
                GameController.main.GameOver();
            }
            if(listWait.Count> 8)
            {
                Danger.main.StartDanger();
            }
            else
            {
                Danger.main.EndDanger();
            }

        }
    }
    public void ChangeSpeedEnemy(float _speed)
    {
        for (int i = 0; i < listWait.Count; i++)
        {
            listWait[i].speed = new Vector3(0, _speed, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemy e = col.GetComponent<Enemy>();
            Destroy(e.gameObject);
            listWait.Remove(e);
            BoxSlow.main.SetLenghtBox(listWait.Count);
            //BoxSlow.main.SetLenghtBox()
            //e.speed.y = speedMove;
            //e.transform.SetParent(transform);
            //spawnEnemy.RemoveEnemy(e);
            //listWait.Add(e);
            //transEnd = listPos[listWait.Count + 1];
        }
    }
    void ChangeSpeedEnemy()
    {
        for(int i =0 ;i<listWait.Count - 1; i++)
        {
            for (int j = i + 1; j < listWait.Count; j++)
            {
                if(Vector3.Distance(listWait[j].transform.localPosition, listWait[i].transform.localPosition) < 0.7f)
                {
                    listWait[j].speed = new Vector3(0, -0.5f, 0);
                }
                //if (Vector3.Distance(listWait[i].transform.localPosition, listWait[i].transform.localPosition) > 1.1f)
                //{
                //    listWait[j].speed = new Vector3(0, -1.2f, 0);
                //}
                //else
                //{
                //    listWait[i].speed = new Vector3(0, -0.8f, 0);
                //}
            }
        }
    }
}
