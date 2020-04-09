using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public float speed = 2f;
    bool isSeen;
    public enum direction { up, down, left, right};
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Funciona");
        if(isSeen)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void ChangeDir(direction newDir)
    {
        switch (newDir)
        {
            case direction.up:
                transform.eulerAngles = Vector3.forward * 90f;
                break;
            case direction.down:
                transform.eulerAngles = Vector3.forward * 270f;
                break;
            case direction.right:
                transform.eulerAngles = Vector3.zero;
                break;
            case direction.left:
                transform.eulerAngles = Vector3.forward * 180f;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator BreakArrow()
    {
        yield return new WaitForSeconds(4);

    }
    private void OnBecameVisible()
    {
        isSeen = true;
    }

    private void OnBecameInvisible()
    {
        isSeen = false;
    }

}
