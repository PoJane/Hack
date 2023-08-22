using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEffect : Enemy
{    
    public float life;
    public int damage;    

    // Start is called before the first frame update
    public void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
        Destroy(gameObject, life);
    }

    public void Update()
    {
        
        move();
    }

    public virtual void move()
    {              
        transform.position += transform.forward * speed * Time.deltaTime;        
    }

    public void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().takeDamage(damage);
            Destroy(gameObject);
        }
    }

    public override void takeDamage(int damage)
    {        
        Destroy(gameObject);
    }
}
