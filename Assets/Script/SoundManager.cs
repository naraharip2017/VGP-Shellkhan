using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource audiosource;
    public AudioClip pickUp; 
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void Awake()
    {
        instance = this; 
    }
    public void PlayPickUp()
    {
        audiosource.PlayOneShot(pickUp);
    }
}
