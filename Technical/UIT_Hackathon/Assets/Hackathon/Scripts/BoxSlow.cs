using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxSlow : MonoBehaviour {

    public static BoxSlow main;
    public int countBox;
    public List<Enemy> listEnemy;
    public BoxCollider2D box;
	// Use this for initialization
	void Start () {
        main = this;
	}
	
	// Update is called once per frame
	void Update () {
        RemoveList();
        if(listEnemy.Count == 0)
        {
            BoundEnemy.main.ChangeSpeedEnemy(-0.8f);
        }
        //if (listEnemy.Count == 1)
        //{
        //    //BoundEnemy.main.AddListWait(listEnemy[0]);
        //    if (listEnemy[0].isCheat == true)
        //        listEnemy[0].OnMouseDown();
        //    //SpawnEnemy.main.ChangeSpeed();
        //}
        
	}
    void RemoveList()
    {
        for(int i =0 ;i <listEnemy.Count;i++)
        {
            if(listEnemy[i].isTouch == true)
            {
                listEnemy.Remove(listEnemy[i]);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Enemy e = col.gameObject.GetComponent<Enemy>();
            if (e.isCheat == true && countBox <= 2)
            {
                countBox++;
                //e.OnMouseDown();
                e.Test();
            }
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            if (!listEnemy.Contains(col.gameObject.GetComponent<Enemy>()))
            {
                col.gameObject.GetComponent<Enemy>().isCheat = false;
                listEnemy.Add(col.gameObject.GetComponent<Enemy>());
                

            }
            if(BoundEnemy.main.listWait.Count >= 3)
            {
                BoundEnemy.main.ChangeSpeedEnemy(0);
            }
            else
            {
                
                for(int i = 0; i<listEnemy.Count;i++)
                {
                    if(listEnemy[i].isCheat)// = Vector3.zero;
                    {
                        listEnemy[i].OnMouseDown();
                    }
                }
            }
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Enemy")
        {
            if (BoundEnemy.main.listWait.Count >= 4)
            {
                BoundEnemy.main.ChangeSpeedEnemy(0.8f);
            }
        }
    }
}
