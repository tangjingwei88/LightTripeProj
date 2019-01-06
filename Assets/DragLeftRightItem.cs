using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragLeftRightItem : MonoBehaviour,IDragHandler
{
    private Vector3 orgPos;

    void Update()
    {
        if (Mathf.Abs(transform.localPosition.x) > Screen.width / 2 - Screen.width / 8)
        {
            if (transform.localPosition.x > 0)
            {
                transform.localPosition = new Vector3(Screen.width / 2 - Screen.width / 8, transform.localPosition.y,  transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(-Screen.width / 2 + Screen.width / 8, transform.localPosition.y, transform.localPosition.z);
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
            transform.localPosition = new Vector3(rt.localPosition.x, orgPos.y,  orgPos.z);
        }
    }

}
