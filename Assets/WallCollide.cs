using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallCollide : MonoBehaviour {

    public Image normalSprite;
    public Image collideSprite;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError("##" + collision.transform.tag);
        if (collision.transform.tag == "boll")
        {
            normalSprite.gameObject.SetActive(false);
            collideSprite.gameObject.SetActive(true);
            StartCoroutine("BackToNormal");
        }

    }

    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(1f);
        normalSprite.gameObject.SetActive(true);
        collideSprite.gameObject.SetActive(false);
    }
}
