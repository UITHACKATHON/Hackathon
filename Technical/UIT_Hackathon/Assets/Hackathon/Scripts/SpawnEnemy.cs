using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public int level;
    public float timeSpawn = 0;
    private float timeDelay = 0;
    public List<GameObject> listEnemy;
    public List<Transform> listPosSpawn;
    public List<Enemy> listEnemyCurrent;
    private bool isSpawn = true;
    public static SpawnEnemy main;
	// Use this for initialization
	void Start () {
        main = this;
        ItemPause.ActionOnPause += PauseSpawn;
        ItemPause.ActionOnResumne += ResumneSpawn;
	}
	void PauseSpawn()
    {
        isSpawn = false;
    }
    void ResumneSpawn()
    {
        isSpawn = true;
    }
	// Update is called once per frame
	void Update () {
        if (isSpawn)
            Spawn();
	}
    void Spawn()
    {
        if (timeDelay >= timeSpawn)
        {
            int rand = Random.Range(0, listEnemy.Count);
            GameObject enemy = Instantiate(listEnemy[rand], Vector3.zero, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(transform);
            int randPos = Random.Range(0, listPosSpawn.Count);
            if (randPos == 2)
            {
                AddEnemy(enemy.GetComponent<Enemy>());
              
            }
            enemy.transform.position = listPosSpawn[randPos].position;
            Enemy e = enemy.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (randPos == 2)
                {
                    e.speed = new Vector3(0, -4, 0);
                }
                else
                {
                    e.speed = new Vector3(0, -Random.Range(2.0f, 4.0f), 0);
                }
            }

            timeDelay = 0;
        }
        timeDelay += Time.deltaTime;
    }
    public void AddEnemy(Enemy enemy)
    {
        if(!listEnemyCurrent.Contains(enemy))
        {
            listEnemyCurrent.Add(enemy);
        }
    }
    public void RemoveEnemy(Enemy enemy)
    {
        if(listEnemyCurrent.Contains(enemy))
        {
            listEnemyCurrent.Remove(enemy);
        }
    }
}
