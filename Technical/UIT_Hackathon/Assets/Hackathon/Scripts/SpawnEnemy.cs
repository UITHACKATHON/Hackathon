using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public int level;
    public float timeSpawn = 0;
    private float timeDelay = 0;
    public List<GameObject> listEnemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Spawn();
	}
    void Spawn()
    {
        if (timeDelay >= timeSpawn)
        {
            int rand = Random.Range(0, listEnemy.Count);
            GameObject enemy = Instantiate(listEnemy[rand], Vector3.zero, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(transform);
            Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, 0);
            enemy.transform.localPosition = pos;
            Enemy e = enemy.GetComponent<Enemy>();
            if (enemy != null)
            {
                e.speed = new Vector3(0, -Random.Range(2.0f, 6.0f), 0);
            }
            timeDelay = 0;
        }
        timeDelay += Time.deltaTime;
    }
}
