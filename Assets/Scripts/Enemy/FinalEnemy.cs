using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalEnemy : Enemy
{

    public Transform RightUp;    
    public Transform LeftDown;
    public Vector3 movePos;
    public float life;

    public float startWaitTime;
    public float waitTime;
    public int damage;

    public string[] names;
    public TMP_Text enemyName;

    void Start()
    {
        movePos = GetRandomPos();
        waitTime = startWaitTime;
        Destroy(gameObject, life);

        names = new string[]
        {
            "Ling Yudie","Liu Xinyi","Director","Art Designer","ScriptWriter","Programmer","Plan","Interface Designer",
            "Music Director","Sound Designer","Project Leader","2D Designer","3D Designer","Blender Modeler","Level Desinger",
            "Enemy Designer","Player Designer","Source Manager","Data Designer","Camera Designer","Game Effect","Animator"
        };

        int i = getRandomNamesIndex();
        enemyName.text = names[i];
    }

    int getRandomNamesIndex()
    {
        int index = Random.Range(0, names.Length);
        return index;
    }
    
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        move();
    }
    
    public override void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePos, speed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, movePos, speed);

        if (Vector3.Distance(transform.position, movePos) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public Vector3 GetRandomPos()
    {
        int r = Random.Range(0, 2);
        Vector3 rndPos;
        if(r == 1)
        {
            float x = Random.Range(LeftDown.position.x, RightUp.position.x);
            float z = RightUp.position.z;
            rndPos = new Vector3(x, 0, z);
        }
        else
        {
            float x = Random.Range(LeftDown.position.x, RightUp.position.x);
            float z = LeftDown.position.z;
            rndPos = new Vector3(x, 0, z);
        }

        return rndPos;
    }

    public override void takeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Partner"))
        {
            other.GetComponent<Player>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
