using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenaultAudioControl : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource motor_audio_source;

    private void Awake()
    {
        motor_audio_source = GameObject.Find("Motor").GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MotorAudioPlay()
    {
        motor_audio_source.Play();
    }

    public void MotorAudioStop()
    {
        motor_audio_source.Stop();
    }
}
