using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public float offset;
   
    // child componnets
    public MeshRenderer renderer;
    public Color originalColor;
    public float flashTime;

    // player
    public GameObject player;

    // attack effect
    public GameObject effect;
    public float gapTime;

    //enemy name
    public string name;

    public void Start()
    {        
        renderer = transform.Find("Body").gameObject.GetComponent<MeshRenderer>();
        originalColor = renderer.material.color;                
    }

    public void Update()
    {
        // find player
        player = GameObject.FindGameObjectWithTag("Player");        
        move();        
    }

    public virtual void attack()
    {        
                   
    }

    /**
     * enemy get hurt
     */
    public virtual void takeDamage(int damage)
    {
        flashColor(flashTime);

        health -= damage;
        if(health <= 0)
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
        renderer.material.color = new Color(1.0f,1.0f,1.0f,0.2f);
        Invoke("resetColor", time);        
    }

    /**
     * enemy reset color
     */
    public virtual void resetColor()
    {
        renderer.material.color = originalColor;
    }

    /**
     * enemy base random move
     */
    public virtual void move()
    {
        
    }    
    
}
