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
	    if(timeDestroy > 2)
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
            Destroy(listWait[0].gameObject);
            listWait.Remove(listWait[0]);
            listWait[0].MoveTween(0.805f);
            listWait[1].MoveTween(1.5f);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            spawnEnemy.RemoveEnemy(col.GetComponent<Enemy>());
        }
    }

}
