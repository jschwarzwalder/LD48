using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {

     [SerializeField] AudioMixer mixer;
     [SerializeField] string mixerReferenceName;

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat(mixerReferenceName, Mathf.Log10(sliderValue) * 20);
    }
}