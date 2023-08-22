using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    public GameObject hackCanvas;
    public GameObject menuCanvas;
    public Animator bgAnimator;
    public Animator hackAnimator;    
    public TMP_Text hackText;
    public WaitForSeconds wait;
    public GameObject speakCanvas;   
    public TMP_Text speakText;

    public GameObject controllCanvas;
    public GameObject rotateCanvas;

    public int turns;
    public float rate;

    void Start()
    {
        wait = new WaitForSeconds(1);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(hackCanvas);
        DontDestroyOnLoad(menuCanvas);
        DontDestroyOnLoad(speakCanvas);

        DontDestroyOnLoad(controllCanvas);
        DontDestroyOnLoad(rotateCanvas);

        GotoNextScene();        
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }        
    }

    public void setSpeakText(string value)
    {
        speakText.text = value;
    }

    public int getTurns()
    {
        return turns;
    }

    public void setTurns(int value)
    {
        turns = value;
    }

    public float getRate()
    {
        return rate;
    }

    public void setRate(float value)
    {
        rate = value;
    }

    void GotoNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(10);
    }

    public void ChangeScene(int index)
    {        
        StartCoroutine(LoadScene(index));            
    }

    IEnumerator LoadScene(int index)
    {
        bgAnimator.SetBool("FadeIn", true);
        bgAnimator.SetBool("FadeOut", false);

        hackAnimator.SetBool("HackIn", true);
        hackAnimator.SetBool("HackOut", false);        

        yield return wait;

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadScene;

    }

    private void OnLoadScene(AsyncOperation async)
    {
        hackAnimator.SetBool("HackIn", false);
        hackAnimator.SetBool("HackOut", true);

        bgAnimator.SetBool("FadeOut", true);
        bgAnimator.SetBool("FadeIn", false);        
    }

    public void QuitGame()
    {
        Application.Quit();        
    }
    
}
