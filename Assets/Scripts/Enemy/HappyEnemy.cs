using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEnemy : Enemy
{
    public bool isHitted;    

    private float originalHealth;
    private WaitForSeconds wait;

    void Start()
    {
        base.Start();
        originalHealth = health;
        wait = new WaitForSeconds(1.0f);
        StartCoroutine(getHitted());
    }
 
    void Update()
    {
        base.Update();        
    }

    // check if get damage from player
    private IEnumerator getHitted()
    {
        while (!isHitted)
        {
            if(health < originalHealth)
            {
                isHitted = true;
                InvokeRepeating("attack", 1.0f, gapTime);
                player.GetComponent<HackPlayer>().isAuto = true;
                yield break;
            }
            else
            {
                yield return wait;
            }
        }
    }

    
    public override void move()
    {
        if (!isHitted)
        {
            transform.RotateAround(new Vector3(0,0,0),Vector3.up,0.1f);
            transform.Rotate(0, 0.1f, 0);
        }
        else
        {
            transform.SetParent(transform);

            transform.LookAt(player.transform);

            transform.position += transform.forward * speed * Time.deltaTime ;
            
        }
    }
    

    public override void attack()
    {        
        Vector3 startPos = transform.forward * offset + transform.position + new Vector3(0,1,0);
        Instantiate(effect, startPos, transform.rotation);
    }
}
