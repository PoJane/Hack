using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E1 : PreLevel
{

    private void Start()
    {        
        base.Start();
        wait = new WaitForSeconds(3);
        tip = transform.Find("tip").gameObject;
        StartCoroutine(waitSpeak());
    }

    private void Update()
    {
        base.Update();
    }

    IEnumerator waitSpeak()
    {
        yield return wait;

        setSpeak("2B...... Where is she?");

        yield return wait;

        setSpeak("Must find her......");

        yield return wait;

        setSpeak(" ");

        yield break;
    }

}
