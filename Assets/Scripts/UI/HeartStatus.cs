using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartStatus : MonoBehaviour
{
    public static int lifeStatus = 4;
    public Animator Heartsy;
    //public GameObject Cora;
    // Start is called before the first frame update
    void Start()
    {
        Heartsy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (lifeStatus)
        {
            case 0:
                Heartsy.SetInteger("LifeStatus", 0);
                break;
            case 1:
                Heartsy.SetInteger("LifeStatus", 1);
                break;
            case 2:
                Heartsy.SetInteger("LifeStatus", 2);
                break;
            case 3:
                Heartsy.SetInteger("LifeStatus", 3);
                break;
            case 4:
                Heartsy.SetInteger("LifeStatus", 4);
                break;
        }
    }
}
