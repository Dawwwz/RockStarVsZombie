using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    public AudioSource soundBackgroundAS;
    public AudioClip[] soundBackgroundAC;

    public AudioSource guitarBGAS;
    public AudioClip[] guitarBGAC;

    public AudioSource soundEffectAS;
    public AudioClip[] soundEffectAC;
    // Start is called before the first frame update
    private void Awake()
    {
        if(audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        SoundBG(5);
    }
    public void Update()
    {
        
    }

    public void SoundBG(int clipIndex)
    {
        soundBackgroundAS.clip = soundBackgroundAC[clipIndex];
        soundBackgroundAS.Play();
    }
    public void guitarBG(int clipIndex)
    {
        guitarBGAS.clip = soundBackgroundAC[clipIndex];
        guitarBGAS.Play();
    }
    public void SoundEffect(int clipIndex)
    {
        soundEffectAS.clip = soundEffectAC[clipIndex];
        soundEffectAS.Play();
    }
    public void Mute()
    {
        soundBackgroundAS.mute = true;
        guitarBGAS.mute = true;
        soundEffectAS.mute = true;
    }
    public void UnMute()
    {
        soundBackgroundAS.mute = false;
        guitarBGAS.mute = false;
        soundEffectAS.mute = false ;
    }
}
