using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCamera : MonoBehaviour
{
    // follow target
    public Vector3 target;
    public Quaternion targetRotate;
    public GameObject player;
    public GameObject other;
    public bool isPlayer;

    // follow diff
    public Vector3 diffPos;

    // camera up
    public Quaternion DOWN;
    public Quaternion oriRotate;
    public Vector3 upPos;
    public Vector3 upDiff;

    // lerp interpolation
    public float smooth;

    public float slideSpeed;

    private Vector3 originalDiff;

    public Transform UP;

    public bool isFollow;
    
    public void Start()
    {
        isFollow = true;
        originalDiff = diffPos;
        DOWN = Quaternion.Euler(new Vector3(90,0, 0));
        oriRotate = transform.rotation;        
    }

    public void Update()
    {
        if (isFollow)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            target = player.transform.position;
            UP = player.transform.Find("Up").transform;
        }       
    }

    public virtual void setPlayer(bool value)
    {        
    }
    
    public void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPos = target - diffPos;

            if (transform.position != targetPos)
            {                
                transform.position = Vector3.Lerp(transform.position, targetPos, smooth);                
            }
                             
        }
    }

    //camera change to z'
    public void slideToUp()
    {
        isFollow = false;

        diffPos = upDiff;       
        
        transform.position = Vector3.Lerp(transform.position, upPos, slideSpeed);                

        while (transform.rotation != DOWN)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, DOWN, slideSpeed);
        }     
    }

    /**
     * camera back to 
     * after player
     */
    public void follow()
    {
        isFollow = true;
        diffPos = originalDiff;
        Vector3 targetPos = target + diffPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, slideSpeed);
        while (transform.rotation != oriRotate)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, oriRotate, slideSpeed);
        }
    }
}
