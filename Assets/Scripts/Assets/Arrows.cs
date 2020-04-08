using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public float speed = 2f;
    bool isSeen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSeen)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        
    }
    private void OnBecameVisible()
    {
        isSeen = true;
    }

    private void OnBecameInvisible()
    {
        isSeen = false;
        Destroy(this.gameObject);
    }
}
