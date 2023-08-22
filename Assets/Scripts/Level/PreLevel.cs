using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLevel : MonoBehaviour
{
    public GameObject gameManager;    
    public WaitForSeconds wait;
    public GameObject tip;
    public GameObject player;
    public float dis;    
    
    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");        
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            loadHackScene(index);
        }
        
    }

    public void loadHackScene(int index)
    {        
        gameManager.GetComponent<GameManager>().ChangeScene(index);        
    }

    public void setSpeak(string value)
    {
        gameManager.GetComponent<GameManager>().setSpeakText(value);
    }

 }
