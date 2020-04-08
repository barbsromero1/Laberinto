using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class setVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetLevel (float sliderValue)
    {
        //mixer.SetFloat("MenuVolume", Mathf.Log10(sliderValue) * 20);
        mixer.SetFloat("MenuVolume", sliderValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
