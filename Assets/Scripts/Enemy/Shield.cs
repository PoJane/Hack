using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public MeshRenderer renderer;
    public Color originalColor;
    public float flashTime;
    public bool isShield;
    public int health;

    public void Start()
    {
        
        renderer = GetComponent<MeshRenderer>();
        originalColor = renderer.material.color;
    }

    public virtual void takeDamage(int damage)
    {
        flashColor(flashTime);

        if (!isShield)
        {
            health -= damage;

            if (health < 0)
            {
                Destroy(gameObject);
            }
        }        
    }

    public virtual void flashColor(float time)
    {
        renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.6f);
        Invoke("resetColor", time);
    }

    public virtual void resetColor()
    {
        renderer.material.color = originalColor;
    }
}
