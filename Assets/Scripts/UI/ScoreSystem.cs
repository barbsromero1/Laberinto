using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue = 0; 

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        PrintScore();
    }
    private void Update()
    {
        if(scoreValue == 5)
        {
            scoreText.text = "X0";
        }
    }

    // Update is called once per frame
    void PrintScore()
    {
        scoreText.text = "X" + scoreValue;
    }

}
