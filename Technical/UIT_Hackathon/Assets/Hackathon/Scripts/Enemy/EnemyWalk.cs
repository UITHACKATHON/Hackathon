using UnityEngine;
using System.Collections;

public class EnemyWalk : Enemy {

    private bool isBla = false;
    public override void Move()
    {
        base.Move();
        if (isCheat == false)
        {
            transform.position += speed * Time.deltaTime;
        }
        else
        {
            if (isBla == false)
            {
                float a = speed.y * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, BoundEnemy.main.transEnd.position, -a);
                if(Vector3.Distance(transform.position, BoundEnemy.main.transEnd.position) < 0.1f)
                {
                    isBla = true;
                }
            }
            else
            {
                transform.position += speed * Time.deltaTime;
            }
        }
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }

}
