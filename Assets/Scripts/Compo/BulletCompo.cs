using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCompo : BaseCompo
{   
    public void Start()
    {
        base.Start();       
    }

    public void Update()
    {
        base.Update();        
    }

    public override void move()
    {
        base.move();
        // move to self z direction
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);     
    }
}
