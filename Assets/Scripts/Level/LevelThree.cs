using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelThree : Level
{
    public GameObject bova;
    public GameObject shield;        

    void Start()
    {
        base.Start();
        
        Round1();

        StartCoroutine(checkBova());

        bova = GameObject.Find("Bova");
    }

    
    void Update()
    {
        
    }

    public override void Round1()
    {        
        GameObject b1 = Instantiate(ballEnemy, new Vector3(30, 0, -30), Quaternion.identity);
        GameObject b2 = Instantiate(ballEnemy, new Vector3(-30, 0, -30), Quaternion.identity);

        StartCoroutine(CheckRound1(b1, b2));
    }
    

    IEnumerator CheckRound1(GameObject b1,GameObject b2)
    {
        while(b1 || b2)
        {
            yield return wait;
        }

        Round2();
        
        yield break;
    }
    
    public override void Round2()
    {
        GameObject s = Instantiate(shield, bova.transform);

        s.transform.SetParent(bova.transform);

        // change camera vision
        followCamera.GetComponent<BaseCamera>().slideToUp();

        // new enemy
        GameObject n1 = Instantiate(defenseDevice, new Vector3(50, 0, 50), Quaternion.identity);
        GameObject n2 = Instantiate(defenseDevice, new Vector3(50, 0, -50), Quaternion.identity);
        GameObject n3 = Instantiate(defenseDevice, new Vector3(-50, 0, 50), Quaternion.identity);
        GameObject n4 = Instantiate(defenseDevice, new Vector3(-50, 0, -50), Quaternion.identity);

        StartCoroutine(CheckRound2(n1, n2, n3, n4, s));
    }

    IEnumerator CheckRound2(GameObject n1, GameObject n2, GameObject n3, GameObject n4,GameObject s)
    {
        while (n1||n2||n3||n4)
        {
            yield return wait;
        }

        Destroy(s);

        Round3();

        yield break;

    }

    void Round3()
    {        
        //followCamera.GetComponent<BaseCamera>().follow();
        bova.GetComponent<BovaEnemy>().move2();
    }

    IEnumerator checkBova()
    {
        while (bova)
        {
            yield return wait;
        }

        nextScene();
    }
}
