using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public List<int> listCountEnemy;
    public int countEnemy;
    public float timeOut;
    public float timeIn;
    public float ratioTime;
    public float timeDelaySpawn;
    public int level;
    public float timeSpawn = 0;
    private float timeDelay = 0;
    public List<GameObject> listEnemy;
    public List<Transform> listPosSpawn;
    public List<Enemy> listEnemyCurrent;
    private bool isSpawn = true;
    public static SpawnEnemy main;
    public Transform posEnd;
	// Use this for initialization
	void Start () {
        main = this;
        isSpawn = false;
        ItemPause.ActionOnPause += PauseSpawn;
        ItemPause.ActionOnResumne += ResumneSpawn;
        //DesignLevel.main.Calculogic();
        
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
    IEnumerator  CreateEnemy()
    {
        yield return new WaitForSeconds(timeDelaySpawn);
        int rand = Random.Range(0, listEnemy.Count);

        GameObject enemy = Instantiate(listEnemy[rand], Vector3.zero, Quaternion.identity) as GameObject;
        enemy.transform.SetParent(transform);
        enemy.GetComponent<SpriteRenderer>().sortingOrder = 10000 - listEnemyCurrent.Count;
        // enemy.transform.SetAsLastSibling();
        int randPos = Random.Range(0, listPosSpawn.Count);
        if (randPos == 2)
        {
            Destroy(enemy);
            //enemy.transform.position = listPosSpawn[randPos].position;
            //AddEnemy(enemy.GetComponent<Enemy>());
        }
        else
        {
            int index = Random.Range(0, 10);
            if (index % 2 == 0)
            {
                enemy.transform.position = new Vector3(Random.Range(-2.5f, -1f), transform.position.y, 0);
            }
            else
            {
                enemy.transform.position = new Vector3(Random.Range(1f, 2.5f), transform.position.y, 0);
            }

        }


        Enemy e = enemy.GetComponent<Enemy>();
        if (enemy != null)
        {
            e.isCheat = true;

            AddEnemy(e);
            if (randPos == 2)
            {
                e.speed = new Vector3(0, -4, 0);
            }
            else
            {
                e.speed = new Vector3(0, -Random.Range(2.0f, 4.0f), 0);
            }
        }
    }
    void Spawn()
    {
        if (timeDelay >= timeSpawn)
        {
            //int rand = Random.Range(0, countEnemy);
            //Debug.Log("Count = " + rand);
            //if (rand == 0)
            //{
            //    timeSpawn += timeOut;
            //    timeDelay = 0;
            //    countEnemy ++;
            //    return;
            //}
            //else
            //{
                for (int i = 0; i < countEnemy; i++)
                {
                    StartCoroutine(CreateEnemy());

                    //Invoke("CreateEnemy", timeDelaySpawn);
                }
                countEnemy = Random.Range(min, max);
                timeDelay = 0;
            //}
        }
        timeDelay += Time.deltaTime;
    }
    public int max;
    public int min;
    public void Design(float _timeDelay, int _min, int _max)
    {
        timeSpawn = _timeDelay;
        min = _min;
        max = _max;
    }
    public void AddEnemy(Enemy enemy)
    {
        if(!listEnemyCurrent.Contains(enemy))
        {
            listEnemyCurrent.Add(enemy);
        }
    }
    public void ChangeSpeed()
    {
        for(int i = 0; i<listEnemyCurrent.Count;i++)
        {
            listEnemyCurrent[i].isCheat = false;
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
