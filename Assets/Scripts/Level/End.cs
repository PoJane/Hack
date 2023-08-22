using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class End : MonoBehaviour
{
    public WaitForSeconds wait;    
    public TMP_Text endText;

    void Start()
    {
       wait = new WaitForSeconds(5);

        StartCoroutine(waitEnd());
    }

    IEnumerator waitEnd()
    {
        yield return wait;

        endText.text = "[ The End ]";
        
        yield break;
    }
}
