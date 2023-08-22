using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefense : Enemy
{    
    void Start()
    {
        base.Start();
        InvokeRepeating("attack", 1.0f, gapTime);
    }
 
    void Update()
    {
        base.Update();
    }

    public override void move()
    {
        base.move();
        transform.Rotate(0, 360f * Time.deltaTime * 0.1f , 0);
    }

    public override void attack()
    {
        base.attack();

        Vector3 startPX = transform.right * offset + transform.position + new Vector3(0, 1, 0);
        Vector3 startNX = -transform.right * offset + transform.position + new Vector3(0, 1, 0);

        Instantiate(effect, startPX, transform.rotation);
        Instantiate(effect, startNX, transform.rotation);
    }
}
