using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwo : Level
{
    public GameObject stage;
    public GameObject happyEnemy;
    
    void Start()
    {
        base.Start();
        Round1();        
    }

    void Update()
    {
        base.Update();
    }

    public override void Round1()
    {
        GameObject s = Instantiate(stage, new Vector3(0, 1.5f, 0), Quaternion.identity);       

        GameObject h1 = Instantiate(happyEnemy, new Vector3(0, 1, -8) , Quaternion.identity);
        GameObject h2 = Instantiate(happyEnemy, new Vector3(0, 1, 8), Quaternion.identity);
        GameObject h3 = Instantiate(happyEnemy, new Vector3(-8, 1, 0), Quaternion.identity);
        GameObject h4 = Instantiate(happyEnemy, new Vector3(8, 1, 0), Quaternion.identity);

        GameObject h5 = Instantiate(happyEnemy, new Vector3(5.66f, 1, 5.66f), Quaternion.identity);
        GameObject h6 = Instantiate(happyEnemy, new Vector3(5.66f, 1, -5.66f), Quaternion.identity);
        GameObject h7 = Instantiate(happyEnemy, new Vector3(-5.66f, 1, 5.66f), Quaternion.identity);
        GameObject h8 = Instantiate(happyEnemy, new Vector3(-5.66f, 1, -5.66f), Quaternion.identity);

        StartCoroutine(checkRound1(h1, h2, h3, h4, h5, h6,h7,h8));    
    }

    IEnumerator checkRound1(GameObject o1, GameObject o2, GameObject o3, GameObject o4, GameObject o5, GameObject o6, GameObject o7, GameObject o8)
    {
        while (o1 || o2 || o3 || o4 || o5 || o6 || o7 || o8)
        {
            yield return wait;
        }

        nextScene();        
    }        
}
