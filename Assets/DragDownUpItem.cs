using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragDownUpItem : MonoBehaviour,IDragHandler
{
    private Vector3 orgPos;

     void Update()
    {
        if (Mathf.Abs(transform.localPosition.y) > Screen.height / 2 - Screen.height / 8)
        {
            if (transform.localPosition.y > 0)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, Screen.height / 2 - Screen.height / 8, transform.localPosition.z);
            }
            else {
                transform.localPosition = new Vector3(transform.localPosition.x, -Screen.height / 2 + Screen.height / 8, transform.localPosition.z);
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        orgPos = transform.localPosition;
        //拖拽移动图片
        SetDraggedPosition(eventData);
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = gameObject.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
           // Debug.LogError("rt.localPosition" + rt.localPosition);
            transform.localPosition = new Vector3 (orgPos.x, rt.localPosition.y,orgPos.z);
        }
    }

}
