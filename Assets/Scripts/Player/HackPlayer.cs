using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackPlayer : Player
{
    // Component
    
    public GameObject bullet;
    
    // Rotation Vector3
    private Quaternion LEFT;
    private Quaternion RIGHT;
    private Quaternion UP;
    private Quaternion DOWN;

    // bullet gap
    public float gapTime;
    // bullet offset
    public float offset;

    public AudioSource audioSource;
    public float rotateSpeed;    

    

    public void Start()
    {
        base.Start();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        LEFT = Quaternion.Euler(new Vector3(0, 270, 0));
        RIGHT = Quaternion.Euler(new Vector3(0, 90, 0));
        UP = Quaternion.Euler(new Vector3(0, 0, 0));
        DOWN = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
    }

    /**
     * player AWSD move control
     */
    public override void move()
    {
        base.move();
        float hDir = Input.GetAxis("Horizontal");   // horizantal direction
        float vDir = Input.GetAxis("Vertical");     // vertical direction        
        Vector3 dir = new Vector3(hDir, 0, vDir);
        transform.position += dir * speed * Time.deltaTime;
    }       

    /**
     * player arrow rotation control
     */
    public override void rotate()
    {
        base.rotate();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateTo(LEFT);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateTo(RIGHT);
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rotateTo(UP);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotateTo(DOWN);
        }        
    }

    /**
     * slowly rotate to target rotation
     */
    public void rotateTo(Quaternion target)
    {        
        transform.rotation = Quaternion.Slerp(transform.rotation, target, rotateSpeed * Time.deltaTime);
    }

    /**
     * player attack
     * fire bullet
     */
    public override void attack()
    {
        base.attack();        
        // left shift or left mouse to attack
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.loop = false;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }            
            CancelInvoke("inst");
            inst();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {            
            InvokeRepeating("inst", 0.1f, 0.1f);
            audioSource.loop = true;
            audioSource.Play();
        }
        
    }

    public override void autoAttack()
    {        
        inst();
    }

    public void inst()
    {
        Vector3 startPos = transform.forward * offset + transform.position - new Vector3(0, 0.5f, 0);
        Instantiate(bullet, startPos, transform.rotation);
    }

    public override void takeDamage(int damage)
    {        
        base.takeDamage(damage);
    }
}
