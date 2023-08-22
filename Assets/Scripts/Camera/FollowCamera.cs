using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    public Transform target; // ����Ŀ��
    public float smooth; // ���Բ�ֵƽ������ (0.1)

    public Vector2 minPos;
    public Vector2 maxPos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    private void LateUpdate()
    {        
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                // ����Ŀ��λ��x��y��Χ
                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
                transform.position = Vector3.Lerp(
                    transform.position,
                    targetPos,
                    smooth
                );
            }
        }
    }

    public void SetCamPosLimit(Vector2 min, Vector2 max)
    {
        minPos = min;
        maxPos = max;

    }
}
