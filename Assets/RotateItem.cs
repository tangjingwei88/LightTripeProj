using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class RotateItem : MonoBehaviour,IDragHandler
{


    public void OnDrag(PointerEventData eventData)
    {
        //没有触摸
        if (Input.touchCount <= 0)
        {
            return;
        }

        //单点触摸， 水平上下旋转
        if (1 == Input.touchCount)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 deltaPos = touch.deltaPosition;
            if(deltaPos.y > 0)
                this.transform.Rotate(new Vector3(0, 0, 1), Mathf.Abs(deltaPos.y));
            else
                this.transform.Rotate(new Vector3(0, 0, -1), Mathf.Abs(deltaPos.y));
        }
    }


}
