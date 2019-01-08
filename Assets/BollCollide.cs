using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollCollide : MonoBehaviour {

    private void Start()
    {
        
    }

    private Vector2 m_preVelocity = new Vector2(30,-50);//上一帧速度
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 dir;
    private bool isDrag = false;
/*    void Update()
    {
        if (!isDrag)
        {
            isDrag = true;
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = transform.localPosition;
                Debug.LogError(startPoint);
            }
            if (Input.GetMouseButtonUp(0))
            {
                endPoint = transform.localPosition;
                Debug.LogError(endPoint);
            }
            dir = endPoint - startPoint;
        }

    }
*/
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError("##" + collision.transform.tag);
        if (collision.transform.tag == "wall")
        {
            ContactPoint2D contactPoint = collision.contacts[0];
            Vector3 newDir = Vector3.zero;

            Vector3 bollPos = transform.localPosition;
            Vector3 wallPos = collision.gameObject.transform.localPosition;

            Vector3 curDir = wallPos - bollPos;
            newDir = Vector2.Reflect(GameData.Instance.firstDir, contactPoint.normal);
            GameData.Instance.firstDir = newDir;
            //Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
            //transform.rotation = rotation;
            //this.rigidbody2D. = newDir.normalized * m_preVelocity.x / m_preVelocity.normalized.x;
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(newDir.x * 30, newDir.y * 30));
        }
        else if (collision.transform.tag == "End")
        {
            Debug.LogError("game over");
        }
    }

    public void OnClick()
    {
        Debug.LogError("OnClick");
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
    }

}
