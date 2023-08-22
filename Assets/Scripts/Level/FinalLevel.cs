using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    public GameObject finalEnemy;
    public GameObject player;
    public Transform RightUp;
    public Transform LeftDown;
    public Vector3[] positions;
    public GameObject partner;
    public GameObject gameManager;
    public WaitForSeconds wait;    
    

    void Start()
    {        
        player = Instantiate(player, new Vector3(0, 1, 0), Quaternion.identity);

        gameManager = GameObject.FindGameObjectWithTag("GameController");

        wait = new WaitForSeconds(1);
        
        positions = new Vector3[]
        {
            new Vector3(5,1,-1),
            new Vector3(-5,1,-1),
            new Vector3(-3,1,7),
            new Vector3(3,1,7),
            new Vector3(3,1,-8),
            new Vector3(-3,1,-8)
        };

        if (gameManager)
        {
            float repeatRate = gameManager.GetComponent<GameManager>().getRate();

            if(repeatRate < 0.2f)
            {
                repeatRate = 0.2f;
            }

            InvokeRepeating("createEnemy", 1.0f, repeatRate);

            Debug.Log("Repeat Rate: " + repeatRate);

            gameManager.GetComponent<GameManager>().setRate(repeatRate - 0.1f);

            int turns = gameManager.GetComponent<GameManager>().getTurns();

            Debug.Log("TURNS :" + turns);

            if (turns > 5)
            {
                turns = 5;
            }

            for (int i = 0; i <= turns; i++)
            {
                createPartner(i);
            }
            
            if (turns == 5)
            {
                StartCoroutine(checkEnd());
            }
        }
        
    }

    IEnumerator checkEnd()
    {
        int i = 1;
        while (i < 30)
        {
            i++;
            yield return wait;
            Debug.Log("WAIT: " + i);
        }

        End();

        yield break;
    }

    void End()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        gameManager.GetComponent<GameManager>().ChangeScene(index);
    }
 
    void Update()
    {
        watchPlayer();
    }

    void watchPlayer()
    {
        if(player.GetComponent<Player>().getHealth() <= 0)
        {
            reloasScene();
        }
    }

    void createPartner(int turns)
    {
        Instantiate(partner, positions[turns], Quaternion.identity);
    }

    void reloasScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        int turns = gameManager.GetComponent<GameManager>().getTurns();
        gameManager.GetComponent<GameManager>().setTurns(turns + 1);
    }

    void createEnemy()
    {
        Vector3 pos = GetRandomPos();
        Instantiate(finalEnemy, pos, Quaternion.identity);
    }

    public Vector3 GetRandomPos()
    {
        float x = Random.Range(LeftDown.position.x, RightUp.position.x);
        float z = Random.Range(LeftDown.position.z, RightUp.position.z);
        Vector3 rndPos = new Vector3(x, 0, z);
        return rndPos;
    }
}
