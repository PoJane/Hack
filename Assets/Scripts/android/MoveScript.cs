//                                      开始拖拽           拖拽中        结束拖拽  
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //记录一开始的坐标和移动位置的坐标
    Vector2 staV2, posV2;
    //判断移动的范围
    private int lenl = 70;
    //是否在移动
    bool boolMove;
    //移动的玩家
    public GameObject player;

    //一开始找到玩家
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    //开始拖拽判断在移动 记录开始的位置
    public void OnBeginDrag(PointerEventData eventData)
    {
        boolMove = true;
        staV2 = transform.position;
    }
    //拖拽中 先计算移动的距离 现在的位置不能超过最大的距离
    public void OnDrag(PointerEventData eventData)
    {
        posV2 = eventData.position - staV2;
        transform.position = Vector2.ClampMagnitude(posV2, lenl) + staV2;
    }
    //结束拖拽 关闭和回归原位
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
                //朝向
                player.transform.LookAt(new Vector3(posV2.x, 0, posV2.y) + player.transform.position);
                //移动
                player.transform.Translate(new Vector3(0, 0, Time.deltaTime * posV2.magnitude / 10));
            }
            
        }
    }
}