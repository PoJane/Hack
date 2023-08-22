using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NinePlayer : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public bool isGround;
    public BoxCollider2D feet;
    public bool canDoubleJump;
    public GameObject gameManager;
    public Animator animator;
    public WaitForSeconds wait;
    public AudioSource audioSource;        

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        feet = gameObject.GetComponent<BoxCollider2D>();
        wait = new WaitForSeconds(1);
        gameManager = GameObject.FindGameObjectWithTag("GameController");       
    }    

    void Update()
    {
        Run();
        Flip();
        CheckGrounded();
        Jump();

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Hack");
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }            
            Hack();
        }
    }

    void Run()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;        
        float moveDir = Input.GetAxis("Horizontal");        
        Vector2 playerVel = new Vector2(moveDir * speed, rigidbody.velocity.y);        
        rigidbody.velocity = playerVel;
        animator.SetBool("isWalk", playerHasXAxisSpeed);

    }    
    void Flip()
    {        
        bool playerHasXAxisSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;     
        if (playerHasXAxisSpeed)
        {            
            if (rigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }         
            if (rigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void CheckGrounded()
    {        
        isGround = feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void Jump()
    {     
        if (Input.GetKeyDown(KeyCode.Space))
        {     
            if (isGround)
            {                
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);             
                rigidbody.velocity = Vector2.up * jumpVel;                
                canDoubleJump = true;
            }            
            else
            {             
                if (canDoubleJump)
                {             
                    Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpSpeed);                 
                    rigidbody.velocity = Vector2.up * doubleJumpVel;                    
                    canDoubleJump = false;
                }
            }
        }
    }

    void Hack()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        gameManager.GetComponent<GameManager>().ChangeScene(index);
    }
}
