using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDevice : MonoBehaviour
{
    public int health;

    public MeshRenderer renderer;
    public Color originalColor;

    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        originalColor = renderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {     

        if (other.gameObject.CompareTag("Weapon"))
        {
            takeDamage();
            Destroy(other.gameObject);
        }
    }

    void takeDamage()
    {
        flashColor(0.1f);

        health -= 1;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getHealth()
    {
        return health;
    }

    /**
     * enemy flash material when get hurt
     */
    public virtual void flashColor(float time)
    {
        renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        Invoke("resetColor", time);
    }

    /**
     * enemy reset color
     */
    public virtual void resetColor()
    {
        renderer.material.color = originalColor;
    }
}
