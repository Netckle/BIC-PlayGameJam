using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioDataPackage audioPackage;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            DestroyObject(this.gameObject);
    }

    public void SimplePlaySound(string name, AudioSource source, float volume, bool isLoop = false)
    {
        AudioClip clip = audioPackage.SearchAudioFromPackage(name);
        source.clip = clip;
        source.volume = volume;
        source.loop = isLoop;

        source.Play();
    }
}
