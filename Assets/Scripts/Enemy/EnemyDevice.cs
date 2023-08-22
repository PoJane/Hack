using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDevice : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        InvokeRepeating("attack", 1.0f, gapTime);               
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        //attack();
    }

    public override void attack()
    {
        base.attack();
        Vector3 startPX = transform.right * offset + transform.position + new Vector3(0, 1, 0);
        Vector3 startNX = - transform.right * offset + transform.position + new Vector3(0, 1, 0);
        Vector3 startPZ = transform.forward * offset + transform.position + new Vector3(0, 1, 0);
        Vector3 startNZ = - transform.forward * offset + transform.position + new Vector3(0, 1, 0);

        Vector3 dirPX = startPX - transform.position;
        dirPX = new Vector3(dirPX.x, 0, dirPX.z);

        Vector3 dirNX = startNX - transform.position;
        dirNX = new Vector3(dirNX.x, 0, dirNX.z);

        Vector3 dirPZ = startPZ - transform.position;
        dirPZ = new Vector3(dirPZ.x, 0, dirPZ.z);

        Vector3 dirNZ = startNZ - transform.position;
        dirNZ = new Vector3(dirNZ.x, 0, dirNZ.z);

        Instantiate(effect, startPX, Quaternion.LookRotation(dirPX));        
        Instantiate(effect, startNX, Quaternion.LookRotation(dirNX));
        Instantiate(effect, startPZ, Quaternion.LookRotation(dirPZ));
        Instantiate(effect, startNZ, Quaternion.LookRotation(dirNZ));        
    }
}
