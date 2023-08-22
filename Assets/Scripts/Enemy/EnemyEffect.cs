using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : MonoBehaviour
{
    public float life;
    public int damage;
    public float speed;    

    void Start()
    {        
        Destroy(gameObject, life);        
    }

    void Update()
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
}
