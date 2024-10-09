using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //public AudioSource bgmSound;
    [SerializeField] private AudioSource sourceClip;

    public AudioClip button;
    public AudioClip buttonInsPage;

    public AudioClip countReady;
    public AudioClip countGo;

    public AudioClip spawnMilk;
    public AudioClip milkGoal;
    public AudioClip milkDestroy;
 
    public AudioClip endPanel;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (instance == null)
        {
            instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void buttonSound()
    {
        sourceClip.PlayOneShot(button);
    }

    public void insPageSound()
    {
        sourceClip.PlayOneShot(buttonInsPage);
    }

    public void countDownReady(AudioClip countReadyClip)
    {
        sourceClip.PlayOneShot(countReadyClip);
    }

    public void countDownGo(AudioClip countGoClip)
    {
        sourceClip.PlayOneShot(countGoClip);
    }

    public void spawnMilkSound()
    {
        sourceClip.PlayOneShot(spawnMilk);
    }

    public void milkGoalSound(AudioClip milkGoalClip)
    {
        sourceClip.PlayOneShot(milkGoalClip);
    }

    public void milkDestroySound(AudioClip milkDestroyClip)
    {
        sourceClip.PlayOneShot(milkDestroyClip);
    }


    public void endSound(AudioClip endClip)
    {
        sourceClip.PlayOneShot(endClip);
    }
}
