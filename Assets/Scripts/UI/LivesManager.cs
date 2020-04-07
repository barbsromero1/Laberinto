using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LivesManager : MonoBehaviour
{
    public int Totallives;
    private int liveCounter;
    private Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        liveCounter = Totallives;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "x " + liveCounter;
    }
    public void TakeLife()
    {
        liveCounter--;
    }
}
