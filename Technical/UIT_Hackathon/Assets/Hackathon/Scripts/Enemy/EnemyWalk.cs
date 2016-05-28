using UnityEngine;
using System.Collections;

public class EnemyWalk : Enemy {


    public override void Move()
    {
        base.Move();
        transform.position += speed * Time.deltaTime;
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }

}
