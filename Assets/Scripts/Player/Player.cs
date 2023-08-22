using UnityEngine;

public class Player : MonoBehaviour
{
    //property
    public float speed;
    public int health;

    public bool isAuto;
    public bool isMove;

    // follow camera
    public GameObject followCamera;

    public Rigidbody rigidbody;

    public GameObject controllerCaanvas;

    // Start is called before the first frame update
    public void Start()
    {
        followCamera = GameObject.FindGameObjectWithTag("FollowCamera");        
    }

    // Update is called once per frame
    public void Update()
    {
        if (isMove)
        {
            move();
            rotate();
            attack();
        }
        else
        {
            stop();
        }    
                
        if (isAuto)
        {
            autoLock();
        }
        else
        {
            commonLock();
        }
    }

    public void setIsAuto(bool value)
    {
        isAuto = value;
    }

    /**
     * player horizontal and vertical move
     */
    public virtual void move()
    {        
    }    

    public virtual void stop()
    {
        rigidbody.isKinematic = true;
    }

    public virtual void setMove(bool value)
    {
        isMove = value;
        if (isMove)
        {
            rigidbody.isKinematic = false;            
        }
        else
        {
            rigidbody.isKinematic = true;            
        }
    }

    /**
     * player rotate
     */
    public virtual void rotate()
    {
        
    }

    /**
     * player attack
     */
    public virtual void attack()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Player Attack!");
        }
    }

    /**
     * player get hurt
     */
    public virtual void takeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            shakeCamera();
            destroyChild(health);
        }
        else
        {
            Debug.Log("Player Dead!");
        }
    }

    public virtual void autoAttack()
    {

    }

    /**
     * player destroy child by index when get hurt
     */
    public void destroyChild(int index)
    {
        if (transform.GetChild(index))
        {
            Destroy(transform.GetChild(index).gameObject);
        }        
    }

    public int getHealth()
    {
        return health;
    }

    /**
     * shake camera when player get hurt
     */
    public virtual void shakeCamera()
    {        
        //Vector3 originPos = followCamera.transform.position;
        followCamera.transform.position = followCamera.transform.position - new Vector3(0.5f, 0, 0);
        Invoke("resetCamera",0.1f);
    }

    public virtual void resetCamera()
    {
        //followCamera.transform.position = pos;
        followCamera.transform.position = followCamera.transform.position + new Vector3(0.5f, 0, 0);
    }

    /**
    * auto lock the most recent enemy     
    */
    public virtual void autoLock()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        

        if (enemys.Length > 0)
        {
            GameObject recentEnemy = GetRecentEnemy(enemys);

            lockEnemy(recentEnemy);
        }        
        
    }

    /**
     * common lock the most recent enemy
     */
    public virtual void commonLock()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            autoLock();
        }
        
    }

    public virtual void lockEnemy(GameObject recentEnemy)
    {        
        Vector3 dir = recentEnemy.transform.position - transform.position;

        dir = new Vector3(dir.x, 0, dir.z);

        transform.rotation = Quaternion.LookRotation(dir);
        
        //transform.LookAt(recentEnemy.transform);        
    }

    /**
     * get the recentest enemy from around enemys
     */
    public virtual GameObject GetRecentEnemy(GameObject[] enemys)
    {
        GameObject recentEnemy = enemys[0];

        // get most recent enemy
        float min = Mathf.Abs(Vector3.Distance(transform.position, recentEnemy.transform.position));

        // by distance
        foreach (GameObject enemy in enemys)
        {
            Vector3 pos = enemy.transform.position;
            float dis = Mathf.Abs(Vector3.Distance(transform.position, pos));
            if (dis < min)
            {
                min = dis;
                recentEnemy = enemy;
            }
        }

        return recentEnemy;
    }
}
