using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header ("--------------audio source--------------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------------audio clip--------------")]
    public AudioClip background;
    public AudioClip start;
    public AudioClip hit;
    public AudioClip jetpack;
    public AudioClip nextLevel;
    public AudioClip end;


    private void Start()
    {
        MusicSource.clip = background;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource.isPlaying == false)
        {
            SFXSource.PlayOneShot(clip);
        }

    }

    public void StopSFX(AudioClip clip)
    {
        if (SFXSource.isPlaying && SFXSource.clip == clip)
        {
            SFXSource.Stop();
        }
    }


}
