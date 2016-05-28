using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoundEnemy : MonoBehaviour {

    public List<Enemy> listWait;
    public SpawnEnemy spawnEnemy;
    private float timeDestroy = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (timeDestroy > 2)
        {
            DestroyByTime();
            timeDestroy = 0;
        }
        timeDestroy += Time.deltaTime;
	}
    void DestroyByTime()
    {
        if (listWait.Count > 0)
        {
            if (listWait[0] != null)
            {
                Destroy(listWait[0].gameObject);
                listWait.Remove(listWait[0]);
                if(listWait.Count>0)
                {
                    listWait[0].MoveTween(0.9f);
                }
                if(listWait.Count > 1)
                {
                    listWait[1].MoveTween(1.6f);
                }

            }
            ///asadsad
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            Enemy e = col.GetComponent<Enemy>();
            e.speed = Vector3.zero;
            e.transform.SetParent(transform);
            spawnEnemy.RemoveEnemy(e);
            listWait.Add(e);
            if (listWait.Count > 2)
            {
                DestroyByTime();
            }

        }
    }

}
