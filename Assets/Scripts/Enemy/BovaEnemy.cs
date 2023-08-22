using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BovaEnemy : Enemy
{    
    public GameObject bova;
    public MeshRenderer bodyRenderer;
    public MeshRenderer dressRenderer;
    public MeshRenderer headRenderer;

    public GameObject effect1;
    public bool isChase;
    WaitForSeconds wait;
    public Rigidbody rigidbody;
    
    void Start()
    {        
        bova = transform.Find("Bova").gameObject;

        bodyRenderer = bova.transform.Find("Body").GetComponent<MeshRenderer>();
        dressRenderer = bova.transform.Find("Dress").GetComponent<MeshRenderer>();
        headRenderer = bova.transform.Find("Head").GetComponent<MeshRenderer>();        

        originalColor = bodyRenderer.material.color;
        wait = new WaitForSeconds(1);

        isChase = false;        

        InvokeRepeating("attack", gapTime, gapTime);
        
        StartCoroutine(waitChase());
    }

    IEnumerator waitChase()
    {
        while(!isChase)
        {            
            yield return wait;
        }
        
        StartCoroutine(attack2());

        yield break;
    }

    IEnumerator attack2()
    {        
        while (gameObject)
        {
            Vector3 startPos = transform.forward * offset + transform.position + new Vector3(0, 1, 0);
            Instantiate(effect, startPos, Quaternion.identity);            

            yield return wait;
        }

        yield break;
    }

    
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");        

        if (!isChase)
        {
            move();
        }
        else
        {
            move2();
        }
    }

    public override void flashColor(float time)
    {
        bodyRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        dressRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        headRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        Invoke("resetColor", time);
    }

    public override void resetColor()
    {
        bodyRenderer.material.color = originalColor;
        dressRenderer.material.color = originalColor;
        headRenderer.material.color = originalColor;
    }

    public override void move()
    {
        transform.Rotate(0, 0.1f, 0);
    }

    public override void attack()
    {
        Vector3 startPX = transform.right * offset + transform.position + new Vector3(0,1,0);
        Vector3 startNX = -transform.right * offset + transform.position + new Vector3(0, 1, 0);
        Vector3 startPZ = transform.forward * offset + transform.position + new Vector3(0, 1, 0);
        Vector3 startNZ = -transform.forward * offset + transform.position + new Vector3(0, 1, 0);

        Vector3 dirPX = startPX - transform.position;
        dirPX = new Vector3(dirPX.x, 0, dirPX.z);

        Vector3 dirNX = startNX - transform.position;
        dirNX = new Vector3(dirNX.x, 0, dirNX.z);

        Vector3 dirPZ = startPZ - transform.position;
        dirPZ = new Vector3(dirPZ.x, 0, dirPZ.z);

        Vector3 dirNZ = startNZ - transform.position;
        dirNZ = new Vector3(dirNZ.x, 0, dirNZ.z);

        Instantiate(effect1, startPX, Quaternion.LookRotation(dirPX));
        Instantiate(effect1, startNX, Quaternion.LookRotation(dirNX));
        Instantiate(effect1, startPZ, Quaternion.LookRotation(dirPZ));
        Instantiate(effect1, startNZ, Quaternion.LookRotation(dirNZ));
    }

    public void move2()
    {
        CancelInvoke("attack");

        isChase = true;

        transform.LookAt(player.transform);
        
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
