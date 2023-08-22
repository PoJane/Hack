using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCompo : MonoBehaviour
{
    public float speed;
    public float life;
    public int damage;

    // Start is called before the first frame update
    public void Start()
    {
        Destroy(gameObject, life);        
    }

    public void Update()
    {
        move();
    }

    public virtual void move()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.CompareTag("Enemy"))
        {            
            other.GetComponent<Enemy>().takeDamage(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Shield"))
        {
            other.GetComponent<Shield>().takeDamage(damage);
            Destroy(gameObject);
        }
    }

}
