using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFour : Level
{
    public GameObject titan;
    public GameObject darkCube;
    public GameObject cubeEnemy;
    public GameObject shield;

    public GameObject s;

    void Start()
    {
        base.Start();        
        Round1();
        s = Instantiate(shield, titan.transform.position, Quaternion.identity);
        StartCoroutine(checkTitan());
    }
    
    void Update()
    {
        base.Update();

    }

    public override void Round1()
    {
        GameObject d1 = Instantiate(darkCube, new Vector3(0, 5, -9),Quaternion.identity);
        GameObject d2 = Instantiate(darkCube, new Vector3(6, 5, -9), Quaternion.identity);
        GameObject d3 = Instantiate(darkCube, new Vector3(-6, 5, -9), Quaternion.identity);
        
        StartCoroutine(checkRound1(d1, d2, d3));
    }

    IEnumerator checkRound1(GameObject o1, GameObject o2, GameObject o3)
    {
        while (o1 || o2 || o3)
        {
            yield return wait;
        }

        yield return wait;

        Round2();

        yield break;
    }

    public override void Round2()
    {
        

        GameObject d1 = Instantiate(cubeEnemy, new Vector3(40,4,-12), Quaternion.identity);
        GameObject d2 = Instantiate(cubeEnemy, new Vector3(-40, 4, -12), Quaternion.identity);
        GameObject d3 = Instantiate(cubeEnemy, new Vector3(50, 4, -12), Quaternion.identity);
        GameObject d4 = Instantiate(cubeEnemy, new Vector3(-50, 4, -12), Quaternion.identity);

        StartCoroutine(CheckRound2(d1, d2, d3, d4, s));
    }

    IEnumerator CheckRound2(GameObject n1, GameObject n2, GameObject n3, GameObject n4, GameObject s)
    {
        while (n1 || n2 || n3 || n4)
        {
            yield return wait;
        }

        Destroy(s);        

        yield break;

    }

    IEnumerator checkTitan()
    {
        while (titan)
        {
            yield return wait;
        }

        nextScene();
    }
}
