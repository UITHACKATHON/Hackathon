using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoundEnemy : MonoBehaviour {

    public List<Enemy> listWait;
    public SpawnEnemy spawnEnemy;
    private float timeDestroy = 0;
    public BoxCollider2D box;
    private Vector3 transEnd = Vector3.zero;

    public List<Transform> listPos;
    
    
	// Use this for initialization
	void Start () {
	
	}
	public Vector3 getPosEnd()
    {
        
        return transEnd;

    }
	// Update is called once per frame
	void Update () {
        if (timeDestroy > 2)
        {
            //DestroyByTime();
            timeDestroy = 0;
        }
        timeDestroy += Time.deltaTime;
	}
    public void AddListWait(Enemy enemy)
    {
        if(!listWait.Contains(enemy))
        {
            listWait.Add(enemy);
        }
    }
    void DestroyByTime()
    {
        //if (listWait.Count > 0)
        //{
        //    if (listWait[0] != null)
        //    {
        //        Destroy(listWait[0].gameObject);
        //        listWait.Remove(listWait[0]);
        //        if(listWait.Count>0)
        //        {
        //            listWait[0].MoveTween(0.9f);
        //        }
        //        if(listWait.Count > 1)
        //        {
        //            listWait[1].MoveTween(1.6f);
        //        }

        //    }
        //    ///asadsad
        //}
        if(listWait.Count > 2)
        {
            
            for(int i = 1;i<listWait.Count;i++)
            {
                listWait[i].MoveTween(listWait[i - 1].transform.localPosition.y);
            }
            Destroy(listWait[0].gameObject);
            listWait.Remove(listWait[0]);
            transEnd = listPos[SpawnEnemy.main.listEnemyCurrent.Count + 1].localPosition;
            return;
        }
        if (listWait.Count > 0)
        {
            if (listWait[0] != null)
            {
                Destroy(listWait[0].gameObject);
                listWait.Remove(listWait[0]);
                if (listWait.Count > 0)
                {
                    listWait[0].MoveTween(0.9f);
                }
                if (listWait.Count > 1)
                {
                    listWait[1].MoveTween(1.6f);
                }
            }
            transEnd = listPos[SpawnEnemy.main.listEnemyCurrent.Count + 1].localPosition;
            return;
        }
        
    }
    public Vector3 SetPosEnd()
    {
        if(listWait.Count > 4)
        {
            return listPos[4].localPosition;
        }
        else
        {
            if(listWait.Count  == 0)
            {
                return listPos[0].localPosition;
            }
            if (listWait.Count == 1)
            {
                return listPos[1].localPosition;
            }
            if (listWait.Count == 2)
            {
                return listPos[2].localPosition;
            }
            if (listWait.Count == 3)
            {
                return listPos[3].localPosition;
            }
            if (listWait.Count == 4)
            {
                return listPos[4].localPosition;
            }
        }
        return Vector3.zero;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //if(col.tag == "Enemy")
        //{
        //    Enemy e = col.GetComponent<Enemy>();
        //    e.speed = Vector3.zero;
        //    e.transform.SetParent(transform);
        //    spawnEnemy.RemoveEnemy(e);
        //    listWait.Add(e);
        //    transEnd = listPos[listWait.Count + 1];
        //}
    }

}
