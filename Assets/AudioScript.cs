using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource.loop = true;
        MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            MusicSource.Stop();
        }   
    }
}
