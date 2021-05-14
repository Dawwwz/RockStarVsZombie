using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    

    [SerializeField] LevelManager levelManager;
    public AudioSource soundBackgroundAS;
    public AudioClip[] soundBackgroundAC;

    public AudioSource guitarBGAS;
    public AudioClip[] guitarBGAC;

    public AudioSource soundEffectAS;
    public AudioClip[] soundEffectAC;
    // Start is called before the first frame upda
    void Start()
    {
        SoundBG(0);
        guitarBG(0);
        /*
        switch (levelManager.scenaAtualString)
        {
            case "Level1":
                SoundBG(0);
                guitarBG(0);
                break;
        }
            case "Level2":
                AudioManager.audioManager.SoundBG(2);
                AudioManager.audioManager.guitarBG(2);
                break;
            case "Level3":
                AudioManager.audioManager.SoundBG(3);
                AudioManager.audioManager.guitarBG(3);
                break;
            case "Level4":
                AudioManager.audioManager.SoundBG(4);
                AudioManager.audioManager.guitarBG(4);
                break;
            case "Level5":
                AudioManager.audioManager.SoundBG(5);
                AudioManager.audioManager.guitarBG(5);
                break;
            case "Level6":
                AudioManager.audioManager.SoundBG(6);
                AudioManager.audioManager.guitarBG(6);
                break;
            case "Level7":
                AudioManager.audioManager.SoundBG(7);
                AudioManager.audioManager.guitarBG(7);
                break;
            case "Level8":
                AudioManager.audioManager.SoundBG(8);
                AudioManager.audioManager.guitarBG(8);
                break;
            case "Level9":
                AudioManager.audioManager.SoundBG(9);
                AudioManager.audioManager.guitarBG(9);
                break;
        */

        // 0  coin
        // 1  kick
        // 2  blood
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
        guitarBGAS.clip = guitarBGAC[clipIndex];
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
    public void RockMode0()
    {

             guitarBGAS.volume = 0;

    }
    public void RockMode()
    {  
            guitarBGAS.volume = 1;
     
    }
}
