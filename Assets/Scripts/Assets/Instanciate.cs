using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public GameObject arrow;
    bool isSeen = true;
    public Arrows.direction arrowDirec;
    const float timeBetweenArrows = 2f;
    public float timeSinceLastArrow = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnArrow());
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastArrow -= Time.deltaTime;
        if (timeSinceLastArrow < 0 /*&& isSeen*/)
        {
            timeSinceLastArrow = timeBetweenArrows;
            var arrowGenerator = Instantiate(arrow, transform.position, Quaternion.identity);
            arrowGenerator.GetComponent<Arrows>().dir = arrowDirec;
        }
    }
    //private void OnBecameVisible()
    //{
    //    isSeen = true;
    //}
    //private void OnBecameInvisible()
    //{
    //    isSeen = false;
    //    //Destroy(this.gameObject);
    //}
}
