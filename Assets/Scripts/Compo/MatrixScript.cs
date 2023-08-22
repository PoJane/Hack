using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Partner"))
        {
            Debug.Log("Player Enter!");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Partner"))
        {
            Debug.Log("Player Exit!");
        }
    }
}
