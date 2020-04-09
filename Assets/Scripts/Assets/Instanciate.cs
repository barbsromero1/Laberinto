using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public GameObject arrow;
    bool isIn = false;
    public Arrows.direction arrowDirec;
    const float timeBetweenArrows = 2f;
    public float timeSinceLastArrow = 2f;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastArrow -= Time.deltaTime;
        if (timeSinceLastArrow < 0 && isIn)
        {
            timeSinceLastArrow = timeBetweenArrows;
            MakeArrow();
        }
    }
    public void MakeArrow()
    {
        var arrowGenerator = Instantiate(arrow, transform.position, Quaternion.identity);
        arrowGenerator.GetComponent<Arrows>().ChangeDir(arrowDirec);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isIn = false;
    }
}
