using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDevice : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Weapon") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.CompareTag("Weapon") || other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
