using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : Enemy
{
    // move properties
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    public float startWaitTime;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        movePos.position = GetRandomPos();
        waitTime = startWaitTime;
        // start attack
        InvokeRepeating("attack", 1.0f, gapTime);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        transform.LookAt(player.transform);
    }

    /**
     * enemy base random move
     */
    public override void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    /**
     * generate random position x,y,z (only used x, z)
     */
    public Vector3 GetRandomPos()
    {
        float x = Random.Range(leftDownPos.position.x, rightUpPos.position.x);
        float z = Random.Range(leftDownPos.position.z, rightUpPos.position.z);
        Vector3 rndPos = new Vector3(x, 0, z);
        return rndPos;
    }

    public override void attack()
    {        
        Vector3 startPos = transform.forward * offset + transform.position + new Vector3(0, 1, 0);
        Instantiate(effect, startPos, transform.rotation);
    }

    public override void takeDamage(int damage)
    {
        flashColor(flashTime);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
