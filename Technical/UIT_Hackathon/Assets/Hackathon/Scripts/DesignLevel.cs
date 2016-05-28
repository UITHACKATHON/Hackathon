using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DesignLevel : MonoBehaviour {

    public static DesignLevel main;

    public float timeOut;
    public float timeIn;
    public float ratioTime;
    public float timeDelay;
    public int countEnemy;

	// Use this for initialization
	void Start () {
        main = this;
	}

	
	// Update is called once per frame
	void Update () {
	
	}

    public void Calculogic()
    {
        timeIn = timeOut * ratioTime;
        int rand = Random.Range(1, 7);
        if(rand != 1)
        {
            timeDelay += timeOut;
        }
        countEnemy = rand;
    }
}
