using UnityEngine;
using System.Collections;
public enum TypeEnemy
{
    NONE = 0,
    WALK = 1,
    RUN = 2,

}
public class Enemy : MonoBehaviour {

    public Vector3 speed;
    private bool isMove = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isMove == false)
            Move();
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -5, 0), -speed.y * Time.deltaTime);
        }
	}

    void OnMouseDown()
    {
        isMove = true;
    }
    void Move()
    {
        transform.position += speed * Time.deltaTime;
    }
}
