using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControl : MonoBehaviour
{
    public AudioClip BGM1;
    public AudioClip BGM2;
    private AudioSource audio;
    static BGMControl S;
    private float playIndex;
    // Start is called before the first frame update
    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else if (S != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.isPlaying != true)
        {
            if (playIndex % 2 == 0)
            {
                audio.clip = BGM1;
                audio.Play();
                playIndex += 1;
            }
            else
            {
                audio.clip = BGM2;
                audio.Play();
                playIndex += 1;
            }
        }
    }
}
