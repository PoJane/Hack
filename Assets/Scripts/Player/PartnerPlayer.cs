using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerPlayer : HackPlayer
{ 

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.SetParent(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(player.transform.forward);        
        attack();
    }

    public override void takeDamage(int damage)
    {
        
    }

    public override void attack()
    {
        // left shift or left mouse to attack
        if (Input.GetMouseButtonDown(0))
        {            
            CancelInvoke("inst");
            inst();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            InvokeRepeating("inst", 0.1f, 0.1f);           
        }
    }
}
