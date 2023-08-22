using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : BaseCamera
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {        
        if (isPlayer)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            other = GameObject.FindGameObjectWithTag("Partner");

            player.GetComponent<Player>().setMove(true);
            other.GetComponent<Player>().setMove(false);            
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Partner");
            other = GameObject.FindGameObjectWithTag("Player");

            player.GetComponent<Player>().setMove(true);
            other.GetComponent<Player>().setMove(false);
        }        

        target = player.transform.position;
        UP = player.transform.Find("Up").transform;
    }

    public override void setPlayer(bool value)
    {
        isPlayer = value;
    }
}
