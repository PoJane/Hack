using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public GameObject ballEnemy;
    public GameObject normalDevice;
    public GameObject defenseDevice;
    public GameObject specialEnemy;
    public GameObject player;
    public GameObject followCamera;
    public GameObject gameManager;
    public WaitForSeconds wait;

    public int round;
    public delegate void startRound();

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");        
        wait = new WaitForSeconds(1);
        StartCoroutine(checkHealth());
    }

    public void Update()
    {        
    }

    public IEnumerator checkHealth()
    {        
        while(player.GetComponent<Player>().getHealth()> 0)
        {
            yield return wait;
        }

        lose();
        
        yield break;
       
    }

    public virtual void Round1()
    {
        
    }

    public virtual void Round2()
    {

    }   

    public void lose()
    {
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        gameManager.GetComponent<GameManager>().ChangeScene(index);
    }

    public void nextScene()
    {
        if (gameManager)
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            gameManager.GetComponent<GameManager>().ChangeScene(index);
        }
    }

    public void setSpeak(string value)
    {
        gameManager.GetComponent<GameManager>().setSpeakText(value);
    }
}
