//                                      ��ʼ��ק           ��ק��        ������ק  
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //��¼һ��ʼ��������ƶ�λ�õ�����
    Vector2 staV2, posV2;
    //�ж��ƶ��ķ�Χ
    private int lenl = 70;
    //�Ƿ����ƶ�
    bool boolMove;
    //�ƶ������
    public GameObject player;

    //һ��ʼ�ҵ����
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    //��ʼ��ק�ж����ƶ� ��¼��ʼ��λ��
    public void OnBeginDrag(PointerEventData eventData)
    {
        boolMove = true;
        staV2 = transform.position;
    }
    //��ק�� �ȼ����ƶ��ľ��� ���ڵ�λ�ò��ܳ������ľ���
    public void OnDrag(PointerEventData eventData)
    {
        posV2 = eventData.position - staV2;
        transform.position = Vector2.ClampMagnitude(posV2, lenl) + staV2;
    }
    //������ק �رպͻع�ԭλ
    public void OnEndDrag(PointerEventData eventData)
    {
        boolMove = false;
        transform.localPosition = Vector3.zero;
    }
    void Update()
    {
        if (boolMove)
        {
            if (player)
            {
                //����
                player.transform.LookAt(new Vector3(posV2.x, 0, posV2.y) + player.transform.position);
                //�ƶ�
                player.transform.Translate(new Vector3(0, 0, Time.deltaTime * posV2.magnitude / 10));
            }
            
        }
    }
}