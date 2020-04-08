using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public float speed = 2f;
    bool isSeen;
    public enum direction { up, down, left, right};
    public direction dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSeen)
        {
            switch (dir)
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
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }
    private void OnBecameVisible()
    {
        isSeen = true;
    }

    private void OnBecameInvisible()
    {
        isSeen = false;
        //Destroy(this.gameObject);
    }
}
