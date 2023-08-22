using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : Enemy
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
        transform.LookAt(player.transform);
        //transform.position = Vector3.Slerp(transform.position, player.transform.position, speed);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public override void attack()
    {
        Vector3 startPos = transform.forward * offset + transform.position + new Vector3(0,1,0);
        Instantiate(effect, startPos, Quaternion.identity);
    }

}
