using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDefense : Enemy
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        InvokeRepeating("attack", 1.0f, gapTime);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void move()
    {
        Quaternion dir = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, dir, rotateSpeed);
        transform.position = Vector3.Slerp(transform.position, player.transform.position, speed * Time.deltaTime);        
    }

    public override void attack()
    {
        Vector3 startPos = transform.forward * offset + transform.position + new Vector3(0, 1f, 0);
        Instantiate(effect, startPos, transform.rotation);
    }
}
