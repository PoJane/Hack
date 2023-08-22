using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : Level
{    

    void Start()
    {
        base.Start();        
        Round1();       
    }  

    public override void Round1()
    {
        base.Round1();        
        GameObject e1 = Instantiate(ballEnemy, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject e2 = Instantiate(normalDevice, new Vector3(-30, 0, -20), Quaternion.identity);
        GameObject e3 = Instantiate(normalDevice, new Vector3(30, 0, -20), Quaternion.identity);
        StartCoroutine(checkRound1(e1, e2, e3));
    }

    IEnumerator checkRound1(GameObject o1,GameObject o2,GameObject o3)
    {
        while(o1 || o2 || o3)
        {            
            yield return wait;
        }
        
        Round2();

        yield break;        
    }
   

    public override void Round2()
    {
        base.Round2();
        GameObject e1 = Instantiate(ballEnemy, new Vector3(0, 0, 30), Quaternion.identity);
        GameObject e2 = Instantiate(defenseDevice, new Vector3(-30, 0, 0), Quaternion.identity);
        GameObject e3 = Instantiate(defenseDevice, new Vector3(30, 0, 0), Quaternion.identity);
        StartCoroutine(checkEnd(e1, e2, e3));
    }

    IEnumerator checkEnd(GameObject o1, GameObject o2, GameObject o3)
    {
        while (o1 || o2 || o3)
        {
            yield return wait;
        }
        
        nextScene();

        yield break;
    }
    
}
