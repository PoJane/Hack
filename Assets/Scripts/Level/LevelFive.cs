using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFive : Level
{
    public GameObject cubeEnemy;
    public GameObject cubeDefense;
    public bool isRoundOne;
    public bool isEnd;    

    public GameObject partner;
    public Vector3 offset;
    public GameObject core;
    public int coreHealth;
    public float distance;

    public WaitForSeconds speakWait;

    void Start()
    {
        base.Start();        
        StartCoroutine(waitRoundOne());
        coreHealth = core.GetComponent<DarkDevice>().getHealth();
        speakWait = new WaitForSeconds(5);
        StartCoroutine(endStarter());
        beginRound();
    }

    void Update()
    {
        base.Update();
    }

    void beginRound()
    {
        GameObject e1 = Instantiate(ballEnemy, new Vector3(-30, 2, 0), Quaternion.identity);
        GameObject e2 = Instantiate(ballEnemy, new Vector3(-60, 2, 0), Quaternion.identity);
        GameObject e3 = Instantiate(defenseDevice, new Vector3(-45, 2, 20), Quaternion.identity);

        StartCoroutine(checkBeginRound(e1, e2, e3));
    }

    IEnumerator checkBeginRound(GameObject o1, GameObject o2, GameObject o3)
    {
        while (o1 || o2 || o3)
        {
            yield return wait;
        }

        followCamera.GetComponent<BaseCamera>().setPlayer(false);        

        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Partner") && !isRoundOne)
        {            
            
            followCamera.GetComponent<BaseCamera>().setPlayer(true);

            isRoundOne = true;
        }        
    }   

    IEnumerator waitRoundOne()
    {
        while(!isRoundOne)
        {
            yield return wait;            
        }               

        Round1();

        yield break;
        
    }

    public override void Round1()
    {
        GameObject e1 = Instantiate(normalDevice, new Vector3(-100, 1, 150), Quaternion.identity);
        GameObject e2 = Instantiate(normalDevice, new Vector3(-90, 1, 150), Quaternion.identity);

        GameObject e3 = Instantiate(defenseDevice, new Vector3(-100, 1, 120), Quaternion.identity);
        GameObject e4 = Instantiate(defenseDevice, new Vector3(-90, 1, 120), Quaternion.identity);

        StartCoroutine(checkRound1(e1, e2, e3, e4));
    }

    IEnumerator checkRound1(GameObject o1, GameObject o2, GameObject o3, GameObject o4)
    {
        while (o1 || o2 || o3 || o4)
        {
            yield return wait;
        }

        followCamera.GetComponent<BaseCamera>().setPlayer(false);

        Round2();

        yield break;
    }

    public override void Round2()
    {
        GameObject e1 = Instantiate(normalDevice, new Vector3(90, 1, 150), Quaternion.identity);
        GameObject e2 = Instantiate(normalDevice, new Vector3(90, 1, 100), Quaternion.identity);

        StartCoroutine(checkRound2(e1, e2));
    }

    IEnumerator checkRound2(GameObject o1, GameObject o2)
    {
        while (o1 || o2)
        {
            yield return wait;
        }

        followCamera.GetComponent<BaseCamera>().setPlayer(true);

        StartCoroutine(waitSpeak());

        yield break;
    }    

    IEnumerator endStarter()
    {
        while (core)
        {
            yield return wait;
        }

        endRound();

        yield break;
    }

    IEnumerator waitSpeak()
    {
        setSpeak("2B is already dead.");

        yield return speakWait;

        setSpeak("This result is set by the program.");        

        yield return speakWait;

        setSpeak("If you want to change the ending");

        yield return speakWait;

        setSpeak("Make a choice, and let me see what you know.");

        yield return speakWait;

        setSpeak(" ");

        yield break;
    }

    public void endRound()
    {


        partner.transform.position = player.transform.position - offset;
        Quaternion.LookRotation(partner.transform.position, player.transform.position);

        GameObject e1 = Instantiate(cubeEnemy, new Vector3(20, 4, 300), Quaternion.identity);
        GameObject e2 = Instantiate(cubeEnemy, new Vector3(-20, 4, 300), Quaternion.identity);

        GameObject e3 = Instantiate(defenseDevice, new Vector3(40, 2, 280), Quaternion.identity);
        GameObject e4 = Instantiate(defenseDevice, new Vector3(-40, 2, 280), Quaternion.identity);

        StartCoroutine(checkEndRound(e1, e2, e3, e4));
    }

    IEnumerator checkEndRound(GameObject o1, GameObject o2, GameObject o3, GameObject o4)
    {

        while (o1 || o2 || o3 || o4)
        {
            partner.GetComponent<Player>().autoAttack();
            yield return wait;
        }        

        nextScene();
    }   
    
}
