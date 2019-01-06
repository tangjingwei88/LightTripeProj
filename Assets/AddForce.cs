using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public GameObject firstWall;
	// Use this for initialization
	void Awake () {

        Vector3 bollPos = transform.localPosition;
        Vector3 wallPos = firstWall.transform.localPosition;
        Vector3 curDir = wallPos - bollPos;
        GameData.Instance.firstDir = curDir;

        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(curDir.x * 10, curDir.y * 10));
    }

    private void Start()
    {
        
    }

}
