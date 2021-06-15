using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 背包界面拖拽
public class BagOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 originalPosition;
    public Vector2 deltaPosition;

    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition); // 打印左键位置
        }
    }
    */

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
        //transform.position = eventData.position;
        deltaPosition = eventData.position - originalPosition;
        transform.position = originalPosition;
        Debug.Log("开始背包拖拽");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position - deltaPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = eventData.position - deltaPosition;
        Debug.Log("结束背包拖拽");
    }

}
