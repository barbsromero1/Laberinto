using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;

    void Start()
    {
        //offset = transform.position - player.position;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player)
        //{
        //    Vector3 newPos = transform.position;
        //    newPos.x = player.position.x + offset.x;
        //    transform.position = newPos;
        //}
        transform.position = player.transform.position + offset;
    }
}
