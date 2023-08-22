using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlayer : HackPlayer
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        followCamera = GameObject.FindGameObjectWithTag("FollowCamera");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void move()
    {
        float hDir = Input.GetAxis("Horizontal");   // horizantal direction
        float vDir = Input.GetAxis("Vertical");     // vertical direction
        // player velocity
        Vector3 dir = new Vector3(hDir, 0, vDir);
        transform.position += dir * speed * Time.deltaTime;

        
    }
}
