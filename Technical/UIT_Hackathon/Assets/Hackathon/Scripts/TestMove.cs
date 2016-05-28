using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour 
{
    public Transform myTarget;
    public float latchSpeed;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float distanceToTarget = Vector3.Distance(myTarget.position, transform.position);
        transform.LookAt(myTarget);
        transform.position = Vector3.MoveTowards(transform.position, myTarget.position, Time.deltaTime * latchSpeed);
	}

}
